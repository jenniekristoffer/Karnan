<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="journal.aspx.cs" Inherits="kärnan.journal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="stylesheet.css"/> 

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">     
 
       <div class ="conteiner">
  
           <%-- Vänster column - Välj familj och enhet --%>
        <div class="vColumn">
        <h4>Skriv journaler</h4>
        <p>&nbsp;</p><%-- mellanrum--%>
        <p>&nbsp;</p> <%-- mellanrum--%>
         
         <div class ="drp">
            <p class ="txbUnit">Välj enhet</p>
             <asp:DropDownList ID="drpEnhet" CssClass="dropdown" runat="server" OnSelectedIndexChanged="drpEnhet_SelectedIndexChanged"></asp:DropDownList>
         <br /> 
             <p>&nbsp;</p><%-- mellanrum--%>
             <p>&nbsp;</p> <%-- mellanrum--%>
            <p> Välj klient</p>
        <asp:DropDownList ID="drpKlient" CssClass="dropdown" runat="server" OnSelectedIndexChanged="drpKlient_SelectedIndexChanged"></asp:DropDownList>
    </div>
</div>
         <%-- Höger column - Skriv journal --%>
     <div class ="rColumn">      
    
      
        <div class="label1"><p>Enhet: <asp:Label ID="lblEnhet" runat="server" Text="Enhet"></asp:Label></p></div>
        <div class="label"><p>Klient: <asp:Label ID="lblKlient" runat="server" Text="Klient"></asp:Label></p></div>     
       
         <p>&nbsp;</p> <%-- mellanrum--%>
         <p>&nbsp;</p> <%-- mellanrum--%>
         
        
         <p>Beskrivning</p> 
         <div class ="beskriv">
         <asp:TextBox ID="txbBeksrivning" runat="server"></asp:TextBox>
         </div>
      
         <p>Journal</p> 
         <div class ="journ">
         <asp:TextBox ID="txbJournal" runat="server" Height="271px" Width="376px"></asp:TextBox>
         </div>

         <div class ="date">
         <p>Datum</p>
         <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar> 
         </div>

         <asp:Button ID="btnAvbry" runat="server" Text="Avbryt" />
         <asp:Button ID="btnSpara" runat="server" Text="Spara" />
     </div>
           

<style type="text/css">

.dropdown{
    background-color: #E6E6D9;
    padding: 13px;
    font-size: 16px;
    border-radius:5px;
    margin-bottom:20px;
    box-shadow: 0px 4px 8px 0px rgba(0,0,0,0.2);    
    position: relative;
    display: inline-block;
    top: 5px;
    left: 6px;
    width: 130px;
    }

.dropdown:hover{
    background-color: #DBDBC9;
    display: inline-block;
}

.vColumn{
    border-right: 3px solid #22383c;
    width: 20%;
    margin:10px;
    float: left;
}

.rColumn{
    float: left;
}
.label{
    float: left;
}

.label1{
    float: right;
}

.date{
   float: left;
}

.beskriv{
    width: 70%;
    padding: 5px 5px;
    margin: 8px 0;
    box-sizing: border-box;
}

.jour{
    width: 70%;
    padding: 120px 5px;
    margin: 8px 0;
    box-sizing: border-box;
}

</style>
</div> 
</asp:Content>
