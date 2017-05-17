<%@ Page Title="" Language="C#" MasterPageFile="~/Master2_Inloggad.Master" AutoEventWireup="true" CodeBehind="inloggad.aspx.cs" Inherits="kärnan.inloggad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">

        <div class="val-div">
        <ul>
            <li><a class="val" href="writeJournal.aspx#">Skriv journal</a></li>
            <li><a class="val" href="readJournal.aspx#">Läs journal</a></li>

        </ul>
    </div>

        <style>
            
.val-div {    
    display: flex;
    flex-direction: column;
    justify-content: flex-start;
    width: 95%;
    margin: auto;
    font-family: 'Open Sans', sans-serif;
    margin-top:40px;
}

.val-div ul {
    display: flex;
    flex-direction: column;
    list-style: none;
    align-items: center;
}

.val{
    text-align:center;
    display:block;
    background-color: #F7E4BE;
    width: 350px;
    height: 41px;
    margin: 5px 10px;
    padding: 0;
    line-height: 41px;
    border: none;
    text-decoration:none;
    color:black;
}

.val:hover {
background-color: #B38184;
}

hr {
    width: 5%;
    margin: auto;
    margin: 5px 0px;
    height: 1px;
    background-color: grey;
    opacity: 0.5;
}

hr.vertical {
    width: 0px;
    height: 100%;
    /* or height in PX */
}


        </style>
       
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
