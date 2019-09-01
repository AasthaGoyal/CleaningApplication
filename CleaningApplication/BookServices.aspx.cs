using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CleaningApplication
{
    public partial class WebForm21 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
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
                Session.Remove("total");
            }
            

        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            string body = "<h1> Hello admin </h1> <br/>";
            body += "<br/>You have received a new message regarding 'Swaach Cleaning Services'. The details are as follows: <br/>";
            body += "<br/> Customer Name: " + txtname2.Text + "<br/>";
            body += "<br/> Email Id: " + txtemailid.Text + "<br/>";
            body += "<br/> Phone No: " + txtphone2.Text + "<br/>";
            body += "<br/> Message: " + txtmessage.Text + ".";


           

            try
            {
                MailMessage message = new MailMessage();
                message.To.Add("swaachclean@gmail.com");
                message.From = new MailAddress("aastha2150@gmail.com");
                message.Subject = "A new 'Request for Quote' received!";
                message.Body = body;
                message.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential nc = new NetworkCredential();
                nc.UserName = "aastha2150@gmail.com";
                nc.Password = "Goyal0412aastha";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = nc;
                smtp.Port = 587;
                smtp.Send(message);

                lblmessage2.Text = "* We have received your query and would be in contact shortly";
            }
            catch (Exception ex)
            {
                lblmessage2.Text = "* Error! " + ex.Message;
            }
        }

        protected void btnfinish_Click(object sender, EventArgs e)
        {
            string body = "<h1> Hello admin </h1> <br/>";
            body += "<br/>You have received a new 'Book service' request regarding 'Swaach Cleaning Services'. The details are as follows: <br/>";
            body += "<br/> First Name: " + txtfirstname.Text + "<br/>";
            body += "<br/> Last Name: " + txtlastname.Text + "<br/>";
            body += "<br/> Email Id: " + txtemail.Text + "<br/>";
            body += "<br/> Phone No: " + txtphone.Text + "<br/>";
            body += "<br/> Street No: " + txtstreetno.Text + "<br/>";
            body += "<br/> Region: " + txtregion.Text + "<br/>";
            body += "<br/> City: " + txttown.Text + "<br/>";
            body += "<br/> Post Code: " + txtpostcode.Text + "<br/>";
            body += "<br/> The preferred date and time for the booking are:<br/>";
            body += "<br/> Date: " + txtdate.Value + "<br/>";
            body += "<br/> Time: " + txttime.Value + "<br/>";




            try
            {
                MailMessage message = new MailMessage();
                message.To.Add("swaachclean@gmail.com");
                message.From = new MailAddress("aastha2150@gmail.com");
                message.Subject = "A new 'Request for Book service' received!";
                message.Body = body;
                message.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential nc = new NetworkCredential();
                nc.UserName = "aastha2150@gmail.com";
                nc.Password = "Goyal0412Aa$h1";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = nc;
                smtp.Port = 587;
                smtp.Send(message);

                lblmessage.Text = "* We have received your request and would be in contact shortly";
            }
            catch (Exception ex)
            {
                lblmessage.Text = "* Error! " + ex.Message;
            }

            Response.Redirect("PaymentPage.aspx");
        }
    }
}