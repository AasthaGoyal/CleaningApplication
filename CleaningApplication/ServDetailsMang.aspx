<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ServDetailsMang.aspx.cs" Inherits="CleaningApplication.WebForm11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <link href="css/bootstrap.css" rel="stylesheet" />
<link href="css/style.css" rel="stylesheet"/>
<link href="css/responsive.css" rel="stylesheet"/>
        <h2> Services Detail Management</h2>
       <br />
          <asp:DropDownList ID="dpcategory" CssClass="form-control" runat="server" DataSourceID="SqlDataSource1" DataTextField="categoryName" DataValueField="categoryName" OnSelectedIndexChanged="dpcategory_SelectedIndexChanged" AutoPostBack="True">
             
        </asp:DropDownList>
        <br />
      
        <asp:DropDownList class="form-control" ID="dpdetails" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dpdetails_SelectedIndexChanged" ></asp:DropDownList>
        <br />
        <asp:GridView ID="GridView1" width="100%" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/background/arrow.png" ShowSelectButton="True">
                <ControlStyle Height="30px" Width="30px" />
                </asp:CommandField>
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
        
       
          <hr />
        <br />

        <h5> The Extra items: </h5>
        <br />
        <asp:GridView ID="gdExtras"  Width="100%" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="extraid"  GridLines="Vertical" OnSelectedIndexChanged="gdExtras_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/background/arrow.png" ShowSelectButton="True">
                <ControlStyle Height="30px" Width="30px" />
                </asp:CommandField>
                <asp:BoundField DataField="extraid" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="extraid" />
                <asp:BoundField DataField="extraName" HeaderText="Name" SortExpression="extraName" />
                <asp:BoundField DataField="eprice" HeaderText="Price" SortExpression="eprice" />
                <asp:BoundField DataField="serviceid" HeaderText="Service Id" SortExpression="serviceid" />
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
        <h4>Select an item to Edit or delete:</h4>  
   <br />
        <br />
        <table width="100%" class="form-control">
            <tr>
                <td colspan="2"><b>Service Details:</b> </td>
                <td colspan="2"> <b>Extra Details:</b></td>
            </tr>
            <tr>
                <td style="width: 20%"> Service Id:</td>
                <td style="width: 30%">  <asp:TextBox class="form-control" ID="txtid" runat="server" Enabled="False" Width="100%"></asp:TextBox>
        </td>
                <td style="width:20%"> Extra Id:</td>
                <td style="width:30%">   <asp:TextBox class="form-control" ID="txtextraid" runat="server" Enabled="False" Width="100%"></asp:TextBox>
       </td>
            </tr>
            <tr>
                <td style="width: 20%"> Service name:</td>
                <td style="width:30%">         <asp:TextBox class="form-control" ID="txtname" runat="server"></asp:TextBox>
        </td>
                <td style="width: 20%"> Extra Name:</td>
                <td style="width:30%">         <asp:TextBox class="form-control" ID="txtextraname" runat="server"></asp:TextBox>
        </td>
            </tr>
            <tr> <td style="width: 20%"> Price(NZD):</td>
                <td style="width:30%"> <asp:TextBox class="form-control" ID="txtprice" runat="server"></asp:TextBox>
        </td>
                <td style="width: 20%"> Price(NZD) for Extra service:</td>
                <td style="width:30%">  <asp:TextBox class="form-control" ID="txtextraprice" runat="server"></asp:TextBox>
       </td>
            </tr>
        </table>
        <br />
        
   
        <br />
        <br />
        <asp:Button ID="btnUpdate" class="btn-success" width="200px" height="50px" runat="server" Text="Update" OnClick="btnUpdate_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnDelete" class="btn-danger " width="200px" height="50px" runat="server" Text="Delete" OnClick="btnDelete_Click" />
      
        <br />
        
        <asp:Label ID="lblMessage" Visible="false" runat="server" ></asp:Label>
        <br />
        <asp:Label ID="lblfeedback" runat="server"  Font-Bold="True" ForeColor="#CC0000"></asp:Label>

       

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbcleaningConnectionString %>" SelectCommand="SELECT [categoryName] FROM [tbcategory]"></asp:SqlDataSource>
        
    </form>
  
</asp:Content>
