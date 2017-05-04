<%@ Page Title="" Language="C#" MasterPageFile="~/Master2_Inloggad.Master" AutoEventWireup="true" CodeBehind="adminPage.aspx.cs" Inherits="kärnan.adminPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <form runat="server">
    <asp:Button ID="btnUnit" OnClick="btnUnit_Click" runat="server" Text="Hantera enhet" />
    <asp:Button ID="btnFamily" OnClick="btnFamily_Click" runat="server" Text="Hantera familj" />
    <asp:Button ID="btnEmployee" OnClick="btnEmployee_Click" runat="server" Text="Hantera personal" />
 </form>
</asp:Content>
