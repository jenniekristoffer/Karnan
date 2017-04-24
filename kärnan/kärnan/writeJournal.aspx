<%@ Page Title="" Language="C#" MasterPageFile="~/Master2_Inloggad.Master" AutoEventWireup="true" CodeBehind="writeJournal.aspx.cs" Inherits="kärnan.writeJournal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--            <link rel="stylesheet" href="stylesheet.css">
        <link rel="stylesheet" type="text/css" href="stylesheet1.css"/>      --%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="conteiner">

        <asp:Label ID="lblInloggad" runat="server" Text=""></asp:Label> 
        <asp:Label ID="lblInitials" runat="server" Text=""></asp:Label>

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
        <p>
            Personnummer: 
            <asp:Label ID="lblPnr" runat="server" Text=""></asp:Label>
        </p>

        <p>&nbsp;</p>
        <%-- mellanrum--%>
        <p>&nbsp;</p>
        <%-- mellanrum--%>

        <p>Beskrivning<asp:Label ID="lblBeskrivning" ForeColor ="Red" runat="server" Text=""></asp:Label>
        </p> 
        <div class="beskriv">
            <textarea cols ="45" rows ="2" runat ="server" id="txbincident" name="inci"></textarea>
        </div>

        <p>Journal<asp:Label ID="lblJournal" ForeColor="Red" runat="server" Text=""></asp:Label>
        </p>
        <div class="journ">
            <textarea cols ="45" rows ="10" runat ="server" id="txbJournal" name ="jour"></textarea>&nbsp;
        </div>
        <%-- Meddelande om sparnining genomförts eller felblivit --%>
       <p>
        <asp:Label ID="lblMeddelande" runat="server" Text=""></asp:Label>
        </p>
        <p>&nbsp;</p>
        <p>&nbsp;</p>
        <p>&nbsp;</p>
        
         <div class="date">
            <p>
                Datum</p>
            <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
        </div>
        <asp:Button ID="btnAvbry" OnClick="btnAvbry_Click" runat="server" Text="Avbryt" />
        <asp:Button ID="btnSpara" OnClick="btnSpara_Click" runat="server" Text="Spara" />
    </div>

    <style type="text/css">
        .drp, .drop {
            padding: 13px;
            font-size: 16px;
            border-radius: 5px;
            margin-bottom: 20px;
            position: relative;
            display: inline-block;
            top: 3px;
            left: 3px;
            width: 155px;
        }

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
