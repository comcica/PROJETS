Module Functions
    Function FormDate(ByVal Madate As String) As String
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

End Module
