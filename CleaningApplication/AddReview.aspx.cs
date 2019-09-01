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
    public partial class WebForm6 : System.Web.UI.Page
    {
        DataAccessLayer dao = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.reviews = System.Drawing.Color.DeepSkyBlue;
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            string body = "<h1> Hello admin </h1> <br/>";
            body += "<br/>You have received a new message regarding 'Swaach Cleaning Services'. The details are as follows: <br/>";
            body += "<br/> Customer Name: " + txtname2.Text + "<br/>";
            body += "<br/> Email Id: " + txtemailid.Text + "<br/>";
            body += "<br/> Phone No: " + txtPhone.Text + "<br/>";
            body += "<br/> Message: " + txtmessage.Text + ".";


            lblmessage2.Text = "Code reaching";

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

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtname.Text != "")
                {
                    dao.addReview(txtname.Text, txtHeading.Text, txtReview.Text, Rating1.CurrentRating);

                }
                else
                {
                    dao.addReview("Anoynomous Customer", txtHeading.Text, txtReview.Text, Rating1.CurrentRating);

                }
                lblMessage.Text = "Thanks for your feedback!";
            }
            catch(Exception ex)
            {
                lblMessage.Text = "Problem in submitting feedback" + ex.Message;
            }


        }
    }
}