<%@ Page Title="" Language="C#" MasterPageFile="~/Master2_Inloggad.Master" AutoEventWireup="true" CodeBehind="writeJournal.aspx.cs" Inherits="kärnan.writeJournal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--            <link rel="stylesheet" href="stylesheet.css">
        <link rel="stylesheet" type="text/css" href="stylesheet1.css"/>      --%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="conteiner">

        <%-- Vänster column - Välj familj och enhet --%>
        <div class="vColumn">
            <h4>Skriv journaler</h4>
            <p>&nbsp;</p>
            <%-- mellanrum--%>
            <p>&nbsp;</p>
            <%-- mellanrum--%>


            <p class="txbUnit">Välj enhet</p>
            <div class="drp">
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataTextField="name"
                    DataValueField="unitid" AppendDataBoundItems="true" CssClass="drp"
                    OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                    <asp:ListItem Value="0">-- Välj enhet --</asp:ListItem>
                </asp:DropDownList>
            </div>
            <br />

            <p>&nbsp;</p>
            <%-- mellanrum--%>
            <p>&nbsp;</p>
            <%-- mellanrum--%>


            <p>Välj klient</p>
            <div class="drop">
                <asp:DropDownList ID="DropDownList2" runat="server" AppendDataBoundItems="true" DataTextField="name"
                    DataValueField="familyid" AutoPostBack="True" CssClass="drop"
                    OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                    <asp:ListItem Value="0">-- Välj namn --</asp:ListItem>
                </asp:DropDownList>

            </div>
        </div>
    </div>
    <%-- Höger column - Skriv journal --%>
    <div class="rColumn">


        <%-- <div class="label1"></div>--%>
        <div class="label">
            <p>
                Enhet:
            <asp:Label ID="lblEnhet" runat="server" Text=""></asp:Label>
            </p>
        </div>
        <p>
            Klient:
                <asp:Label ID="lblKlient" runat="server" Text=""></asp:Label>
        </p>
<%--        <p>
            Personnummer: 
            <asp:Label ID="lblPnr" runat="server" Text=""></asp:Label>
        </p>--%>

        <p>&nbsp;</p>
        <%-- mellanrum--%>
        <p>&nbsp;</p>
        <%-- mellanrum--%>

        <p>Beskrivning</p>
        <div class="beskriv">
            <%--<asp:TextBox ID="txbBeksrivning" runat="server"></asp:TextBox>--%>
            <textarea cols ="45" rows ="2" runat ="server" id="txbincident" name="inci"></textarea>
        </div>

        <p>Journal</p>
        <div class="journ">
            <%--<asp:TextBox ID="txbJournal" runat="server" Height="271px" Width="376px"></asp:TextBox>--%>
            <textarea cols ="45" rows ="10" runat ="server" id="txbJournal" name ="jour"></textarea>
        </div>

        <div class="date">
            <p>Datum</p>
            <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
        </div>

        <asp:Button ID="btnAvbry" OnClick="btnAvbry_Click" runat="server" Text="Avbryt" />
        <asp:Button ID="btnSpara" OnClick="btnSpara_Click" runat="server" Text="Spara" />
    </div>

    <style type="text/css">
        .drp, .drop {
            /*background-color: #E6E6D9;*/
            padding: 13px;
            font-size: 16px;
            border-radius: 5px;
            margin-bottom: 20px;
            /*box-shadow: 0px 1px 2px 0px rgba(0,0,0,0.2);*/
            position: relative;
            display: inline-block;
            top: 3px;
            left: 3px;
            width: 155px;
            /*height: 30px;*/
        }

        /*.drp:hover, .drop:hover {
                background-color: #DBDBC9;
                display: inline-block;
            }*/

        .vColumn {
            border-right: 3px solid #22383c;
            width: 20%;
            margin: 10px;
            float: left;
        }

        .rColumn {
            float: left;
        }

        .label {
            float: left;
            width: 222px;
        }

        .label1 {
            float: right;
        }

        .date {
            float: left;
        }

        .beskriv {
            width: 70%;
            padding: 5px 5px;
            margin: 8px 0;
            box-sizing: border-box;
        }

        .jour {
            width: 70%;
            padding: 120px 5px;
            margin: 8px 0;
            box-sizing: border-box;
        }
    </style>

</asp:Content>
