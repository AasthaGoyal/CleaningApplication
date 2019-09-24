<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="StoryDetails.aspx.cs" Inherits="CleaningApplication.WebForm24" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
       
             <header>
        	<meta charset="utf-8">
<link href="css/bootstrap.css" rel="stylesheet">
<link href="css/style.css" rel="stylesheet">
<link href="css/responsive.css" rel="stylesheet">

     <link href="themes/1/js-image-slider.css" rel="stylesheet" type="text/css" />
    <script src="themes/1/js-image-slider.js" type="text/javascript"></script>
    <link href="generic.css" rel="stylesheet" type="text/css" />
<!--<link href="css/color.css" rel="stylesheet">-->

<link rel="shortcut icon" href="images/favicon.png" type="image/x-icon">
<link rel="icon" href="images/favicon.png" type="image/x-icon">

<!-- Responsive -->
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0">

<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
	</header>
           <section class="page-title" style="background-image:url(images/background/3.jpg)">
		<div class="auto-container">
			<h2>
                <asp:Label ID="lblheading" runat="server" ></asp:Label></h2>
		</div>
	</section>
        <asp:TextBox ID="txtbox" runat="server"></asp:TextBox>
        <br />
        <div id="sliderFrame">
        <div id="slider">
      
           <div id="myCarousel" class="carousel slide">
  <%--<ol class="carousel-indicators">
    <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
    <li data-target="#myCarousel" data-slide-to="1"></li>
    <li data-target="#myCarousel" data-slide-to="2"></li>
  </ol>--%>
  <!-- Carousel items -->
  <div class="carousel-inner" role="listbox">
      <asp:Repeater ID="Repeater1" runat="server">
          <ItemTemplate>
               <div class= 'item <%#Container.ItemIndex==0?"Active":""%>'>
                   <asp:Image ID="Image1" runat="server" src="<%# Eval("imagePhoto") %>" alt=""/>
                   <div class="carousel-caption"></div>
               </div>


          </ItemTemplate>
      </asp:Repeater>
   
  
  </div>
  <!-- Carousel nav -->
  <a class="carousel-control left" href="#myCarousel" data-slide="prev">&lsaquo;</a>
  <a class="carousel-control right" href="#myCarousel" data-slide="next">&rsaquo;</a>
</div>
         
       
     
        </div>
       
    </div>
    </form>
</asp:Content>
