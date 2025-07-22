
Public Class PalindromeChecker
    Public Function IsPalindrome(number As Integer) As Boolean
        If number < 0 Then Return False

        Dim original As Integer = number
        Dim reversed As Integer = 0

        While number > 0
            Dim digit As Integer = number Mod 10
            reversed = reversed * 10 + digit
            number \= 10
        End While

        Return original = reversed
    End Function
End Class
