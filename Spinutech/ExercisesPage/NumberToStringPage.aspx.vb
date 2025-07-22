Imports System.Globalization
Imports System.Threading
Imports Newtonsoft.Json.Linq

Public Class NumberToStringPage
    Inherits Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If Not IsPostBack Then
            LBL_ButtonTitle.Text = "Convert Number to Words"
        End If
    End Sub
    Protected Sub BTN_Convert_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            If TXT_Number.Text <> "" AndAlso TXT_Number.Text.Length < 12 Then
                Dim decimalNumber As Decimal = Decimal.Parse(TXT_Number.Text, CultureInfo.InvariantCulture)
                Dim NumberToString As New NumberToString
                LBL_Result.Text = "Your number are: " + NumberToString.ConvertAmountToString(decimalNumber)
            Else
                LBL_Result.Text = ""
            End If
        Catch ex As Exception
            LBL_Result.Text = ex.Message
        End Try
    End Sub

End Class