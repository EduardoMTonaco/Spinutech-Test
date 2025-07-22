Public Class PokerHandEvaluator
    Dim RankOrder As New Dictionary(Of String, Integer) From {
       {"2", 2}, {"3", 3}, {"4", 4}, {"5", 5}, {"6", 6},
       {"7", 7}, {"8", 8}, {"9", 9}, {"10", 10},
       {"J", 11}, {"Q", 12}, {"K", 13}, {"A", 14}
   }
    Public Function EvaluateHand(handStr As String) As String
        Dim cards = handStr.Split(" "c)
        Dim ranks As New List(Of String)
        Dim suits As New List(Of Char)
        For Each card In cards
            Dim rank = card.Substring(0, card.Length - 1)
            Dim suit = card.Last()
            ranks.Add(rank)
            suits.Add(suit)
        Next
        Try
            ' Convert ranks to integers
            Dim values = ranks.Select(Function(r) RankOrder(r)).OrderBy(Function(v) v).ToList()

            ' Count occurrences
            Dim rankGroups = ranks.GroupBy(Function(r) r).Select(Function(g) New With {.Rank = RankOrder, .Count = g.Count()}).ToList()
            Dim counts As List(Of Integer) = rankGroups.Select(Function(g) g.Count).OrderByDescending(Function(c) c).ToList()

            Dim isFlush As Boolean = suits.Distinct().Count() = 1
            Dim isStraight As Boolean = values.Distinct().Count() = 5 AndAlso values.Max() - values.Min() = 4
            Dim isRoyal As Boolean = values.SequenceEqual(New List(Of Integer) From {10, 11, 12, 13, 14})

            ' Special case: A-2-3-4-5 Straight
            If values.SequenceEqual(New List(Of Integer) From {2, 3, 4, 5, 14}) Then
                isStraight = True
            End If

            Dim handRank As String
            If isFlush AndAlso isStraight AndAlso isRoyal Then
                handRank = "Royal Straight Flush"
            ElseIf isFlush AndAlso isStraight Then
                handRank = "Straight Flush"
            ElseIf counts.SequenceEqual({4, 1}) Then
                handRank = "Four of a Kind"
            ElseIf counts.SequenceEqual({3, 2}) Then
                handRank = "Full House"
            ElseIf isFlush Then
                handRank = "Flush"
            ElseIf isStraight Then
                handRank = "Straight"
            ElseIf counts.SequenceEqual({3, 1, 1}) Then
                handRank = "Three of a Kind"
            ElseIf counts.SequenceEqual({2, 2, 1}) Then
                handRank = "Two Pair"
            ElseIf counts.SequenceEqual({2, 1, 1, 1}) Then
                handRank = "One Pair"
            Else
                handRank = "High Card"
            End If

            Return $"Hand: {handStr}  ->  {handRank}"
        Catch ex As Exception
            Throw
        End Try
    End Function
End Class
