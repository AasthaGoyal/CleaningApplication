<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="AddReview.aspx.cs" Inherits="CleaningApplication.WebForm6" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">

   
      <section class="page-title" style="background-image:url(images/background/3.jpg)">
    	<div class="auto-container">
        	<h2>Give us a Review</h2>
        </div>
    </section>

<br />
   <div class="auto-container">
       Your name (Optional):
       <asp:TextBox ID="txtname" runat="server" CssClass="form-control"></asp:TextBox>
       <br />
       Heading of Review:
       <asp:TextBox ID="txtHeading" runat="server" CssClass="form-control"></asp:TextBox>
       <br />
       Your Review:
       <asp:TextBox ID="txtReview" runat="server" CssClass="form-control"></asp:TextBox>
       <br />
       How many stars would you rate us?
       <asp:DropDownList ID="dpStars" runat="server" CssClass="form-control">
           <asp:ListItem>1</asp:ListItem>
           <asp:ListItem>2</asp:ListItem>
           <asp:ListItem>3</asp:ListItem>
           <asp:ListItem>4</asp:ListItem>
           <asp:ListItem>5</asp:ListItem>
       </asp:DropDownList>
       <br />
       <asp:Button ID="btnsubmit" runat="server" Text="Submit" class="btn-primary form-control" OnClick="btnsubmit_Click"/>
       <br />
       <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="#CC0000" ></asp:Label>
   </div>
         </form>
</asp:Content>
