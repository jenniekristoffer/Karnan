<%@ Page Title="" Language="C#" MasterPageFile="~/Master2_Inloggad.Master" AutoEventWireup="true" CodeBehind="adminUnit.aspx.cs" Inherits="kärnan.adminUnit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <form runat ="server">

    <%-- Lägg till ny enhet --%>
    <asp:Label ID="lblUnitAdd" runat="server" Text="Lägg till enhet"></asp:Label>
    <asp:TextBox ID="txbAddUnit" runat="server"></asp:TextBox>
    <asp:Button ID="btnAddUnit" runat="server" OnClick="btnAddUnit_Click" Text="Lägg till " />
    <asp:Label ID="lblUnitMessage" runat="server" Text=""></asp:Label>
    <%-- SLUT --%>

       <%-- Ändra namn på befintligt enhet --%>
       <asp:Label ID="lblChangeUnit" runat="server" Text="Välj enhet du vill ändra namnet på"></asp:Label>

      <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataTextField="unitname"
       DataValueField="unitid" AppendDataBoundItems="true" CssClass="drp"
       OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
       <asp:ListItem Value="0">-- Välj enhet --</asp:ListItem>
       </asp:DropDownList>

       <asp:TextBox ID="txbChangeUnit" runat="server"></asp:TextBox>
       <asp:Button ID="btnChangeUnit" OnClick="btnChangeUnit_Click" runat="server" Text="Ändra namn på unit" />
       <asp:Label ID="lblCorrectMessage" runat="server" Text=""></asp:Label>
       <%-- SLUT --%>

       <%-- Radera enhet --%>
       <asp:Label ID="lblRemove" runat="server" Text="Välj enhet du vill ta bort och tryck på knappen 'Radera enhet'"></asp:Label>
      <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" DataTextField="unitname"
       DataValueField="unitid" AppendDataBoundItems="true" CssClass="drp"
       OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
       <asp:ListItem Value="0">-- Välj enhet --</asp:ListItem>
       </asp:DropDownList>

       <asp:Button ID="btnRemove" runat="server" OnClick="btnRemove_Click" Text="Radera enhet" />
       <%-- SLUT --%>


</form>

</asp:Content>
