 <%@ Page Title="" Language="C#" MasterPageFile="~/ServicesNested.master" AutoEventWireup="true" CodeBehind="ServiceDetails.aspx.cs" Inherits="CleaningApplication.WebForm3" %>
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
	

	
   </asp:Content>
