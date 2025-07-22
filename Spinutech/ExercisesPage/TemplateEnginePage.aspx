<%@ Page Title="Template Engine" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TemplateEnginePage.aspx.vb" Inherits="Spinutech.TemplateEnginePage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        <div>
            <h2>Template:</h2>
            <asp:TextBox ID="TXT_Template" runat="server" TextMode="MultiLine" Rows="5" Columns="50"></asp:TextBox>
            <br />
            <h2>Variables:</h2>
            <asp:TextBox ID="TXT_VarNameOne" runat="server" placeholder="Name"></asp:TextBox>
            <asp:TextBox ID="TXT_VarValueOne" runat="server" placeholder="Value"></asp:TextBox>
            <br />
            <asp:TextBox ID="TXT_VarNameTwo" runat="server" placeholder="Name"></asp:TextBox>
            <asp:TextBox ID="TXT_VarValueTwo" runat="server" placeholder="Value"></asp:TextBox>
            <br />
            <asp:TextBox ID="TXT_VarNameThree" runat="server" placeholder="Name"></asp:TextBox>
            <asp:TextBox ID="TXT_VarValueThree" runat="server" placeholder="Value"></asp:TextBox>
            <br />
            <asp:Button ID="BTN_Generate" runat="server" Text="Generate" />
            <br />
            <h2>Result:</h2>
            <asp:Label ID="LBL_Result" runat="server"></asp:Label>
        </div>
    </main>

</asp:Content>
