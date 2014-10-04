﻿Imports System.Reflection

Public Class SplashScreenStartup

    Private VERSION As String = Assembly.GetExecutingAssembly().GetName().Version.Major.ToString + "." + Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString
    Private Const LASTUPDATE = "2013-07-03"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        txtLastUpdate.Text = LASTUPDATE
        txtVersion.Text = VERSION
    End Sub

    Private Sub Window_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded

    End Sub
End Class
