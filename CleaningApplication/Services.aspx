<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Services.aspx.cs" Inherits="CleaningApplication.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<form runat="server">
	<header>
		<meta charset="utf-8">
<link href="css/bootstrap.css" rel="stylesheet">
<link href="css/style.css" rel="stylesheet">
<link href="css/responsive.css" rel="stylesheet">
<!--<link href="css/color.css" rel="stylesheet">-->

<link rel="shortcut icon" href="images/favicon.png" type="image/x-icon">
<link rel="icon" href="images/favicon.png" type="image/x-icon">

<!-- Responsive -->
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0">

	</header>

	<section class="page-title" style="background-image:url(images/background/3.jpg)">
		<div class="auto-container">
			<h2>Services</h2>
		</div>
	</section>
	<!--End Page Title-->
	
	<!--Services Section-->
	<section class="services-section">
		<div class="auto-container">
			<div class="row clearfix">
				<asp:Repeater  ID="RepterDetails"  runat="server">
					<HeaderTemplate>

					</HeaderTemplate>
					<ItemTemplate>
						 <div class="services-block-four col-lg-4 col-md-6 col-sm-12">
					<div class="inner-box">
						<div class="upper-content">
							<h3><a href="ServiceDetails.aspx?categoryid=<%#Eval("categoryid") %>">
								<asp:Label ID="Label1" runat="server" Text='<%#Eval("categoryName") %>'></asp:Label></a></h3>
							<div class="text"><asp:Label ID="Label2" runat="server" Text='<%#Eval("categoryDesc") %>'></asp:Label></div>
							<div class="icon-box">
								<span class="icon flaticon-shining"></span>
							</div>
						</div>
						<div class="lower-content">
							<div class="image">
								<a  href="ServiceDetails.aspx?categoryid=<%#Eval("categoryid") %>"><img src='<%#Eval("categoryPhoto") %>' alt="" style="width:370px; height:198px"/></a>
							</div>
						</div>
					</div>
				</div>
				
					</ItemTemplate>
					<FooterTemplate>

					</FooterTemplate>
				</asp:Repeater>
				  </div>
		</div>
	</section>
	
<script src="js/jquery.js"></script>
<script src="js/popper.min.js"></script>
<script src="js/bootstrap.min.js"></script>
<script src="js/jquery.mCustomScrollbar.concat.min.js"></script>
<script src="js/jquery.fancybox.js"></script>
<script src="js/appear.js"></script>
<script src="js/owl.js"></script>
<script src="js/wow.js"></script>
<script src="js/jquery-ui.js"></script>
<script src="js/script.js"></script>

		
	</form>

	</asp:Content>
