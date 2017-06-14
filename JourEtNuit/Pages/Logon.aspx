<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logon.aspx.cs" Inherits="JourEtNuit.Pages.Logon" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server">Nom</asp:Label>
            <asp:TextBox ID="tb_login" runat="server" Text="ludovic" />
            <br />
            <asp:Label runat="server">Mot de passe</asp:Label>
            <asp:TextBox ID="tb_pwd" TextMode="Password"  runat="server" />
            <asp:CustomValidator ID="pwdLengthValidator" runat="server" ControlToValidate="tb_pwd" ErrorMessage="Le mot de passe doit faire au moins 8 caractères" OnServerValidate="pwdLengthValidator_ServerValidate"/>
            <br />
            <br />

            <asp:Button Text="Add user" runat="server" ID="Btn_AddUser" OnClick="Btn_AddUser_Click" />
            <asp:Button Text="login" runat="server" ID="login" OnClick="login_Click" />
            
        </div>
    </form>
</body>
</html>
