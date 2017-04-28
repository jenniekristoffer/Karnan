<%@ Page Title="" Language="C#" MasterPageFile="~/MasterMasterPage.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="kärnan.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="login-container">

        <p class="input-rubrik"><strong>Användarnamn:</strong></p>
        <input type="text" class="input" placeholder="" name="uname" required>
        <p class="input-rubrik"><strong>Lösenord:</strong></p>
        <input type="password" class="input" placeholder="" name="psw" required>
        <div class="btn-logincancel">

<%--        <button class="btn-cancel">Avbryt</button>
            <button class="btn-login">Logga in</button>--%>
            <asp:Button ID="btn_cancel" CssClass="btn-cancel" runat="server" Text="Avbryt" />
            <asp:Button ID="btn_login" CssClass="btn-login" runat="server" Text="Logga in" />

        </div>
    </div>



    <style>

.login-container {
    max-width: 400px;
    min-height: 500px;
    margin: auto;
    display: flex;
    padding: 15px;
    flex-direction: column;
    background-color: #f5f5f5;
    /*    border: solid 1px #6c6c6c;
*/
    align-items: flex-start;
    font-family: roboto;
}

.btn-logincancel {
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    width: 100%
}

.input {
    font-size: 18px;
    height: 41px;
    width: 100%;
    max-width: 398px;
    border: none;
    border: 1px solid grey;
    margin-bottom: 20px;
}

.btn-cancel,
.btn-login {
    height: 41px;
    width: 49%;
    border: none;
    background-color: #ffd966;
    font-family: roboto;
}

.btn-cancel:hover,
.btn-login:hover {
    height: 41px;
    width: 49%;
    border: none;
    background-color: #f6b26b;
}

.input-rubrik {
    color: #4a4a4a;
    margin-bottom: 5px;
}


    </style>


</asp:Content>
