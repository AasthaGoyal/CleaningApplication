<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="StaffManagement.aspx.cs" Inherits="CleaningApplication.WebForm20" %>
<%@ MasterType VirtualPath="~/Admin.Master" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="container form-control">
        
    <h3> Select a staff to Edit or Delete</h3>
<br />
      <table class="form-control">
         <tr>
             <td style="width:20%"> Staff Id:</td>
             <td style="width:30%"> <asp:TextBox class="form-control" ID="txtid" runat="server" Enabled="False"></asp:TextBox></td>
             <td style="width:20%"> Email Id:</td>
             <td style="width:30%"> <asp:TextBox class="form-control" ID="txtemail" runat="server"></asp:TextBox></td>
         </tr>
           <tr>
             <td style="width:20%"> Name:</td>
             <td style="width:30%"> <asp:TextBox class="form-control" ID="txtname" runat="server"></asp:TextBox></td>
             <td style="width:20%"> Positon:</td>
             <td style="width:30%"> <asp:TextBox class="form-control" ID="txtPosition" runat="server"></asp:TextBox></td>
         </tr>
          
           <tr>
                <td style="width:20%"> Phone No:</td>
             <td style="width:30%"> <asp:TextBox class="form-control" ID="txtphone" runat="server"></asp:TextBox></td>
       
             <td style="width:20%">Address:</td>
             <td style="width:30%"> <asp:TextBox class="form-control" ID="txtaddress" runat="server"></asp:TextBox></td>
         </tr>
          
       
          <tr> 
               <td rowspan="2" style="width:20%"> Photo:</td>
             <td rowspan="2" style="width:30%">
                 <asp:Image ID="imgPhoto" Width="60px" Height="60px" runat="server" />
                 <br />
                 <asp:TextBox ID="txtphoto" runat="server" CssClass="form-control"></asp:TextBox>
                 <br />
                 <asp:FileUpload ID="fpImage" runat="server" />
               </td>
               <td style="width:20%"> Username:</td>
             <td style="width:30%"> <asp:TextBox class="form-control" ID="txtusername" runat="server"></asp:TextBox></td>
            
          </tr>
      </table>
       
        
         <br />
        <asp:Label ID="lblmessage" runat="server" Font-Bold="True" ForeColor="#CC0000" ></asp:Label>
      <br />
        <br />
        <asp:Button ID="btnUpdate" class="btn-success" width="200px" height="50px" runat="server" Text="Update" OnClick="btnUpdate_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnDelete" class="btn-danger " width="200px" height="50px" runat="server" Text="Delete" OnClick="btnDelete_Click" />
      <br />
        <br />
        <asp:GridView width="100%" ID="gdStaff"  runat="server" AutoGenerateColumns="False"  BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" OnSelectedIndexChanged="gdStaff_SelectedIndexChanged"  >
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <Columns>
            <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/background/arrow.png" ShowSelectButton="True">
            <ControlStyle Height="30px" Width="30px" />
            </asp:CommandField>
            <asp:BoundField DataField="staffId" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="staffId" />
            <asp:BoundField DataField="fullname" HeaderText="Name" SortExpression="fullname" />
            <asp:TemplateField HeaderText="Photo" SortExpression="photo">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("photo") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Image ID="Image1" width="50px" height="50px" runat="server" ImageUrl='<%# Bind("photo") %>' />
                    <%--<asp:Label ID="Label1" runat="server" Text='<%# Bind("photo") %>'></asp:Label>
           --%>     </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="position" HeaderText="Position" SortExpression="position" />
            <asp:BoundField DataField="emailid" HeaderText="Email" SortExpression="emailid" />
            <asp:BoundField DataField="phoneNo" HeaderText="Phone No" SortExpression="phoneNo" />
            <asp:BoundField DataField="staffAddress" HeaderText="Address" SortExpression="staffAddress" />
            <asp:BoundField DataField="username" HeaderText="Username" SortExpression="username" />
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
