<%@ Page Title="Number To Words " Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NumberToStringPage.aspx.vb" Inherits="Spinutech.NumberToStringPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        <table>
            <tr>
                <td>
                    <asp:Label ID="LBL_Number" runat="server">Number</asp:Label></td>
                <td>
                    <asp:TextBox ID="TXT_Number" runat="server" AutoCompleteType="Disabled" AutoPostBack="False" Width="150px" MaxLength="11" onkeypress="mask(this, justNumbersWithDecimal)" placeholder="Number"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LBL_ButtonTitle" runat="server"></asp:Label></td>
                <td>
                    <asp:Button ID="BTN_Convert" runat="server" AutoPostBack="False" Text="Convert" Width="80px" OnClick="BTN_Convert_Click" />
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


