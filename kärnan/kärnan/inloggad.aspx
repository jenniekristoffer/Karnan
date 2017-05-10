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
            <li><a class="val" href="adminFamily.aspx#">Hantera klienter</a></li>
            <li><a class="val" href="adminUnit.aspx#">Hantera enheter</a></li>
            <li><a class="val" href="adminEmployee.aspx#">Hantera admins</a></li>
            <li><a class="val" href="#"> admins</a></li>
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


        </form>
</asp:Content>
