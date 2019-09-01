<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="CleaningApplication.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <div class="container form-control">
  
    <h1 class="text-center" style="margin-left: 40px"> Login</h1>
    <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    Username:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* Username required" ControlToValidate="txtUsername" Font-Bold="True" ForeColor="#CC0000" ValidationGroup="loginuser"></asp:RequiredFieldValidator>
       &nbsp;<asp:TextBox class="form-control" ID="txtUsername" runat="server" placeholder="Enter Username"></asp:TextBox>
          
       <br />
          Password:<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="* Password required" ControlToValidate="txtPassword" Font-Bold="True" ForeColor="#CC0000" ValidationGroup="loginuser"></asp:RequiredFieldValidator>
      
            <asp:TextBox class="form-control" type="password" PasswordChar="*" ID="txtPassword" runat="server" placeholder="Enter Password" TextMode="Password"></asp:TextBox>
           
              <br />
       
            <asp:Button ID="btnLogin" runat="server" Text="Login" class="form-control btn-success" OnClick="btnLogin_Click" ValidationGroup="loginuser"/>
            <br />
             <table class="form-control">
                 <tr>
          <td style="width:50%">    <a href="#" onclick="window.open('ForgotPassword.aspx','FP','width=500, height=100,top=300,left=500,fullscreen=null,resize=0');">
                <asp:Label ID="Label4" runat="server" Text="Forgot Password" Font-Bold="True" ForeColor="#333399"></asp:Label>
          
             
            </a></td>
            <td  class="text-center"> <asp:Label ID="lblmessage" runat="server" Font-Bold="True" ForeColor="#009900" ></asp:Label></td>
        
        </tr>
    </table>
    </div>

         <div class="container">
			<div class="row">
				<div class="col-xs-12">
					<div class="modal" id="quotemodal" >

		
		<div class="modal-dialog">
			<div class="modal-content">
				<div class="modal-header" style="background-color:darkblue">
                    
	   
					<h4 class="modal-title" style="color: #FFFFFF"> Request Quote</h4>
					 <button class="close" data-dismiss="modal" style="color: #FFFFFF">&times;</button>
				</div>
				<div class="modal-body">
				
						<div class="form-group">
							<label for="name"> Full Name*</label>
							<asp:TextBox runat="server" class="form-control" placeholder="Enter your name" type="text" id="nametxt" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="* Name is required" ControlToValidate="nametxt" Font-Bold="True" ValidationGroup="requestQuote" ForeColor="#CC0000"></asp:RequiredFieldValidator>
						</div>
						<div class="form-group">
							 <label for="name"> Email Id</label>
							<asp:TextBox runat="server" class="form-control" placeholder="Enter your emailid"  id="emailidtxt" />

						</div>
						<div class="form-group">
							 <label for="name"> Phone No*</label>
							<asp:TextBox runat="server" class="form-control" placeholder="Enter your Contact No"  id="phonetxt" />
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="* Phone is required" ControlToValidate="phonetxt" Font-Bold="True" ValidationGroup="requestQuote" ForeColor="#CC0000"></asp:RequiredFieldValidator>
					
						</div>
						<div class="form-group">
							 <label for="name"> Message*</label>
							<asp:TextBox runat="server" height="70px" class="form-control" placeholder="Enter your message"  id="messagetxt" />
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="* Message is required" ControlToValidate="messagetxt" Font-Bold="True" ValidationGroup="requestQuote" ForeColor="#CC0000"></asp:RequiredFieldValidator>
					
						</div>
					

				</div>
                     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
		<ContentTemplate>
				<div class="modal-footer">
					<asp:Label ID="messagelbl" runat="server" Font-Bold="True" ForeColor="#CC0000" ></asp:Label>
                    
	
					<asp:Button ID="btnConfirm" runat="server" ValidationGroup="requestQuote" Text="Confirm" class="btn btn-primary" OnClick="btnConfirm_Click"/>
					<%--<button id="btnConfirm" class="btn btn-primary" AutoPostBack="true" onclick="btnConfirm_onClick" >Submit</button>--%>
					<button class="btn btn-primary" data-dismiss ="modal"> Close</button>
				</div>
             </ContentTemplate>

		 <Triggers>
			 <asp:AsyncPostBackTrigger ControlID="btnConfirm" EventName="Click" />
		 </Triggers>
	</asp:UpdatePanel>
			</div>
		</div>
			</div>
		
				</div>
			</div>
		</div>
          </form>
</asp:Content>
