<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TextForm.aspx.vb" Inherits="AnonWeb.TextForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:TextBox ID="txtUserName" TextMode="SingleLine" runat="server" />
                <br />
                <br />
                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" />
                <br />
                <br />
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                <br />
                <br />
                <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click"/>
            </div>
        </div>
    </form>
</body>
</html>
