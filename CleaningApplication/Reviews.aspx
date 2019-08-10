<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Reviews.aspx.cs" Inherits="CleaningApplication.WebForm5" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	  <section class="page-title" style="background-image:url(images/background/3.jpg)">
		<div class="auto-container">
			<h2>Testimonials</h2>
		</div>
	</section>
	

 <section class="testimonial-page-section">
		<div class="auto-container">
			<div class=" row clearfix">
				
				<!--Testimonial Block Three-->
				 <asp:Repeater runat="server" ID="rpReviews" >
							   <HeaderTemplate>

							   </HeaderTemplate>
							   <ItemTemplate>
				<!--Testimonial Block Three-->
				<div class="testimonial-block-three masonry-item col-lg-4 col-md-6 col-sm-12">
					<div class="inner-box">
						<div class="quote-icon">
							<span class="icon flaticon-two-quotes"></span>
						</div>
						<div>
						   
							   <img src="images/background/star.jpg" width="55px" height="55px"/>
		
						</div>
						<br />
						<h3>
							<asp:Label ID="lblname" runat="server" Text='<%#Eval("heading")%>'></asp:Label></h3>
						<div class="text">
							 <asp:Label ID="lblreview" runat="server" Text='<%#Eval("review") %>'></asp:Label></div>
						<br />
						 - <b><asp:Label ID="lblHeading" runat="server" Text='<%#Eval("customerName")%>'></asp:Label></b>  
						 

					</div>
					
				</div>
				
			 </ItemTemplate>
							   <FooterTemplate>

							   </FooterTemplate>
						   </asp:Repeater>
				
		   </div>
		 </div>
	</section>
	<!--End Testimonial Page Section-->
	<%--<section class="testimonial-page-section" visible="false">
		<div class="auto-container">
			<div class="masonry-items row clearfix">
				
			  
				</div>
		</div>
	</section>--%>
	
</asp:Content>
