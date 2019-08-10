<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="registerUser.aspx.cs" Inherits="CleaningApplication.WebForm19" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
         <link href="css/bootstrap.css" rel="stylesheet" />
<link href="css/style.css" rel="stylesheet"/>
<link href="css/responsive.css" rel="stylesheet"/>
        
       
        <h3 class="text-center"> Register a new Staff</h3>
        <br />
        Enter Full name:  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Full name required" ControlToValidate="txtname" ValidationGroup="adduser" ForeColor="#CC0000"></asp:RequiredFieldValidator>
      
        <asp:TextBox ID="txtname" CssClass="form-control" placeholder="Enter full name" runat="server" Height="27px"></asp:TextBox>
        <br />
          Enter Address:
        <asp:TextBox ID="txtaddress" CssClass="form-control" placeholder="Enter Address" runat="server" Height="27px"></asp:TextBox>
       <br />
          Enter Phone No:
        <asp:TextBox ID="txtphone" CssClass="form-control" placeholder="Enter Phone No" runat="server" Height="27px"></asp:TextBox>
       <br />
          Enter Email Id:  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Email Id is required" ControlToValidate="txtemail" ValidationGroup="adduser" ForeColor="#CC0000"></asp:RequiredFieldValidator>
      
        <asp:TextBox ID="txtemail" CssClass="form-control" placeholder="Enter Email id" runat="server" Height="27px"></asp:TextBox>
       <br />
          Enter Position:   <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*Position is required" ControlToValidate="txtposition" ValidationGroup="adduser" ForeColor="#CC0000"></asp:RequiredFieldValidator>
     
        <asp:TextBox ID="txtposition" CssClass="form-control" placeholder="Enter Position" runat="server" Height="27px"></asp:TextBox>
       
   <br />
        Photo:
        <asp:FileUpload ID="fpImage" runat="server" />
        <br />
        Username: <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*Username is required" ControlToValidate="txtusername" ValidationGroup="adduser" ForeColor="#CC0000"></asp:RequiredFieldValidator>
     
        <asp:TextBox ID="txtusername" CssClass="form-control" placeholder="Enter Username" runat="server" Height="27px"></asp:TextBox>
         <br />
        Password:  <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*Password is required" ControlToValidate="txtpassword" ValidationGroup="adduser" ForeColor="#CC0000"></asp:RequiredFieldValidator>
      
        <asp:TextBox ID="txtpassword" CssClass="form-control" PasswordChar="*" placeholder="Enter Password" runat="server" Height="27px"></asp:TextBox>
       <br />

        <asp:Button ID="btnSubmit" class="form-control btn-success" ValidationGroup="addUser" runat="server" Text="Add Staff" OnClick="btnSubmit_Click" />
        <br />
        <asp:Label ID="lblmessage" runat="server" Font-Bold="True" ForeColor="#CC0000" ></asp:Label>
    </form>
</asp:Content>
