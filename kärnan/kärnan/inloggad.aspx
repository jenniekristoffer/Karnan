﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master2_Inloggad.Master" AutoEventWireup="true" CodeBehind="inloggad.aspx.cs" Inherits="kärnan.inloggad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:Label ID="lblonline" runat="server" Text=""></asp:Label>
    <asp:Label ID="lblInitials" runat="server" Text=""></asp:Label>

        <div class="val-div">
        <ul>            
                        
            <asp:Button ID="btnSkriv" CssClass="val" runat="server" OnClick="btnSkriv_Click" Text="Skriv journal" />
            <asp:Button ID="btnLäs" runat="server" CssClass="val" OnClick="btnLäs_Click" Text="Läs journal" />
              
        </ul>
        <hr /> 
          <asp:Button ID="btnHantera" CssClass="val" runat="server" OnClick="btnHantera_Click" Text="Hantera enheter & klienter" />
   
             </div>
</asp:Content>
