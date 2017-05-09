﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master2_Inloggad.Master" AutoEventWireup="true" CodeBehind="adminEmployee.aspx.cs" Inherits="kärnan.adminEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">

   
    <asp:Button ID="btnAddEmployee" OnClick="btnAddEmployee_Click" runat="server" Text="Spara ny anställd" />


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




            <div class="unit-container">
        <div class="sektion">
            <h3>Hanterings alternativ</h3>
            <p class="mellan-rubrik">Vad vill du göra?</p>
            <asp:DropDownList ID="DropDownList3" runat="server" CssClass="drop"></asp:DropDownList>
            <p class="mellan-rubrik">Välj den admin du vill hantera</p>
            <asp:ListBox ID="ListBox1" runat="server" CssClass="journal-list"></asp:ListBox>
        </div>

        <div class="sektion">
            <div class="klient-top">
                <h3>Uppgifter för klient</h3>
            </div>
            <p class="mellan-rubrik">Förnamn: </p>
            <asp:TextBox ID="txbName" runat="server" CssClass="new-name"></asp:TextBox>
            <p class="mellan-rubrik">Efternamn: </p>
            <asp:TextBox ID="txbSurname" runat="server" CssClass="new-name"></asp:TextBox>
            <p class="mellan-rubrik">Initialer: </p>
            <asp:TextBox ID="txbInitials" runat="server" CssClass="new-name"></asp:TextBox>
            <div class="checkbox">
            <asp:CheckBox ID="cbxAdmin" Text ="Utökade admin egenskaper" runat="server" CssClass="mellan-rubrik" />
                </div>
            <div class="unit-buttons-div">
                <button class="unit-buttons">Töm fält</button>
                <button class="unit-buttons">Lägg till admin</button>
                <button class="unit-buttons">Spara ändringar</button>
                <button class="unit-buttons">Radera admin</button>
            </div>
        </div>
    </div>


        <style>

.unit-container {
    width: 100%;
    max-width: 100%;
    height: 100%;
    display: flex;
    flex-direction: row;
    font-family: Roboto;
    padding: 0;
    flex-wrap: wrap;
}

.sektion {
    display: flex;
    flex-direction: column;
    padding: 22px;
    background-color: #FFFEDF;
}

sektion,
h3 {
    margin-bottom: 20px;
}

.sektion:first-of-type {
    flex-grow: 1;
    border: 1px solid rgba(60, 60, 60, 0.49);
}

.sektion:nth-of-type(2) {
    flex-grow: 1;
    border: 1px solid rgba(60, 60, 60, 0.49);
}

.sektion:nth-of-type(3) {
    flex-grow: 1;
    border: 1px solid rgba(60, 60, 60, 0.49);
}

.sektion-top {
    display: flex;
    flex-direction: row;
}

.sektion-top h3 {
    display: flex;
    flex-direction: row;
    padding-right: 30px;
}

#datepicker {
    width: 150px;
}

.alla-datum {
    border: 1px solid rgba(64, 64, 64, 0.39);
    padding: 12px 0px 12px 0px;
    margin-left: 10px;
    background-color: #cecece;
}

.journal-list {
    height: 500px;
    width: 100%;
}

.beskrivning {
    display: flex;
    flex-direction: row;
    width: 100%;
    justify-content: space-between;
}

#txb-beskrivning {
    width: 100%;
    height: 37px;
    margin-right: 25px;
}

.mellan-rubrik {
    margin-bottom: 5px;
    margin-top: 10px;
}

.drop {
    height: 41px;
    width: 100%;
}


/*Unit Admin*/

.unit-buttons-div {
    display: flex;
    flex-direction: row;
    justify-content: flex-end;
    flex-wrap: wrap;
}

.unit-buttons {
    width: 150px;
    border: 1px solid rgba(64, 64, 64, 0.39);
    padding: 12px 0px 12px 0px;
    background-color: #cecece;
    margin-top: 20px;
    margin-left: 10px;
}

.new-name {
    height: 37px;
    max-width: 99.5%;
}

.sektion-topp {
    display: flex;
    flex-direction: column;
    margin-bottom: 50px;
}

.sektion-botten {
    display: flex;
    flex-direction: column;
}

.klient-top {
    display: flex;
    justify-content: flex-start;
    flex-direction: row;
}

.checkbox{
    display:flex;
    justify-content:flex-start;
    flex-direction:row;
    margin-top:10px;
}

        </style>




=======
>>>>>>> 9a264fb1a9554b6d4fd040bde4534ad8ba898fd3
</form>
</asp:Content>
