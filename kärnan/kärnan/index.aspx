<%@ Page Title="" Language="C#" MasterPageFile="~/MasterMasterPage.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="kärnan.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        
        <div class="index-content">
        <div class="logo-img">
            <img src="bilder/logo.karnan.jpg" />
        </div>
        <div class="index-rubrik">
            <h1>kärnan</h1>
            <p>Den enkla journalhanteraren</p>
        </div>
        <div class="color-bar">
            <div class="bar" id="bar1"></div>
            <div class="bar" id="bar2"></div>
            <div class="bar" id="bar3"></div>
            <div class="bar" id="bar4"></div>
            <div class="bar" id="bar5"></div>
            <div class="bar" id="bar6"></div>
            <div class="bar" id="bar7"></div>
            <div class="bar" id="bar8"></div>
            <div class="bar" id="bar9"></div>
            <div class="bar" id="bar10"></div>
        </div>
        <div class="responsiv-text">
            <p>Trött på gamla svåra bökiga journal system?<br>Kärnan är ett nytt, enkelt och säkert journalsystem. Att skriva journaler ska inte vara något svårt, det ska vara enkelt och inte behöva ta en massa tid.<br>Kärnan är responsivt och fungerar så väl på din dator som på din telefon eller surfplatta.</p>
        </div>
        <div class="responsiv">

            <img src="bilder/laptop.karnan.jpg" />
            <img src="bilder/mobile.karnan.jpg" />
        </div>
    </div>




    <style>
        
.index-content {
    display: flex;
    flex-direction: column;
    align-items: center;
    font-family: Open sans, sans-serif;
    margin-top: 40px;
}

.index-rubrik {
    text-align: center;
}

.index-rubrik h1 {
    font-family: Francois One;
    font-weight: 100;
    font-size: 50px;
    color: #434343;
    text-transform: lowercase;
}

.index-rubrik p {
    font-weight: 600;
    color: #434343;
    font-size: 18.78px;
    margin-bottom: 120px;
}

img {
    display: inline-block;
    vertical-align: middle;
    max-height: 100%;
    max-width: 100%;
}

.logo-img {
    display: inline-block;
    vertical-align: middle;
    height: 200px;
}

.responsiv {
    display: flex;
    flex-direction: column;
    justify-content: flex-start;
    height: 300px;
    font-family: Open sans, sans-serif;
    text-align: center;
}

.responsiv-text p {
    font-weight: 600;
    color: #434343;
    font-size: 15.78px;
    text-align: center;
    line-height: 2;
}

.color-bar {
    display: flex;
    flex-direction: row;
    height: 5px;
    justify-content: center;
    align-content: center;
    align-items: center;
    width: 100%;
}

.bar {
    height: 5px;
    width: 100%;
    margin-bottom: 120px;
}

#bar1 {
    background-color: #F7E4BE;
}

#bar2 {
    background-color: #F7E4BE;
}

#bar3 {
    background-color: #F0B49E;
}

#bar4 {
    background-color: #B38184;
}

#bar5 {
    background-color: #73626E;
}

#bar6 {
    background-color: #73626E;
}

#bar7 {
    background-color: #B38184;
}

#bar8 {
    background-color: #F0B49E;
}

#bar9 {
    background-color: #F7E4BE;
}

#bar10 {
    background-color: #F7E4BE;
}



    </style>


</asp:Content>

