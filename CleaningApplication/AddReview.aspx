<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="AddReview.aspx.cs" Inherits="CleaningApplication.WebForm6" %>
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
							<asp:TextBox runat="server" height="70px" class="form-control" placeholder="Enter your message"  id="txtmessage" />
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="* Message is required" ControlToValidate="txtmessage" Font-Bold="True" ValidationGroup="requestQuote" ForeColor="#CC0000"></asp:RequiredFieldValidator>
					
						</div>
					

				</div>
                
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
         </form>
</asp:Content>
