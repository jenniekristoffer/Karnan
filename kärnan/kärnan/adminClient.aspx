<%@ Page Title="" Language="C#" MasterPageFile="~/masterAdmin.Master" AutoEventWireup="true" CodeBehind="adminClient.aspx.cs" Inherits="kärnan.adminClientt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--        <form runat="server">--%> 
        <div class="sektions-huvud">
        <h3>Hantera klient</h3>
        </div>
        <div class="unit-container">
            <div class="sektion">
            <div class="rubrik-hjalp-div">
                <h3>Hanterings alternativ</h3>
                <div class="tooltip"><i class="fa fa-question-circle" style="font-size: 23px;"></i>
                    <span class="tooltiptext"><strong>Steg 1.   Hanterings alternativ</strong><br/>Välj först vad du vill göra, välj sedan den klient du vill hantera.<br />Den valda klienten kommer upp till höger.</span>
                </div>
            </div>

                <p class="mellan-rubrik">Vad vill du göra?</p>
              <asp:DropDownList ID="drpChoice" runat="server" OnSelectedIndexChanged="drpChoice_SelectedIndexChanged" AutoPostBack="true" CssClass="drop">
                <asp:ListItem Enabled="true" Text="-- Välj alternativ --" Value="-1"></asp:ListItem>
                <asp:ListItem Text="Lägg till" Value="1"></asp:ListItem>
                <asp:ListItem Text="Uppdatera" Value="2"></asp:ListItem>
                <asp:ListItem Text="Radera" Value="3"></asp:ListItem>
               </asp:DropDownList>

                <p class="mellan-rubrik">Välj den klient du vill hantera</p>
                <asp:ListBox ID="lsbClient" AutoPostBack="true" OnSelectedIndexChanged="lsbClient_SelectedIndexChanged" runat="server" CssClass="journal-list"></asp:ListBox>      
            </div>

            <div class="sektion">
            <div class="rubrik-hjalp-div">
                <h3>Uppgifter för klient</h3>
                <div class="tooltip"><i class="fa fa-question-circle" style="font-size: 23px;"></i>
                    <span class="tooltiptext"><strong>Steg 2.   Hantera uppgifter</strong><br/>Genomför de ändringarna du vill göra. Klicka sedan på relevant knapp.</span>
                </div>
            </div>


                <p class="mellan-rubrik">Förnamn: </p>
                <asp:TextBox ID="txbName" runat="server" CssClass="new-name" style="margin-top: 0px; margin-bottom: 0px;"></asp:TextBox>
                <p class="mellan-rubrik">Efternamn: </p>
                <asp:TextBox ID="txbSurname" runat="server" CssClass="new-name" style="margin-top: 0px; margin-bottom: 0px;"></asp:TextBox>
                <p class="mellan-rubrik">Personnummer: </p>
                <asp:TextBox ID="txbBirth" runat="server" CssClass="new-name" style="margin-top: 0px; margin-bottom: 0px;"></asp:TextBox>
                <p class="mellan-rubrik">Tillhörande enhet: </p>
                <asp:DropDownList ID="drpUnit" runat="server" AutoPostBack="True" DataTextField="unitname"
                    DataValueField="unitid" AppendDataBoundItems="true" CssClass="drop"
                     OnSelectedIndexChanged= "drpUnit_SelectedIndexChanged">
                    <asp:ListItem Value="0">-- Välj enhet --</asp:ListItem>
                </asp:DropDownList>
                    
                <div class="unit-buttons-div">
                <asp:Button ID="btnClearText" CssClass="unit-buttons" runat="server" OnClick="btnClearText_Click" Text="Töm fält" />
                   <asp:Button ID="btnAddClient" OnClick="btnAddClient_Click" runat="server" CssClass="unit-buttons" Text="Lägg till klient" />
                    <asp:Button ID="btnUpdateClient" OnClick="btnUpdateClient_Click" CssClass="unit-buttons" runat="server" Text="Uppdatera klient" />
                    <asp:Button ID="btnRemoveClient" OnClick="btnRemoveClient_Click" CssClass="unit-buttons" runat="server" Text="Radera klient" />
                    </div>
                    
             <asp:Label ID="lblmeddelande" ForeColor="Red" runat="server" Text=""></asp:Label>
             <asp:Label ID="lblcorrekt" runat="server" Text=""></asp:Label>
            </div>
        </div>


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
                flex-wrap:wrap;
            }

            .unit-buttons {
                width: 150px;
                border: 1px solid rgba(64, 64, 64, 0.39);
                padding: 12px 0px 12px 0px;
                margin-top: 20px;
                margin-left: 10px;
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

            /*#navbar ul li:hover .tooltip {
            display: none;
            }*/


        </style>



<%--    </form>--%>
</asp:Content>
