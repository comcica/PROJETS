Imports System.Data
Imports System.Threading
Imports System.Windows

Public Class Wd_Login

    Public Sub New()

        ' This call is required by the designer.

        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub Wd_Login_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Closing
        If PunchClock_Connect.gStateConnectDB = False Then
            Dim result = System.Windows.Forms.MessageBox.Show("The connection to the database  failed, Would you like to try again  ?", "Database connection", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2)
            If result = MessageBoxResult.OK Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub Window_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded

    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub BtnConnect_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles BtnConnect.Click
        Dim luser As String = Trim(TbSQLLogin.Text)
        Dim lpassword As String = Trim(PasswordUser.Password)

        If Trim(TbSQLLogin.Text) = "" Or Trim(PasswordUser.Password) = "" Then
            System.Windows.Forms.MessageBox.Show("Saisie Invalide")
            Exit Sub
        End If
        PunchClock_Connect.InitConnect(luser, lpassword)

        If Not MyConn.conn Is Nothing Then
            MyConn.disconnect()
        End If

        If setup.gDBModeUse = "0" Then 'use normal DB
            If MyConn.Connect_BD() = True Then
                PunchClock_Connect.gStateConnectDB = True
            Else
                PunchClock_Connect.gStateConnectDB = False
            End If
        Else 'creation DB gDBModeUse = 1
            If MyConn.ConnectInit() = True Then
                MyConn.createDB(DatabaseName)
                MyConn.disconnect()
                'creation Tables
                If MyConn.Connect_BD() = True Then
                    If MyConn.createTables() = True Then
                        PunchClock_Connect.gStateConnectDB = True
                        setup.gDBModeUse = "0"
                        setup.savesetup()
                    Else
                        PunchClock_Connect.gStateConnectDB = False
                    End If
                Else
                    PunchClock_Connect.gStateConnectDB = False
                End If
            End If

        End If
        If PunchClock_Connect.gStateConnectDB = True Then
            Me.Close()
        Else
            System.Windows.Forms.MessageBox.Show("The connection to the database  failed ")
        End If

    End Sub

End Class
