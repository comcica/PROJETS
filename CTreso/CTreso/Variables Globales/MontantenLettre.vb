Module MontantenLettre
    Public Pays As Byte
    Dim Decim As String, Stade As Integer
    Dim strResultat(6) As String
    Dim Reste As Single
    Dim StrReste As String
    Dim Devize As String
    Public Unite(19) As String
    Public Monnaie(7) As String
    Public Dixaines(9) As String
    Dim ValNb(6) As Double
    Dim mStrTemp As String
    Public Sep As String

    Function EnTexte(ByVal Chiffre As Double, Optional ByVal Langue As Byte = 0, Optional ByVal Devise As Byte = 0, Optional ByVal Decimale As Byte = 0) As String
        Dim i As Integer, txt As String
        Dim strTemp As String
        Dim Nombre As String, TB()
        If Chiffre = 0 Then EnTexte = "Zéro" : Exit Function
        Nombre = CStr(Chiffre) : strTemp = ""
        If Decimale = 0 Or Int(Chiffre) = Chiffre Then
            Nombre = Arrondi(Nombre, 0)
            Reste = 0
            If Int(Chiffre) = 0 And Reste = 0 Then EnTexte = "Zéro" : Exit Function
        Else
            TB = Split(CStr(Chiffre), Sep)
            Reste = TB(1) / 10 ^ Len(TB(1)) 'pour 2 décimales
            StrReste = TB(1) 'si pas de devise, met toutes les décimales
            If Chiffre < 1 Then
                strTemp = "Zéro "
                GoTo PasUnite
            End If
            Nombre = Int(Chiffre)
        End If
        Pays = Langue
        If Unite(1) = "" Then InitVar()
        InitPays()
reco:
        If Len(Nombre) / 3 <> Int(Len(Nombre) / 3) Then
            Nombre = "0" & Nombre
            GoTo reco
        End If
        Stade = (Len(Nombre) / 3)
        For i = 0 To Stade - 1
            txt = Mid(Nombre, (i * 3) + 1, 3)
            ValNb(i) = Val(txt)
            strResultat(i) = Centaine(txt)
        Next i
        i = 0
        If Stade > 4 Then 'Billiard
            If strResultat(i) <> "" Then
                strTemp = VoirRegle(strResultat(i)) & IIf(ValNb(i) = 1, "Billiard ", "Billiards ")
            End If
            i = i + 1
        End If
        If Stade > 3 Then 'Milliard
            If strResultat(i) <> "" Then
                strTemp = strTemp & VoirRegle(strResultat(i)) & IIf(ValNb(i) = 1, "Milliard ", "Milliards ")
            End If
            i = i + 1
        End If
        If Stade > 2 Then 'Million
            If strResultat(i) <> "" Then
                strTemp = strTemp & VoirRegle(strResultat(i)) & IIf(ValNb(i) = 1, "Million ", "Millions ")
            End If
            i = i + 1
        End If
        If Stade > 1 Then 'millier
            If strResultat(i) <> "" Then
                If strResultat(i) = "un " Then
                    strTemp = strTemp & "Mille "
                Else
                    strTemp = strTemp & VoirRegle(strResultat(i)) & "Mille "
                End If
            End If
            i = i + 1
        End If
        If Stade > 0 Then 'les unités
            If strResultat(i) <> "" Then
                If strTemp <> "" And ValNb(i) < 100 And (Right(strResultat(i), 3) <> "un " Or Len(strResultat(i)) = 3) Then
                    TB = Split(strTemp, " ")

                    Select Case TB(UBound(TB) - 1)
                        Case "Million", "Millions", "Milliard", "Milliards", "Billiard", "Billiards"
                            strTemp = strTemp & "et "
                    End Select
                End If
                strTemp = strTemp & VoirRegle(strResultat(i), False)
            End If
        End If
        TB = Split(strTemp, " ")
        Select Case TB(UBound(TB) - 1)
            Case "Million", "Millions", "Milliard", "Milliards", "Billiard", "Billiards"
                Select Case Devise
                    Case 1, 3 : strTemp = strTemp & "de "
                    Case 2 : strTemp = strTemp & "d'"
                End Select
        End Select
