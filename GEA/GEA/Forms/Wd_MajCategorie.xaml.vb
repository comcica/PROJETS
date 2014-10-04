Imports System.Data.SqlClient
Imports System.Data

Public Class Wd_MajCategorie
    Public gmode As String
    Public gtitre As String
    Public gid As String
    Public glib As String

    Public Sub New(ByVal lmode As String, ByVal ltitre As String, ByVal lid As Integer, ByVal llib As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        gmode = lmode 'Ajouter, Modifier
        gtitre = ltitre ' Armoires, Rayons, Classeurs, Dossiers
        gid = lid
        glib = llib
        If gmode = "Ajouter" Then
            Tb_Designation.Text = ""
        Else
            Tb_Designation.Text = glib
        End If
    End Sub
    Private Sub Btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Btn_Cancel.Click
        Me.Close()
    End Sub

    Private Sub Btn_Valider_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Btn_Valider.Click
        Dim myCmd As SqlCommand = Nothing

        If gmode = "Ajouter" Then
            Select Case gtitre
                Case "Armoires"
                    Dim lCommandText As String = "SELECT * FROM T_Armoires WHERE Designation = '" & Trim(Tb_Designation.Text) & "'"
                    If lcsqlserver.Trouver(lCommandText) = True Then
                        MessageBox.Show("Ce Armoire existe dejà ")
                    Else
                        lCommandText = "INSERT INTO T_Armoires ( Designation ) VALUES (@Designation)"
                        myCmd = New SqlCommand(lCommandText, lcsqlserver.myConn)
                        myCmd.Parameters.Add("@Designation", SqlDbType.NVarChar).Value = Trim(Tb_Designation.Text)

                        myCmd.ExecuteNonQuery()
                        myCmd.Cancel()
                    End If

                Case "Rayons"
                    If Trim(gid) = "" Or Trim(gid) = "0" Then
                        MessageBox.Show("Selectionner en premier l'armoire devant contenir le rayon")
                    Else
                        Dim lCommandText As String = "SELECT * FROM T_Rayons WHERE Designation = '" & Trim(Tb_Designation.Text) & "'"
                        If lcsqlserver.Trouver(lCommandText) = True Then
                            MessageBox.Show("Ce rayon existe dejà ")
                        Else
                            lCommandText = "INSERT INTO T_Rayons ( ArmoireID, Designation ) VALUES (@ArmoireID, @Designation)"
                            myCmd = New SqlCommand(lCommandText, lcsqlserver.myConn)
                            myCmd.Parameters.Add("@Designation", SqlDbType.NVarChar).Value = Trim(Tb_Designation.Text)
                            myCmd.Parameters.Add("@ArmoireID", SqlDbType.Int).Value = gid

                            myCmd.ExecuteNonQuery()
                            myCmd.Cancel()
                        End If
                    End If
                Case "Classeurs"
                    If Trim(gid) = "" Or Trim(gid) = "0" Then
                        MessageBox.Show("Selectionner en premier le rayon devant contenir le classeur")
                    Else
                        Dim lCommandText As String = "SELECT * FROM T_Classeurs WHERE Designation = '" & Trim(Tb_Designation.Text) & "'"
                        If lcsqlserver.Trouver(lCommandText) = True Then
                            MessageBox.Show("Ce classeur existe dejà ")
                        Else
                            lCommandText = "INSERT INTO T_Classeurs ( RayonID, Designation ) VALUES (@RayonID, @Designation)"
                            myCmd = New SqlCommand(lCommandText, lcsqlserver.myConn)
                            myCmd.Parameters.Add("@Designation", SqlDbType.NVarChar).Value = Trim(Tb_Designation.Text)
                            myCmd.Parameters.Add("@RayonID", SqlDbType.Int).Value = gid

                            myCmd.ExecuteNonQuery()
                            myCmd.Cancel()
                        End If
                    End If
                Case "Dossiers"
                    If Trim(gid) = "" Or Trim(gid) = "0" Then
                        MessageBox.Show("Selectionner en premier le classeur devant contenir le dossier")
                    Else
                        Dim lCommandText As String = "SELECT * FROM T_Dossiers WHERE Designation = '" & Trim(Tb_Designation.Text) & "'"
                        If lcsqlserver.Trouver(lCommandText) = True Then
                            MessageBox.Show("Ce dossier existe dejà ")
                        Else
                            lCommandText = "INSERT INTO T_Dossiers ( ClasseurID, Designation ) VALUES (@ClasseurID, @Designation)"
                            myCmd = New SqlCommand(lCommandText, lcsqlserver.myConn)
                            myCmd.Parameters.Add("@Designation", SqlDbType.NVarChar).Value = Trim(Tb_Designation.Text)
                            myCmd.Parameters.Add("@ClasseurID", SqlDbType.Int).Value = gid

                            myCmd.ExecuteNonQuery()
                            myCmd.Cancel()
                        End If
                    End If
            End Select
            Me.Close()
        End If
        If gmode = "Modifier" Then
            Select gtitre
                Case "Armoires"
                    'MyStringInsert = String.Format("UPDATE t_worker SET worker_name = '{0}', worker_email = '{1}', worker_state = '{2}', worker_led = '{3}', worker_valid = '{4}' WHERE Id_Worker = '{5}'", _
                    'Trim(Tbx_WorkerName.Text), Trim(Tbx_WorkerEmail.Text), Trim(Cb_WorkerState.Text), Trim(Tbx_WorkerLed.Text), Trim(Cb_WorkerValid.Text), Trim(Tbx_idworker.Text))

                    Dim lCommandText As String = "UPDATE T_Armoires SET Designation = @Designation WHERE ArmoireID = @ID"
                    myCmd = New SqlCommand(lCommandText, lcsqlserver.myConn)
                    myCmd.Parameters.Add("@Designation", SqlDbType.NVarChar).Value = Trim(Tb_Designation.Text)
                    myCmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = gid

                    myCmd.ExecuteNonQuery()
                    myCmd.Cancel()

                Case "Rayons"
                    Dim lCommandText As String = "UPDATE T_Rayons SET Designation = @Designation WHERE RayonID = @ID"
                    myCmd = New SqlCommand(lCommandText, lcsqlserver.myConn)
                    myCmd.Parameters.Add("@Designation", SqlDbType.NVarChar).Value = Trim(Tb_Designation.Text)
                    myCmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = gid


                    myCmd.ExecuteNonQuery()
                    myCmd.Cancel()

                Case "Classeurs"
                    Dim lCommandText As String = "UPDATE T_Classeurs SET Designation = @Designation WHERE ClasseurID = @ID"
                    myCmd = New SqlCommand(lCommandText, lcsqlserver.myConn)
                    myCmd.Parameters.Add("@Designation", SqlDbType.NVarChar).Value = Trim(Tb_Designation.Text)
                    myCmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = gid

                    myCmd.ExecuteNonQuery()
                    myCmd.Cancel()

                Case "Dossiers"
                    Dim lCommandText As String = "UPDATE T_Dossiers SET Designation = @Designation WHERE DossierID = @ID"
                    myCmd = New SqlCommand(lCommandText, lcsqlserver.myConn)
                    myCmd.Parameters.Add("@Designation", SqlDbType.NVarChar).Value = Trim(Tb_Designation.Text)
                    myCmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = gid


                    myCmd.ExecuteNonQuery()
                    myCmd.Cancel()

            End Select
            Me.Close()

        End If
    End Sub

    Private Sub Window_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        Me.Title = gtitre & " : " & gmode
        'Select Case gtitre
        '    Case "Armoires"
        '        Me.Title = "Armoires : " & c

        '    Case "Rayons"
        '        Me.Title = "Rayons : " & gmode
        '    Case "Classeurs"
        '        Me.Title = "Classeurs : " & gmode
        '    Case "Dossiers"
        '        Me.Title = "Dossiers : " & gmode
        'End Select
    End Sub
End Class
