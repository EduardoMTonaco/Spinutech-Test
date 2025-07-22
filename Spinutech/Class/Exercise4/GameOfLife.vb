Public Class GameOfLife
    Public Function NextGeneration(board As List(Of List(Of String))) As List(Of List(Of String))
        Dim rows As Integer = board.Count
        Dim cols As Integer = board(0).Count
        Dim nextBoard As New List(Of List(Of String))()

        For i As Integer = 0 To rows - 1
            Dim newRow As New List(Of String)()
            For j As Integer = 0 To cols - 1
                Dim liveNeighbors As Integer = CountLiveNeighbors(board, i, j, rows, cols)
                Dim cell As Integer = Integer.Parse(board(i)(j))

                Dim newCell As String = "0" ' Default dead
                If cell = 1 AndAlso (liveNeighbors = 2 OrElse liveNeighbors = 3) Then
                    newCell = "1" ' Lives
                ElseIf cell = 0 AndAlso liveNeighbors = 3 Then
                    newCell = "1" ' Becomes alive
                End If

                newRow.Add(newCell)
            Next
            nextBoard.Add(newRow)
        Next

        Return nextBoard
    End Function

    Private Function CountLiveNeighbors(board As List(Of List(Of String)), row As Integer, col As Integer, rows As Integer, cols As Integer) As Integer
        Dim directions As Integer(,) = {
            {-1, -1}, {-1, 0}, {-1, 1},
            {0, -1}, {0, 1},
            {1, -1}, {1, 0}, {1, 1}
        }

        Dim liveCount As Integer = 0
        For k As Integer = 0 To directions.GetLength(0) - 1
            Dim newRow As Integer = row + directions(k, 0)
            Dim newCol As Integer = col + directions(k, 1)
            If newRow >= 0 AndAlso newRow < rows AndAlso newCol >= 0 AndAlso newCol < cols Then
                If board(newRow)(newCol) = "1" Then
                    liveCount += 1
                End If
            End If
        Next
        Return liveCount
    End Function
End Class