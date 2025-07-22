<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="Spinutech._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">Test for Spinutech</h1>
            <p class="lead">This test was made by: Eduardo Mariano Tonaco.</p>
            <p><a href="https://www.linkedin.com/in/eduardo-mariano-tonaco-564953220/" class="btn btn-primary btn-md">Linkedin &raquo;</a></p>
        </section>
        <section>
            <div class="collapse navbar-collapse d-sm-inline-flex justify-content-between">
                <ul class="navbar-nav flex-grow-1">
                    <li class="nav-item"><a runat="server" href="~/ExercisesPage/NumberToStringPage">Exercice One - Number To String</a></li>
                    <li class="nav-item"><a runat="server" href="~/ExercisesPage/PokerPage">Exercice Two - Poker Page</a></li>
                    <li class="nav-item"><a runat="server" href="~/ExercisesPage/SpiralNumberPage">Exercice Three - Spiral Number</a></li>
                    <li class="nav-item"><a runat="server" href="~/ExercisesPage/GameOfLifePage">Exercice Four - Game Of Life</a></li>
                    <li class="nav-item"><a runat="server" href="~/ExercisesPage/TemplateEnginePage">Exercice Five - Template Engine</a></li>
                    <li class="nav-item"><a runat="server" href="~/ExercisesPage/PalindromePage">Exercice Six -  Palindrome</a></li>
                </ul>
            </div>
        </section>
    </main>
</asp:Content>
