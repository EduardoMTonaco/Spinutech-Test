Imports Newtonsoft.Json.Linq

Public Class GameOfLifePage
    Inherits Page
    Private Const gridSize As Integer = 5

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        BuildBoard()
        LBL_SetGenaration.Text = "Set Life to Calculate the Next Generation"
    End Sub

    Private Sub BuildBoard()
        For i As Integer = 0 To gridSize - 1
            Dim row As New TableRow()
            For j As Integer = 0 To gridSize - 1
                Dim cell As New TableCell()
                Dim ddl As New DropDownList()
                ddl.ID = $"ddl_{i}_{j}"
                ddl.Items.Add(New ListItem("0", "0"))
                ddl.Items.Add(New ListItem("1", "1"))
                ddl.SelectedIndex = 0 ' Default to 0
                cell.Controls.Add(ddl)
                row.Cells.Add(cell)
            Next
            tblBoard.Rows.Add(row)
        Next
    End Sub

    Protected Sub btnNextGen_Click(sender As Object, e As EventArgs)
        Try
            Dim board As New List(Of List(Of String))()

            ' Get current generation from interactive table
            For i As Integer = 0 To gridSize - 1
                Dim row As New List(Of String)()
                For j As Integer = 0 To gridSize - 1
                    Dim cell As TableCell = tblBoard.Rows(i).Cells(j)
                    Dim ddl As DropDownList = CType(cell.Controls(0), DropDownList)
                    row.Add(ddl.SelectedValue)
                Next
                board.Add(row)
            Next

            ' Compute next generation
            Dim gameOfLife As New GameOfLife
            Dim nextGen = gameOfLife.NextGeneration(board)

            ' Show both generations as static tables
            pnlOutput.Visible = True
            litCurrentGen.Text = GenerateHtmlTable(board)
            litNextGen.Text = GenerateHtmlTable(nextGen)
        Catch ex As Exception
            ' Hide tables and show error message
            pnlOutput.Visible = False
            litCurrentGen.Text = ""
            litNextGen.Text = ""
            lblError.Text = "An error occurred: " & ex.Message
        End Try
    End Sub

    Private Function GenerateHtmlTable(matrix As List(Of List(Of String))) As String
        Dim sb As New System.Text.StringBuilder()
        sb.Append("<table border='1' style='border-collapse: collapse;'>")
        For Each row In matrix
            sb.Append("<tr>")
            For Each cell In row
                sb.AppendFormat("<td style='padding:5px; text-align:center;'>{0}</td>", cell)
            Next
            sb.Append("</tr>")
        Next
        sb.Append("</table>")
        Return sb.ToString()
    End Function
End Class