<%@ Page Title="PokerPage" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PokerPage.aspx.vb" Inherits="Spinutech.PokerPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        <asp:Repeater ID="RPT_Cards" runat="server">
            <ItemTemplate>
                <asp:DropDownList ID="DDL_Card" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDL_Changed"></asp:DropDownList>
                <asp:DropDownList ID="DDL_Suit" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDL_Changed"></asp:DropDownList>
                <br />
            </ItemTemplate>
        </asp:Repeater>
        <table>
            <tr>
                <td>
                    <asp:Label ID="LBL_ButtonTitle" runat="server"></asp:Label></td>
                <td>
                    <asp:Button ID="BTN_Convert" runat="server" AutoPostBack="False" Text="" Width="80px" OnClick="BTN_CheckHand_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="LBL_Result" runat="server" AutoPostBack="False"></asp:Label>
                </td>
            </tr>
        </table>

    </main>

</asp:Content>
