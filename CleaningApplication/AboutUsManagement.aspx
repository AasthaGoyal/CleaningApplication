<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AboutUsManagement.aspx.cs" Inherits="CleaningApplication.WebForm14" %>
<%@ MasterType VirtualPath="~/Admin.Master" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/bootstrap.css" rel="stylesheet" />
<link href="css/style.css" rel="stylesheet"/>
<link href="css/responsive.css" rel="stylesheet"/>
    <form runat="server">
        <div class="container form-control" >
            <h3> About us Page management</h3>
            <br />
       
        Tagline:
        <asp:TextBox ID="txttagline" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
        <br />
        Line 1:
        <asp:TextBox ID="txtline1"  Enabled="false" height="80px" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
        <br />
        Line 2:
        <asp:TextBox ID="txtline2" Enabled="false" height="80px" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
        <br />
        Core Values:
        <asp:TextBox ID="txtcore" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
        <br />
        Our Mission:
        <asp:TextBox ID="txtmission" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
        <br />
        Our Values:
        <asp:TextBox ID="txtvision" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
        <br />
              <asp:Label ID="lblmessage" runat="server" Font-Bold="True" ForeColor="#CC0000" ></asp:Label>
      
         <br />
          <asp:Button ID="btnEdit" class="btn-info" width="200px" height="50px" runat="server" Text="Edit" OnClick="btnEdit_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnUpdate" class="btn-success" width="200px" height="50px" runat="server" Text="Update" OnClick="btnUpdate_Click" />
      
      
    
        
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
         </div>
    </form>
</asp:Content>
