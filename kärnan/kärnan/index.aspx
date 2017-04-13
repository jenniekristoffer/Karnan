<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="kärnan.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <link rel="stylesheet" href="stylesheet.css"/>

    <asp:DropDownList ID="DropDownList1" CssClass="dropdown" runat="server">
     <asp:ListItem Selected="True">--Select--</asp:ListItem>

 <asp:ListItem>India</asp:ListItem>
 <asp:ListItem>China</asp:ListItem>
 <asp:ListItem>Pakistan</asp:ListItem>
 <asp:ListItem>Srilanka</asp:ListItem>
    </asp:DropDownList>

        <div class="hej"></div>



<%--    <style>
        .hej{
    width:100px;
    height:100px;
    background-color:coral;

}

.dropdown{

width: 200px;
height: 40px;
border: none;
background-color: rgb(88, 88, 88);
color: rgb(11, 164, 194);
font-size: 20px;
padding-left: 3px;
-webkit-border-radius:1px; 
-moz-border-radius:1px; 
border-radius:1px;
text-shadow: 0px 2px 0px #000000;
padding-top: 5px;
padding-bottom: 5px;
padding-right: 5px;
}
       
.dropdown select {
background: green;
width: 268px;
padding: 5px;
border: 0;
border-radius: 0;
font-size: 16px;
line-height: 1;
height: 34px;
-webkit-appearance: none;
text-shadow: 0px 2px 0px #000000;
}

    </style>--%>



</asp:Content>

