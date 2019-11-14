<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddChecklist.aspx.cs" Inherits="CleaningApplication.WebForm28" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <link href="css/bootstrap.css" rel="stylesheet" />
<link href="css/style.css" rel="stylesheet"/>
<link href="css/responsive.css" rel="stylesheet"/>
    <form runat="server">
         <div class="form-control container">
                        
                       <h2> What kind of option do you want to add?</h2>
             <br />
             <asp:DropDownList ID="dpOptiontype" class="form-control" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
                 <asp:ListItem Value="Multiple ">Multiple (Checklist)</asp:ListItem>
                 <asp:ListItem Value="Single ">Single (Drop down menu)</asp:ListItem>
                       </asp:DropDownList>
             <br />
             <asp:Panel runat="server" ID="multiple" Visible="false">

            
                    <h3> Adding Multiple-selection option (Shown as Checklist)</h3>
                    <br />
                  </asp:Panel>

             <asp:Panel runat="server" ID="single" Visible="false">

            
                    <h3> Adding Single-selection option (Shown as Drop-down menu)</h3>
                    <br />
                  </asp:Panel>

             <asp:Panel runat="server" ID="maincontent" Visible="false">

             
                    <asp:TextBox ID="txtheading" CssClass="form-control" placeholder=" Heading (Eg-Number of Bedrooms):" runat="server"></asp:TextBox>
                <br />
          
                    <b>Add Its option(Eg - 2 Bedrooms - 134):</b>
                    <br />
                         How many options do you want to add [format: name - amount]:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox runat="server" width="206px"  ID="CounterTextBox" AutoPostBack="false" BorderStyle="Solid" BorderColor="#999999" BorderWidth="2px" />
                        &nbsp;
                    <asp:Button ID="btnAddOptions" runat="server" BackColor="#999999" OnClick="btnAddOptions_Click" Text="Add" width="50px" />
             <br />

                    <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
             <asp:UpdatePanel ID="UpdatePanel1" runat="server">

                 <ContentTemplate>--%>
                    <asp:PlaceHolder ID="phOptions" runat="server" />
                    <%--  </ContentTemplate>

                 <Triggers>
			 <asp:AsyncPostBackTrigger ControlID="btnAddOptions" EventName="Click" />
		 </Triggers>
             </asp:UpdatePanel>--%>
                    <br />
                    <asp:Label ID="lblmessage" runat="server" Font-Bold="True" ForeColor="#CC0000"></asp:Label>
                    <%--<asp:Literal ID="Literal1" runat="server"></asp:Literal>--%>
                    <br/>

             <asp:Button ID="btnfinish" runat="server" Text="Add the Checklist option" OnClick="ConfirmButton_Click" class="btn-success form-control" />
                 
                         
                          <br />
                    Do you want to add another Option?
                    <br />
                    <asp:Button ID="btngoBack" runat="server" CssClass="btn-primary" height="30px" OnClick="btngoBack_Click" Text="Go back" width="200px" />
                 
                         
                          <%-- <asp:Button ID="btnAdd" class="btn-danger"  width="200px" AutoPostBack="false" height="50px" runat="server" Text="Add" OnClick="btnAdd_Click"  />
 --%>
                       </asp:Panel>
                     
                    </div>
        </form>
</asp:Content>
