<%@ Page Title="" Language="C#" MasterPageFile="~/Master2_Inloggad.Master" AutoEventWireup="true" CodeBehind="jour.aspx.cs" Inherits="kärnan.jour" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
           <%-- Vänster column - Välj familj och enhet --%>
        <div class ="vColumn">
            <h4>Skriv journaler</h4>
            <p>&nbsp;</p><%-- mellanrum--%>
            <p>&nbsp;</p> <%-- mellanrum--%>
        </div>

    <table style="width: 100%; height: 86px;">  
        <tr>            
            <td class="style1">  
                <asp:Label ID="Label1" runat="server" Text="Välj enhet :"></asp:Label>  
            </td>  
            <td class ="dropdown">  
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True"   
                    DataTextField="name" DataValueField="unitid" AppendDataBoundItems="true" 
                    OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">  
                    <asp:ListItem Value="0">--Välj enhet--</asp:ListItem>  
                </asp:DropDownList>  
            </td>  

                
            <td>  
                 </td>  
        </tr>  
        <tr>  
            <td class="style1">  
                <asp:Label ID="Label2" runat="server" Text="Välj familj :"></asp:Label>  
            </td>  
            <td class ="dropdown">  
                <asp:DropDownList ID="DropDownList2" runat="server" AppendDataBoundItems="true" DataTextField="name"   
                    DataValueField="familyid" AutoPostBack="True" 
                    OnSelectedIndexChanged ="DropDownList2_SelectedIndexChanged">  
                    <asp:ListItem Value="0">-- Välj familjemedlem--</asp:ListItem>  
                </asp:DropDownList>  
            </td>  
            <td>  
                 </td>  
            
        </tr>  
    </table>  

    <style type="text/css">

        .dropdown{
    background-color: #E6E6D9;
    padding: 13px;
    font-size: 16px;
    border-radius:5px;
    margin-bottom:20px;
    box-shadow: 0px 4px 8px 0px rgba(0,0,0,0.2);    
    position: relative;
    display: inline-block;
    top: 0px;
    left: 0px;
    width: 130px;
    
    border-right: 3px solid #22383c;
    width: 20%;
    margin:10px;
    float: left;
    }

.dropdown:hover{
    background-color: #DBDBC9;
    display: inline-block;
}

.vColumn{
    border-right: 3px solid #22383c;
    width: 20%;
    margin:10px;
    float: left;
}

.rColumn{
    float: left;
}
.label{
    float: left;
}

.label1{
    float: right;
}

.date{
   float: left;
}

.beskriv{
    width: 70%;
    padding: 5px 5px;
    margin: 8px 0;
    box-sizing: border-box;
}

.jour{
    width: 70%;
    padding: 120px 5px;
    margin: 8px 0;
    box-sizing: border-box;
}

</style>

</asp:Content>
