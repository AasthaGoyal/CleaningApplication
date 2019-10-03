<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="StoryDetails.aspx.cs" Inherits="CleaningApplication.WebForm27" %>
<%@ MasterType VirtualPath="~/Home.Master" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<form id="form1" runat="server">
		<link href="themes/1/js-image-slider.css" rel="stylesheet" type="text/css" />
	<script src="themes/1/js-image-slider.js" type="text/javascript"></script>
	<link href="generic.css" rel="stylesheet" type="text/css" />
	 <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

	<meta name="viewport" content="width=device-width, initial-scale=1" /> 
	<link href="Content/bootstrap.min.css" rel="stylesheet" /> 
	<link href="Content/site.css" rel="stylesheet" /> 
	<script src="Scripts/jquery-1.9.1.min.js"></script> 
	<script src="Scripts/bootstrap.min.js"></script>
	<link rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.css" />
		<link rel="stylesheet" href="~/css/site.css" />
		  <section class="page-title" style="background-image:url(images/background/3.jpg)">
		<div class="auto-container">
			<h2>
				<asp:Label ID="lblheading" runat="server" ></asp:Label></h2>
		</div>
	</section>
        
<div class="container">
   
   
    <br />
	 <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
   
	<table class="form-control">
		<tr>
			<td> 
				<h3 style="color: #000080; font-weight: bold; font-size: large; font-family: 'Comic Sans MS'; text-align: center"> Before </h3>
			</td>
			<td>
				 <h3 style="color: #000080; font-weight: bold; font-size: large; font-family: 'Comic Sans MS'; text-align: center"> After </h3>
		  
			</td>
		</tr>
		<tr>
			<td> 
				<asp:UpdatePanel ID="UpdatePanel1" runat="server">
		<ContentTemplate>
			<div style="padding:10px">
				   <asp:Timer ID="Timer1" runat="server" Interval="3000" OnTick="Timer1_Tick"></asp:Timer>
			<asp:Image ID="Image1" Height="400px" Width="700px" runat="server" />
		 

			</div>
		 
	   
		</ContentTemplate>
  </asp:UpdatePanel> 

			</td>
			<td>
				<asp:UpdatePanel ID="UpdatePanel2" runat="server">
		<ContentTemplate>
			<div style="padding:10px">
			<asp:Timer ID="Timer2" runat="server" Interval="3000" OnTick="Timer2_Tick"></asp:Timer>
			<asp:Image ID="Image2" Height="400px" Width="700px" runat="server" />
		 </div>

	   
		</ContentTemplate>
  </asp:UpdatePanel> 
			</td>
		</tr>
	   
	</table>
	<br />

  
    <br />
    <h4>
        <asp:Label ID="lbldesc"  Height="60px" runat="server" ></asp:Label>  </h4>
	</div>
	</form>
</asp:Content>
