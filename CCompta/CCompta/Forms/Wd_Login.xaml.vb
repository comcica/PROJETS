﻿Imports System.Data
Imports System.Threading
Imports System.Windows

Public Class Wd_Login

    Public Sub New()

        ' This call is required by the designer.

        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub Wd_Login_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Closing
        If CCompta_Connect.gStateConnectDB = False Then
            Dim result = MessageBox.Show("The connection to the database  fallen, Would you like to try again  ?", "Database connection", MessageBoxButton.OKCancel, MessageBoxImage.Stop, MessageBoxResult.Cancel)
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
        Dim lserver As String = Trim(IP1.Text) & "." & Trim(IP2.Text) & "." & Trim(IP3.Text) & "." & Trim(IP4.Text)
        Dim luser As String = Trim(TbSQLLogin.Text)
        Dim lpassword As String = Trim(PasswordUser.Password)

        If Trim(TbSQLLogin.Text) = "" Or Trim(PasswordUser.Password) = "" Or Trim(IP1.Text) = "" Or Trim(IP2.Text) = "" Or Trim(IP3.Text) = "" Or Trim(IP4.Text) = "" Then
            MessageBox.Show("Saisie Invalide")
            Exit Sub
        End If
        CCompta_Connect.InitConnect(lserver, luser, lpassword)

        If Not MyConn.conn Is Nothing Then
            MyConn.disconnect()
        End If

        If setup.gDBModeUse = "0" Then 'use normal DB
            If MyConn.Connect_BD() = True Then
                Dim lCommandText As String = "SELECT * FROM p_dossier"
                If MyConn.FindSociete(lCommandText) = False Then
                    MessageBox.Show("Les infos de votre Société ne sont pas disponibles ")
                End If
                '
                CCompta_Connect.gStateConnectDB = True
            Else
                CCompta_Connect.gStateConnectDB = False
            End If
        Else 'creation DB gDBModeUse = 1
            If MyConn.ConnectInit() = True Then
                MyConn.createDB(DatabaseName)
                MyConn.disconnect()
                'creation Tables
                If MyConn.Connect_BD() = True Then
                    If MyConn.createTables() = True Then
                        ' ajout info ste
                        CCompta_Connect.gStateSociete = True
                        lwd_Societe = New Wd_Societe
                        lwd_Societe.ShowDialog()

                        CCompta_Connect.gStateSociete = False
                        CCompta_Connect.gStateConnectDB = True
                        setup.gDBModeUse = "0"
                        setup.savesetup()
                    Else
                        CCompta_Connect.gStateConnectDB = False
                    End If
                Else
                    CCompta_Connect.gStateConnectDB = False
                End If
            End If

        End If
        If CCompta_Connect.gStateConnectDB = True Then
            Me.Close()
        Else
            MessageBox.Show("The connection to the database  fallen ")
        End If

    End Sub

End Class
