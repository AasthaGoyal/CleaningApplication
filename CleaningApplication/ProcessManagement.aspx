<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ProcessManagement.aspx.cs" Inherits="CleaningApplication.WebForm16" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
         
    <h1> Process Management</h1>
    <br />
        Process Id:
        <asp:TextBox class="form-control" height="30px" ID="txtprocessid" runat="server" Enabled="False" Width="100%"></asp:TextBox>
        <br />
        Process name:
        <asp:TextBox class="form-control" ID="txtname" runat="server" ></asp:TextBox>
        <br />
        Process Short Line(How it would be displayed on the home page):
        <asp:TextBox class="form-control" ID="txtheading" wrap="true" runat="server" ></asp:TextBox>
        <br />
        Process description:
        <asp:TextBox class="form-control" TextMode="MultiLine" height="120px" Wrap="true" ID="txtdescription" runat="server" ></asp:TextBox>
        <br />
        <asp:Label ID="lblmessage" runat="server" Font-Bold="True" ForeColor="#CC0000" ></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnUpdate" class="btn-success" width="200px" height="50px" runat="server" Text="Update" OnClick="btnUpdate_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnDelete" class="btn-danger " width="200px" height="50px" runat="server" Text="Delete" OnClick="btnDelete_Click" />
      
        <br />
        <br />
       
            
             <asp:GridView class="form-control" ID="gdProcess" runat="server" AutoGenerateColumns="False" DataKeyNames="processid"  BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" OnSelectedIndexChanged="gdProcess_SelectedIndexChanged" >
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" ButtonType="Image" SelectImageUrl="~/images/background/arrow.png" >
                <ControlStyle Height="50px" Width="50px" />
                </asp:CommandField>
                <asp:BoundField DataField="processid" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="processid" />
                <asp:BoundField DataField="processName" HeaderText="Name" SortExpression="processName" />
                 <asp:BoundField DataField="heading" HeaderText="Heading" SortExpression="heading" />
                <asp:BoundField DataField="processDesc" HeaderText="Description" SortExpression="processDesc" />
               
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
        
            
           </form>

</asp:Content>
