<%@ Page Title="" Language="C#" MasterPageFile="~/Master2_Inloggad.Master" AutoEventWireup="true" CodeBehind="inloggad.aspx.cs" Inherits="kärnan.inloggad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">


    <asp:Label ID="lblonline" runat="server" Text=""></asp:Label>
    <asp:Label ID="lblInitials" runat="server" Text=""></asp:Label>



        <div class="val-div">
        <ul>
            <li><a class="val" href="writeJournal.aspx#">Skriv journal</a></li>
            <li><a class="val" href="readJournal.aspx#">Läs journal</a></li>
            <hr>

<<<<<<< HEAD
            <li><a class="val" href="adminPage.aspx#">Hantera enheter & klienter</a></li>
=======
            <li><a class="val" runat="server" id="btnHandel" href="adminPage.aspx#">Hantera enheter & klienter</a></li>
>>>>>>> 9a264fb1a9554b6d4fd040bde4534ad8ba898fd3
        </ul>
    </div>
   
        </form>
</asp:Content>
