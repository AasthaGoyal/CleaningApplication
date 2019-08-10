<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ServicesManagement.aspx.cs" Inherits="CleaningApplication.WebForm18" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
   
    <h2> Services Management</h2>
    <br />
    Category Id:
      <asp:TextBox class="form-control" height="30px" ID="txtcategoryid" runat="server" Enabled="False" Width="100%"></asp:TextBox>
        <br />
    Category Name:
     <asp:TextBox class="form-control" ID="txtname" runat="server" ></asp:TextBox>
        <br />
    Photo:
     <asp:Image ID="imgPhoto" runat="server" Width="250px" Height="120px" />
        <br />
        <asp:TextBox class="form-control" ID="txtPhoto" runat="server"></asp:TextBox>
        <br />
        <asp:FileUpload ID="fpImage" runat="server" />
        <br />
         <br />
    Description:
        <asp:TextBox class="form-control" TextMode="MultiLine" height="120px" Wrap="true" ID="txtdescription" runat="server" ></asp:TextBox>
        <br />
    Importance Rank:
     <asp:TextBox class="form-control" ID="txtrank" runat="server" ></asp:TextBox>
        <br />
        <asp:Label ID="lblmessage" runat="server" Font-Bold="True" ForeColor="#CC0000" ></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnUpdate" class="btn-success" width="200px" height="50px" runat="server" Text="Update" OnClick="btnUpdate_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnDelete" class="btn-danger " width="200px" height="50px" runat="server" Text="Delete" OnClick="btnDelete_Click" />
      
        <br />
      
      
        <br />
        <asp:GridView ID="GridView1" width="100%" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1"  >
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" ButtonType="Image" SelectImageUrl="~/images/background/arrow.png" >
                <ControlStyle Height="50px" Width="50px" />
                </asp:CommandField>
                <asp:BoundField DataField="categoryid" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="categoryid" />
                <asp:BoundField DataField="categoryName" HeaderText="Name" SortExpression="categoryName" />
                <asp:BoundField DataField="categoryPhoto" HeaderText="Photo" SortExpression="categoryPhoto" />
                <asp:BoundField DataField="categoryDesc" HeaderText="Description" SortExpression="categoryDesc" />
                <asp:BoundField DataField="rank" HeaderText="Rank" SortExpression="rank" />
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

     <%--   <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbcleaningConnectionString %>" SelectCommand="SELECT * FROM [tbcategory]"></asp:SqlDataSource>--%>

  </form>
</asp:Content>
