<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeBehind="Paypal.aspx.cs" Inherits="CleaningApplication.WebForm31" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

   
    
    <%--<form id="payForm" runat="server" method="post" action="https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_xclick">
        <input id="cmd" name="cmd" value="_xclick" runat="server"/>
        <input id="business" runat="server"/>
        <input id="item_name" value="Carpet cleaning"/>
        <input id="amount" value="12.00"/>
        <input id="no_shipping" value="1" runat="server"/>
        <input id="return" value="Default.aspx" runat="server"/>
        <input id="rm" />
        <input id="notify_url" />
        <input id="cancel_return" value="Services.aspx"  />
        <input id="currency_code" value="NZD" runat="server" />
        <input id="custom" runat="server"  />
        
      
    </form>--%>
    <form runat="server">

  
    <asp:ImageButton width="120px" Height="50px" id="PayPalBtn" runat="server" ImageUrl="https://www.paypalobjects.com/en_GB/i/btn/btn_buynow_LG.gif" onClick="PayPalBtn_Click" />

          <asp:Label ID="lblmessage" runat="server" Text="Label"></asp:Label>
         
      </form>
  <%--  <script type="text/javascript">
       
        document.forms["payForm"].submit();
    </script>
  --%>

</asp:Content>
