<%@ Page Title="" Language="C#" MasterPageFile="~/Master2_Inloggad.Master" AutoEventWireup="true" CodeBehind="readJournal.aspx.cs" Inherits="kärnan.readJournal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<%--    <form runat="server">--%>

    <script>
                $(function () {
                    $("#datepicker").datepicker();
                });

                $(function () {
                    $("#datepicker2").datepicker();
                });
    </script>

    <div class="sektions-huvud">
        <h3>Läs journal</h3>
    </div>
    <div class="read-container">
        <div class="sektion">
            <div class="rubrik-hjalp-div">
                <h3>Välj enhet och klient</h3>
                <div class="tooltip"><i class="fa fa-question-circle" style="font-size: 23px;"></i>
                    <span class="tooltiptext"><strong>Steg 1.   Val av klient</strong><br/>Välj först enhet, välj sedan den klient du vill se journaler för.</span>
                </div>
            </div>

            <p class="mellan-rubrik-top">Välj enhet:</p>
                    <asp:DropDownList ID="drpUnit" runat="server" AutoPostBack="True" DataTextField="unitname"
                    DataValueField="unitid" AppendDataBoundItems="true" CssClass="drop" 
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
            <div class="rubrik-hjalp-div">
            <div class="sektion-top">
                <h3>Enhet:</h3><asp:Label ID="lblunit" runat="server" Text="" CssClass="label"></asp:Label>
                <h3>Klient:</h3> <asp:Label ID="lblclient" runat="server" Text="" CssClass="label"></asp:Label>             
            </div>                        
                <h3>Välj enhet och klient</h3>
                <div class="tooltip"><i class="fa fa-question-circle" style="font-size: 23px;"></i>
                    <span class="tooltiptext"><strong>Steg 2.   Filtrera journaler</strong><br/>För att se datumspann: Välj datum <b>Från</b> och <b>Till</b>. Klicka sedan på <b>Visa mellan datum</b>. För att se alla datum: Klicka på <b>Visa alla datum</b></span>
                </div>
            </div>

            <p class="mellan-rubrik-top">Välj journaler efter datum: </p>
            <div class="date">
                <input type="text" class="datepick" id="datepicker" name="date1" placeholder="Från: " style="margin-top: 0px; margin-bottom: 0px;"/>
                <input type="text" class="datepick" id="datepicker2" name="date2" placeholder="Till: " style="margin-top: 0px; margin-bottom: 0px;"/>
                <asp:Button ID="btnShowSpecifik" CssClass ="alla-datum" runat="server" OnClick="btnShowSpecifik_Click" Text="Visa mellan datum" />  
                <asp:Button ID="btnShowAll" CssClass ="alla-datum" runat="server" OnClick="btnShowAll_Click" Text="Visa alla datum" />
              
            </div>
            <asp:Label ID="lblFelmeddelande" ForeColor ="Red" runat="server" Text=""></asp:Label>
            <div class="lista">
                <p class="mellan-rubrik">Journaler:</p>
                <asp:ListBox ID="lsbList" AutoPostBack="true" OnSelectedIndexChanged="lsbList_SelectedIndexChanged" runat="server" CssClass="journal-list"></asp:ListBox>
            </div>
        </div>

        <div class="sektion">
            <div class="rubrik-hjalp-div">
            <h3>Journal</h3>
                 </div>
            <div class="readjournal">

                <div class="read-right-top">

                <div class="read-rubrik">
                <p class="mellan-rubrik-top">Rubrik:</p>
                <textarea width="100%" rows ="2" readonly ="readonly" runat ="server" id="txbRubrik" class="rubrik read-right-rubrik" name="jourlista"></textarea>    
                </div>

                <div class="read-date">    
                <p class="mellan-rubrik-top date-rubrik-top">Datum:</p>
                <textarea width="100%" rows ="2" readonly ="readonly" runat ="server" id="txbDate" class="rubrik read-right-date" name="date"></textarea>
                </div>
                </div>
                  <p class="mellan-rubrik">Journalanteckning:</p>
                <textarea cols ="45" rows ="10" readonly ="readonly" runat ="server" id="txbJournal" class="journal-anteckning" name ="jour"></textarea>
                <div class="signatur-div">
                    <p class="mellan-rubrik">Signatur:</p>
                <asp:Label ID="lblInitialer" runat="server" Text="" CssClass="mellan-rubrik initials"></asp:Label>
                    </div>
            </div>
            

        </div>
    </div>

<%--        </form>--%>




</asp:Content>
