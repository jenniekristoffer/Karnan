<%@ Page Title="" Language="C#" MasterPageFile="~/Master2_Inloggad.Master" AutoEventWireup="true" CodeBehind="writeJournal.aspx.cs" Inherits="kärnan.writeJournal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<<<<<<< HEAD

=======
    <div class="conteiner">
>>>>>>> 8549ac42b013d589a4bf9fe239bce8b969c63600
        <form runat="server">

                <!--Här börjar writejournal-->


                <div class="write-container">
        <div class="sektion">
            <h3>Välj enhet och klient</h3>
            <p class="mellan-rubrik">Välj enhet:</p>
            <%--<button class="drop">"enhet"</button>--%>
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataTextField="unitname"
                    DataValueField="unitid" AppendDataBoundItems="true" CssClass="drop"
                    OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                    <asp:ListItem Value="0">-- Välj enhet --</asp:ListItem>
                </asp:DropDownList>
            <!--byt ut dessa mot drop down med samma namn i cssclass-->
            <p class="mellan-rubrik">Välj klient:</p>
<%--            <button class="drop">"klient"</button>--%>
                    <asp:DropDownList ID="DropDownList2" runat="server" AppendDataBoundItems="true" DataTextField="name" 
                    DataValueField="familyid" AutoPostBack="True" CssClass="drop"
                    OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                    <asp:ListItem Value="0">-- Välj namn --</asp:ListItem>
                </asp:DropDownList>
            <!--byt ut dessa mot drop down med samma namn i cssclass-->
        </div>
        <div class="sektion">
            <div class="sektion-top">
                <h3>Enhet:</h3>
                <asp:Label ID="lblEnhet" runat="server" Text=""></asp:Label>
                <!--här ska det finnas en label efter h3-->
                <h3>Klient:</h3>
                <asp:Label ID="lblKlient" runat="server" Text=""></asp:Label>
                <!--här ska det finnas en label efter h3-->
                <h3>Person-nr:</h3>
                <asp:Label ID="lblPnr" runat="server" Text=""></asp:Label>
            </div>
            <p class="mellan-rubrik">Beskrivning:</p>
            <div class="beskrivning">
                <%--<input type="text" id="txb-beskrivning">--%>
                <textarea cols ="45" rows ="2" runat ="server" id="txbincident" name="inci" class="txb-beskrivning"></textarea>
                <input type="text" class="datepick" id="datepicker" placeholder="Datum: "/>
            </div>
            <div class="lista">
                <p class="mellan-rubrik">Journaler:</p>
                <%--<input type="text" id="journal-list">--%>
                <textarea cols ="45" rows ="10" runat ="server" id="txbJournal" name ="jour" class="journal-list"></textarea>
            </div>
            <div class="knappar">
                <asp:Button ID="Button1" OnClick="btnAvbry_Click" runat="server" CssClass="write-buttons" Text="Avbryt" />
                <asp:Button ID="Button2" OnClick="btnSpara_Click" runat="server" CssClass="write-buttons" Text="Spara" />
            </div>
<%--            <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>--%>
            <asp:Label ID="lblInitials" runat="server" Text=""></asp:Label>

            <asp:Label ID="lblMeddelande" runat="server" Text=""></asp:Label>

            <asp:Label ID="lblBeskrivning" ForeColor ="Red" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblJournal" ForeColor="Red" runat="server" Text=""></asp:Label>

        </div>
    </div>
    </form>


    </form>



    <style type="text/css">

        /* Read Journal */

.write-container {
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
    flex-grow: 4;
    flex-shrink: 1;
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

.datepick {
    width: 150px;
    height: 37px;
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

.txb-beskrivning {
    width: 100%;
    height: 39px;
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

textarea{
    resize: none;
}

.knappar{
    display:flex;
    flex-direction:row;
    justify-content:flex-end;
}

.write-buttons {
    width:100px;
    border: 1px solid rgba(64, 64, 64, 0.39);
    padding: 12px 0px 12px 0px;
    background-color: #cecece;
    margin-top:10px;
    margin-bottom:20px;
}

.write-buttons:nth-of-type(2) {
margin-left:20px;
}

</style>


</asp:Content>





