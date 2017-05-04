<%@ Page Title="" Language="C#" MasterPageFile="~/Master2_Inloggad.Master" AutoEventWireup="true" CodeBehind="readJournal.aspx.cs" Inherits="kärnan.readJournal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form runat="server">

    <div class="read-container">
        <div class="sektion">
            <h3>Välj enhet och klient</h3>
            <p>Välj enhet:</p>
                    <asp:DropDownList ID="drpUnit" runat="server" AutoPostBack="True" DataTextField="unitname"
                    DataValueField="unitid" AppendDataBoundItems="true" CssClass="drp" 
                    OnSelectedIndexChanged ="drpUnit_SelectedIndexChanged" >
                    <asp:ListItem Value="0">-- Välj enhet --</asp:ListItem>
                </asp:DropDownList>

            <p>Välj klient:</p>
                    <asp:DropDownList ID="drpClient" runat="server" AppendDataBoundItems="true" DataTextField="name" 
                    DataValueField="familyid" AutoPostBack="True" CssClass="drop" 
                    OnSelectedIndexChanged="drpClient_SelectedIndexChanged">
                    <asp:ListItem Value="0">-- Välj namn --</asp:ListItem>
                </asp:DropDownList>
        </div>
        <div class="sektion">
            <div class="sektion-top">
                <h3>Enhet:</h3><asp:Label ID="lblunit" runat="server" Text=""></asp:Label>
                <h3>Klient:</h3> <asp:Label ID="lblclient" runat="server" Text=""></asp:Label>             
            </div>

            <p>Välj journaler efter datum: </p>
            <div class="date">
                <input type="text" class="datepick" id="datepicker" placeholder="Från: ">
                <input type="text" class="datepick" id="datepicker2" placeholder="Till: ">
                <%--<button class="alla-datum datepick">Välj alla datum</button>--%>
                <asp:Button ID="btnShowAll" CssClass ="alla-datum datepick" runat="server" OnClick="btnShowAll_Click" Text="Välj alla datum" />
            </div>
            <asp:Label ID="lblFelmeddelande" ForeColor ="Red" runat="server" Text=""></asp:Label>
            <div class="lista">
                <p>Journaler:</p>
                <%--<input type="text" id="journal-list">--%>
                <asp:ListBox ID="lsbList" AutoPostBack="true" OnSelectedIndexChanged="lsbList_SelectedIndexChanged" runat="server" Height="220px" Width="359px"></asp:ListBox>
                <%--<textarea cols ="45" rows ="15" runat ="server" id="txbList" name="jourlist"></textarea>--%>
            </div>
        </div>

        <div class="sektion">
            <h3>Journal</h3>
            <div class="readjournal">
                <p>Rubrik:</p>
                <%--<input type="text" id="rubrik">--%>
                 <textarea cols ="45" rows ="2" runat ="server" id="txbRubrik" name="jourlista"></textarea>
                <p>Journalanteckning:</p>
                <%--<input type="text" id="journal-anteckning">--%>
                <textarea cols ="45" rows ="10" runat ="server" id="txbJournal" name ="jour"></textarea>
                <asp:Label ID="lblInitialer" runat="server" Text=""></asp:Label>
            </div>
            

        </div>
    </div>

        </form>

    <script>
        $(function() {
            $("#datepicker").datepicker();
        });

        $(function() {
            $("#datepicker2").datepicker();
        });
    </script>


    <footer>
    </footer>

       <style>

.read-container {
    width: 100%;
    max-width: 100%;
    height: 600px;
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
}

.sektion:nth-of-type(2) {
    flex-grow: 2;
    flex-shrink: 1;
}

.sektion:nth-of-type(3) {
    flex-grow: 4;
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

.drop {
    max-width: 250px;
    margin-bottom: 50px;
    background-color: #3E4147;
}

.date {
    display: flex;
    flex-direction: row;
}

#datepicker,
#datepicker2,
.alla-datum {
    max-width: 110px;
}

.datepick:nth-of-type(2) {
    margin-left: 10px;
}

.alla-datum {
    border: 1px solid rgba(64, 64, 64, 0.39);
    padding: 12px 0px 12px 0px;
    margin-left: 10px;
    background-color: #3E4147;
}

#journal-list,
#journal-anteckning {
    height: 400px;
}

       </style>
</asp:Content>
