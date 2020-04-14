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

namespace CleaningApplication
{
    public partial class WebForm21 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Environment.SetEnvironmentVariable("SwaachKey", "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");

            if (!IsPostBack)
            {
                string t = Session["total"].ToString();
                string col1 = Session["column1"].ToString();
                string col2 = Session["column22"].ToString();

                int price = Convert.ToInt32(t.Substring(1));
             
               
                var col1values = col1.Split(',');
                var col2values = col2.Split(',');

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

        protected async void btnConfirm_Click(object sender, EventArgs e)
        {
            await GetResponse(Environment.GetEnvironmentVariable("MyApikey"), txtname2.Text, txtemailid.Text, txtphone2.Text, txtmessage.Text);
            lblmessage2.Text = "The message has been successfully sent";
        }

        public static async Task GetResponse(string apikey, string name, string email, string phoneno, string message)
        {
            // Retrieve the API key from the environment variables. See the project README for more info about setting this up.
            //   var apiKey = Environment.GetEnvironmentVariable("MyApikey");

            var client = new SendGridClient(apikey);
            string body = "<h1> Hello admin </h1> <br/>";
            body += "<br/>You have received a new message regarding 'Swaach Cleaning Services'. The details are as follows: <br/>";
            body += "<br/> Customer Name: " + name + "<br/>";
            body += "<br/> Email Id: " + email + "<br/>";
            body += "<br/> Phone No: " + phoneno + "<br/>";
            body += "<br/> Message: " + message + ".";



            // Send a Single Email using the     Mail Helper
            var from = new EmailAddress("aastha2150@gmail.com", "Swaach Cleaning");
            var subject = "A new query received for Swaach Cleaning services!";
            var to = new EmailAddress("swaachclean@gmail.com", "Swaach Cleaning ");
            var plainTextContent = body;
            var htmlContent = body;

            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            Console.WriteLine("the msg is", msg);
            var response = await client.SendEmailAsync(msg);
            Console.WriteLine("the response is", response);

        }
        protected void btnfinish_Click(object sender, EventArgs e)
        {
            //string body = "<h1> Hello admin </h1> <br/>";
            //body += "<br/>You have received a new 'Book service' request regarding 'Swaach Cleaning Services'. The details are as follows: <br/>";
            //body += "<br/> First Name: " + txtfirstname.Text + "<br/>";
            //body += "<br/> Last Name: " + txtlastname.Text + "<br/>";
            //body += "<br/> Email Id: " + txtemail.Text + "<br/>";
            //body += "<br/> Phone No: " + txtphone.Text + "<br/>";
            //body += "<br/> Street No: " + txtstreetno.Text + "<br/>";
            //body += "<br/> Region: " + txtregion.Text + "<br/>";
            //body += "<br/> City: " + txttown.Text + "<br/>";
            //body += "<br/> Post Code: " + txtpostcode.Text + "<br/>";
            //body += "<br/> The preferred date and time for the booking are:<br/>";
            //body += "<br/> Date: " + txtdate.Value + "<br/>";
            //body += "<br/> Time: " + txttime.Value + "<br/>";




            //try
            //{
            //    MailMessage message = new MailMessage();
            //    message.To.Add("swaachclean@gmail.com");
            //    message.From = new MailAddress("aastha2150@gmail.com");
            //    message.Subject = "A new 'Request for Book service' received!";
            //    message.Body = body;
            //    message.IsBodyHtml = true;
            //    SmtpClient smtp = new SmtpClient();
            //    smtp.Host = "smtp.gmail.com";
            //    smtp.EnableSsl = true;
            //    NetworkCredential nc = new NetworkCredential();
            //    nc.UserName = "aastha2150@gmail.com";
            //    nc.Password = "Goyal0412Aa$h1";
            //    smtp.UseDefaultCredentials = true;
            //    smtp.Credentials = nc;
            //    smtp.Port = 587;
            //    smtp.Send(message);

            //    lblmessage.Text = "* We have received your request and would be in contact shortly";
            //}
            //catch (Exception ex)
            //{
            //    lblmessage.Text = "* Error! " + ex.Message;
            //}
            DataAccessLayer dao = new DataAccessLayer();
            //Label label1 = new Label();
            //label1 = (Label)Page.Master.FindControl("lblname");
            //string name = label1.Text.ToString();
            string t = Session["total"].ToString();
            int id = dao.insertGoods("Carpet cleaning", Convert.ToDecimal(t.Substring(1)));
           
            // lblmessage.Text = "The good has been  added successfully" + id;
            //Response.Redirect("IPNHandler.aspx?goodsid=" + request_id);
            Response.Redirect("ConfirmOrder.aspx?goods_id=" + id);
        }

        protected string labelProperty
        {
            get
            {
                return hidden.Value;
            }

            set
            {
                hidden.Value = value;
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

       
       
       


    }
}