<%@ Page Title="" Language="C#" MasterPageFile="~/Master2_Inloggad.Master" AutoEventWireup="true" CodeBehind="readJournal.aspx.cs" Inherits="kärnan.readJournal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form runat="server">

    <script>
                $(function () {
                    $("#datepicker").datepicker();
                });

                $(function () {
                    $("#datepicker2").datepicker();
                });
    </script>


    <div class="read-container">
        <div class="sektion">
            <h3>Välj enhet och klient</h3>
<<<<<<< HEAD
            <p class="mellan-rubrik-top">Välj enhet:</p>
                    <asp:DropDownList ID="drpUnit" runat="server" AutoPostBack="True" DataTextField="unitname"
                    DataValueField="unitid" AppendDataBoundItems="true" CssClass="drop" 
=======
            <p>Välj enhet:</p>
                    <asp:DropDownList ID="drpUnit" runat="server" AutoPostBack="True" DataTextField="unitname"
                    DataValueField="unitid" AppendDataBoundItems="true" CssClass="drp" 
>>>>>>> 8549ac42b013d589a4bf9fe239bce8b969c63600
                    OnSelectedIndexChanged ="drpUnit_SelectedIndexChanged" >
                    <asp:ListItem Value="0">-- Välj enhet --</asp:ListItem>
                </asp:DropDownList>

            <p class="mellan-rubrik">Välj klient:</p>
                    <asp:DropDownList ID="drpClient" runat="server" AppendDataBoundItems="true" DataTextField="name" 
                    DataValueField="familyid" AutoPostBack="True" CssClass="drop"
                    OnSelectedIndexChanged="drpClient_SelectedIndexChanged">
                    <asp:ListItem Value="0">-- Välj klient --</asp:ListItem>
                </asp:DropDownList>
        </div>
        <div class="sektion">
            <div class="sektion-top">
                <h3>Enhet:</h3><asp:Label ID="lblunit" runat="server" Text=""></asp:Label>
                <h3>Klient:</h3> <asp:Label ID="lblclient" runat="server" Text=""></asp:Label>             
            </div>

            <p class="mellan-rubrik-top">Välj journaler efter datum: </p>
            <div class="date">
                <input type="text" class="datepick" id="datepicker" placeholder="Från: ">
                <input type="text" class="datepick" id="datepicker2" placeholder="Till: ">
                <%--<button class="alla-datum datepick">Välj alla datum</button>--%>
                <asp:Button ID="btnShowAll" CssClass ="alla-datum" runat="server" OnClick="btnShowAll_Click" Text="Välj alla datum" />
            </div>
            <asp:Label ID="lblFelmeddelande" ForeColor ="Red" runat="server" Text=""></asp:Label>
            <div class="lista">
                <p class="mellan-rubrik">Journaler:</p>
                <%--<input type="text" id="journal-list">--%>
                <asp:ListBox ID="lsbList" AutoPostBack="true" OnSelectedIndexChanged="lsbList_SelectedIndexChanged" runat="server" CssClass="journal-list"></asp:ListBox>
                <%--<textarea cols ="45" rows ="15" runat ="server" id="txbList" name="jourlist"></textarea>--%>
            </div>
        </div>

        <div class="sektion">
            <h3>Journal</h3>
            <div class="readjournal">
                <p class="mellan-rubrik-top">Rubrik:</p>
                <%--<input type="text" id="rubrik">--%>
<<<<<<< HEAD
                 <textarea cols ="45" rows ="2" readonly ="readonly" runat ="server" id="txbRubrik" class="rubrik" name="jourlista"></textarea>
                <p class="mellan-rubrik">Journalanteckning:</p>
                <%--<input type="text" id="journal-anteckning">--%>
                <textarea cols ="45" rows ="10" readonly ="readonly" runat ="server" id="txbJournal" class="journal-anteckning" name ="jour"></textarea>
=======
                 <textarea cols ="45" rows ="2" runat ="server" id="txbRubrik" name="jourlista"></textarea>
                <p>Journalanteckning:</p>
                <%--<input type="text" id="journal-anteckning">--%>
                <textarea cols ="45" rows ="10" runat ="server" id="txbJournal" name ="jour"></textarea>
>>>>>>> 8549ac42b013d589a4bf9fe239bce8b969c63600
                <asp:Label ID="lblInitialer" runat="server" Text=""></asp:Label>
            </div>
            

        </div>
    </div>

        </form>




</asp:Content>
