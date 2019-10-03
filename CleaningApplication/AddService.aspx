<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddService.aspx.cs" Inherits="CleaningApplication.WebForm24" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/bootstrap.css" rel="stylesheet" />
<link href="css/style.css" rel="stylesheet"/>
<link href="css/responsive.css" rel="stylesheet"/>
        
  <form runat="server">
        <div class="container form-control">
             Number of TextBoxes: <asp:TextBox runat="server" class="form-control" ID="CounterTextBox" 
    OnTextChanged="CounterTextBox_TextChanged" AutoPostBack="True" /><br/> 
<asp:PlaceHolder runat="server" ID="TextBoxPlaceHolder" /><br/>
            <asp:Button ID="btnSubmit" runat="server" AutoPostBack="true" Text="Submit" OnClick="ConfirmButton_Click"/>
<asp:Button runat="server" ID="ConfirmButton" Text="Show data" 
    OnClick="ConfirmButton_Click" /><br/>
Result: <asp:Literal runat="server" ID="ResultLiteral"/>
            </div>
      </form>
</asp:Content>
