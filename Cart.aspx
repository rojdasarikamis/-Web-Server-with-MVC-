<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Your Carts:" Font-Bold="True" Font-Size="36pt" BorderColor="#FFCCCC" BorderStyle="Double" BorderWidth="5px" Height="66px" Width="269px"></asp:Label>
        <br /><br />
        <asp:Panel ID="cartContainer" runat="server">
            <br />
            <br />
        </asp:Panel>
        <div id="secondChance" runat="server"></div>
    </div>
    </form>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</body>
</html>
