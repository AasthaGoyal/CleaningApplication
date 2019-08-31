<%@ Page Title="" Language="C#" MasterPageFile="~/ServicesNested.master" AutoEventWireup="true" CodeBehind="BookServices.aspx.cs" Inherits="CleaningApplication.WebForm21" %>
<%@ MasterType VirtualPath="~/ServicesNested.master" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
	<br />
	<asp:Button ID="btnfinish" runat="server" class="btn-success form-control" Text="Book service" OnClick="btnfinish_Click" />
	<br />
	<asp:Button ID="btnpay" runat="server" Text="Finish Payment" />
	<asp:Label ID="lblmessage" runat="server" Font-Bold="True" ForeColor="#CC0000" ></asp:Label>
</asp:Content>
