<%@ Page Title="Game Of Life" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GameOfLifePage.aspx.vb" Inherits="Spinutech.GameOfLifePage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
           <h2 id="title"><%: Title %>.</h2>
        <asp:Label ID="LBL_SetGenaration" runat="server"></asp:Label>
        <asp:Table ID="tblBoard" runat="server" />
        <asp:Button ID="btnNextGen" runat="server" Text="Next Generation" OnClick="btnNextGen_Click" />
        <asp:Panel ID="pnlOutput" runat="server" Visible="false">
            <h3>Current Generation</h3>
            <asp:Literal ID="litCurrentGen" runat="server" />
            <h3>Next Generation</h3>
            <asp:Literal ID="litNextGen" runat="server" />
            <asp:Label ID="lblError" runat="server" ForeColor="Red" EnableViewState="false" />
        </asp:Panel>
    </main>

</asp:Content>
