<%@ Page Title="" Language="C#" MasterPageFile="~/Master2_Inloggad.Master" AutoEventWireup="true" CodeBehind="adminEmployee.aspx.cs" Inherits="kärnan.adminEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">

    <%-- Lägg till anställd --%>
        <p>Förnamn</p>
    <asp:TextBox ID="txbName" runat="server"></asp:TextBox>
        <p>Efternamn</p>
    <asp:TextBox ID="txbSurname" runat="server"></asp:TextBox>
        <p>Initialer</p>
    <asp:TextBox ID="txbInitials" runat="server"></asp:TextBox>
    <asp:CheckBox ID="cbxAdmin" Text ="Adminegenskaper" runat="server" />

    <asp:Button ID="btnAddEmployee" OnClick="btnAddEmployee_Click" runat="server" Text="Spara ny anställd" />

    <%-- SLUT --%>

<%--          <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataTextField="unitname"
       DataValueField="unitid" AppendDataBoundItems="true" CssClass="drp"
       OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
       <asp:ListItem Value="0">-- Välj enhet --</asp:ListItem>
       </asp:DropDownList>--%>


</form>
</asp:Content>
