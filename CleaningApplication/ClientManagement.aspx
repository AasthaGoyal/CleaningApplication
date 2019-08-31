<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ClientManagement.aspx.cs" Inherits="CleaningApplication.WebForm13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <form runat="server">
   
    <h2> Client Managemrnt</h2>
    <br />
          <asp:GridView class="form-control" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="clientid" DataSourceID="SqlDataSource1">
              <Columns>
                  <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                  <asp:BoundField DataField="clientid" HeaderText="clientid" InsertVisible="False" ReadOnly="True" SortExpression="clientid" />
                  <asp:BoundField DataField="clientLogo" HeaderText="clientLogo" SortExpression="clientLogo" />
                  <asp:BoundField DataField="clientName" HeaderText="clientName" SortExpression="clientName" />
              </Columns>
          </asp:GridView>
          <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbcleaningConnectionString %>" DeleteCommand="DELETE FROM [tbclient] WHERE [clientid] = @clientid" InsertCommand="INSERT INTO [tbclient] ([clientLogo], [clientName]) VALUES (@clientLogo, @clientName)" SelectCommand="SELECT * FROM [tbclient]" UpdateCommand="UPDATE [tbclient] SET [clientLogo] = @clientLogo, [clientName] = @clientName WHERE [clientid] = @clientid">
              <DeleteParameters>
                  <asp:Parameter Name="clientid" Type="Int32" />
              </DeleteParameters>
              <InsertParameters>
                  <asp:Parameter Name="clientLogo" Type="String" />
                  <asp:Parameter Name="clientName" Type="String" />
              </InsertParameters>
              <UpdateParameters>
                  <asp:Parameter Name="clientLogo" Type="String" />
                  <asp:Parameter Name="clientName" Type="String" />
                  <asp:Parameter Name="clientid" Type="Int32" />
              </UpdateParameters>
          </asp:SqlDataSource>
          </form>
</asp:Content>
