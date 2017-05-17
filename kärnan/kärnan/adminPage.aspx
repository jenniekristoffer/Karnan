<%@ Page Title="" Language="C#" MasterPageFile="~/masterAdmin.Master" AutoEventWireup="true" CodeBehind="adminPage.aspx.cs" Inherits="kärnan.adminPag" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">  
   <form runat="server">  

      <div class="val-div">
        <ul>
            <li><a class="val" href="adminWriteJournal.aspx#">Skriv journal</a></li>
            <li><a class="val" href="adminReadJournal.aspx#">Läs journal</a></li>
            <hr>           
            <li><a class="val" href="adminClient.aspx#">Hantera klienter</a></li>
            <li><a class="val" href="adminUnit.aspx#">Hantera enheter</a></li>
            <li><a class="val" href="adminEmployee.aspx#">Hantera admins</a></li>
        </ul>
            <p id="message" style="display:none; color:forestgreen;">Nytt namn sparat.</p>
    </div>
 
       
       
                <style>
            
.val-div {
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    width: 95%;
    margin: auto;
    font-family: 'Open Sans',sans-serif;
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
