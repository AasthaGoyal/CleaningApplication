using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MailKit.Net.Smtp;

using MailKit.Security;
using SendGrid.Helpers.Mail;
using SendGrid;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net.Mime;

namespace CleaningApplication
{
    public partial class WebForm21 : System.Web.UI.Page
    {
        public string col1, col2,t;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                 t = Session["total"].ToString();
                 col1 = Session["column1"].ToString();
                 col2 = Session["column22"].ToString();

                int price = Convert.ToInt32(t.Substring(1));
             
               
                var col1values = col1.Split(',');
                var col2values = col2.Split(',');

                lblhidden.Text = col1;
                for(int i=0;i<col1values.Length;i++)
                {
                    TableRow row1 = new TableRow();
                    TableCell cell1 = new TableCell();
                    cell1.Text = col1values[i].ToString();
                    TableCell cell2 = new TableCell();
                    cell2.Text = col2values[i].ToString();
                    row1.Cells.Add(cell1);
                    row1.Cells.Add(cell2);
                    myTable.Rows.Add(row1);
                }
                lblTotal.Text = t;
               
                this.Master.statusheading = "Book Service and payment";

                Session.Remove("column1");
              
            }
            

        }

        protected  void btnConfirm_Click(object sender, EventArgs e)
        {
           
            
            try
            {
                lblmessage2.Text = "Sending message....please wait";
                MailMessage mailMsg = new MailMessage();

                mailMsg.To.Add(new MailAddress("swaachclean@gmail.com", "The Recipient"));

                mailMsg.From = new MailAddress("swaachclean@gmail.com", "The Sender");

                mailMsg.Subject = "A new query received from REQUEST QUOTE section";
                string text = "You have received a new query regarding swaach cleaning services.";
                string html = @"<strong> Name: </strong>" + txtname2.Text + " <br/>";
                html += @"<strong> Email Id: </strong>" + txtemailid.Text + "<br/>";
                html += @"<strong>Phone no: </strong>" + txtphone2.Text + "<br/>";
                html += @"<strong>Message: </strong>" + txtmessage.Text + "<br/>";
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

                System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient("smtp.sendgrid.net",
                                                       Convert.ToInt32(587));
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("swaachclean", "Yajatshah@9");
                smtpClient.Credentials = credentials;

                smtpClient.Send(mailMsg);
                lblmessage2.Text = "The message has been send";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                lblmessage2.Text = "the error is" + ex.Message;
            }
        }

       
      

        protected void PayPalBtn_Click(object sender, ImageClickEventArgs e)
        {
            string business = "Swaach Cleaning Services";
            string itemName = "Carpet Cleaning";
            double itemAmount =20.00;
            string currencyCode = "NZD";

            StringBuilder ppHref = new StringBuilder();

            ppHref.Append("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=FSJX49ZLMZ8WU");
            ppHref.Append("&business=" + business);
            ppHref.Append("&item_name=" + itemName);
            ppHref.Append("&amount=" + itemAmount);
            ppHref.Append("&currency_code=" + currencyCode);
            ppHref.Append("&no_shipping=" + "1");
            ppHref.Append("&rm=" + "2");
            ppHref.Append("&notify_url="+ "url");
            ppHref.Append("&cancel_return=" + "url");
            ppHref.Append("&return=" + "url");
            ppHref.Append("&custom=" + "2");


            Response.Redirect(ppHref.ToString(), true);
        }

        protected void btnBook_Click(object sender, EventArgs e)
        {
            btnBook.BackColor = System.Drawing.Color.Gray;

            try
            {
                
               
                MailMessage mailMsg = new MailMessage();
                string serviceName = this.Master.accessName;


                mailMsg.To.Add(new MailAddress("swaachclean@gmail.com", "The Recipient"));

                mailMsg.From = new MailAddress("swaachclean@gmail.com", "The Sender");

                mailMsg.Subject = "A new query received from BOOK SERVICE section";
                string text = "A Booking request for the service <h3> " + this.Master.statusheading + "</h3> has been received";
                string html = @"<strong> Name: </strong>" + txtname.Text + " <br/>";
                html += @"<strong> Email Id: </strong>" + txtemail.Text + "<br/>";
                html += @"<strong> Preferred Date: </strong>" + txtdate.Value + "<br/>";
                html += @"<strong>Preferred Time: </strong>" + txttime.Value + "<br/>";
                html += @"<strong> Address: </strong>" + txtaddress.Text + "<br/>";
                html += @"<strong> Extra Notes: </strong>" + txtnotes.Text + "<br/>";
                html += @"<strong> Email Id: </strong>" + txtemail.Text + "<br/><br/>";
                html += @"<h3> SERVICE DETAILS: </h3>";
                html += @"<strong>Name:</strong>" + serviceName + "<br/>" ;
                html += @"<strong>Details:</strong> " + lblhidden.Text + "<br/>";
                html += @" And the total price for all the services is <strong> " + lblTotal.Text + "</strong>";
               
               
              
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

                System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient("smtp.sendgrid.net",
                                                       Convert.ToInt32(587));
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("swaachclean", "Yajatshah@9");
                smtpClient.Credentials = credentials;

                smtpClient.Send(mailMsg);
                lblmessage.Text = "The message has been successfully send";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                lblmessage.Text = "the error is" + ex.Message;
            }
        }
    }
}