<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 120px;
        }
    </style>
</head>
<body style="width: 391px">
    <form id="form1" runat="server">
    <div style="font-size: large; border: thick double #FFCCCC">
    
        <br />
        <br />
    
        <asp:Label ID="Label1" runat="server" Text="First Name:" Width="100"></asp:Label>

        <asp:TextBox ID="TextBox1" runat="server" Height="22px" Width="174px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Last Name:"  Width="100"></asp:Label>

        <asp:TextBox ID="TextBox2" runat="server" Height="21px" Width="172px"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            
        <br />
        <br />
            
    </div>
        <p class="auto-style1">
        <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
    
        </p>
    </form>
</body>
</html>
