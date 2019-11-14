<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddNewService.aspx.cs" Inherits="CleaningApplication.WebForm25" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link href="css/bootstrap.css" rel="stylesheet" />
<link href="css/style.css" rel="stylesheet"/>
<link href="css/responsive.css" rel="stylesheet"/>
    <form runat="server">
        <div class="container form-control">
            
              <h3> Add a new Service:</h3>
            
            <br />
            
              
                <br />
                Category Name:
                <asp:TextBox ID="txtcname" CssClass="form-control" placeholder="Enter category name" runat="server"></asp:TextBox>
                <br />
                Category Photo:
                <asp:FileUpload ID="fpPhoto" class="form-control" runat="server" />
                <br />
                Category Description:
                 <asp:TextBox ID="txtcdescription" CssClass="form-control" placeholder="Enter category name" runat="server"></asp:TextBox>
                <br />
                Rank:
                 <asp:TextBox ID="txtcrank" width="100%" enabled="false" CssClass="form-control" placeholder="Enter category name" runat="server"></asp:TextBox>
                <br />
                <br />
            <asp:Label ID="lblmessage" runat="server" ></asp:Label>
                   
            <asp:Button ID="btnaddCategory" CssClass="btn-primary form-control" runat="server" Text="Add the service" OnClick="btnaddCategory_Click" />
              <br />
              
                   Click the button to add further Multiple and single options:
            <br />
            <b> Note: Multiple-choice options (including Extras) are shown as a checklit while single-choice options are shown as a drop-down list</b>
                   <br />
            <asp:Button ID="btnaddOptions" runat="server" CssClass="btn-block form-control" Text="Add a filter option" BackColor="#FF6600" OnClick="btnaddOptions_Click" />
                   
                </div>
        </form>
</asp:Content>
