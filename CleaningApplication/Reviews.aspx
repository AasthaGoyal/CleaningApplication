<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Reviews.aspx.cs" Inherits="CleaningApplication.WebForm5" %>
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
			<h2>Testimonials</h2>
		</div>
	</section>
	

 <section class="testimonial-page-section">
		<div class="auto-container">
			<div class=" row clearfix">
				<asp:ScriptManager ID="ScriptManager1" runat="server">
		</asp:ScriptManager>
				

			  
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
						<div style="align-content:center">
							
							<%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
								<ContentTemplate>--%>
									<cc1:Rating ID="Rating1" runat="server"
					StarCssClass="starRating" 
					FilledStarCssClass="FilledStars"
					EmptyStarCssClass="EmptyStars"
					WaitingStarCssClass="WaitingStars"
					 CurrentRating="3"
				   ></cc1:Rating>

								<%--</ContentTemplate>
					
								</asp:UpdatePanel>--%>
		<br />
						</div>
						<br />
						<br />
						<h3>
							<asp:Label ID="lblname" runat="server" Text='<%#Eval("heading")%>'></asp:Label></h3>
						<div class="text">
							 <asp:Label ID="lblreview" runat="server" Text='<%#Eval("review") %>'></asp:Label></div>
						<br />
                         <asp:Label ID="Label1" runat="server" Text='<%#Eval("stars") %>'></asp:Label></div>
					
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
	</form>
</asp:Content>
