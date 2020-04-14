<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="thankyou.aspx.cs" Inherits="CleaningApplication.WebForm32" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server" id="form1">
        <div class="form-control container">

 
        <h2> Thank you for using Swaach Cleaning Services</h2>
        <br />
        <p> We have booked our service <span> <asp:label runat="server" ID="lblservicename"></asp:label></span>
            on the date/time <span> <asp:label runat="server" ID="lbldatetime"> </asp:label></span>
       
        </p>

        <p>
            We have received the complete payment of <span> <asp:label runat="server" ID="lblprice"></asp:label></span>
            for the service so no further action is required and you would receive a confirmation email shortly. 
        </p>
        
        <b> Click on the button below to close of this window and finish the booking. </b>
        <br />
            <br />
         <asp:Button ID="btnfinish" class="form-control btn-success" runat="server" Text="Confirm Booking" OnClick="btnfinish_Click1" />
            <br />
    
   
    <asp:Label ID="lblmessage" runat="server" Font-Bold="True" ForeColor="#CC0000" ></asp:Label>
	
               </div>
    </form>

</asp:Content>
