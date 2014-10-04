
Imports System.Data.SqlClient
Imports System.Data

Public Class CSQLSERVER
    'Private myConnDB As SqlConnection = Nothing
    Public myConn As SqlConnection = Nothing
    Private myCmd As SqlCommand = Nothing
    Private myBuilder As SqlCommandBuilder
    Public dt As DataTable = New DataTable("Docs")

    Public Sub New()

    End Sub
    Public Function connectDB(ByVal lipInstance As String, ByVal lBD As String, ByVal luser As String, ByVal lpassword As String) As Boolean
        Dim strconnect = "Server=" & lipInstance & ";" & "Database=" & lBD & ";" & "User Id=" & luser & ";" & "Password=" & lpassword

        Try
            myConn = New SqlConnection(strconnect)
            myConn.Open()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function createDB(ByVal lDBName As String) As Boolean
        Dim lCommandText As String = "CREATE DATABASE " & lDBName
        Dim myCommand As SqlCommand = New SqlCommand(lCommandText, myConn)
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
        Dim myCommand As SqlCommand = myConn.CreateCommand()

        Try
            'T_Armoires
            lCommandText = ""
            lCommandText = "CREATE TABLE T_Armoires (ArmoireID BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY, Designation VARCHAR(50) NOT NULL)"
            myCommand.CommandText = lCommandText
            myCommand.ExecuteNonQuery()
            'T_Rayons
            lCommandText = ""
            lCommandText = "CREATE TABLE T_Rayons (RayonID BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY, ArmoireID BIGINT NOT NULL, Designation VARCHAR(50) NOT NULL)"
            myCommand.CommandText = lCommandText
            myCommand.ExecuteNonQuery()
            'T_Classeurs
            lCommandText = ""
            lCommandText = "CREATE TABLE T_Classeurs (ClasseurID BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY, RayonID BIGINT NOT NULL, Designation VARCHAR(50) NOT NULL)"
            myCommand.CommandText = lCommandText
            myCommand.ExecuteNonQuery()
            'T_Dossiers
            lCommandText = ""
            lCommandText = "CREATE TABLE T_Dossiers (DossierID BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY, ClasseurID BIGINT NOT NULL, Designation VARCHAR(50) NOT NULL)"
            myCommand.CommandText = lCommandText
            myCommand.ExecuteNonQuery()
            'T_Archives
            lCommandText = "CREATE TABLE T_Archives (ArchiveID BIGINT IDENTITY(1,1) NOT NULL, ArmoireID BIGINT NOT NULL, RayonID BIGINT NOT NULL, ClasseurID BIGINT NOT NULL, DossierID BIGINT NOT NULL, " & _
                "fileType VARCHAR(6) Null, fileName VARCHAR(50) NOT NULL, fileDate VARCHAR(10) NULL, " & _
                "fileLastAcces VARCHAR(10) NULL, fileLastWrite VARCHAR(10) NULL, fileLength FLOAT NULL, fileData VARBINARY(max) NULL, fileImage IMAGE NULL, PRIMARY KEY (ArchiveID, ArmoireID, RayonID, ClasseurID, DossierID), )"
            myCommand.CommandText = lCommandText
            myCommand.ExecuteNonQuery()

            'CREATE UNIQUE INDEX idxfileName ON T_Archives 
            lCommandText = "CREATE UNIQUE INDEX idxfileName ON T_Archives(fileName)"
            myCommand.CommandText = lCommandText
            myCommand.ExecuteNonQuery()


            myCommand.Cancel()

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function displaydocs(ByVal lCommandText As String) As DataTable
        'Dim lCommandText As String = "SELECT * FROM T_Files"
        Dim da As New SqlDataAdapter()
        Dim dt As DataTable = New DataTable("Files")

        da = New SqlDataAdapter(lCommandText, myConn)
        myBuilder = New SqlCommandBuilder(da)
        da.Fill(dt)
        'gdFile.ItemsSource = dt.DefaultView
        da.Dispose()

        Return dt


    End Function
    Public Sub Maj(ByVal ltxtSQL As String)
        Dim lcmd As SqlCommand

        lcmd = New SqlCommand(ltxtSQL, myConn)
        lcmd.ExecuteNonQuery()

        lcmd.Cancel()

    End Sub
    Public Function Trouver(ByVal ltxtSQL As String) As Boolean
        Dim lcmd As SqlCommand
        Dim lreader As SqlDataReader = Nothing

        Try
            lcmd = New SqlCommand(ltxtSQL, myConn)
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
    Public Function getID(ByVal ltxtSQL As String) As String
        Dim reader As SqlDataReader
        Dim lid As Integer = 0
        reader = Nothing

        Dim cmd As New SqlCommand(ltxtSQL, myConn)
        Try
            reader = cmd.ExecuteReader()
            If (reader.Read()) Then
                lid = reader.GetSqlInt64(0)
            End If
            Return lid
        Catch ex As SqlException
            Return lid
        Finally
            If Not reader Is Nothing Then reader.Close()
        End Try
    End Function
    Public Function getDesgnation(ByVal ltxtSQL As String) As String
        Dim reader As SqlDataReader
        Dim ldesignation As String = ""
        reader = Nothing

        Dim cmd As New SqlCommand(ltxtSQL, myConn)
        Try
            reader = cmd.ExecuteReader()
            If (reader.Read()) Then
                ldesignation = reader.GetSqlString(0)
            End If
            Return ldesignation
        Catch ex As SqlException
            Return ldesignation
        Finally
            If Not reader Is Nothing Then reader.Close()
        End Try
    End Function


    Public Sub disconnect()
        If Not myConn Is Nothing Then
            myConn.Dispose()
            myConn.Close()
        End If
    End Sub
End Class
