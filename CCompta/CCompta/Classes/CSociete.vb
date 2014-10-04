Public Class CSociete
    Public D_RaisonSoc, D_Profession, D_Adresse, D_Complement, D_CodePostal, D_Ville, D_Pays, D_Commentaire, D_Identifiant, D_DebutExo01 As String
    Public D_DebutExo02, D_DebutExo03, D_DebutExo04, D_DebutExo05, D_FinExo01, D_FinExo02, D_FinExo03, D_FinExo04, D_FinExo05 As String
    Public D_Telephone, D_Telecopie, D_EMailSoc, D_Site, D_Anneefiscale As String

    Public Sub New()

    End Sub

    Public Sub New(ByVal lD_RaisonSoc As String, ByVal lD_Profession As String, ByVal lD_Adresse As String, ByVal lD_Complement As String, ByVal lD_CodePostal As String, ByVal lD_Ville As String, _
                   ByVal lD_Pays As String, ByVal lD_Commentaire As String, ByVal lD_Identifiant As String, ByVal lD_DebutExo01 As String, ByVal lD_DebutExo02 As String, ByVal lD_DebutExo03 As String, _
                   ByVal lD_DebutExo04 As String, ByVal lD_DebutExo05 As String, ByVal lD_FinExo01 As String, ByVal lD_FinExo02 As String, ByVal lD_FinExo03 As String, ByVal lD_FinExo04 As String, _
                   ByVal lD_FinExo05 As String, ByVal lD_Telephone As String, ByVal lD_Telecopie As String, ByVal lD_EMailSoc As String, ByVal lD_Site As String, ByVal lD_Anneefiscale As String)

        D_RaisonSoc = lD_RaisonSoc
        D_Profession = lD_Profession
        D_Adresse = lD_Adresse
        D_Complement = lD_Complement
        D_CodePostal = lD_CodePostal
        D_Ville = lD_Ville
        D_Pays = lD_Pays
        D_Commentaire = lD_Commentaire
        D_Identifiant = lD_Identifiant
        D_DebutExo01 = lD_DebutExo01
        D_DebutExo02 = lD_DebutExo02
        D_DebutExo03 = lD_DebutExo03
        D_DebutExo04 = lD_DebutExo04
        D_DebutExo05 = lD_DebutExo05
        D_FinExo01 = lD_FinExo01
        D_FinExo02 = lD_FinExo02
        D_FinExo03 = lD_FinExo03
        D_FinExo04 = lD_FinExo04
        D_FinExo05 = lD_FinExo05
        D_Telephone = lD_Telephone
        D_Telecopie = lD_Telecopie
        D_EMailSoc = lD_EMailSoc
        D_Site = lD_Site
        D_Anneefiscale = lD_Anneefiscale

    End Sub
End Class
