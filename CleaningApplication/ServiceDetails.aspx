 <%@ Page Title="" Language="C#" MasterPageFile="~/ServicesNested.master" AutoEventWireup="true" CodeBehind="ServiceDetails.aspx.cs" Inherits="CleaningApplication.WebForm3" %>
<%@ MasterType VirtualPath="~/ServicesNested.Master" %> 

<%--<asp:Content ID="Content1" ContentPlaceHolderID="Cont1" runat="server">
	<h2>
		
		<asp:Label ID="lblname"  runat="server" ></asp:Label></h2>
<%--</asp:Content>--%>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="Cont2" runat="server">
	<h3>Services/<asp:Label ID="lblname2"  runat="server" ></asp:Label></h3>
<%--</asp:Content>--%>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="Cont3" runat="server">
	<p> <asp:label runat="server" id="lblDesc"></asp:label></p>
<%--</asp:Content>--%>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DropDownList class="form-control" ID="dpFilter" runat="server" Visible="false"></asp:DropDownList>
	<br />
	<asp:Panel ID="pnEndoftenancy" visible="false" runat="server">
		
	Number of Bedrooms:
	<asp:DropDownList class="form-control" ID="dpBedrooms" runat="server"  ></asp:DropDownList>
	<br />
	Number of Bathrooms:
	<asp:DropDownList class="form-control" ID="dpBathrooms" runat="server"></asp:DropDownList>
		<asp:CheckBoxList ID="cbBathroomExtras" runat="server"></asp:CheckBoxList>
	<br />
	Number of Garages:
	<asp:DropDownList class="form-control" ID="dpGarages" runat="server"></asp:DropDownList>
	<br />
	<b> Number of Bedrooms for window cleaning:</b>
	   <asp:CheckBoxList runat="server" ID="cbWindows" ></asp:CheckBoxList>
	<br />
	Number of Bedrooms for Ceiling cleaning:
	<asp:DropDownList class="form-control" ID="dpCeiling" runat="server"></asp:DropDownList>
	<br />
   <b> Extras:</b>
	<asp:CheckBoxList ID="CheckBoxList1" runat="server" ></asp:CheckBoxList>
	<br />
	</asp:Panel>
	<asp:panel ID="pncarpet" Visible="false" runat="server">
		 <asp:DropDownList ID="dpCarpet" CssClass="form-control" runat="server"></asp:DropDownList>
	<br />
	Enter the Area Sq Meters:
	<asp:TextBox ID="txtarea" class="form-control" runat="server"  ></asp:TextBox>
	<br />
		<asp:CheckBoxList ID="cbCarpetExtras" runat="server"></asp:CheckBoxList>
		<br />
	</asp:panel>
	<asp:Panel ID="pnExtra" runat="server">
		<asp:CheckBoxList class="form-control" ID="cbExtras" runat="server" RepeatColumns="1"></asp:CheckBoxList>
	</asp:Panel>
	
    <asp:Panel ID="dynamic" runat="server" Visible="false">
        <asp:DropDownList ID="dpDynamic" runat="server"></asp:DropDownList>
        <asp:CheckBoxList ID="cbDynamic" runat="server"></asp:CheckBoxList>
    </asp:Panel>
	<asp:Button ID="btnclick" class="btn-primary form-control" runat="server" Text="Check Price" OnClick="btnclick_Click"  />
	 
	<hr />
	<br />
	
	<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
		<ContentTemplate>
	   
		<asp:table ID="myTable" runat="server" class="form-control" BorderStyle="Solid" >
	  <asp:tableRow Width="100%">
		  <asp:tablecell width="90%" style="text-align:left"> <b>Items:</b></asp:tablecell>
		  <asp:tablecell width="10%" style=" font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif; font-size: medium; font-weight: bold; text-transform: capitalize; text-align:right"> <b>Price: </b> </asp:tablecell>
	  </asp:tableRow>
	 
  </asp:table>
	<hr />
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
		
  
	</ContentTemplate>

		 <Triggers>
			 <asp:AsyncPostBackTrigger ControlID="btnclick" EventName="Click" />
		 </Triggers>
	</asp:UpdatePanel>
	
	
	  
		<br />

		 <asp:Button ID="btnBookService" CssClass="form-control btn-success"  runat="server" Text="Book Service" OnClick="btnBookService_Click"  />

	
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
                
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
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
       

	
   </asp:Content>
