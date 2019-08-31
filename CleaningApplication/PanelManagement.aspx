<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="PanelManagement.aspx.cs" Inherits="CleaningApplication.WebForm17" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        

    
    <h2> Panel Managemrnt</h2>
    <br />

    Company Name:
      <asp:TextBox class="form-control" width="100%" height="40px" Enabled="False" ID="txtcname" runat="server"  ></asp:TextBox>
        <br />
     Company Logo:
        <asp:Image ID="imgLogo" runat="server" Width="250px" Height="120px" />
    
        <br />
        <asp:FileUpload ID="fpLogo" runat="server" />
        <br />
         <br />
    Phone No (primary):
      <asp:TextBox class="form-control" width="100%" height="40px" Enabled="False" ID="txtphoneno" runat="server" ></asp:TextBox>
        <br />
        Phone No (secondary):
         <asp:TextBox class="form-control" width="100%" height="40px" Enabled="False" ID="txtphoneno2" runat="server" ></asp:TextBox>
        <br />
    Street Address:
      <asp:TextBox class="form-control" width="100%" height="40px" Enabled="False" ID="txtstreetAddress" runat="server" ></asp:TextBox>
        <br />
     Suburb:
        <asp:TextBox class="form-control" width="100%" height="40px" Enabled="False" ID="txtsuburb" runat="server" ></asp:TextBox>
        <br />
     Email Id:
        <asp:TextBox class="form-control"  width="100%" height="40px" Enabled="False" ID="txtemail" runat="server" ></asp:TextBox>
        <br />
    Timings:
      <asp:TextBox class="form-control" width="100%" height="40px" Enabled="False" ID="txttimings" runat="server" ></asp:TextBox>
        <br />
    About us:
      <asp:TextBox class="form-control" TextMode="MultiLine" height="120px" Wrap="true" ID="txtAboutus" runat="server" Enabled="False" ></asp:TextBox>
        <br />
         <asp:Label ID="lblmessage" runat="server" Font-Bold="True" ForeColor="#CC0000" ></asp:Label>
      
    <br />
          <asp:Button ID="btnEdit" class="btn-info" width="200px" height="50px" runat="server" Text="Edit" OnClick="btnEdit_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnUpdate" class="btn-success" width="200px" height="50px" runat="server" Text="Update" OnClick="btnUpdate_Click" />
      
      
    
   </form>
   
   
</asp:Content>
