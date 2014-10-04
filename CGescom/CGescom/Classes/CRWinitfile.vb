Imports System.Runtime.InteropServices
Imports System.Text

Public Class CRWinitfile

    Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpAppName As String, _
        ByVal lpKeyName As String, _
        ByVal lpDefault As String, _
        ByVal lpReturnedString As StringBuilder, _
        ByVal nSize As Integer, _
        ByVal lpFileName As String) As Integer

    Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpAppName As String, _
        ByVal lpKeyName As String, _
        ByVal lpDefault As String, _
        ByVal lpFileName As String) As Integer
    '
    Public Sub New()

    End Sub

    Public Function ReadINI(ByVal pHeader As String, ByVal pVariable As String, ByVal pFileName As String, Optional ByVal pMaxCharQtyToRead As Integer = 254) As String

        Dim lReturn As StringBuilder
        lReturn = New StringBuilder(Chr(0), pMaxCharQtyToRead + 1)
        GetPrivateProfileString(pHeader, pVariable, "", lReturn, 255, pFileName)

        Return lReturn.ToString().Trim()
    End Function
    '
    Public Sub WriteINI(ByVal pHeader As String, ByVal pVariable As String, ByVal pValue As String, ByVal pFileName As String)

        WritePrivateProfileString(pHeader, pVariable, pValue, pFileName)

    End Sub

End Class
