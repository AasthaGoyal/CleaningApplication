<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="CleaningApplication.WebForm4" %>
<%@ MasterType VirtualPath="~/Home.Master" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<form runat="server">

   
	 

	<section class="in-touch-section" style="background-image:url(images/background/5.jpg)">
		<div class="auto-container">
			<div class="sec-title light">
				<h2>Get Touch With Us</h2>
				<div class="separator"></div>
			</div>
			<div class="row clearfix">
			
				<!--In Touch Block-->
				<div class="in-touch-block col-lg-4 col-md-4 col-sm-12">
					<div class="inner-box">
						<h3>Visit Our Place</h3>
						<ul>
							<li>
								<asp:Label ID="lblAddress" runat="server" ></asp:Label></li>
							
						</ul>
						<a href="https://www.google.com/maps/place/555+Richardson+Rd,+Mount+Roskill,+Auckland+1041/@-36.9197206,174.7327171,17z/data=!3m1!4b1!4m5!3m4!1s0x6d0d467eed12a785:0x7645b4142ec52985!8m2!3d-36.9197249!4d174.7349058" class="link">Find Us On Map</a>
					</div>
				</div>
				
				<!--In Touch Block-->
				<div class="in-touch-block col-lg-4 col-md-4 col-sm-12">
					<div class="inner-box">
						<h3>Phone & Mail</h3>
						<ul>
							<li>
								<asp:Label ID="lblPhone" runat="server" ></asp:Label></li>
							<li> <asp:Label ID="lblphone2" runat="server"></asp:Label></li>
							<li>
								<asp:Label ID="lblEmail" runat="server" ></asp:Label></li>
						</ul>
						<a href="mailto:swaachclean@gmail.com" class="link">Request Quote</a>
					</div>
				</div>
				
				<!--In Touch Block-->
				<div class="in-touch-block col-lg-4 col-md-4 col-sm-12">
					<div class="inner-box">
						<h3>Opening Hours</h3>
						<ul>
							<li>
								<asp:Label ID="lblTimings" runat="server" ></asp:Label></li>
						</ul>
						<a href="tel: 02040050006" class="link">24 Hrs Emergency</a>
					</div>
				</div>
				
			</div>
		</div>
	</section>
	<!--End In Touch Section-->

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
							<asp:TextBox runat="server" class="form-control" placeholder="Enter your name" type="text" id="txtname2" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* Name is required" ControlToValidate="txtname2" Font-Bold="True" ValidationGroup="requestQuote" ForeColor="#CC0000"></asp:RequiredFieldValidator>
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
							<asp:TextBox runat="server" height="70px" class="form-control" placeholder="Enter your message"  id="txtmessage2" />
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="* Message is required" ControlToValidate="txtmessage2" Font-Bold="True" ValidationGroup="requestQuote" ForeColor="#CC0000"></asp:RequiredFieldValidator>
					
						</div>
					

				</div>
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
		<ContentTemplate>
				<div class="modal-footer">
					<asp:Label ID="lblmessage2" runat="server" Font-Bold="True" ForeColor="#CC0000" ></asp:Label>
                    
	
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
							
	<!--Contact Page Section-->
	<section class="contact-page-section">
		<div class="auto-container">
			<div class="row clearfix">
				
				<!--Form Column-->
					<div class="form-column col-lg-6 col-md-12 col-sm-12">
					<div class="inner-column">
						<!--Contact Form-->
						<div class="contact-form">
							<form method="post" action="sendemail.php" id="contact-form">
								<div class="row clearfix">
									<div class="form-group col-lg-12 col-md-12 col-sm-12">

										<label>Name</label>
									  
										<asp:textbox runat="server" type="text" id="txtName" placeholder="Enter Your Name" />
									</div>
									
									<div class="form-group col-md-6 col-sm-6">
										<label>Email</label>
										<asp:TextBox runat="server" type="email"   id="txtEmail" placeholder="Email Address" />
									</div>
									
									<div class="form-group col-md-6 col-sm-6">
										<label>Phone</label>
										<asp:TextBox runat="server" type="text"   id="txtPhoneNo" placeholder="Phone" />
									</div>
									
									<div class="form-group col-md-12 col-sm-12">
										<label>Your Message</label>
									   
										<asp:TextBox runat="server" ID="txtMessage" placeholder="Your message.." Height="112px"/>
									</div>
									
								<div class="form-group col-md-12 col-sm-12">
									<asp:Button ID="btnSubmit" type="submit" class="theme-btn message-btn" runat="server" Text="Submit"  OnClick="btnSubmit_Click"  />
								
									   
									<asp:Label ID="lblMessage" runat="server" ForeColor="#CC0000" Font-Bold="True" ></asp:Label>
										</div>  
								</div>
							</form>
						</div>
						<!--End Contact Form-->
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
							<h2>Contact Persons</h2>
							<div class="separator"></div>
						</div>
						<div class="text">You can talk directly with any department you want to talk to, Feel free to contact us.</div>
						<div class="row clearfix">
						
							<asp:Repeater ID="RepStaff" runat="server">
								<HeaderTemplate>

								</HeaderTemplate>
								<ItemTemplate>
									<!--Person Block-->
							<div class="person-block col-lg-6 col-md-6 col-sm-12">
								<div class="inner-box">
									<div class="image">
										<img id="photo" src="<%#Eval("photo") %>" style="width:80px; height:80px" alt="" />
									</div>
									<h3>
										<asp:Label ID="lblName" runat="server" Text='<%#Eval("fullname") %>'></asp:Label></h3>
									<div class="title">
										<asp:Label ID="lblPosition" runat="server" Text='<%#Eval("position") %>'></asp:Label></div>
									<ul>
										<li>
											<asp:Label ID="lblPhoneNo" runat="server" Text='<%#Eval("phoneNo") %>'></asp:Label></li>
										<li>
											<asp:Label ID="lblEmailid" runat="server" Text='<%#Eval("emailid") %>'></asp:Label></li>
									</ul>
								</div>
							</div>
								</ItemTemplate>
								<FooterTemplate>

								</FooterTemplate>
							</asp:Repeater>
							
							
							
						
						</div>
					</div>
				</div>
				<%--<img src="images/main-slider/contact.png" />--%>
	<!--End Contact Page Section-->
				</div>
			</div>
	 </section>
	
	 </form>
	
   
	
</asp:Content>
