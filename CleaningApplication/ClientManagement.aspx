<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ClientManagement.aspx.cs" Inherits="CleaningApplication.WebForm13" %>
<%@ MasterType VirtualPath="~/Admin.Master" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <form runat="server">
          <div class="container form-control">
   
    <h2> Client Managemrnt</h2>
    <br />
             Client Id:
      <asp:TextBox class="form-control" width="100%" height="40px" Enabled="False" ID="txtclientid" runat="server"  ></asp:TextBox>
        <br />
     Client Logo:
        <asp:Image ID="imgLogo" runat="server" Width="250px" Height="120px" />
    
        <br />
        <asp:FileUpload ID="fpLogo" runat="server" />
        <br />
         <br />
    Client Name:
      <asp:TextBox class="form-control" width="100%" height="40px"  ID="txtcname" runat="server" ></asp:TextBox>
        <br />
              <asp:Label ID="lblmessage" runat="server" Font-Bold="True" ForeColor="#CC0000" ></asp:Label>
      
    <br />
        <asp:Button ID="btnUpdate" class="btn-success" width="200px" height="50px" runat="server" Text="Update" OnClick="btnUpdate_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnDelete" class="btn-danger " width="200px" height="50px" runat="server" Text="Delete" OnClick="btnDelete_Click" />
      <br />
              <br />
          <asp:GridView width="100%" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="clientid"  BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
              <Columns>
                  <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/background/arrow.png" ShowSelectButton="True" >
                  <ControlStyle Height="50px" Width="50px" />
                  </asp:CommandField>
                  <asp:BoundField DataField="clientid" HeaderText="Client Id" InsertVisible="False" ReadOnly="True" SortExpression="clientid" />
                  <asp:TemplateField HeaderText="Logo" SortExpression="clientLogo">
                      <EditItemTemplate>
                          <asp:Image ID="Image1" runat="server" width="50px" height="50px" ImageUrl='<%# Bind("clientLogo") %>'/>  </EditItemTemplate>
                      <ItemTemplate>
                           <asp:Image ID="Image1" runat="server" width="50px" height="50px" ImageUrl='<%# Bind("clientLogo") %>'/>  </EditItemTemplate>
                       </ItemTemplate>
                  </asp:TemplateField>
                  <asp:BoundField DataField="clientName" HeaderText="Name" SortExpression="clientName" />
              </Columns>
              <FooterStyle BackColor="White" ForeColor="#000066" />
              <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
              <RowStyle ForeColor="#000066" />
              <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
              <SortedAscendingCellStyle BackColor="#F1F1F1" />
              <SortedAscendingHeaderStyle BackColor="#007DBB" />
              <SortedDescendingCellStyle BackColor="#CAC9C9" />
              <SortedDescendingHeaderStyle BackColor="#00547E" />
          </asp:GridView>
               
              </div>
          </form>
</asp:Content>
