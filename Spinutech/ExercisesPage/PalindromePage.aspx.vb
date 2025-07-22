Public Class PalindromePage
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LBL_ButtonTitle.Text = "Verify if is Palindrome"
        End If
    End Sub
    Protected Sub BTN_CheckPalindrome_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            If TXT_Number.Text <> "" AndAlso TXT_Number.Text.Length < 12 Then
                Dim number As Integer = Integer.Parse(TXT_Number.Text)
                Dim palindromeChecker As New PalindromeChecker

                If palindromeChecker.IsPalindrome(number) Then
                    LBL_Result.Text = $"{number} is a palindrome."
                Else
                    LBL_Result.Text = $"{number} is not a palindrome."
                End If
            Else
                LBL_Result.Text = ""
            End If
        Catch ex As Exception
            LBL_Result.Text = ex.Message
        End Try
    End Sub
End Class