PasUnite:
        Select Case Devise
            Case Is > 0 : strTemp = strTemp & Monnaie(Devise) & IIf(Nombre = 1, " ", " ") '"s ")
        End Select
        If Reste <> 0 And Decimale = 1 Then
            If Devise = 0 Then
                strTemp = strTemp & "Virgule "
                'Appel pour les décimales en base 3
                strTemp = strTemp & AprVirgule(StrReste)
            Else
                strTemp = strTemp & " "
                Reste = Int(Reste * 1000) / 10
                ValNb(1) = Arrondi(Reste, 0)

                If ValNb(1) = 100 Then 'rectifie 100 centimes
                    strTemp = EnTexte(Arrondi(Chiffre, 0), Pays, Devise, 0)
                Else
                    txt = Right("00" & Trim(Str(ValNb(1))), 3)
                    txt = Centaine(txt) : txt = Trim(txt) & " "
                    strTemp = strTemp & VoirRegle(txt)
                    strTemp = strTemp & Monnaie(Devise + 4) & IIf(ValNb(1) = 1, "", "") '"s ")
                End If
            End If
        End If
        EnTexte = strTemp
    End Function

    Private Function AprVirgule(ByVal Nombre As String) As String
        Dim i As Integer, txt As String, strTemp As String, N(2)
        N(0) = "Millième" : N(1) = "Millionnième" : N(2) = "Milliardième"
reco:
        If Len(Nombre) / 3 <> Int(Len(Nombre) / 3) Then
            Nombre = Nombre & "0"
            GoTo reco
        End If
        Stade = (Len(Nombre) / 3) : strTemp = ""
        If Stade > 3 Then Stade = 3
        For i = 0 To Stade - 1
            txt = Mid(Nombre, (i * 3) + 1, 3)
            ValNb(i) = Val(txt)
            strResultat(i) = Centaine(txt)
        Next i
        For i = 0 To Stade - 1
            If strResultat(i) <> "" Then
                strTemp = strTemp & VoirRegle(strResultat(i)) & N(i) & IIf(ValNb(i) > 1, " ", " ") ' "s ", " ")
            End If
        Next i
        AprVirgule = strTemp
    End Function

    Private Function Centaine(ByVal Nombre As String) As String
        Dim i As Integer, e(3) As Integer, a As String
        Dim strBuff As String
        For i = 3 To 1 Step -1
            e(i) = Val(Mid(Nombre, i, 1))
        Next i
        e(0) = Val(Right(Nombre, 2))

        If e(3) = 1 Then
            If Pays = 0 Then
                If e(2) <= 7 Then strBuff = "et un " Else strBuff = Unite(e(3))
            Else
                If e(2) <> 8 Then strBuff = "et un " Else strBuff = Unite(e(3))
            End If
        Else
            strBuff = Unite(e(3))
        End If
        If e(0) < 20 Then
            strBuff = Unite(e(0))
        ElseIf e(0) < 70 Or (e(0) > 79 And e(0) < 90) Or Pays <> 0 Then
            If e(3) > 0 And Left(strBuff, 2) <> "et" Then
                strBuff = Trim(Dixaines(e(2))) & "-" & LTrim(strBuff)
            ElseIf strBuff <> "" Then
                strBuff = Dixaines(e(2)) & strBuff
            Else
                strBuff = Dixaines(e(2))
            End If
        Else
            If e(0) > 89 Then i = 80 Else i = 60
            If e(3) = 1 And e(2) = 7 Then
                strBuff = RTrim(Dixaines(e(2) - 1)) & " " & "et onze "
            Else
                strBuff = RTrim(Dixaines(e(2) - 1)) & "-" & Unite(e(0) - i)
            End If
        End If

        'Centaine
        If e(1) = 1 Then
            strBuff = "cent " & strBuff
        ElseIf e(1) >= 1 Then
            If e(0) = 0 Then a = "cents " Else a = "cent "
            strBuff = Unite(e(1)) & "cent " & strBuff
        End If
        Centaine = strBuff
    End Function

    Private Function Arrondi(ByVal Nombre, ByVal Decimales)
        Arrondi = Int(Nombre * 10 ^ Decimales + 1 / 2) / 10 ^ Decimales
    End Function

    Private Function VoirRegle(ByVal V As String, Optional ByVal Stde As Boolean = True) As String
        If Right(V, 6) = "vingt " Then
            If Stde Then
                VoirRegle = V
            ElseIf Len(V) > 6 Then
                VoirRegle = RTrim(V) & " " '"s "
            Else
                VoirRegle = V
            End If
        ElseIf Right(V, 4) = "ent " Then
            If Stde Then
                VoirRegle = V
            ElseIf Len(V) > 5 Then
                VoirRegle = RTrim(V) & " " ' "s "
            Else
                VoirRegle = V
            End If
        Else
            VoirRegle = V
        End If
    End Function
End Module
