Imports System.Data
Imports System.Threading

Public Class Wd_Login

    Public Sub New()

        ' This call is required by the designer.
        Dim lwdwait As Wd_Wait = New Wd_Wait
        lwdwait.Show()

        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GetServerSQlInstance()
        lwdwait.Close()
    End Sub
    Public Sub GetServerSQlInstance()
        Dim dt As DataTable = Nothing, dr As DataRow = Nothing

        Try
            dt = Sql.SqlDataSourceEnumerator.Instance.GetDataSources()

            CmbSQLServers.Items.Clear()
            CmbSQLInstance.Items.Clear()

            For Each dr In dt.Rows
                Me.CmbSQLServers.Items.Add(dr.Item(0).ToString)
                Me.CmbSQLInstance.Items.Add(dr.Item(1).ToString)
            Next
            'Me.DGVSQLInstances.DataSource = dt

        Catch ex As System.Data.SqlClient.SqlException
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error!")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error!")
        Finally
            dr = Nothing
            dt = Nothing
        End Try

    End Sub

    Private Sub Window_Loaded(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded

    End Sub

    Private Sub BtnCancel_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub BtnConnect_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles BtnConnect.Click
        Dim linstance As String = Trim(CmbSQLServers.Text) & "\" & Trim(CmbSQLInstance.Text)
        Dim luser As String = Trim(TbSQLLogin.Text)
        Dim lpassword As String = Trim(PasswordUser.Password)

        If Trim(CmbSQLServers.Text) = "" Or Trim(CmbSQLInstance.Text) = "" Or Trim(TbSQLLogin.Text) = "" Or Trim(PasswordUser.Password) = "" Then
            MessageBox.Show("Saisie Invalide")
            Exit Sub
        End If
        GEA_Connect.InitConnect(linstance, luser, lpassword)

        If Not lcsqlserver.myConn Is Nothing Then
            lcsqlserver.disconnect()
        End If

        If setup.gModeUse = "0" Then 'use normal
            If lcsqlserver.connectDB(linstance, gDBName, luser, lpassword) = True Then
                GEA_Connect.gStateConnectDB = True
            Else
                GEA_Connect.gStateConnectDB = False
            End If
        Else 'creation DB gModeUse = 1
            If lcsqlserver.connectDB(linstance, "", luser, lpassword) = True Then
                lcsqlserver.createDB(gDBName)
                lcsqlserver.disconnect()
                'creation Tables
                If lcsqlserver.connectDB(linstance, gDBName, luser, lpassword) = True Then
                    If lcsqlserver.createTables() = True Then
                        GEA_Connect.gStateConnectDB = True
                        setup.gModeUse = "0"
                        setup.savesetup()
                    Else
                        GEA_Connect.gStateConnectDB = False
                    End If
                Else
                    GEA_Connect.gStateConnectDB = False
                End If
            End If

        End If

        Me.Close()
    End Sub
End Class
