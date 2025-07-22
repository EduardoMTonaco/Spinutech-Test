Imports System.Globalization
Imports Newtonsoft.Json.Linq

Public Class SpiralNumberPage
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LBL_ButtonTitle.Text = "Convert Number to Spiral"
        End If
    End Sub
    Protected Sub BTN_Convert_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            If TXT_Number.Text <> "" AndAlso TXT_Number.Text.Length < 4 Then
                Dim number As Integer = Integer.Parse(TXT_Number.Text)
                Dim SpiralNumber As New SpiralNumber
                Dim spiral As IList(Of String) = SpiralNumber.CreateSpiralList(number)
                Dim result As String = ""
                For Each text As String In spiral
                    result += text + "</br>"
                Next

                For index = 1 To 0

                Next
                LBL_Result.Text = result
            Else
                LBL_Result.Text = ""
            End If
        Catch ex As Exception
            LBL_Result.Text = ex.Message
        End Try
    End Sub
End Class