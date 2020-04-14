<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="StoryManagement.aspx.cs" Inherits="CleaningApplication.WebForm26" %>
<%@ MasterType VirtualPath="~/Admin.Master" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server" id="form1">
         <div class="container form-control">

             <h2> Story Management</h2>
        
           
       
    <br />
        <asp:GridView ID="gdStories" class="form-control" width="100%"  runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="storyid"  OnSelectedIndexChanged="gdStories_SelectedIndexChanged">
                 <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                 <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/background/arrow.png" ShowSelectButton="True">
            <ControlStyle Height="30px" Width="30px" />
            </asp:CommandField>
                <asp:BoundField DataField="storyid" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="storyid" />
                <asp:BoundField DataField="storyName" HeaderText="Name" SortExpression="storyName" />
                <asp:BoundField DataField="storyDesc" HeaderText="Description" SortExpression="storyDesc" />
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
             <br />
            
        <br />
         <asp:Button ID="btnDelete" class="btn-danger " width="200px" height="50px" runat="server" Text="Delete" OnClick="btnDelete_Click" />

               <asp:Label ID="lblmessage" runat="server" Font-Bold="True" ForeColor="#CC0000" ></asp:Label>
             <asp:TextBox ID="txtid" Visible=false runat="server"></asp:TextBox>
          </div>
             </form>
</asp:Content>

