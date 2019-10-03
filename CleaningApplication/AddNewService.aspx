<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddNewService.aspx.cs" Inherits="CleaningApplication.WebForm25" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link href="css/bootstrap.css" rel="stylesheet" />
<link href="css/style.css" rel="stylesheet"/>
<link href="css/responsive.css" rel="stylesheet"/>
    <form runat="server">
        <div class="container form-control">
            
              <h3> Add a new Service:</h3>
            
            <br />
            
              
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
                   
          <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                  
           
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:Panel runat="server" ID="choices" Visible="true">
            What kind of customize options you want to have with this service?
            <asp:RadioButtonList class="form-control" ID="rbChoices" runat="server" OnSelectedIndexChanged="rbChoices_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem Value="choice1">Add multiple selection option (check list)</asp:ListItem>
                <asp:ListItem Value="choice2">Add single selection option (dropdown list)</asp:ListItem>
                 <asp:ListItem Value="choice3">No customization needed</asp:ListItem>
              </asp:RadioButtonList>
                    </asp:Panel>
              <br />
              
                    <div class="form-control container">
                        <asp:Panel runat="server" ID="multiple" Visible="false">

                        
                    <h2> Adding Multiple-selection option (Shown as Checklist)</h2>
                    <br />
                    <asp:TextBox ID="txtheading" CssClass="form-control" placeholder=" Heading (Eg-Number of Bedrooms):" runat="server"></asp:TextBox>
                <br />
            
                        <b>Add Its option(Eg - 2 Bedrooms - $134):</b>
                    <br />
                         How many options do you want to add [format: name - $amount]:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox runat="server" width="206px"  ID="CounterTextBox" AutoPostBack="false" BorderStyle="Solid" BorderColor="#999999" BorderWidth="2px" />
                        <asp:Button ID="btnAddOptions" runat="server" OnClick="btnAddOptions_Click" Text="Add" />
                        <br/> 

                                <asp:PlaceHolder runat="server" ID="phOptions" />
                                 <asp:Button class="btn-success"  width="200px" height="30px" AutoPostBack="false" ID="btnfinish" runat="server" Text="Finish"  OnClick="ConfirmButton_Click" /> 
                     <asp:Label ID="lblmessage" runat="server"  Font-Bold="True" ForeColor="#CC0000"></asp:Label>
        
                        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
<br/>    <asp:Button ID="btnAdd" class="btn-danger"  width="200px" height="50px" runat="server" Text="Add" OnClick="btnAdd_Click"  />
 
                       
                     </asp:Panel>
                    </div>
                   
                   
                  <br />
               
                   
                    </ContentTemplate>

                 <Triggers>
			 <asp:AsyncPostBackTrigger ControlID="rbChoices" EventName="SelectedIndexChanged" />
		 </Triggers>

                </asp:UpdatePanel>
                   
               
                
            <br />
            
           <%-- <asp:Button ID="btnAdd" class="btn-danger"  width="200px" height="50px" runat="server" Text="Add" OnClick="btnAdd_Click"  />
  --%>   </div>
   
        </form>
</asp:Content>
