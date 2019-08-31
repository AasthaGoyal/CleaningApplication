<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="PaymentPage.aspx.cs" Inherits="CleaningApplication.WebForm22" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" src="https://js.stripe.com/v2/"> </script>
    <script type="text/javascript">
        Stripe.setPublishableKey('pk_test_Pn4XtavFViFqUFUaajsjWe9u00WXUVimJy')
    </script>
    <h3> Payment Page</h3>
    <br />
    <h5> The final amount is:</h5>
    <asp:Label ID="lblamount" runat="server" Text="12"></asp:Label>
</asp:Content>
