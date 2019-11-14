<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeBehind="ConfirmOrder.aspx.cs" Inherits="CleaningApplication.WebForm30" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server" id="form">
        <div class="container form-control">

            <h3> Review your order before confirming</h3>
            <br />
            Item name:
            <asp:TextBox ID="txtitemname" runat="server"></asp:TextBox>
            <br />
            Total amount to pay:
            <asp:TextBox ID="txtamount" runat="server"></asp:TextBox>
            <br />
            <asp:Panel ID="pnlPayPal" runat="server" Width="100%">
                <asp:ImageButton ImageUrl="./images/background/payment.jfif" runat="server" ID="ibPayPal" OnClick="ibPayPal_Click" />
            </asp:Panel>
        </div>
    </form>
</asp:Content>
