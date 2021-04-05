Imports System.Security.Cryptography
Imports System.IO
Public Class CryptoSecVb

    Private key() As Byte = {}
    Private IV() As Byte = {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}

    Public Function Decrypt(ByVal stringToDecrypt As String, ByVal sEncryptionKey As String) As String

        Dim inputByteArray(stringToDecrypt.Length) As Byte

        Try
            key = System.Text.Encoding.UTF8.GetBytes(Microsoft.VisualBasic.Strings.Left(sEncryptionKey, 8))
            Dim des As New DESCryptoServiceProvider()
            inputByteArray = Convert.FromBase64String(stringToDecrypt)
            Dim ms As New MemoryStream()
            Dim cs As New CryptoStream(ms, des.CreateDecryptor(key, IV), _
                CryptoStreamMode.Write)
            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()
            Dim encoding As System.Text.Encoding = System.Text.Encoding.UTF8
            Return encoding.GetString(ms.ToArray())
        Catch e As Exception
            'Throw New Exception("-CR-->ProVictimasUTIL.CryptoUtil.Decrypt->Source=" & Err.Source & "-CR-->Descripcion=" & Err.Description )
            Throw New Exception("44") 'Está intentando violar las reglas de validación de información, verifique sus datos e intente nuevamente
        End Try

    End Function

End Class
