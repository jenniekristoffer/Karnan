<%@ Page Title="" Language="C#" MasterPageFile="~/Master2_Inloggad.Master" AutoEventWireup="true" CodeBehind="inloggad.aspx.cs" Inherits="kärnan.inloggad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">

        <div class="val-div">
        <ul>
            <li><a class="val" href="writeJournal.aspx#">Skriv journal</a></li>
            <li><a class="val" href="readJournal.aspx#">Läs journal</a></li>
            <hr>
            <li><a class="val" href="adminPage.aspx#">Hantera enheter & klienter</a></li>
        </ul>
    </div>
   
        </form>
</asp:Content>
