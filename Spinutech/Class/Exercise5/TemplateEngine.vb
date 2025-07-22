Public Class TemplateEngine
    Public Function Render(template As String, variables As Dictionary(Of String, String)) As String
        Dim result As String = template

        ' Escapar strings (permitir ${${var}})
        result = result.Replace("${${", "${${${").Replace("}}}", "${}}}")
        result = Regex.Replace(result, "\${${(.*?)}${}", Function(m) "${" & GetVariableValue(m.Groups(1).Value, variables) & "}")

        ' Substituir variáveis
        Dim matches = Regex.Matches(result, "\${(.*?)}")
        For Each match In matches.Cast(Of Match)
            Dim varName = match.Groups(1).Value
            result = result.Replace("${" & varName & "}", GetVariableValue(varName, variables))
        Next

        Return result
    End Function

    Private Function GetVariableValue(varName As String, variables As Dictionary(Of String, String)) As String
        If variables.ContainsKey(varName) Then
            Return variables(varName)
        Else
            Throw New ArgumentException("Unassigned variable in template: " & varName)
        End If
    End Function
End Class
