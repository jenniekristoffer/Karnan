<%@ Page Title="" Language="C#" MasterPageFile="~/Master2_Inloggad.Master" AutoEventWireup="true" CodeBehind="adminUnit.aspx.cs" Inherits="kärnan.adminUnit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <form runat ="server">

        <div class="unit-container">
        <div class="sektion">
            <h3>Enhets överblick</h3>
            <p class="mellan-rubrik">Samtliga enheter i verksamheten:</p>

            <asp:ListBox ID="ListBox1" runat="server" CssClass="listbox"></asp:ListBox>

            <asp:ListBox ID="lsbAllUnit" OnSelectedIndexChanged="lsbAllUnit_SelectedIndexChanged" runat="server" CssClass="journal-list"></asp:ListBox>

        </div>
        <div class="sektion">
            <h3>Lägg till nya enheter</h3>
            <div class="sektion-2-topp">
                <p class="mellan-rubrik">Namn på ny enhet: </p>
                <asp:TextBox ID="txbAddUnit" runat="server" CssClass="new-name"></asp:TextBox>
                <div class="unit-buttons-div">
                    <asp:Button ID="btnAddUnit" runat="server" OnClick="btnAddUnit_Click" CssClass="unit-buttons" Text="Lägg till enhet" />
                    <asp:Label ID="lblUnitMessage" runat="server" Text=""></asp:Label>
                </div>
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
                 <asp:TextBox ID="txbChangeUnit" runat="server" CssClass="new-name"></asp:TextBox>
                <div class="unit-buttons-div">
                     <asp:Button ID="btnChangeUnit" OnClick="btnChangeUnit_Click" CssClass="bok" runat="server" Text="Ändra namn på enhet" />                     
                </div>
                <div class="unit-buttons-div">
                    <asp:Label ID="lblCorrectMessage" runat="server" Text=""></asp:Label>
                    

                </div>
                <p id="message" style="display:none; color:forestgreen;">Nytt namn sparat.</p>
            </div>
        </div>
        <div class="sektion">
            <h3>Tabort enheter</h3>
            <p class="mellan-rubrik">Välj den enhet du vill tabort:</p>
                  <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" DataTextField="unitname"
       DataValueField="unitid" AppendDataBoundItems="true" CssClass="drop"
       OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
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


/*Unit Admin*/

.unit-buttons-div{
    display: flex;
    flex-direction: row;
    justify-content: flex-end;
}

.unit-buttons-label-div{
    display: flex;
    flex-direction: column;
    justify-content: flex-start;
}

.unit-buttons {
    width:150px;
    border: 1px solid rgba(64, 64, 64, 0.39);
    padding: 12px 0px 12px 0px;
    background-color: #cecece;
    margin-top:10px;
    margin-bottom:20px;
}

.new-name {
    height: 37px;
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
