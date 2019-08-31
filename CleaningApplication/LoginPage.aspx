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
          </form>
</asp:Content>
