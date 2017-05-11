<%@ Page Title="" Language="C#" MasterPageFile="~/Master2_Inloggad.Master" AutoEventWireup="true" CodeBehind="adminClient.aspx.cs" Inherits="kärnan.adminFamily" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">


        <%--  <asp:Button ID="btnAddFamily" OnClick="btnAddFamily_Click" runat="server" Text="Lägg till ny familjemedlem" />--%>

        <%--<asp:ListBox ID="ListBox1" AutoPostBack="true" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" runat="server" ></asp:ListBox>--%>
<%--        <p>Namn</p>
        <asp:TextBox ID="txbUpdateName" runat="server"></asp:TextBox>
        <p>Efternamn</p>
        <asp:TextBox ID="txbUpdateSurname" runat="server"></asp:TextBox>
        <p>Personnummer</p>
        <asp:TextBox ID="txbUpdateBirth" runat="server"></asp:TextBox>--%>

<%--        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataTextField="unitname"
            DataValueField="unitid" AppendDataBoundItems="true" CssClass="drp"
            OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem Value="0">-- Välj enhet --</asp:ListItem>
        </asp:DropDownList>

        <%--   <asp:Button ID="btnUpdateFamily" OnClick="btnUpdateFamily_Click" runat="server" Text="Uppdatera familj" />--%>
        <%-- SLUT --%>

        <%-- Radera information om familj --%>
<%--        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" AppendDataBoundItems="true" CssClass="drp"
            OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
            <asp:ListItem Value="0">-- Välj enhet --</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="btnRemoveFamily" runat="server" OnClick="btnRemoveFamily_Click" Text="Radera familj" />--%>
        <%-- SLUT --%>
        
        <div class="unit-container">
            <div class="sektion">
                <h3>Hanterings alternativ</h3>
                <p class="mellan-rubrik">Vad vill du göra?</p>
                <asp:DropDownList ID="drpChoice" runat="server" CssClass="drop"></asp:DropDownList>
                <p class="mellan-rubrik">Välj den klient du vill hantera</p>
                <asp:ListBox ID="lsbClient" AutoPostBack="true" OnSelectedIndexChanged="lsbClient_SelectedIndexChanged" runat="server" CssClass="journal-list"></asp:ListBox>
                <%--<asp:ListBox ID="ListBox1" AutoPostBack="true" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" runat="server"></asp:ListBox>--%>
            </div>

            <div class="sektion">
                <div class="klient-top">
                    <h3>Uppgifter för klient</h3>
                </div>
                <p class="mellan-rubrik">Förnamn: </p>
                <asp:TextBox ID="txbName" runat="server" CssClass="new-name"></asp:TextBox>
                <p class="mellan-rubrik">Efternamn: </p>
                <asp:TextBox ID="txbSurname" runat="server" CssClass="new-name"></asp:TextBox>
                <p class="mellan-rubrik">Personnummer: </p>
                <asp:TextBox ID="txbBirth" runat="server" CssClass="new-name"></asp:TextBox>
                <p class="mellan-rubrik">Tillhörande enhet: </p>
                <asp:DropDownList ID="drpUnit" runat="server" AutoPostBack="True" DataTextField="unitname"
                    DataValueField="unitid" AppendDataBoundItems="true" CssClass="drop"
                    OnSelectedIndexChanged="drpUnit_SelectedIndexChanged">
                    <asp:ListItem Value="0">-- Välj enhet --</asp:ListItem>
                </asp:DropDownList>

                <div class="unit-buttons-div">

                    <asp:Button ID="btnClearText" CssClass="unit-buttons" runat="server" OnClick="btnClearText_Click" Text="Töm fält" />
                    <%--<button class="unit-buttons">Töm fält</button>--%>

                    <asp:Button ID="btnAddFamily" OnClick="btnAddFamily_Click" runat="server" CssClass="unit-buttons" Text="Lägg till klient" />
                    <%--            <button class="unit-buttons">Lägg till klient</button>--%>

                    <asp:Button ID="btnUpdateFamily" CssClass="unit-buttons" OnClick="btnUpdateFamily_Click" runat="server" Text="Spara ändringar" />
                    <%--<button class="unit-buttons">Spara ändringar</button>--%>

                    <asp:Button ID="Button1" CssClass="unit-buttons" runat="server" OnClick="btnRemoveFamily_Click" Text="Radera familj" />
                    <%--<button class="unit-buttons">Radera klient</button>--%>
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
                margin: 0;
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
                width: 99.5%;
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
        </style>



    </form>
</asp:Content>
