	<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CleaningApplication.WebForm1" %>
<%@ MasterType VirtualPath="~/Home.Master" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<form runat="server">


		
	<section class="main-slider">
		
		<div class="main-slider-carousel owl-carousel owl-theme">
			
			<div class="slide" style="background-image:url(images/main-slider/image-1.jpg);  height:700px;">
				<div class="auto-container">
					<div class="content">
						<div class="title">Referred for a reason.</div>
						<h2>Clean Home. <br> Professional Service. <br> Fair Price.</h2>
						<a href="ContactUs.aspx" class="theme-btn btn-style-one">Contact Us</a>
					</div>
				</div>
			</div>
			
			<div class="slide" style="background-image:url(images/main-slider/image-2.jpg);  height:700px;">
				<div class="auto-container">
					<div class="content alternate">
						<div class="title">We provide cleaning services at affordable prices</div>
						<h2>Provides high quality <br> cleaning services</h2>
						<a href="Services.aspx" class="theme-btn btn-style-one">Our Services</a>
					</div>
				</div>
			</div>
			
			<div class="slide" style="background-image:url(images/main-slider/image-3.jpg);  height:700px;">
				<div class="auto-container">
					<div class="content">
						<div class="title ">We make sure that out customer are happy</div>
						<h2 >Why should you <br> choose us? <br> </h2>
						<a href="WhyUs.aspx" class="theme-btn btn-style-two">Read More</a>
					</div>
				</div>
			</div>
			
		</div>
	</section>

  

	<section class="welcome-section">
		<div class="auto-container">
			<!--Sec Title-->
			<div class="sec-title">
				<div class="clearfix">
					<div class="pull-left">
						<div class="icon-box">
							<span class="icon flaticon-broom"></span>
						</div>
						<h2>Welcome to Swaach Cleaning</h2>
						<div class="separator"></div>
					</div>
					<div class="pull-right">
						<div class="text">We understand the importance of making a good first impression <br /> and believe in cleaning with Perfection.</div>
					</div>
				</div>
			</div>
			
			<div class="row clearfix">
				
				<!--Welcome Block-->
				<%--<div class="welcome-block col-lg-6 col-md-12 col-sm-12">
					<div class="inner-box wow fadeInLeft" data-wow-delay="0ms" data-wow-duration="1500ms">
						<div class="image">
							<a href="carpet-cleaning.html"><img src="images/resource/welcome-1.jpg" alt="" /></a>
							<div class="content-outer">
								<div class="content">
									<h3>Commercial & Society</h3>
									<div class="text">Inventore veritatis et quasi architecto beatae.</div>
								</div>
								<a href="carpet-cleaning.html" class="arrow flaticon-next-5"></a>
							</div>
						</div>
					</div>
				</div>
				
				<!--Welcome Block-->
				<div class="welcome-block alternate col-lg-6 col-md-12 col-sm-12">
					<div class="inner-box wow fadeInRight" data-wow-delay="0ms" data-wow-duration="1500ms">
						<div class="image">
							<a href="carpet-cleaning.html"><img src="images/resource/welcome-2.jpg" alt="" /></a>
							<div class="content-outer">
								<div class="content">
									<h3>Carpet & Cleaning</h3>
									<div class="text">Inventore veritatis et quasi architecto beatae.</div>
								</div>
								<a href="carpet-cleaning.html" class="arrow flaticon-next-5"></a>
							</div>
						</div>
					</div>
				</div>
				--%>
			</div>
			
		</div>
	</section>

	

		<section class="featured-section">
		<div class="auto-container">
			 <div class="sec-title centered">
				<div class="icon-box">
					<span class="icon flaticon-broom"></span>
				</div>
				<h2>Featured Services</h2>
				<div class="separator"></div>
			</div>
			<div class="three-item-carousel owl-carousel owl-theme">
				<asp:Repeater runat="server" ID="RepterDetails">
					<HeaderTemplate>

					</HeaderTemplate>
					<ItemTemplate>
						 <div class="featured-block">
					<div class="inner-box">
						<div class="upper-content">
							<h3><a href="ServiceDetails.aspx?categoryid=<%#Eval("categoryid") %>">	<asp:Label ID="Label1" runat="server" Text='<%#Eval("categoryName") %>'></asp:Label></a></h3>
							<div class="text"><asp:Label ID="Label2" runat="server" Text='<%#Eval("categoryDesc") %>'></asp:Label></div>
							<div class="icon-box">
								<span class="icon flaticon-shining"></span>
							</div>
						</div>
						<div class="lower-content">
							<div class="image">
								<a href="ServiceDetails.aspx?categoryid=<%#Eval("categoryid") %>"><img src='<%#Eval("categoryPhoto") %>' alt="" style="width:370px; height:198px"/></a>
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
							<asp:TextBox runat="server" class="form-control" placeholder="Enter your name" type="text" id="txtname" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* Name is required" ControlToValidate="txtname" Font-Bold="True" ValidationGroup="requestQuote" ForeColor="#CC0000"></asp:RequiredFieldValidator>
						</div>
						<div class="form-group">
							 <label for="name"> Email Id</label>
							<asp:TextBox runat="server" class="form-control" placeholder="Enter your emailid"  id="txtemailid" />

						</div>
						<div class="form-group">
							 <label for="name"> Phone No*</label>
							<asp:TextBox runat="server" class="form-control" placeholder="Enter your Contact No"  id="txtPhone" />
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="* Phone is required" ControlToValidate="txtPhone" Font-Bold="True" ValidationGroup="requestQuote" ForeColor="#CC0000"></asp:RequiredFieldValidator>
					
						</div>
						<div class="form-group">
							 <label for="name"> Message*</label>
							<asp:TextBox runat="server" height="70px" class="form-control" placeholder="Enter your message"  id="txtmessage" />
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="* Message is required" ControlToValidate="txtmessage" Font-Bold="True" ValidationGroup="requestQuote" ForeColor="#CC0000"></asp:RequiredFieldValidator>
					
						</div>
					

				</div>
                 <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
		<ContentTemplate>
				<div class="modal-footer">
					<asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="#CC0000" ></asp:Label>
                    
	
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
       
   

	<!--Process Section-->
	   <section class="process-section" style="background-image:url(images/background/1.jpg)">
		<div class="top-layer"></div>
		<div class="auto-container">
			<!--Sec Title-->
			<div class="sec-title centered">
				<div class="icon-box">
					<span class="icon flaticon-broom"></span>
				</div>
				<h2>our Work Process</h2>
				<div class="separator"></div>
			</div>
			
			<!--Process Blocks-->
			<div class="process-blocks">
				<div class="clearfix row">
					
					<!--Process Block-->
					<div class="process-block col-lg-3 col-md-6 col-sm-12">
						<div class="inner-box wow fadeInLeft" data-wow-delay="0ms" data-wow-duration="1500ms">
							<div class="icon-box">
								<span class="icon ">
									<img src="images/background/wp1.png" height="80px" width="80px" /></span>
							</div>
							<div class="number-line">
								<div class="number">1</div>
							</div>
							<div class="text">
								<asp:Label ID="lblhead1" runat="server" ></asp:Label></div>
						</div>
					</div>
					
					<!--Process Block-->
					<div class="process-block col-lg-3 col-md-6 col-sm-12">
						<div class="inner-box wow fadeInUp" data-wow-delay="0ms" data-wow-duration="1500ms">
							<div class="icon-box">
								<span class="icon flaticon-brush-2"></span>
							</div>
							<div class="number-line">
								<div class="number">2</div>
							</div>
							<div class="text"> <asp:Label ID="lblhead2" runat="server" ></asp:Label></div>
						</div>
					</div>
					
					<!--Process Block-->
					<div class="process-block col-lg-3 col-md-6 col-sm-12">
						<div class="inner-box wow fadeInUp" data-wow-delay="0ms" data-wow-duration="1500ms">
							<div class="icon-box">
								<span class="icon ">
									<img src="images/background/w3.png" height="80px" width="80px"/>
								</span>
							</div>
							<div class="number-line">
								<div class="number">3</div>
							</div>
							<div class="text"> <asp:Label ID="lblhead3" runat="server" ></asp:Label></div>
						</div>
					</div>
					
					<!--Process Block-->
					<div class="process-block col-lg-3 col-md-6 col-sm-12">
						<div class="inner-box wow fadeInRight" data-wow-delay="0ms" data-wow-duration="1500ms">
							<div class="icon-box">
								<span class="icon flaticon-spray-1">
									
								</span>
							</div>
							<div class="number-line">
								<div class="number">4</div>
							</div>
							<div class="text"> <asp:Label ID="lblhead4" runat="server" ></asp:Label></div>
						</div>
					</div>
					
				</div>
				</div>
	
				
			
			<!--Fact Counter-->
			<div class="fact-counter">
				<div class="row clearfix">
					
					<!--Column-->
					<div class="column counter-column col-lg-3 col-md-6 col-sm-12">
						<div class="inner">
							<div class="content">
								<div class="count-outer count-box">
									<span class="count-text" data-speed="4000" data-stop="2.4">0</span>K
								</div>
								<h4 class="counter-title">Projects Completed</h4>
							</div>
						</div>
					</div>
			
					<!--Column-->
					<div class="column counter-column col-lg-3 col-md-6 col-sm-12">
						<div class="inner">
							<div class="content">
								<div class="count-outer count-box">
									<span class="count-text" data-speed="2500" data-stop="1.8">0</span>K
								</div>
								<h4 class="counter-title">Positive Customers</h4>
							</div>
						</div>
					</div>
			
					<!--Column-->
					<div class="column counter-column col-lg-3 col-md-6 col-sm-12">
						<div class="inner">
							<div class="content">
								<div class="count-outer count-box">
									<span class="count-text" data-speed="4000" data-stop="236">0</span>
								</div>
								<h4 class="counter-title">Staff & Expert Cleaners</h4>
							</div>
						</div>
					</div>
					
					<!--Column-->
					<div class="column counter-column col-lg-3 col-md-6 col-sm-12">
						<div class="inner">
							<div class="content">
								<div class="count-outer count-box">
									<span class="count-text" data-speed="3000" data-stop="05">0</span>
								</div>
								<h4 class="counter-title">Authorised Certification</h4>
							</div>
						</div>
					</div>
			
				</div>
			</div>
			
		</div>
	</section>
	<!--End Process Section-->

	<section class="cleaner-section">
		<div class="auto-container">
			<!--Sec Title-->
			<div class="sec-title">
				<div class="icon-box">
					<span class="icon flaticon-broom"></span>
				</div>
				<h2>Why choose us?</h2>
				<div class="separator"></div>
			</div>
			
			<!--Upper Section-->
			<div class="upper-section">
				<div class="row clearfix">
					
					<div class="column col-lg-6 col-md-12 col-sm-12">
						<div class="text">
							<p>Our main aim is "Cleaning with Perfection", to follow which we offer cost-effective services which uses all eco-friendly products so our environment remains green and safe. Also, our highly motivated team will finish every job and make sure that our customers are satisfied with the job.</p>
							<%--<p>Shortly after opening, founder Mitchel Sweedon offered something special cleaning backed by a 100% best carpet cleaner satisfaction guarantee. As a result, his small business flourished & many more cleaning services were added in our company.</p>--%>
						</div>
					</div>
					
					<div class="images-column col-lg-6 col-md-12 col-sm-12">
						<div class="inner-column">
							<div class="row clearfix">
								<!--Image Column-->
								<div class="image-column col-lg-6 col-md-6 col-sm-12">
									<div class="image">
										<img src="images/resource/cleaner-1.jpg" />
										
										
									</div>
								</div>
								<!--Image Column-->
								<div class="image-column col-lg-6 col-md-6 col-sm-12">
									<div class="image">
										<img src="images/main-slider/cleaner-2.png"  />
									</div>
								</div>
							</div>
						</div>
					</div>
					
				</div>
			</div>
			
			<!--Lower Section-->
			<div class="lower-section">
				<div class="row clearfix">
				
					<!--Video Column-->
					<div class="video-column col-lg-6 col-md-12 col-sm-12">
						<div class="inner-column">
							<div class="video-box">
								<figure class="image">
									<img src="images/main-slider/green-cleaning.png" >
								</figure>
								<%--<a href="https://www.youtube.com/watch?v=kxPCFljwJws" class="lightbox-image overlay-box"><span class="flaticon-play-arrow"></span><div class="text">About Company</div></a>--%>
							</div>
						</div>
					</div>
					
					<!--Accordian Column-->
					<div class="accordian-column col-lg-6 col-md-12 col-sm-12">
						<div class="inner-column">
							
							<!--Accordian Box-->
							<ul class="accordion-box">
								
								<!--Block-->
								<li class="accordion block">
									<div class="acc-btn"><div class="icon-outer flaticon-tick-inside-circle"></div>Satisfaction Guaranteed.</div>
									<div class="acc-content">
										<div class="content">
											<div class="text">Choose us because of our reputation for excellence. Our highly trained and motivated team makes sure that our cutsomers are happy and satisfied with our services.</div>
										</div>
									</div>
								</li>
		
								<!--Block-->
								<li class="accordion block active-block">
									<div class="acc-btn active"><div class="icon-outer flaticon-tick-inside-circle"></div>We use eco-friendly products</div>
									<div class="acc-content current">
										<div class="content">
											<div class="text">We make sure that along with cleaning your houses, our enviornment is not degrading, for which all our products are eco-friendly keeping our enviornment clean and green. </div>
										</div>
									</div>
								</li>
								
								<!--Block-->
								<li class="accordion block">
									<div class="acc-btn"><div class="icon-outer flaticon-tick-inside-circle"></div>Immediate, Accurate Online Quotes.</div>
									<div class="acc-content">
										<div class="content">
											<div class="text">We are always here to help you find the price and service that you are looking for. We provide on-call help and email quotes to provide you 24/7 support.</div>
										</div>
									</div>
								</li>
								
								<!--Block-->
								<li class="accordion block">
									<div class="acc-btn"><div class="icon-outer flaticon-tick-inside-circle"></div>Cost effective and Budget oriented</div>
									<div class="acc-content">
										<div class="content">
											<div class="text">We understand that cleaning your property can be a tiring and expensive task, and we provide cost effective services to make sure you get your house clean along with saving money.</div>
										</div>
									</div>
								</li>
								
								<!--Block-->
								<li class="accordion block">
									<div class="acc-btn"><div class="icon-outer flaticon-tick-inside-circle"></div>Trained contractors and Highly motivated team</div>
									<div class="acc-content">
										<div class="content">
											<div class="text">Our cleaning team is highly motivated and trained to guarantee best services. We train our contractors in-house but no contractors used on the job.</div>
										</div>
									</div>
								</li>
								
							</ul>
							
						</div>
					</div>
					
				</div>
			</div>
			
		</div>
	</section>

	 <section class="feedback-section">
		<div class="auto-container">
			<!--Sec Title-->
			<div class="sec-title centered">
				<div class="icon-box">
					<span class="icon flaticon-broom"></span>
				</div>
				<h2>Customers Feedback</h2>
				<div class="separator"></div>
			</div>
			
		 <div class="feedback-carousel owl-carousel owl-theme">
				<asp:Repeater ID="rpReviews" runat="server" >
					<HeaderTemplate>

					</HeaderTemplate>
					<ItemTemplate>
						  <div class="feedback-block">
					<div class="inner-box">
						<div class="image">
							<a href="carpet-cleaning.html"><img src="images/resource/feedback-1.jpg" alt="" /></a>
						</div>
						<div class="lower-content">
							<div class="quote-icon">
								<span class="icon flaticon-two-quotes"></span>
							</div>
							<h3><a href="carpet-cleaning.html">
								<asp:Label ID="lblname" runat="server" Text='<%#Eval("customerName") %>'></asp:Label></a></h3>
							<%--<div class="rating">
								<span class="fa fa-star-o"></span>
								<span class="fa fa-star-o"></span>
								<span class="fa fa-star-o"></span>
								<span class="fa fa-star-o"></span>
								<span class="fa fa-star-o"></span>
							</div>--%>
							<div class="text">
								<asp:Label ID="lblheading" runat="server" Text='<%#Eval("heading") %>'></asp:Label>
								<asp:Label ID="lblReview" runat="server" Text='<%#Eval("review") %>'></asp:Label></div>
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
	<!--End Feedback Section-->

		<section class="feedback-section">
		<div class="auto-container">
			<!--Sec Title-->
			<div class="sec-title centered">
				<div class="icon-box">
					<span class="icon flaticon-broom"></span>
				</div>
				<h2>Our Clients</h2>
				<div class="separator"></div>
			</div>

			<asp:DataList ID="dlClients" runat="server" DataSourceID="SqlDataSource1" RepeatColumns="6">
				<ItemTemplate>
					<asp:Image ID="Image1" runat="server" Height="202px" Width="271px" ImageUrl='<%# Eval("clientLogo") %>'/>
					<br />
					<center>
					<asp:Label ID="clientNameLabel" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#000066" Text='<%# Eval("clientName") %>' />
					</center>
						
				</ItemTemplate>
			</asp:DataList>
			<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbcleaningConnectionString %>" SelectCommand="SELECT [clientLogo], [clientName] FROM [tbclient]"></asp:SqlDataSource>
			</div>
			</section>


		</form>

	</asp:Content>
