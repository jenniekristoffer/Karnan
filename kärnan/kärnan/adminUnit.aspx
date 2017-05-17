<%@ Page Title="" Language="C#" MasterPageFile="~/masterAdmin.Master" AutoEventWireup="true" CodeBehind="adminUnit.aspx.cs" Inherits="kärnan.adminUnitt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <form runat ="server">

        <div class="unit-container">
        <div class="sektion">
            <h3>Enhets överblick</h3>
            <p class="mellan-rubrik">Samtliga enheter i verksamheten:</p>
            <asp:ListBox ID="lsbAllUnit" runat="server" OnSelectedIndexChanged="lsbAllUnit_SelectedIndexChanged" AutoPostBack="true" CssClass="listbox"></asp:ListBox>    

        </div>
        <div class="sektion">
            <h3>Lägg till ny enhet</h3>
            <div class="sektion-2-topp">
                <p class="mellan-rubrik">Namn på ny enhet: </p>
                <asp:TextBox ID="txbAddUnit" runat="server" CssClass="new-name" style="margin-top: 0px; margin-bottom: 0px;"></asp:TextBox>
                <div class="unit-buttons-div">
                    <asp:Button ID="btnAddUnit" runat="server" OnClick="btnAddUnit_Click" CssClass="unit-buttons" Text="Lägg till enhet" />                    
                </div>
                <asp:Label ID="lblUnitMessage" runat="server" Text=""></asp:Label>
            </div>                
            <h3>Byt namn på enhet</h3>
            <div class="sektion-2-botten">
                <p class="mellan-rubrik">Välj den enhet du vill ändra:</p>
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataTextField="unitname"
                    DataValueField="unitid" AppendDataBoundItems="true" CssClass="drop"
                     OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                    <asp:ListItem Value="0">-- Välj enhet --</asp:ListItem>
                    </asp:DropDownList>

                <p class="mellan-rubrik">Ändra namnet och klicka på spara:</p>
                 <asp:TextBox ID="txbChangeUnit" runat="server" CssClass="new-name" style="margin-top: 0px; margin-bottom: 0px;"></asp:TextBox>
                <div class="unit-buttons-div">
                     <asp:Button ID="btnChangeUnit" OnClick="btnChangeUnit_Click" CssClass="unit-buttons" runat="server" Text="Ändra namn på enhet" />                     
                </div>
                <div class="unit-buttons-div">
                    <asp:Label ID="lblCorrectMessage" runat="server" Text=""></asp:Label>
                    

                </div>
                <p id="message" style="display:none; color:forestgreen;">Nytt namn sparat.</p>
            </div>
        </div>
        <div class="sektion">
            <h3>Tabort enheter</h3>
            <p class="mellan-rubrik">Välj den enhet du vill ta bort:</p>
                  <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" DataTextField="unitname"
       DataValueField="unitid" AppendDataBoundItems="true" CssClass="drop"
        OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
       <asp:ListItem Value="0">-- Välj enhet --</asp:ListItem>
       </asp:DropDownList>
            <div class="unit-buttons-label">
                <asp:Button ID="btnRemove" runat="server" OnClick="btnRemove_Click" CssClass="unit-buttons" Text="Radera enhet" />
            </div>
            <asp:Label ID="lblRemoveUnit" runat="server" Text=""></asp:Label>
        </div>
    </div>
     

         <script>
                   $(document).ready(function () {
                       $(".bok").click(function () {
                           $("#message").fadeIn(2000);
                           $("#message").fadeOut(5000);
                       });
                   });
       </script>


       <style>
.unit-container {
    width: 100%;
    max-width: 100%;
    height: 100%;
    display: flex;
    flex-direction: row;
    font-family: 'Open Sans';
    padding: 0;
    flex-wrap: wrap;
}

.sektion {
    display: flex;
    flex-direction: column;
    padding: 22px;
    background-color: #f6f6f6;
    border: 2px solid #fafafa;
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


/*Unit Admin*/

.unit-buttons-div{
    display: flex;
    flex-direction: row;
    justify-content: flex-end;
}

            .unit-buttons {
                width: 150px;
                height:41px;
                border: 1px solid rgba(64, 64, 64, 0.39);
                margin-top: 20px;
                background-color: #9b6e71;
                color:white;
                font-size:14px;
                cursor:pointer;
                font-family:'Open Sans', sans-serif;
                border:none;
            }

            .unit-buttons:hover{
                    background-color:#B38184;
            }

.new-name {
    height: 41px;
    width: 99%;
}

.sektion-2-topp {
    display: flex;
    flex-direction: column;
    margin-bottom: 50px;
}

.sektion-2-botten {
    display: flex;
    flex-direction: column;
}

.listbox {
    height: 502px;
    width: 100%;
    border: 1px solid grey;
    /*margin-top: 0px;*/
}

       </style>


</form>

</asp:Content>
