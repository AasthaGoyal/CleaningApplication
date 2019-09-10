<%@ Page Title="" Language="C#" MasterPageFile="~/ServicesNested.master" AutoEventWireup="true" CodeBehind="BookServices.aspx.cs" Inherits="CleaningApplication.WebForm21" %>
<%@ MasterType VirtualPath="~/ServicesNested.master" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <header>
          <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    </header>
    <table class="form-control" style="width:100%">
		<tr>
			<td width="20%"> First Name *</td>
			<td width="80%">        <asp:TextBox class="form-control"  placeholder="Your First name" ID="txtfirstname" runat="server"></asp:TextBox>
			 </td>
		</tr>
			<tr>
				<td>
					Last Name *

				</td>
				<td> <asp:TextBox class="form-control" placeholder="Your Last name" ID="txtlastname" runat="server"></asp:TextBox>
		   </td>
			</tr>
		<tr>
			<td>
				<br /><b>Street Address </b>
				<br />
			</td>
		
		</tr>
		<tr>
			<td>   House/ Street No *

			  </td>
			<td>
				<asp:TextBox class="form-control" placeholder="House or Street No" ID="txtstreetno" runat="server"></asp:TextBox>
				   
			</td>
		</tr>
		<tr>
			<td> Town/City *</td>
		   
			<td>    <asp:TextBox class="form-control" placeholder="Your Town/City" ID="txttown" runat="server"></asp:TextBox>
			 </td>
		   </tr>
		<tr>
			<td> Region (optional)</td>
			<td>
				   <asp:TextBox class="form-control" placeholder="Your Region (optional)" ID="txtregion" runat="server"></asp:TextBox>
			 
			</td>
		</tr>
		<tr>
			<td> 
			   
				Postcode *</td>
			<td>   
			   <asp:TextBox class="form-control" placeholder="Your Postcode" ID="txtpostcode" runat="server"></asp:TextBox>
			 </td>
		</tr>
		<tr>
			<td> <br />Phone No *</td>
			<td>   <br /> <asp:TextBox class="form-control" placeholder="Your Phone No" ID="txtphone" runat="server"></asp:TextBox>
			 </td>
		</tr>
		<tr>
			<td> Email address *</td>
			<td>    <asp:TextBox class="form-control" placeholder="Your Email Id" ID="txtemail" runat="server"></asp:TextBox>
			 </td>
		</tr>
		
	   <tr>
			<td>
				<br /><b>Booking Details </b>
				<br />
			</td>
	   </tr>
		<tr>
			<td> Preferred date *</td>
			<td> <input type="date" id="txtdate" runat="server" class="form-control" /></td>
		</tr>
		<tr>
			<td> Preferred Time *</td>
			<td> <input type="time" id="txttime" runat="server" class="form-control" /></td>
		</tr>
		<tr>
			 <td colspan="2">
				<br /><b>Any additional information or notes </b>
				<br />
			</td>

		</tr>
		<tr>
			<td colspan="2"> <asp:TextBox ID="txtnotes" placeholder="Notes" height="50px" CssClass="form-control" runat="server"></asp:TextBox></td>
		</tr>
			</table>
	<br />
	<h4> <asp:Label ID="Label1" runat="server" Text="Your Order" Font-Bold="True" Font-Size="Medium" ForeColor="#000066"></asp:Label></h4>
	<br />
	
		<asp:table ID="myTable" runat="server" class="form-control" BorderStyle="Solid" >
	  <asp:tableRow Width="100%">
		  <asp:tablecell width="90%" style="text-align:left"> <b>Items:</b></asp:tablecell>
		  <asp:tablecell width="10%" style=" font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif; font-size: medium; font-weight: bold; text-transform: capitalize; text-align:right"> <b>Price: </b> </asp:tablecell>
	  </asp:tableRow>
	 
  </asp:table>
	<br />
	<asp:Table ID="total" runat="server" CssClass="form-control" BackColor="#CC0000" Font-Bold="True" ForeColor="White">
		<asp:TableRow Width="100%">
			<asp:TableCell Width="90%"  style="text-align:left">
				Total Price:
			</asp:TableCell>
			<asp:TableCell Width="10%"  style="text-align:right">
				<asp:Label ID="lblTotal" runat="server"></asp:Label>
			</asp:TableCell>

		</asp:TableRow>
	</asp:Table>
  <br />
  <%--  <asp:Button ID="btnshow"  AutoPostBack="false" runat="server" Text="Button"  OnClientClick="returnAmount();"/>
  --%>  <%--<asp:HiddenField runat="server" ID="hiddenTotal" />--%>
	<br />
    <h3>Proceed to Payment</h3>
    <br />
     <div id="paypal-button-container"></div>
     <asp:HiddenField id="hidden" Value="2" runat="server"> </asp:HiddenField>
    <!-- Include the PayPal JavaScript SDK -->
    <script src="https://www.paypal.com/sdk/js?client-id=ARXG0L7C9sWQzfjZmRsRqzUQWede7HWhjYjK8mdXKDklZmwLZtuhhGGIOMGXaxOnb1noQuAYLPSW_Xrp&currency=NZD"></script>

    <script>
        <%--function returnAmount() {
            var amount = document.getElementById('<%=lblTotal.ClientID%>').value;
              document.getElementById('<%=lblmessage.ClientID %>').value = 'Done'+ amount;
              
        }--%>

       // Render the PayPal button into #paypal-button-container
        paypal.Buttons({

            // Set up the transaction
            createOrder: function (data, actions) {

            return actions.order.create({
                purchase_units: [{
                    amount: {

                        value: '2.0'
                        }
                }]
                });
        },

            // Finalize the transaction
            onApprove: function(data, actions) {
            return actions.order.capture().then(function(details) {
                // Show a success message to the buyer
                alert('Transaction completed by ' + details.payer.name.given_name + '!');
                document.getElementById('<%=hidden.ClientID %>').value = 'Done';
                });
            }


        }).render('#paypal-button-container');
    </script>
    <br />
	<asp:Button ID="btnfinish" runat="server" class="btn-success form-control" Text="Finish Booking" OnClick="btnfinish_Click" />
	<br />
	<asp:Label ID="lblmessage" runat="server" Font-Bold="True" ForeColor="#CC0000" ></asp:Label>
    <br />
   
    <br />
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
							<asp:TextBox runat="server" class="form-control" placeholder="Enter your Contact No"  id="txtphone2" />
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="* Phone is required" ControlToValidate="txtphone2" Font-Bold="True" ValidationGroup="requestQuote" ForeColor="#CC0000"></asp:RequiredFieldValidator>
					
						</div>
						<div class="form-group">
							 <label for="name"> Message*</label>
							<asp:TextBox runat="server" height="70px" class="form-control" placeholder="Enter your message"  id="txtmessage" />
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="* Message is required" ControlToValidate="txtmessage" Font-Bold="True" ValidationGroup="requestQuote" ForeColor="#CC0000"></asp:RequiredFieldValidator>
					
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
						
</asp:Content>
