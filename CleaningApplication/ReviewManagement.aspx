<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ReviewManagement.aspx.cs" Inherits="CleaningApplication.WebForm15" %>
<%@ MasterType VirtualPath="~/Admin.Master" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="container form-control">
        
    <h2> Review Management</h2>
    <br />
    Review Id:
       <asp:TextBox class="form-control" height="30px" ID="txtreviewid" runat="server" Enabled="False" Width="100%"></asp:TextBox>
        <br />
    Review Heading:
     <asp:TextBox class="form-control" ID="txtheading" runat="server" ></asp:TextBox>
        <br />
    Review:
     <asp:TextBox class="form-control" ID="txtreview" runat="server" ></asp:TextBox>
        <br />
    Customer name:
     <asp:TextBox class="form-control" ID="txtname" runat="server" ></asp:TextBox>
        <br />
    Number of Stars:
      <asp:TextBox class="form-control" ID="txtstars" runat="server" ></asp:TextBox>
        <br />
        <asp:Label ID="lblmessage" runat="server" Font-Bold="True" ForeColor="#CC0000" ></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnUpdate" class="btn-success" width="200px" height="50px" runat="server" Text="Update" OnClick="btnUpdate_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnDelete" class="btn-danger " width="200px" height="50px" runat="server" Text="Delete" OnClick="btnDelete_Click" />
      <br />
    <br />

    <asp:GridView ID="gdReviews" class="form-control" width="100%" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="reviewid"  GridLines="Vertical" OnSelectedIndexChanged="gdReviews_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <Columns>
            <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/background/arrow.png" ShowSelectButton="True">
            <ControlStyle Height="50px" Width="50px" />
            </asp:CommandField>
            <asp:BoundField DataField="reviewid" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="reviewid" />
            <asp:BoundField DataField="customerName" HeaderText="Customer Name" SortExpression="customerName" />
            <asp:BoundField DataField="heading" HeaderText="Heading" SortExpression="heading" />
            <asp:BoundField DataField="review" HeaderText="Review" SortExpression="review" />
            <asp:BoundField DataField="stars" HeaderText="Stars" SortExpression="stars" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#0000A9" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#000065" />
        </asp:GridView>
            </div>
         </form>
</asp:Content>
