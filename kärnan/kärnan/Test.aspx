<%@ Page Title="" Language="C#" MasterPageFile="~/Master2_Inloggad.Master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="kärnan.Test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form1" runat="server">
     
   <p> användarnamn</p>
<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <p>Lösenord</p>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>

    <asp:Button ID="Button1" OnClick="Button1_Click" runat="server" Text="Button" />

</form>

</asp:Content>
