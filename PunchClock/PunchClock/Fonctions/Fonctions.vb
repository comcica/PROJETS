Imports System.IO

Module Fonctions

    Function CalculDifferenceHeure(ByVal sTimeStart As String, ByVal sTimeStop As String) As String

        Dim dFrom As DateTime
        Dim dTo As DateTime

        Dim TS As TimeSpan
        Dim hour As Integer
        Dim mins As Integer
        Dim secs As Integer
        Dim timeDiff As String = "00:00:00"

        If DateTime.TryParse(sTimeStart, dFrom) AndAlso DateTime.TryParse(sTimeStop, dTo) Then
            TS = dTo - dFrom
            hour = TS.Hours
            mins = TS.Minutes
            secs = TS.Seconds
            timeDiff = ((hour.ToString("00") & ":") + mins.ToString("00") & ":") + secs.ToString("00")
        End If
        'CalculDifferenceHeure = timeDiff
        Return timeDiff

    End Function
    Function CalculTotalHeure(ByVal dgv As DataGridView) As String

        Dim dFrom As DateTime
        Dim dTo As DateTime

        Dim TotalHeure As TimeSpan
        Dim ts As TimeSpan

        Dim hour As Integer
        Dim mins As Integer
        Dim secs As Integer

        Dim timeDiff As String = "00:00:00"
        Dim td As String = "00:00:00"

        Dim i As Integer = 1
        For Each d_dgv As DataGridViewRow In dgv.Rows
            If i <= dgv.RowCount - 1 Then
                If DateTime.TryParse(d_dgv.Cells(8).Value.ToString, dTo) AndAlso DateTime.TryParse(td, dFrom) Then
                    ts = dTo - dFrom
                    TotalHeure = TotalHeure + ts
                End If
            End If
            i = i + 1
        Next
        hour = TotalHeure.Hours
        mins = TotalHeure.Minutes
        secs = TotalHeure.Seconds

        timeDiff = ((hour.ToString("00") & ":") + mins.ToString("00") & ":") + secs.ToString("00")
        Return timeDiff
    End Function
    Function FormDate(Madate As String) As String
        '"fr-CA" or '"en-US"
        Dim MyPos As Integer
        Dim ch As String = ""
        Dim MYstring As String = ""
        Dim date_mois As String = ""
        Dim date_jour As String = ""
        Dim date_annee As String = ""

        Dim lcultureinfo As String = System.Globalization.CultureInfo.CurrentCulture.ToString()

        Select Case lcultureinfo
            Case "fr-CA"
                MYstring = Mid(Madate, 1, 4) & "/" & Mid(Madate, 6, 2) & "/" & Mid(Madate, 9, 2)

                Return MYstring

            Case "en-US"
                MyPos = InStr(Madate, "/")
                date_mois = Mid(Madate, 1, MyPos - 1)
                ch = Mid(Madate, MyPos + 1)

                MyPos = InStr(ch, "/")
                date_jour = Mid(ch, 1, MyPos - 1)
                date_annee = Mid(ch, MyPos + 1, 4)

                If Len(date_jour) = 1 Then
                    date_jour = "0" & date_jour
                End If

                If Len(date_mois) = 1 Then
                    date_mois = "0" & date_mois
                End If

                MYstring = Trim(date_annee) & "/" & Trim(date_mois) & "/" & Trim(date_jour)

                Return MYstring

            Case "fr-FR", "en-CA", "en-GB"
                MYstring = Mid(Madate, 7, 4) & "/" & Mid(Madate, 4, 2) & "/" & Mid(Madate, 1, 2)

                Return MYstring
            Case Else
                MessageBox.Show("Parametres Regionaux incorrects.")
				MYstring = Mid(Madate, 7, 4) & "/" & Mid(Madate, 4, 2) & "/" & Mid(Madate, 1, 2)
                Return MYstring

        End Select

    End Function
    Public Sub Main()
        Application.EnableVisualStyles()
        '
        If Not File.Exists(RepTravail & "\" & SetupName) Then
            setup = New CSetup
        Else
            setup.loadsetup()
        End If
        '
        Dim gWd_Login As Wd_Login = New Wd_Login
        PunchClock_Connect.gStateConnectDB = False
        gWd_Login.ShowDialog()
        If PunchClock_Connect.gStateConnectDB = True Then
            '
            If setup.gModeUse = 0 Then '0 = Frm_MenuP 1 = Frm_Punch
                Dim lfrm_menuP As Frm_MenuP = New Frm_MenuP
                lfrm_menuP.ShowDialog()
            Else
                Dim lfrm_punch As Frm_Punch = New Frm_Punch
                lfrm_punch.ShowDialog()
            End If
        End If
    End Sub
End Module
