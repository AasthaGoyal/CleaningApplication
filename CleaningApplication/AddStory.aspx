<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddStory.aspx.cs" Inherits="CleaningApplication.WebForm23" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <link href="css/bootstrap.css" rel="stylesheet" />
<link href="css/style.css" rel="stylesheet"/>
<link href="css/responsive.css" rel="stylesheet"/>
        
  <form runat="server">
        <div class="container form-control">
            <h3>Add a new Story: </h3>
            <br />
          
             Story Heading:
            <br />
            <asp:TextBox ID="txtheading" runat="server" placeholder ="Enter the story heading" CssClass="form-control"></asp:TextBox>
            <br />
             Description:
            <asp:TextBox ID="txtdescription" runat="server" height="80px" placeholder ="Enter the story description" CssClass="form-control"></asp:TextBox>
            <br />
          
          
            <asp:Button ID="btnAdd" class="btn-primary" width="200px" height="31px" runat="server" Text="Add Story" OnClick="btnAdd_Click"  />
            <br />
     <br />
          <h4> Add Before and After Images:</h4>
            <br />
          
            <div class="form-control">
                  Before Photos:
                <br />
                <asp:FileUpload ID="fpBefore" runat="server" width="80%" AllowMultiple="true"/>
                <br />
                <br />
            <asp:Button ID="btnbefore" runat="server"  width="20%" class="btn-success" Text="Upload" OnClick="btnbefore_Click" />
          
            </div>          
                          
            <br />
            
            <div class="form-control">
              After Photos:
                <br />
                  <asp:FileUpload ID="fpAfter" runat="server" width="80%" AllowMultiple="true"/>
                <br />
                <br />
            <asp:Button ID="btnafter" runat="server"  Text="Upload" width="20%" class="btn-success" OnClick="btnafter_Click" />
                </div>
                <br />
    
             <asp:Label ID="lblmessage" runat="server"  Font-Bold="True" ForeColor="#CC0000"></asp:Label>
            <br />
        </div>
       </form>

    <script type="text/javascript">

        $('#fileUpload').fileupload();

        $('.fileupload').each(function () {
            $(this).fileupload({
                dropZone: $(this)
            });
        });
    </script>
   
</asp:Content>

