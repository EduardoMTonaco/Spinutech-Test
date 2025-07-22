Public Class SpiralNumber
    Public Function CreateSpiralList(n As Integer) As List(Of String)
        Dim resultList As IList(Of String) = New List(Of String)()

        Dim size As Integer = Math.Ceiling(Math.Sqrt(n + 1))
        If size Mod 2 = 0 Then
            size += 1
        End If

        Dim spiral(size - 1, size - 1) As Integer
        Dim filled(size - 1, size - 1) As Boolean

        Dim x As Integer = size \ 2
        Dim y As Integer = size \ 2

        Dim dx() As Integer = {1, 0, -1, 0}
        Dim dy() As Integer = {0, 1, 0, -1}
        Dim dir As Integer = 0
        Dim steps As Integer = 1
        Dim currentValue As Integer = 0

        Do While currentValue <= n
            For i As Integer = 0 To 1
                For j As Integer = 1 To steps
                    If x >= 0 AndAlso x < size AndAlso y >= 0 AndAlso y < size Then
                        If currentValue > n Then Exit For
                        spiral(y, x) = currentValue
                        filled(y, x) = True
                        currentValue += 1
                    End If
                    x += dx(dir)
                    y += dy(dir)
                Next
                dir = (dir + 1) Mod 4
            Next
            steps += 1
        Loop


        Dim maxDigits As Integer = n.ToString().Length  ' Calculate max number of digits
        Dim fieldWidth As Integer = maxDigits + 1 ' 1 extra space for padding


        For row As Integer = 0 To size - 1
            Dim line As String = ""
            For col As Integer = 0 To size - 1
                If filled(row, col) Then
                    Dim padded = spiral(row, col).ToString().PadLeft(fieldWidth)
                    line += padded.Replace(" ", "&nbsp;")
                Else
                    line += String.Concat(Enumerable.Repeat("&nbsp;", fieldWidth))
                End If
            Next
            resultList.Add(line)
        Next

        Return resultList
    End Function
End Class
