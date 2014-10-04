Imports MySql.Data.MySqlClient
Imports System.Data

Public Class CMySQL_Bd_Connection
    Public conn As MySqlConnection
    Private myBuilder As MySqlCommandBuilder

    Public Function Connect_BD() As Boolean
        Dim strconnect As String
        If Not conn Is Nothing Then conn.Close()

        strconnect = "Server=" & CCompta_Connect.gServer & ";" & "User Id=" & CCompta_Connect.gUser & ";" & "Password=" & CCompta_Connect.gPassword & ";" & "Database=" & DatabaseName
        Try
            conn = New MySqlConnection(strconnect)
            conn.Open()
            Return True
        Catch ex As MySqlException
            MessageBox.Show("Error connecting to the server: " + ex.Message)
            Return False
        End Try

    End Function
    Public Function ConnectInit() As Boolean
        Dim strconnect As String
        If Not conn Is Nothing Then conn.Close()

        strconnect = "Server=" & CCompta_Connect.gServer & ";" & "User Id=" & CCompta_Connect.gUser & ";" & "Password=" & CCompta_Connect.gPassword & ";" & "Database=" & ""
        Try
            conn = New MySqlConnection(strconnect)
            conn.Open()
            Return True
        Catch ex As MySqlException
            MessageBox.Show("Error connecting to the server: " + ex.Message)
            Return False
        End Try

    End Function

    Public Function createDB(ByVal lDBName As String) As Boolean
        Dim lCommandText As String = "CREATE DATABASE " & lDBName
        Dim myCommand As MySqlCommand = New MySqlCommand(lCommandText, conn)
        Try
            myCommand.ExecuteNonQuery()
            myCommand.Cancel()

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function createTables() As Boolean
        Dim lCommandText As String
        Dim myCommand As MySqlCommand = conn.CreateCommand()

        Try
            'p_dossier
            lCommandText = ""
            lCommandText = "CREATE TABLE p_dossier (D_NumDossier int(11) NOT NULL AUTO_INCREMENT, D_RaisonSoc varchar(35) NOT NULL, D_Profession varchar(35) DEFAULT NULL, D_Adresse varchar(35) DEFAULT NULL, " & _
                "D_Complement varchar(35) DEFAULT NULL, D_CodePostal varchar(9) DEFAULT NULL, D_Ville varchar(35) DEFAULT NULL, D_Pays varchar(35) DEFAULT NULL, " & _
                "D_Commentaire varchar(69) DEFAULT NULL, D_Identifiant varchar(25) NOT NULL, D_DebutExo01 varchar(10) DEFAULT NULL, D_DebutExo02 varchar(10) DEFAULT NULL, " & _
                "D_DebutExo03 varchar(10) DEFAULT NULL, D_DebutExo04 varchar(10) DEFAULT NULL, D_DebutExo05 varchar(10) DEFAULT NULL, D_FinExo01 varchar(10) DEFAULT NULL, " & _
                "D_FinExo02 varchar(10) DEFAULT NULL, D_FinExo03 varchar(10) DEFAULT NULL, D_FinExo04 varchar(10) DEFAULT NULL, D_FinExo05 varchar(10) DEFAULT NULL, " & _
                "D_Telephone varchar(21) DEFAULT NULL, D_Telecopie varchar(21) DEFAULT NULL, D_EMailSoc varchar(35) DEFAULT NULL, D_Site varchar(35) DEFAULT NULL, D_Anneefiscale varchar(4) NOT NULL, " & _
                "PRIMARY KEY (D_NumDossier))"
            myCommand.CommandText = lCommandText
            myCommand.ExecuteNonQuery()
            'f_compteg
            lCommandText = ""
            lCommandText = "CREATE TABLE f_compteg (CG_Numordre int(11) NOT NULL AUTO_INCREMENT, CG_Num varchar(13) NOT NULL, CG_Intitule varchar(35) NOT NULL, CG_Type int(11) DEFAULT '0', " & _
                "N_Nature int(11) DEFAULT '0', CG_Report int(11) DEFAULT NULL, CG_Tiers int(11) DEFAULT NULL, CG_DateCreate varchar(10) DEFAULT NULL, " & _
                "TA_Code varchar(3) DEFAULT NULL, PRIMARY KEY (CG_Numordre), UNIQUE KEY (CG_Num))"
            myCommand.CommandText = lCommandText
            myCommand.ExecuteNonQuery()

            'f_comptet
            lCommandText = ""
            lCommandText = "CREATE TABLE f_comptet (CT_Numordre int(11) NOT NULL AUTO_INCREMENT, CT_Num varchar(17) NOT NULL, CT_Intitule varchar(35) NOT NULL, CT_Type int(11) NOT NULL, " & _
                "CG_NumPrinc varchar(13) NOT NULL, CT_Contact varchar(35) DEFAULT NULL, CT_Adresse varchar(35) DEFAULT NULL, CT_Complement varchar(35) DEFAULT NULL, " & _
                "CT_CodePostal varchar(9) DEFAULT NULL, CT_Ville varchar(35) DEFAULT NULL, CT_CodeRegion varchar(25) DEFAULT NULL, " & _
                "CT_Pays varchar(35) DEFAULT NULL, CT_Identifiant varchar(25) DEFAULT NULL, CT_Sommeil int(11) DEFAULT NULL, " & _
                "CT_Telephone varchar(21) DEFAULT NULL, CT_Telecopie varchar(21) DEFAULT NULL, CT_EMail varchar(35) DEFAULT NULL, CT_Site varchar(35) DEFAULT NULL, " & _
                "PRIMARY KEY (CT_Numordre), UNIQUE KEY (CT_Num))"
            myCommand.CommandText = lCommandText
            myCommand.ExecuteNonQuery()
            'f_comptetg
            lCommandText = ""
            lCommandText = "CREATE TABLE f_comptetg (Numordre int(11) NOT NULL AUTO_INCREMENT, CT_Num varchar(17) NOT NULL, CG_Num varchar(13) NOT NULL, " & _
                "PRIMARY KEY (Numordre), KEY (CT_Num), KEY (CG_Num))"
            myCommand.CommandText = lCommandText
            myCommand.ExecuteNonQuery()
            'f_taxe
            lCommandText = ""
            lCommandText = "CREATE TABLE f_taxe (TA_Intitule varchar(35) NOT NULL, TA_Taux DECIMAL(3,2) NOT NULL, CG_Num varchar(13) NOT NULL, " & _
                "TA_Code varchar(3) NOT NULL, TA_Sens int(11) NOT NULL, " & _
                "PRIMARY KEY (TA_Code), KEY (CG_Num), KEY (TA_Intitule))"
            myCommand.CommandText = lCommandText
            myCommand.ExecuteNonQuery()

            'f_etaxe 
            lCommandText = ""
            lCommandText = "CREATE TABLE f_etaxe (CG_Num varchar(13) NOT NULL, TA_Code varchar(3) NOT NULL, " & _
                "KEY (CG_Num), KEY (TA_Code))"
            myCommand.CommandText = lCommandText
            myCommand.ExecuteNonQuery()

            'f_journaux
            lCommandText = ""
            lCommandText = "CREATE TABLE f_journaux (Numordrecj int(11) NOT NULL AUTO_INCREMENT, JO_Num varchar(6) NOT NULL, JO_Intitule varchar(35) NOT NULL, CG_Num varchar(13) DEFAULT NULL, " & _
                "JO_Type int(11) NOT NULL, JO_Sommeil int(11) DEFAULT NULL, " & _
                "PRIMARY KEY (Numordrecj), KEY (JO_Num))"
            myCommand.CommandText = lCommandText
            myCommand.ExecuteNonQuery()
            'f_ecriturec
            lCommandText = ""
            lCommandText = "CREATE TABLE f_ecriturec (EC_No bigint(20) NOT NULL AUTO_INCREMENT, JO_Num varchar(6) NOT NULL, JM_Date varchar(10) NOT NULL, EC_Jour int(11) NOT NULL, " & _
                "EC_Date varchar(10) NOT NULL, EC_Piece varchar(13) NOT NULL, EC_RefPiece varchar(17) NOT NULL, EC_TresoPiece varchar(17) NOT NULL, " & _
                "CG_Num varchar(13) NOT NULL, CG_NumCont varchar(13) NOT NULL, CT_Num varchar(17) DEFAULT NULL, " & _
                "EC_Intitule varchar(35) DEFAULT NULL, EC_Sens int(11) NOT NULL, EC_Montant DECIMAL(3,2) NOT NULL, " & _
                "EC_Cloture int(11) DEFAULT NULL, TA_Code varchar(3) DEFAULT NULL, " & _
                "PRIMARY KEY (EC_No), KEY (CG_Num), KEY (CT_Num), KEY (EC_Date))"
            myCommand.CommandText = lCommandText
            myCommand.ExecuteNonQuery()

            myCommand.Cancel()

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
    Public Function AddSociete(ByVal lD_RaisonSoc As String, ByVal lD_Profession As String, ByVal lD_Adresse As String, ByVal lD_Complement As String, ByVal lD_CodePostal As String, ByVal lD_Ville As String, _
                   ByVal lD_Pays As String, ByVal lD_Commentaire As String, ByVal lD_Identifiant As String, ByVal lD_DebutExo01 As String, ByVal lD_DebutExo02 As String, ByVal lD_DebutExo03 As String, _
                   ByVal lD_DebutExo04 As String, ByVal lD_DebutExo05 As String, ByVal lD_FinExo01 As String, ByVal lD_FinExo02 As String, ByVal lD_FinExo03 As String, ByVal lD_FinExo04 As String, _
                   ByVal lD_FinExo05 As String, ByVal lD_Telephone As String, ByVal lD_Telecopie As String, ByVal lD_EMailSoc As String, ByVal lD_Site As String, ByVal lD_Anneefiscale As String) As Boolean

        Dim MyStringInsert As String = ""
        Dim cmd = conn.CreateCommand()
        ' table
        Try
            cmd.Parameters.AddWithValue("@RaisonSoc", lD_RaisonSoc)
            cmd.Parameters.AddWithValue("@Profession", lD_Profession)
            cmd.Parameters.AddWithValue("@Adresse", lD_Adresse)
            cmd.Parameters.AddWithValue("@Complement", lD_Complement)
            cmd.Parameters.AddWithValue("@CodePostal", lD_CodePostal)
            cmd.Parameters.AddWithValue("@Ville", lD_Ville)
            cmd.Parameters.AddWithValue("@lPays", lD_Pays)
            cmd.Parameters.AddWithValue("@Commentaire", lD_Commentaire)
            cmd.Parameters.AddWithValue("@Identifiant", lD_Identifiant)
            cmd.Parameters.AddWithValue("@DebutExo01", lD_DebutExo01)
            cmd.Parameters.AddWithValue("@DebutExo02", lD_DebutExo02)
            cmd.Parameters.AddWithValue("@DebutExo03", lD_DebutExo03)
            cmd.Parameters.AddWithValue("@DebutExo04", lD_DebutExo04)
            cmd.Parameters.AddWithValue("@DebutExo05", lD_DebutExo05)
            cmd.Parameters.AddWithValue("@FinExo01", lD_FinExo01)
            cmd.Parameters.AddWithValue("@FinExo02", lD_FinExo02)
            cmd.Parameters.AddWithValue("@FinExo03", lD_FinExo03)
            cmd.Parameters.AddWithValue("@FinExo04", lD_FinExo04)
            cmd.Parameters.AddWithValue("@FinExo05", lD_FinExo05)
            cmd.Parameters.AddWithValue("@Telephone", lD_Telephone)
            cmd.Parameters.AddWithValue("@Telecopie", lD_Telecopie)
            cmd.Parameters.AddWithValue("@EMailSoc", lD_EMailSoc)
            cmd.Parameters.AddWithValue("@Site", lD_Site)
            cmd.Parameters.AddWithValue("@Anneefiscale", lD_Anneefiscale)


            cmd.CommandText = "INSERT INTO p_dossier (D_RaisonSoc, D_Profession, D_Adresse, D_Complement, D_CodePostal, D_Ville, " & _
            "D_Pays, D_Commentaire, D_Identifiant, D_DebutExo01, D_DebutExo02, D_DebutExo03, D_DebutExo04, D_DebutExo05, D_FinExo01, " & _
            "D_FinExo02, D_FinExo03, D_FinExo04, D_FinExo05, D_Telephone, D_Telecopie, D_EMailSoc, D_Site, D_Anneefiscale) VALUES ( " & _
            "@RaisonSoc, @Profession, @Adresse, @Complement, @CodePostal, @Ville, @lPays, @Commentaire, @Identifiant, @DebutExo01, @DebutExo02, " & _
            "@DebutExo03, @DebutExo04, @DebutExo05, @FinExo01, @FinExo02, @FinExo03, @FinExo04, @FinExo05, @Telephone, @Telecopie, @EMailSoc, @Site, @Anneefiscale)"

            cmd.ExecuteNonQuery()

            Return True
        Catch
            Return False
        End Try

    End Function
    Public Function UpdateSociete(ByVal lD_RaisonSoc As String, ByVal lD_Profession As String, ByVal lD_Adresse As String, ByVal lD_Complement As String, ByVal lD_CodePostal As String, ByVal lD_Ville As String, _
               ByVal lD_Pays As String, ByVal lD_Commentaire As String, ByVal lD_Identifiant As String, ByVal lD_DebutExo01 As String, ByVal lD_DebutExo02 As String, ByVal lD_DebutExo03 As String, _
               ByVal lD_DebutExo04 As String, ByVal lD_DebutExo05 As String, ByVal lD_FinExo01 As String, ByVal lD_FinExo02 As String, ByVal lD_FinExo03 As String, ByVal lD_FinExo04 As String, _
               ByVal lD_FinExo05 As String, ByVal lD_Telephone As String, ByVal lD_Telecopie As String, ByVal lD_EMailSoc As String, ByVal lD_Site As String, ByVal lD_Anneefiscale As String) As Boolean

        Dim MyStringInsert As String = ""
        Dim cmd = conn.CreateCommand()
        ' table
        Try
            cmd.Parameters.AddWithValue("@RaisonSoc", lD_RaisonSoc)
            cmd.Parameters.AddWithValue("@Profession", lD_Profession)
            cmd.Parameters.AddWithValue("@Adresse", lD_Adresse)
            cmd.Parameters.AddWithValue("@Complement", lD_Complement)
            cmd.Parameters.AddWithValue("@CodePostal", lD_CodePostal)
            cmd.Parameters.AddWithValue("@Ville", lD_Ville)
            cmd.Parameters.AddWithValue("@lPays", lD_Pays)
            cmd.Parameters.AddWithValue("@Commentaire", lD_Commentaire)
            cmd.Parameters.AddWithValue("@Identifiant", lD_Identifiant)
            cmd.Parameters.AddWithValue("@DebutExo01", lD_DebutExo01)
            cmd.Parameters.AddWithValue("@DebutExo02", lD_DebutExo02)
            cmd.Parameters.AddWithValue("@DebutExo03", lD_DebutExo03)
            cmd.Parameters.AddWithValue("@DebutExo04", lD_DebutExo04)
            cmd.Parameters.AddWithValue("@DebutExo05", lD_DebutExo05)
            cmd.Parameters.AddWithValue("@FinExo01", lD_FinExo01)
            cmd.Parameters.AddWithValue("@FinExo02", lD_FinExo02)
            cmd.Parameters.AddWithValue("@FinExo03", lD_FinExo03)
            cmd.Parameters.AddWithValue("@FinExo04", lD_FinExo04)
            cmd.Parameters.AddWithValue("@FinExo05", lD_FinExo05)
            cmd.Parameters.AddWithValue("@Telephone", lD_Telephone)
            cmd.Parameters.AddWithValue("@Telecopie", lD_Telecopie)
            cmd.Parameters.AddWithValue("@EMailSoc", lD_EMailSoc)
            cmd.Parameters.AddWithValue("@Site", lD_Site)
            cmd.Parameters.AddWithValue("@Anneefiscale", lD_Anneefiscale)


            cmd.CommandText = "UPDATE p_dossier SET D_RaisonSoc=@RaisonSoc, D_Profession= @Profession, D_Adresse=@Adresse, D_Complement=@Complement, D_CodePostal=@CodePostal, D_Ville=@Ville, " & _
            "D_Pays=@lPays, D_Commentaire=@Commentaire, D_Identifiant=@Identifiant, D_DebutExo01=@DebutExo01, D_DebutExo02=@DebutExo02, D_DebutExo03=@DebutExo03, D_DebutExo04=@DebutExo04, D_DebutExo05=@DebutExo05, D_FinExo01=@FinExo01, " & _
            "D_FinExo02=@FinExo02, D_FinExo03=@FinExo03, D_FinExo04=@FinExo04, D_FinExo05=@FinExo05, D_Telephone=@Telephone, D_Telecopie=@Telecopie, D_EMailSoc=@EMailSoc, D_Site=@Site, D_Anneefiscale=@Anneefiscale"

            cmd.ExecuteNonQuery()

            Return True
        Catch
            Return False
        End Try

    End Function

    Public Function FindSociete(ByVal ltxtSQL As String) As Boolean
        Dim lcmd As MySqlCommand
        Dim lreader As MySqlDataReader = Nothing
        Dim lRaisonSoc, lProfession, lAdresse, lComplement, lCodePostal, lVille, lPays, lCommentaire, lIdentifiant As String
        Dim lDebutExo01, lDebutExo02, lDebutExo03, lDebutExo04, lDebutExo05, lFinExo01, lFinExo02, lFinExo03, lFinExo04 As String
        Dim lFinExo05, lTelephone, lTelecopie, lEMailSoc, lSite, lanneefiscale As String

        Try
            lcmd = New MySqlCommand(ltxtSQL, conn)
            lreader = lcmd.ExecuteReader()

            If lreader.Read() Then

                lRaisonSoc = lreader.GetString(1)
                lProfession = lreader.GetString(2)
                lAdresse = lreader.GetString(3)
                lComplement = lreader.GetString(4)
                lCodePostal = lreader.GetString(5)
                lVille = lreader.GetString(6)
                lPays = lreader.GetString(7)
                lCommentaire = lreader.GetString(8)
                lIdentifiant = lreader.GetString(9)
                lDebutExo01 = lreader.GetString(10)
                lDebutExo02 = lreader.GetString(11)
                lDebutExo03 = lreader.GetString(12)
                lDebutExo04 = lreader.GetString(13)
                lDebutExo05 = lreader.GetString(14)
                lFinExo01 = lreader.GetString(15)
                lFinExo02 = lreader.GetString(16)
                lFinExo03 = lreader.GetString(17)
                lFinExo04 = lreader.GetString(18)
                lFinExo05 = lreader.GetString(19)
                lTelephone = lreader.GetString(20)
                lTelecopie = lreader.GetString(21)
                lEMailSoc = lreader.GetString(22)
                lSite = lreader.GetString(23)
                lanneefiscale = lreader.GetString(24)
                '
                d_socete = New CSociete(lRaisonSoc, lProfession, lAdresse, lComplement, lCodePostal, lVille, lPays, lCommentaire, lIdentifiant, _
                                        lDebutExo01, lDebutExo02, lDebutExo03, lDebutExo04, lDebutExo05, lFinExo01, lFinExo02, lFinExo03, lFinExo04, _
                                        lFinExo05, lTelephone, lTelecopie, lEMailSoc, lSite, lanneefiscale)

                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
        Finally
            If Not lreader Is Nothing Then lreader.Close()

        End Try
    End Function

    Public Function Maj(ByVal ltxtSQL As String) As Boolean
        Dim lcmd As MySqlCommand

        Try
            lcmd = New MySqlCommand(ltxtSQL, conn)
            lcmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
    Public Function Trouver(ByVal ltxtSQL As String) As Boolean
        Dim lcmd As MySqlCommand
        Dim lreader As MySqlDataReader = Nothing

        Try
            lcmd = New MySqlCommand(ltxtSQL, conn)
            lreader = lcmd.ExecuteReader()
            If lreader.Read() Then
                Return True
            Else
                Return False
            End If
            lcmd.Cancel()
        Catch
            Return False
        Finally
            If Not lreader Is Nothing Then lreader.Close()
        End Try

    End Function
    Public Function displayGrid(ByVal lCommandText As String) As DataTable
        'Dim lCommandText As String = "SELECT * FROM T_Files"
        Dim da As New MySqlDataAdapter()
        Dim dt As DataTable = New DataTable("Compte")

        da = New MySqlDataAdapter(lCommandText, conn)
        myBuilder = New MySqlCommandBuilder(da)
        da.Fill(dt)
        'gdFile.ItemsSource = dt.DefaultView
        da.Dispose()

        Return dt
    End Function
    Public Function getCTIntitule(ByVal ltxtSQL As String) As String
        Dim reader As MySqlDataReader
        Dim lIntitule As String = ""
        reader = Nothing

        Dim cmd As New MySqlCommand(ltxtSQL, conn)
        Try
            reader = cmd.ExecuteReader()
            If (reader.Read()) Then
                lIntitule = reader.GetString(0)
            End If
            Return lIntitule
        Catch ex As MySqlException
            Return lIntitule
        Finally
            If Not reader Is Nothing Then reader.Close()
        End Try
    End Function

    Public Sub disconnect()
        If Not conn Is Nothing Then
            conn.Dispose()
            conn.Close()
        End If
    End Sub

End Class
