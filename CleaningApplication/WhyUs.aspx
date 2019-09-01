<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="WhyUs.aspx.cs" Inherits="CleaningApplication.WebForm10" %>
<%@ MasterType VirtualPath="~/Home.Master" %> 

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
		 <section class="page-title" style="background-image:url(images/background/3.jpg)">
		<div class="auto-container">
			<h2>About Us</h2>
		</div>
	</section>

        
	 <div class="container">
			<div class="row">
				<div class="col-xs-12">
					<div class="modal" id="quotemodal" >

		
		<div class="modal-dialog">
			<div class="modal-content">
				<div class="modal-header" style="background-color:darkblue">
                    
	   
					<h4 class="modal-title" style="color: #FFFFFF"> Request Quote</h4>
					 <button class="close" data-dismiss="modal" style="color: #FFFFFF">&times;</button>
				</div>
				<div class="modal-body">
				
						<div class="form-group">
							<label for="name"> Full Name*</label>
							<asp:TextBox runat="server" class="form-control" placeholder="Enter your name" type="text" id="nametxt" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* Name is required" ControlToValidate="nametxt" Font-Bold="True" ValidationGroup="requestQuote" ForeColor="#CC0000"></asp:RequiredFieldValidator>
						</div>
						<div class="form-group">
							 <label for="name"> Email Id</label>
							<asp:TextBox runat="server" class="form-control" placeholder="Enter your emailid"  id="emailidtxt" />

						</div>
						<div class="form-group">
							 <label for="name"> Phone No*</label>
							<asp:TextBox runat="server" class="form-control" placeholder="Enter your Contact No"  id="phonetxt" />
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="* Phone is required" ControlToValidate="phonetxt" Font-Bold="True" ValidationGroup="requestQuote" ForeColor="#CC0000"></asp:RequiredFieldValidator>
					
						</div>
						<div class="form-group">
							 <label for="name"> Message*</label>
							<asp:TextBox runat="server" height="70px" class="form-control" placeholder="Enter your message"  id="messagetxt" />
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="* Message is required" ControlToValidate="messagetxt" Font-Bold="True" ValidationGroup="requestQuote" ForeColor="#CC0000"></asp:RequiredFieldValidator>
					
						</div>
					

				</div>
                 <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
		<ContentTemplate>
				<div class="modal-footer">
					<asp:Label ID="messagelbl" runat="server" Font-Bold="True" ForeColor="#CC0000" ></asp:Label>
                    
	
					<asp:Button ID="btnConfirm" runat="server" ValidationGroup="requestQuote" Text="Confirm" class="btn btn-primary" OnClick="btnConfirm_Click"/>
					<%--<button id="btnConfirm" class="btn btn-primary" AutoPostBack="true" onclick="btnConfirm_onClick" >Submit</button>--%>
					<button class="btn btn-primary" data-dismiss ="modal"> Close</button>
				</div>
             </ContentTemplate>

		 <Triggers>
			 <asp:AsyncPostBackTrigger ControlID="btnConfirm" EventName="Click" />
		 </Triggers>
	</asp:UpdatePanel>
			</div>
		</div>
			</div>
		
				</div>
			</div>
		</div>
       
		 <section class="client-section">
		<div class="image-layer" style="background-image:url(images/background/4.jpg)"></div>
		<div class="auto-container">
		
			<!--Upper Section-->
			<div class="upper-section">
				<div class="row clearfix">
					
					<!--Carousel Column-->
					<div class="carousel-column col-lg-6 col-md-12 col-sm-12">
						<div class="inner-column">
							<div class="single-item-carousel owl-carousel owl-theme">
								
								<div class="slide">
									<div class="image">
										<img src="images/resource/image1.jpg" alt="" />
									</div>
								</div>
								
								<div class="slide">
									<div class="image">
										<img src="images/resource/image2.jpg" alt="" />
									</div>
								</div>
								
								<div class="slide">
									<div class="image">
										<img src="images/resource/image3.png" alt="" />
									</div>
								</div>
								
							</div>
						</div>
					</div>
					
					<!--Content Column-->
					<div class="content-column col-lg-6 col-md-12 col-sm-12">
						<div class="inner-column">
							<!--Sec Title-->
							<div class="sec-title">
								<div class="icon-box">
									<span class="icon flaticon-broom"></span>
								</div>
								<h2>
                                    <asp:Label ID="lbltagline" runat="server" ></asp:Label></h2>
								<div class="separator"></div>   
							</div>
							<div class="text" >
								<p style="color: #000000">
                                    <asp:Label ID="lblline1" runat="server" ></asp:Label></p>
								<p style="color: #000000"> <asp:Label ID="lblline2" runat="server" ></asp:Label></p>
							</div>
						</div>
					</div>
					
				</div>
			</div>
			
			<!--Lower Section-->
			<div class="lower-section">
				<div class="row clearfix">
					
					<!--Services Block Three-->
					<div class="services-block-three col-lg-4 col-md-6 col-sm-12">
						<div class="inner-box">
							<h3><a href="carpet-cleaning.html">Our Core Values</a></h3>
							<div class="text">
                                <asp:Label ID="lblvalues" runat="server" ></asp:Label></div>
						</div>
					</div>
					
					<!--Services Block Three-->
					<div class="services-block-three col-lg-4 col-md-6 col-sm-12">
						<div class="inner-box">
							<h3><a href="carpet-cleaning.html">Our Mission</a></h3>
							<div class="text">
                                <asp:Label ID="lblmission" runat="server" ></asp:Label></div>
						</div>
					</div>
					
					<!--Services Block Three-->
					<div class="services-block-three col-lg-4 col-md-6 col-sm-12">
						<div class="inner-box">
							<h3><a href="carpet-cleaning.html">Our Vision</a></h3>
							<div class="text">
                                <asp:Label ID="lblvision" runat="server" ></asp:Label></div>
						</div>
					</div>
					
				</div>
			</div>
			
		</div>
	</section>

	 <section class="featured-section-three">
		<div class="auto-container">
			<!--Sec Title-->
			<div class="sec-title centered">
				<div class="icon-box">
					<span class="icon flaticon-broom"></span>
				</div>
				<h2>Why Choose Us</h2>
				<div class="separator"></div>
			</div>
			<div class="row clearfix">
				
				<!--Image Column-->
				<div class="image-column col-lg-6 col-md-12 col-sm-12">
					<div class="image wow bounce" data-wow-delay="600ms" data-wow-duration="1500ms">
						<img src="images/main-slider/green-cleaning.png" alt="" />
					</div>	
				</div>
				
				<!--Left Column-->
				<div class="left-column order-first col-lg-3 col-md-6 col-sm-12">
					
					<!--Featured Block Three-->
					<div class="featured-block-three">
						<div class="inner-box wow fadeInLeft" data-wow-delay="0ms" data-wow-duration="1500ms">
							<div class="icon-box">
								<span class="icon flaticon-staff"></span>
							</div>
							<h3><a href="case-single.html">Highly motivated and professional Team</a></h3>
							<div class="text">Our team is trained and certified to specalize in cleaning</div>
						</div>
					</div>
					
					<!--Featured Block Three-->
					<div class="featured-block-three">
						<div class="inner-box wow fadeInLeft" data-wow-delay="300ms" data-wow-duration="1500ms">
							<div class="icon-box">
								<span class="icon flaticon-medal-1"></span>
							</div>
							<h3><a href="case-single.html">Extensive in-house training for all newbies</a></h3>
							<div class="text">We believe in 'Practice makes one perfect' and provide in-house training for the new members </div>
						</div>
					</div>
					
					<!--Featured Block Three-->
					<div class="featured-block-three">
						<div class="inner-box wow fadeInLeft" data-wow-delay="600ms" data-wow-duration="1500ms">
							<div class="icon-box">
								
								<span class="icon flaticon-vacuum"></span>
							</div>
							<h3><a href="case-single.html">Satisfaction Guaranteed</a></h3>
							<div class="text">Our reputation is for excellence and we provide all services so our customers are always satisfied with our services</div>
						</div>
					</div>
					
				</div>
				
				<!--Right Column-->
				<div class="right-column order-last col-lg-3 col-md-6 col-sm-12">
					
					<!--Featured Block Four-->
					<div class="featured-block-four">
						<div class="inner-box wow fadeInRight" data-wow-delay="0ms" data-wow-duration="1500ms">
							<div class="icon-box">
								<span class="icon flaticon-benefits"></span>
							</div>
							<h3><a href="case-single.html">Cost effective and Budget oriented</a></h3>
							<div class="text">We provide more services at a cost that is affordable so along with a clean house, you can spend money on things you love</div>
						</div>
					</div>
					
					<!--Featured Block Four-->
					<div class="featured-block-four">
						<div class="inner-box wow fadeInRight" data-wow-delay="300ms" data-wow-duration="1500ms">
							<div class="icon-box">
								<span class="icon flaticon-vacuum"></span>
							</div>
							<h3><a href="case-single.html">Immediate and Accurate Online quotes</a></h3>
							<div class="text">If you are not sure of the price of your service, you can always ask for a free online quote</div>
						</div>
					</div>
					
					<!--Featured Block Four-->
					<div class="featured-block-four">
						<div class="inner-box wow fadeInRight" data-wow-delay="600ms" data-wow-duration="1500ms">
							<div class="icon-box">
								<span class="icon flaticon-soap"></span>
							</div>
							<h3><a href="case-single.html">Quality approved and eco-friendly products</a></h3>
							<div class="text">All our products are quality approved and eco-friendly so we contribute to a clean and green environment along with your clean house</div>
						</div>
					</div>
					
				</div>
				
			</div>
		</div>
	</section>

		 <section class="expert-section">
		<div class="auto-container">
			<div class="row clearfix">
				
				<!--Title Column-->
				<div class="title-column col-lg-3 col-md-12 col-sm-12">
					<div class="inner-column">
						<!--Sec Title-->
						<div class="sec-title light">
							<div class="icon-box">
								<span class="icon flaticon-broom"></span>
							</div>
							<h2>Our Experts</h2>
							<div class="separator"></div>
						</div>
						<div class="text">Our team consist of fully trained experts. Every individuals trained in every aspects of our cleaning services.</div>
						<a href="ContactUs.aspx" class="theme-btn btn-style-four">View All</a>
					</div>
				</div>
				
				<!--Blocks Column-->
				<div class="blocks-column col-lg-9 col-md-12 col-sm-12">
					<div class="inner-column">
						<div class="three-item-carousel owl-carousel owl-theme">
				<asp:Repeater runat="server" ID="repStaff">
								<HeaderTemplate>

								</HeaderTemplate>
								<ItemTemplate>
				
							
									<div class="team-block">
								<div class="inner-box">
									<div class="image">
										<img src="images/resource/team-2.jpg" />
										 <ul class="social-option">
											<li><a href="#"><span class="fa fa-facebook"></span></a><span class="tooltip-data">facebook</span></li>
											<li><a href="#"><span class="fa fa-twitter"></span></a><span class="tooltip-data">twitter</span></li>
										</ul>
									</div>
									<div class="lower-box">
										<h3><a href="mailto:<%#Eval("emailid") %>">
											<asp:Label ID="lblname" runat="server" Text='<%#Eval("fullname") %>'></asp:Label></a></h3>
										<div class="designation">
											<asp:Label ID="lblPosition" runat="server" Text='<%#Eval("position") %>'></asp:Label></div>
									</div>
								</div>
							</div>

							
							<!--Team Block-->

						</ItemTemplate>
								<FooterTemplate>

								</FooterTemplate>
							</asp:Repeater>
							</div>
					</div>
				</div>
						
				
			</div>
		</div>
	</section>

	  <section class="reviews-section">
		<div class="auto-container">
			<!--Title Box-->
			<div class="title-box">
				<h2>What our Customers Say</h2>
			   
				<div class="text">“See what our customers say and how did they find our services”</div>
			</div>
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
	</form>
</asp:Content>
