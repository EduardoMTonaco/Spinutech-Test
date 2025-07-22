<%@ Page Title="Palindrome" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PalindromePage.aspx.vb" Inherits="Spinutech.PalindromePage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        <table>
            <tr>
                <td>
                    <asp:Label ID="LBL_Number" runat="server">Number</asp:Label></td>
                <td>
                    <asp:TextBox ID="TXT_Number" runat="server" AutoPostBack="False" AutoCompleteType="Disabled" Width="150px" MaxLength="12" onkeypress="mask(this, justNumbers)" placeholder="Number"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LBL_ButtonTitle" runat="server"></asp:Label></td>
                <td>
                    <asp:Button ID="BTN_CheckPalindrome" runat="server" AutoPostBack="False" Text="Check" Width="80px" OnClick="BTN_CheckPalindrome_Click" />
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
