<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Reviews.aspx.cs" Inherits="CleaningApplication.WebForm5" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/Home.Master" %> 

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
                 <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
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
