Public Class CPiece
    Public numPiece, designation, ldate, ref, nfact, tiers, benef, cpteg, mt As String
    Public typetreso, sens As Integer
    Public Sub New(ByVal lnumPiece As String, ByVal ldesignation As String, ByVal lldate As String, ByVal lref As String, _
                   ByVal lnfact As String, ByVal ltiers As String, ByVal lbenef As String, ByVal lcpteg As String, ByVal lsens As String, ByVal lmt As String, ByVal ltypetreso As Integer)

        numPiece = lnumPiece
        designation = ldesignation
        ldate = lldate
        ref = lref
        nfact = lnfact
        tiers = ltiers
        benef = lbenef
        cpteg = lcpteg
        sens = lsens
        mt = lmt
        typetreso = ltypetreso

    End Sub
End Class
