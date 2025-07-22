Imports Microsoft.Ajax.Utilities
Imports Newtonsoft.Json.Linq

Public Class PokerPage
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            RPT_Cards.DataSource = New Integer() {1, 2, 3, 4, 5}
            RPT_Cards.DataBind()
            LBL_ButtonTitle.Text = "Check Hand"
            BTN_Convert.Text = "Check"
        End If
    End Sub

    Protected Sub rptCartas_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles RPT_Cards.ItemDataBound
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim ddlCard As DropDownList = CType(e.Item.FindControl("DDL_Card"), DropDownList)
            Dim ddlSuit As DropDownList = CType(e.Item.FindControl("DDL_Suit"), DropDownList)

            If ddlCard IsNot Nothing AndAlso ddlSuit IsNot Nothing Then

                Dim cardNumber As Integer = 2
                ddlCard.Items.Add(New ListItem("--Select Card--", -1))
                For Each card As String In New String() {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"} ' fill card, start with 2
                    ddlCard.Items.Add(New ListItem(card, cardNumber))
                    cardNumber += 1
                Next
                ddlSuit.Items.Add(New ListItem("--Select Suit--", -1))
                For Each suit As String In New String() {"Diamonds", "Hearts", "Spades", "Clubs"} ' fill suit
                    ddlSuit.Items.Add(New ListItem(suit, suit.Substring(0, 1)))
                Next
            End If
        End If
    End Sub


    Protected Sub DDL_Changed(sender As Object, e As EventArgs)
        CheckCards()
    End Sub

    Private Sub CheckCards()
        Dim cards As New List(Of String)
        For Each item As RepeaterItem In RPT_Cards.Items
            Dim DDL_Card As DropDownList = CType(item.FindControl("DDL_Card"), DropDownList)
            Dim DDL_Suit As DropDownList = CType(item.FindControl("DDL_Suit"), DropDownList)
            Dim card As String = DDL_Card.SelectedValue & "_" & DDL_Suit.SelectedValue
            If cards.Contains(card) Then
                DDL_Card.SelectedValue = "-1"
                DDL_Suit.SelectedValue = "-1"
            Else
                cards.Add(card)
            End If
        Next
    End Sub
    Protected Sub BTN_CheckHand_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim card As String = ""
            For Each item As RepeaterItem In RPT_Cards.Items
                Dim DDL_Card As DropDownList = CType(item.FindControl("DDL_Card"), DropDownList)
                Dim DDL_Suit As DropDownList = CType(item.FindControl("DDL_Suit"), DropDownList)
                If DDL_Card.SelectedValue = "-1" OrElse DDL_Suit.SelectedValue = "-1" Then
                    LBL_Result.Text = ""
                    Return
                End If
                card += DDL_Card.SelectedItem.Text & DDL_Suit.SelectedValue + " "
            Next
            Dim pokerHandEvaluator As New PokerHandEvaluator
            LBL_Result.Text = pokerHandEvaluator.EvaluateHand(card.Trim())
        Catch ex As Exception
            LBL_Result.Text = ex.Message
        End Try
    End Sub
End Class