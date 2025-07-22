Public Class NumberToString

    Function ConvertAmountToString(number As Decimal) As String
        Dim wholeNumbers As Long = Math.Floor(number)
        Dim decimalNumbers As Integer = CInt((number - wholeNumbers) * 100)

        Dim wholeNumbersWords As String = ConvertNumberToString(wholeNumbers)
        Dim decimalWords As String = decimalNumbers.ToString("00")
        Dim finalNumber = $"{wholeNumbersWords}"
        If decimalWords <> "00" Then
            finalNumber = finalNumber + $" and {decimalWords}/100"
        End If

        Return finalNumber + " dollars"
    End Function
    Function ConvertNumberToString(number As Long) As String
        If number = 0 Then Return "Zero"

        Dim unitsMap() As String = {"Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten",
                                    "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"} ' Map zero to Nineteen 
        Dim tensMap() As String = {"Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"} ' Map tens

        Dim parts As New List(Of String)()

        If number >= 1_000_000_000 Then
            parts.Add($"{ConvertNumberToString(number \ 1_000_000_000)} billion") ' Add billion using this same method
            number = number Mod 1_000_000_000 ' remainder of division
        End If

        If number >= 1_000_000 Then
            parts.Add($"{ConvertNumberToString(number \ 1_000_000)} million")  ' Add million using this same method
            number = number Mod 1_000_000 ' remainder of division
        End If

        If number >= 1_000 Then
            parts.Add($"{ConvertNumberToString(number \ 1_000)} thousand") ' Add thousand using this same method
            number = number Mod 1_000 ' remainder of division
        End If

        If number >= 100 Then
            parts.Add($"{ConvertNumberToString(number \ 100)} hundred") ' Add hundred using this same method
            number = number Mod 100 ' remainder of division
        End If

        If number > 0 Then
            If number < 20 Then ' numbers betwen 0 and 19
                parts.Add(unitsMap(number))
            Else ' numbers betwen 20 and 99
                Dim tens = tensMap(number \ 10)
                Dim units = number Mod 10
                If units > 0 Then
                    parts.Add($"{tens}-{unitsMap(units).ToLower()}")
                Else
                    parts.Add(tens)
                End If
            End If
        End If

        Return String.Join(" ", parts).Trim().Replace("  ", " ")
    End Function
End Class
