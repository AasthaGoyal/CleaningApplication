<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="CleaningApplication.ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
         <div class="auto-style1">
            
                <h1 class="auto-style1"> Forgot Password...</h1>
                Enter your registered Email id:&nbsp; <asp:TextBox ID="TxtEmail" runat="server" Width="194px"></asp:TextBox>
                &nbsp;<asp:Button ID="Butpass" runat="server" Text="Submit" OnClick="Butpass_Click" Width="114px"></asp:Button>
                <br />
                <asp:Label ID="lblmsg" runat="server" ForeColor="#0CC000" Font-Bold="True" ></asp:Label>
            
        </div>
    </form>
</body>
</html>
