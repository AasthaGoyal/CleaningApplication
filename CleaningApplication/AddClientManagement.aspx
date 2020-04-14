<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddClientManagement.aspx.cs" Inherits="CleaningApplication.WebForm22" %>
<%@ MasterType VirtualPath="~/Admin.Master" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link href="css/bootstrap.css" rel="stylesheet" />
<link href="css/style.css" rel="stylesheet"/>
<link href="css/responsive.css" rel="stylesheet"/>
    <form runat="server">
        <div class="container form-control">
              <h3> Add a new Client:</h3>
            <br />
   
            <br />
     Client Logo:
   
        <asp:FileUpload ID="fpLogo" runat="server" />
           
        <br />
   <br />
    Client Name:
      <asp:TextBox class="form-control" width="100%" height="40px"  ID="txtcname" runat="server" ></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="* Client name is required" Font-Bold="True" ForeColor="#CC0000" ValidationGroup="addclient" ControlToValidate="txtcname"></asp:RequiredFieldValidator>
          
            <br />
              <asp:Label ID="lblmessage" runat="server" Font-Bold="True" ForeColor="#CC0000" ></asp:Label>
      
              <br />
            
        <asp:Button ID="btnadd" class="btn-primary" width="200px" height="50px" runat="server" Text="Add Client" OnClick="btnadd_Click" ValidationGroup="addclient" />

        </div>
    </form>
</asp:Content>
