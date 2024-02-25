<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="AnonWeb.DefaultAnonPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #Button1 {
            height: 111px;
            width: 145px;
        }
    </style>
</head>
<body>
    <div>
        <form runat="server">
            <asp:Label ID="Label1" runat="server" Text="Label" Font-Size="Large"></asp:Label>
            <br />
            <br />
            <input id="Text1" type="text" placeholder="Nama" /><br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button_Click" />
        </form>
    </div>
</body>
</html>
