<%@ Page Title="" Language="C#" MasterPageFile="~/masterAdmin.Master" AutoEventWireup="true" CodeBehind="adminEmployee.aspx.cs" Inherits="kärnan.adminEmployeee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">

        <div class="sektions-huvud">
        <h3>Hantera användare</h3>
         </div>
        <div class="unit-container">           
        <div class="sektion"> 
            <h3>Hanterings alternativ</h3>
            <p class="mellan-rubrik">Vad vill du göra?</p>
                       <asp:DropDownList ID="drpChoice" runat="server" OnSelectedIndexChanged="drpChoice_SelectedIndexChanged" AutoPostBack="true" CssClass="drop">
                <asp:ListItem Enabled="true" Text="-- Välj alternativ --" Value="-1"></asp:ListItem>
                <asp:ListItem Text="Lägg till" Value="1"></asp:ListItem>
                <asp:ListItem Text="Uppdatera" Value="2"></asp:ListItem>
                <asp:ListItem Text="Radera" Value="3"></asp:ListItem>
               </asp:DropDownList>
            <p class="mellan-rubrik">Välj den admin du vill hantera:</p> 
        <asp:ListBox ID="lsbEmployee" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="lsbEmployee_SelectedIndexChanged"  runat="server" CssClass="journal-list"></asp:ListBox>
           
        </div>

        <div class="sektion">
            <div class="klient-top">
                <h3>Uppgifter för anställd</h3>
            </div>
            <p class="mellan-rubrik">Förnamn: </p>
            <asp:TextBox ID="txbName" runat="server" CssClass="new-name" style="margin-top: 0px; margin-bottom: 0px;"></asp:TextBox>
            <p class="mellan-rubrik">Efternamn: </p>
            <asp:TextBox ID="txbSurname" runat="server" CssClass="new-name" style="margin-top: 0px; margin-bottom: 0px;"></asp:TextBox>
            <p class="mellan-rubrik">Initialer: </p>
            <asp:TextBox ID="txbInitials" runat="server" CssClass="new-name" style="margin-top: 0px; margin-bottom: 0px;"></asp:TextBox>
            <div class="checkbox">
            <asp:CheckBox ID="cbxAdmin" Text =" Utökade admin egenskaper" runat="server" CssClass="mellan-rubrik" />
                </div>
            <div class="unit-buttons-div">
                <asp:Button ID="btnEmptyField" runat="server" OnClick="btnEmptyField_Click" CssClass="unit-buttons" Text="Töm fält" />
                <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" CssClass="unit-buttons" Text="Uppdatera anställd" />
                <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" CssClass="unit-buttons" Text="Lägg till anställd" />
                <asp:Button ID="btnRemove" runat="server" OnClick="btnRemove_Click" CssClass="unit-buttons" Text="Radera anställd" />
            </div>
            <asp:Label ID="lblCorrekt" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblmeddelande" ForeColor="Red" runat="server" Text=""></asp:Label>
        </div>


        <div class="sektion">

        <h3>Användarnamn och lösenord</h3>
        <p class="mellan-rubrik">Användarnamn: </p>
        <asp:TextBox ID="txbAnv" ReadOnly="true" runat="server" style="margin-top: 0px; margin-bottom: 0px;" CssClass="new-name"></asp:TextBox>

        <p class="mellan-rubrik">Lösenord: </p>
        <asp:TextBox ID="txbPass" runat="server" style="margin-top: 0px;margin-bottom: 0px;" CssClass="new-name"></asp:TextBox>
        <p class="mellan-rubrik">Upprepa lösenord: </p>
        <asp:TextBox ID="txbPass2" runat="server" style="margin-top: 0px;margin-bottom: 0px;" CssClass="new-name"></asp:TextBox>
            <div class="unit-buttons-div">
        <asp:Button ID="btnUsername" runat="server" Text="Skapa nytt loggin " CssClass="unit-buttons" OnClick="btnUsername_Click" />
        <asp:Button ID="btnUpdateName" runat="server" CssClass="unit-buttons" Text="Ändra lösenord" OnClick="btnUpdateName_Click" />
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
    font-family: 'Open Sans', sans-serif;
    padding: 0;
    flex-wrap: wrap;
}

.sektion {
    display: flex;
    flex-direction: column;
    padding: 22px;
    background-color: #f6f6f6;
    border: 2px solid #fafafa;
    font-family:'Open Sans', sans-serif;
}

sektion,
h3 {
    margin-bottom: 20px;
}

.sektion:first-of-type {
    flex-grow: 1;
}

.sektion:nth-of-type(2) {
    flex-grow: 1;
}

.sektion:nth-of-type(3) {
    flex-grow: 1;
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
    width:150px;
    border: none;
    padding: 12px 0px 12px 0px;    
    margin-top:10px;
    margin-bottom:20px;
    margin-left:10px;
    background-color: #9b6e71;
    color:white;
    font-size:14px;
    cursor:pointer;
    font-family:'Open Sans', sans-serif;
}

.unit-buttons:hover{
    background-color:#B38184;
}

.new-name {
    height: 41px;
    width:100%;
    margin:0px;
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


.sektions-huvud {
    display: flex;
    flex-direction: row;
    justify-content: center;
    height: 41px;
    padding: 0px 22px;
    background-color: #f6f6f6;
    border: 2px solid #fafafa;
}

.sektions-huvud h3 {
    line-height: 37px;
    font-family: 'Open Sans', sans-serif;
    font-weight: bold;
    margin: 0px;
    text-align: center;
            }

        </style>
</form>


</asp:Content>
