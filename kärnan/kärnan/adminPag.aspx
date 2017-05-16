<%@ Page Title="" Language="C#" MasterPageFile="~/masterAdmin.Master" AutoEventWireup="true" CodeBehind="adminPag.aspx.cs" Inherits="kärnan.adminPag" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="val-div">
        <ul>
            <li><a class="val" href="writeJournal.aspx#">Skriv journal</a></li>
            <li><a class="val" href="readJournal.aspx#">Läs journal</a></li>
            <hr>           
            <li><a class="val" href="adminClient.aspx#">Hantera klienter</a></li>
            <li><a class="val" href="adminUnit.aspx#">Hantera enheter</a></li>
            <li><a class="val" href="adminEmployee.aspx#">Hantera admins</a></li>
        </ul>
            <p id="message" style="display:none; color:forestgreen;">Nytt namn sparat.</p>
    </div>
   

               <script>
           $(document).ready(function () {
               $(".val").click(function () {
                   $("#message").fadeIn(2000);
                   $("#message").fadeOut(5000);
               });
           });
       </script>
</asp:Content>
