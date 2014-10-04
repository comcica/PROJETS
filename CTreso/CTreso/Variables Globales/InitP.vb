Module InitP
        Public Sub InitVar()
            Unite(0) = "" : Unite(1) = "un " : Unite(2) = "deux " : Unite(3) = "trois " : Unite(4) = "quatre "
            Unite(5) = "cinq " : Unite(6) = "six " : Unite(7) = "sept " : Unite(8) = "huit " : Unite(9) = "neuf "
            Unite(10) = "dix " : Unite(11) = "onze " : Unite(12) = "douze " : Unite(13) = "treize " : Unite(14) = "quatorze "
            Unite(15) = "quinze " : Unite(16) = "seize " : Unite(17) = "dix-sept " : Unite(18) = "dix-huit " : Unite(19) = "dix-neuf "

            Dixaines(2) = "vingt " : Dixaines(3) = "trente " : Dixaines(4) = "quarante " : Dixaines(5) = "cinquante " : Dixaines(6) = "soixante "

        Monnaie(0) = "" : Monnaie(1) = "Dollar" : Monnaie(2) = "Euro" : Monnaie(3) = ""
        Monnaie(4) = "" : Monnaie(5) = "Cent" : Monnaie(6) = "Centime" : Monnaie(7) = ""
        End Sub

        Sub InitPays()
            Select Case Pays
                Case 0 'France
                    Dixaines(7) = "soixante-dix "
                    Dixaines(8) = "quatre-vingt "
                    Dixaines(9) = "quatre-vingt-dix "
                Case 1 'Belge
                    Dixaines(7) = "septante "
                    Dixaines(8) = "quatre-vingt "
                    Dixaines(9) = "nonante "
                Case 2 'suisse
                    Dixaines(7) = "septante "
                    Dixaines(8) = "huitante "
                    Dixaines(9) = "nonante "
            End Select
        End Sub
End Module
