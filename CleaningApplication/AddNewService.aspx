<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddNewService.aspx.cs" Inherits="CleaningApplication.WebForm25" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link href="css/bootstrap.css" rel="stylesheet" />
<link href="css/style.css" rel="stylesheet"/>
<link href="css/responsive.css" rel="stylesheet"/>
    <form runat="server">
        <div class="container form-control">
              <h3> Add a new Service:</h3>
            <br />
            Please choose one of the options:
            <br />
            <asp:RadioButtonList class="form-control" ID="rboptions" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                <asp:ListItem Value="option1">Existing Category</asp:ListItem>
                <asp:ListItem Value="option2">Create a new category</asp:ListItem>
              </asp:RadioButtonList>
            <br />
            <asp:Panel ID="Panel1" runat="server" Visible="false">
                <asp:DropDownList class="form-control" ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="categoryName" DataValueField="categoryName"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbcleaningConnectionString %>" SelectCommand="SELECT [categoryName] FROM [tbcategory]"></asp:SqlDataSource>
            </asp:Panel>
            <br />
            <asp:Panel ID="Panel2" visible="false" runat="server">

                <h5> <b>Add a new category:</b></h5>
                <br />
                Category Name:
                <asp:TextBox ID="txtcname" CssClass="form-control" placeholder="Enter category name" runat="server"></asp:TextBox>
                <br />
                Category Photo:
                <asp:FileUpload ID="fpPhoto" class="form-control" runat="server" />
                <br />
                Category Description:
                 <asp:TextBox ID="txtcdescription" CssClass="form-control" placeholder="Enter category name" runat="server"></asp:TextBox>
                <br />
                Rank:
                 <asp:TextBox ID="txtcrank" width="100%" enabled="false" CssClass="form-control" placeholder="Enter category name" runat="server"></asp:TextBox>
                <br />
                <br />
               
            <asp:Label ID="lblmessage" runat="server"  Font-Bold="True" ForeColor="#CC0000"></asp:Label>
          
           
            <br />
            What kind of customize options you want to have with this service?
            <asp:RadioButtonList class="form-control" ID="rbChoices" runat="server" OnSelectedIndexChanged="rbChoices_SelectedIndexChanged">
                <asp:ListItem Value="choice1">Add multiple selection option (check list)</asp:ListItem>
                <asp:ListItem Value="choice2">Add single selection option (dropdown list)</asp:ListItem>
                 <asp:ListItem Value="choice3">No customization needed</asp:ListItem>
              </asp:RadioButtonList>

              <br />
              	<asp:Table ID="tbmultiple" runat="server" CssClass="form-control"  Font-Bold="True" >
		            <asp:TableRow Width="100%">
			                <asp:TableCell Width="50%"  style="text-align:left">
				                Heading (Eg-Number of Bedrooms):
			                </asp:TableCell>
			        <asp:TableCell Width="50%"  style="text-align:right">
				            Options (Eg - 2 Bedrooms - $134)<br /> (format: name - $amount):
			        </asp:TableCell>

		         </asp:TableRow>
                        <asp:TableRow Width="100%">
			                <asp:TableCell Width="50%"  style="text-align:left">
				               <asp:TextBox ID="txtheading" CssClass="form-control" placeholder="Enter the check list criteria (e.g - Window cleaning)" runat="server"></asp:TextBox>
                 
			                </asp:TableCell>
			        <asp:TableCell Width="50%"  style="text-align:right">
				              <asp:TextBox ID="txtc1" CssClass="form-control" placeholder="Enter the option" runat="server"></asp:TextBox>
                 
			        </asp:TableCell>

		         </asp:TableRow>
	            </asp:Table>
           
                   
                    <asp:Button ID="btnaddnew" class="btn-success" width="163px" height="30px" runat="server" Text="Add another option" OnClick="btnaddnew_Click"    />
                 <br />
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                
            <br />
             </asp:Panel>
            <asp:Button ID="btnAdd" class="btn-primary" width="200px" height="50px" runat="server" Text="Add" OnClick="btnAdd_Click"  />
     
   </div>
        </form>
</asp:Content>
