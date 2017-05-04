<%@ Page Title="" Language="C#" MasterPageFile="~/Master2_Inloggad.Master" AutoEventWireup="true" CodeBehind="adminFamily.aspx.cs" Inherits="kärnan.adminFamily" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <form runat="server">
     <%-- ÖVERBLICK på familj --%>
     <asp:ListBox ID="lsbFamily" runat="server"></asp:ListBox>
     <%-- SLUT --%>

     <%-- Lägg till information om familj --%>
     <p>Namn</p>
     <asp:TextBox ID="txbName" runat="server"></asp:TextBox>
     <p>Efternamn</p>
     <asp:TextBox ID="txbSurname" runat="server"></asp:TextBox>
     <p>Personnummer</p>
     <asp:TextBox ID="txbBirth" runat="server"></asp:TextBox>

      <asp:DropDownList ID="drpUnit" runat="server" AutoPostBack="True" DataTextField="unitname"
       DataValueField="unitid" AppendDataBoundItems="true" CssClass="drp"
       OnSelectedIndexChanged="drpUnit_SelectedIndexChanged" >
      <asp:ListItem Value="0">-- Välj enhet --</asp:ListItem>
      </asp:DropDownList>

     <asp:Button ID="btnAddFamily" OnClick="btnAddFamily_Click" runat="server" Text="Lägg till ny familjemedlem" />
     <%-- SLUT --%>

      <%-- Uppdatera information om familj --%>

     <asp:ListBox ID="ListBox1" AutoPostBack="true" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" runat="server" ></asp:ListBox>
      <p>Namn</p>
     <asp:TextBox ID="txbUpdateName" runat="server"></asp:TextBox>
      <p>Efternamn</p>
     <asp:TextBox ID="txbUpdateSurname" runat="server"></asp:TextBox>
     <p>Personnummer</p>
     <asp:TextBox ID="txbUpdateBirth" runat="server"></asp:TextBox>
     
     <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataTextField="unitname"
       DataValueField="unitid" AppendDataBoundItems="true" CssClass="drp"
       OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" >
      <asp:ListItem Value="0">-- Välj enhet --</asp:ListItem>
      </asp:DropDownList>

     <asp:Button ID="btnUpdateFamily" OnClick="btnUpdateFamily_Click" runat="server" Text="Uppdatera familj" />
      <%-- SLUT --%>

      <%-- Radera information om familj --%>
       <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" AppendDataBoundItems="true" CssClass="drp"
        OnSelectedIndexChanged ="DropDownList2_SelectedIndexChanged" >
       <asp:ListItem Value="0">-- Välj enhet --</asp:ListItem>
      </asp:DropDownList>
     <asp:Button ID="btnRemoveFamily" runat="server" OnClick="btnRemoveFamily_Click" Text="Radera familj" />
     <%-- SLUT --%>
 </form>
</asp:Content>
