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

    <%-- Ta bort anställd --%>
   <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" AppendDataBoundItems="true" CssClass="drp"
      OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" > <asp:ListItem Value="0">-- Radera anställd --</asp:ListItem>
   </asp:DropDownList>

    <asp:Button ID="btnRemoveEmployee" runat="server" Text="Radera" OnClick="btnRemoveEmployee_Click" />
    <%-- SLUT --%>

    <%-- Uppdatera anställd --%>
   <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" AppendDataBoundItems="true" CssClass="drp"
        OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" > <asp:ListItem Value="0">-- Uppdatera anställd --</asp:ListItem>
   </asp:DropDownList>
        <p>Förnamn</p>
        <asp:TextBox ID="txbUpdateName" runat="server"></asp:TextBox>
        <p>Efternamn</p>
        <asp:TextBox ID="txbUpdateSurname" runat="server"></asp:TextBox>
        <p>Initialer</p>
        <asp:TextBox ID="txbUpdateInitials" runat="server"></asp:TextBox>
        <asp:CheckBox ID="cbxUpdateAdmin" Text ="Adminegenskap" runat="server" />

   <asp:Button ID="btnUpdateEmployee" runat="server" Text="Uppdatera anställd" OnClick="btnUpdateEmployee_Click" />
    <%-- SLUT --%>


</form>
</asp:Content>
