<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="AddReview.aspx.cs" Inherits="CleaningApplication.WebForm6" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <style>

        .starRating
        {
            width:50px;
            height:50px;
            cursor:pointer;
            background-repeat:no-repeat;
            display:block;
            background-size:cover;
        }

        .FilledStars{
            background-image:url("images/background/filledStar.png");

        }

        .WaitingStars{
            background-image:url("images/background/redStar.png");
        }


        .EmptyStars{
            background-image:url("images/background/emptyStar.png");
        }
    </style>
   
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
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <cc1:Rating ID="Rating1" runat="server"
                    StarCssClass="starRating" 
                    FilledStarCssClass="FilledStars"
                    EmptyStarCssClass="EmptyStars"
                    WaitingStarCssClass="WaitingStars"></cc1:Rating>
                <br />
                
               
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
      <br />
       <br />
       <asp:Button ID="btnsubmit" runat="server" Text="Submit" class="btn-primary form-control" OnClick="btnsubmit_Click"/>
       <br />
       <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="#CC0000" ></asp:Label>
   </div>
         </form>
</asp:Content>
