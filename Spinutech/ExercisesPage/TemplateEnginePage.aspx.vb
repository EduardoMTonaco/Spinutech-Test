Imports Newtonsoft.Json.Linq

Public Class TemplateEnginePage
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            TXT_Template.Text = "${name} has an appointment on ${day} , ${hour}"
        End If
    End Sub

    Protected Sub BTN_Generate_Click(sender As Object, e As EventArgs) Handles BTN_Generate.Click
        Dim template As String = TXT_Template.Text
        Dim variables As New Dictionary(Of String, String)

        If Not String.IsNullOrEmpty(TXT_VarNameOne.Text) AndAlso Not String.IsNullOrEmpty(TXT_VarValueOne.Text) Then
            variables.Add(TXT_VarNameOne.Text, TXT_VarValueOne.Text)
        End If

        If Not String.IsNullOrEmpty(TXT_VarNameTwo.Text) AndAlso Not String.IsNullOrEmpty(TXT_VarValueTwo.Text) Then
            variables.Add(TXT_VarNameTwo.Text, TXT_VarValueTwo.Text)
        End If


        If Not String.IsNullOrEmpty(TXT_VarNameThree.Text) AndAlso Not String.IsNullOrEmpty(TXT_VarValueThree.Text) Then
            variables.Add(TXT_VarNameThree.Text, TXT_VarValueThree.Text)
        End If

        Dim engine As New TemplateEngine()
        Try
            Dim result = engine.Render(template, variables)
            LBL_Result.Text = result
        Catch ex As ArgumentException
            LBL_Result.Text = "Error: " & ex.Message
        Catch ex As Exception
            LBL_Result.Text = "Error: " & ex.Message
        End Try
    End Sub
End Class