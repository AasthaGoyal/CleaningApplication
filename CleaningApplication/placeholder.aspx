<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="placeholder.aspx.cs" Inherits="CleaningApplication.placeholder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           Number of TextBoxes: <asp:TextBox runat="server" ID="CounterTextBox" 
    OnTextChanged="CounterTextBox_TextChanged" AutoPostBack="True" /><br/> 
<asp:PlaceHolder runat="server" ID="TextBoxPlaceHolder" /><br/>
            <asp:Button ID="btnSubmit" runat="server" AutoPostBack="true" Text="Submit" OnClick="ConfirmButton_Click"/>
<asp:Button runat="server" ID="ConfirmButton" Text="Show data" 
    OnClick="ConfirmButton_Click" /><br/>
Result: <asp:Literal runat="server" ID="ResultLiteral"/>
        </div>
    </form>
</body>
</html>
