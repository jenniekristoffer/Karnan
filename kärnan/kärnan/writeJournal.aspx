<%@ Page Title="" Language="C#" MasterPageFile="~/Master2_Inloggad.Master" AutoEventWireup="true" CodeBehind="writeJournal.aspx.cs" Inherits="kärnan.writeJournal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<%--        <form runat="server">--%>
             <div class="sektions-huvud">
              <h3 style="margin:0px;">Skriv journal</h3>
            </div>
                <div class="write-container">
        <div class="sektion">
            <h3>Välj enhet och klient</h3>
            <p class="mellan-rubrik">Välj enhet:</p>
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataTextField="unitname"
                    DataValueField="unitid" AppendDataBoundItems="true" CssClass="drop"
                    OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                    <asp:ListItem Value="0">-- Välj enhet --</asp:ListItem>
                </asp:DropDownList>
            <p class="mellan-rubrik">Välj klient:</p>
                    <asp:DropDownList ID="DropDownList2" runat="server" AppendDataBoundItems="true" DataTextField="name" 
                    DataValueField="familyid" AutoPostBack="True" CssClass="drop"
                    OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                    <asp:ListItem Value="0">-- Välj namn --</asp:ListItem>
                </asp:DropDownList>
        </div>
        <div class="sektion">
            <div class="sektion-top">
                <h3>Enhet:</h3>
                <asp:Label ID="lblEnhet" runat="server" Text="" CssClass="label"></asp:Label>
                <h3>Klient:</h3>
                <asp:Label ID="lblKlient" runat="server" Text="" CssClass="label"></asp:Label>             
            </div>
            <p class="mellan-rubrik">Beskrivning:</p>
            <div class="beskrivning">
                <textarea cols ="45" rows ="2" runat ="server" id="txbincident" name="inci" class="txb-beskrivning"></textarea>
                <input type="text" class="datepick" name="datepicker" id="datepicker" placeholder="Datum: " style="margin-top: 0px; margin-bottom: 0px;"/>
            </div>
            <div class="lista">
                <p class="mellan-rubrik">Journal:</p>
                <textarea cols ="45" rows ="10" runat ="server" id="txbJournal" name ="jour" class="journal-list"></textarea>
            </div>
            <div class="knappar-div">
                <asp:Button ID="Button2" OnClick="btnSpara_Click" runat="server" CssClass="write-buttons" Text="Spara" />
            </div>
            <asp:Label ID="lblInitials" runat="server" Text=""></asp:Label>

            <asp:Label ID="lblMeddelande" runat="server" Text=""></asp:Label>

            <asp:Label ID="lblBeskrivning" ForeColor ="Red" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblJournal" ForeColor="Red" runat="server" Text=""></asp:Label>
            <p id ="date"></p>

        </div>
    </div>
<%--    </form>--%>

    <%-- Visa datum i datepicker --%>
<script type="text/javascript">
    n = new Date();
    y = n.getFullYear();
    m = n.getMonth() + 1;
    d = n.getDate();
    document.getElementById('datepicker').value = "0" + m + "/" + d + "/" + y;
</script>


<style type="text/css">

.write-container {
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
    flex-grow: 4;
    flex-shrink: 1;
}

.sektion-top {
    display: flex;
    flex-direction: row;
}

.sektion-top h3 {
    display: flex;
    flex-direction: row;
    padding-right: 10px;
}

.datepick {
    width: 150px;
    height: 41px;
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
    height: 41px;
    margin-right: 25px;
}

.mellan-rubrik {
    margin-bottom: 5px;
    margin-top: 10px;
}

.drop {
    height: 41px;
    width: 100%;
    cursor:pointer;
}

textarea{
    resize: none;
}

.knappar-div{
    display:flex;
    flex-direction:row;
    justify-content:flex-end;
}

.write-buttons {
    width:150px;
    border: none;
    padding: 12px 0px 12px 0px;    
    margin-top:10px;
    margin-bottom:20px;
    background-color: #9b6e71;
    color:white;
    font-size:14px;
    cursor:pointer;
    font-family:'Open Sans', sans-serif;
}

.write-buttons:hover{
    background-color:#B38184;
}
    
.write-buttons:nth-of-type(2) {
margin-left:20px;
}

.label{
    font-family:inherit;
    font-size:18.72px;
    color:cyan;
    margin-right:15px;
    margin-bottom: 20px;
    color:black;
}

.sektions-huvud{
    display:flex;
    flex-direction:row;
    justify-content:center;
    height:41px;
    padding:0px 22px;
    background-color: #f6f6f6;
    border: 2px solid #fafafa;
}

.sektions-huvud h3{
    line-height:37px;
    font-family:'Open Sans', sans-serif;
    font-weight:bold;
    margin:0px;
    text-align:center;
}


</style>


</asp:Content>





