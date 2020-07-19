using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net.Mime;

namespace CleaningApplication
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected  void btnConfirm_Click(object sender, EventArgs e)
        {
           
            try
            {
                messagelbl.Text = "Sending message....please wait";
                MailMessage mailMsg = new MailMessage();

                mailMsg.To.Add(new MailAddress("swaachclean@gmail.com", "The Recipient"));

                mailMsg.From = new MailAddress("swaachclean@gmail.com", "The Sender");

                mailMsg.Subject = "A new query received from REQUEST QUOTE section";
                string text = "You have received a new query regarding swaach cleaning services.";
                string html = @"<strong> Name: </strong>" + nametxt.Text + " <br/>";
                html += @"<strong> Email Id: </strong>" + emailidtxt.Text + "<br/>";
                html += @"<strong>Phone no: </strong>" + phonetxt.Text + "<br/>";
                html += @"<strong>Message: </strong>" + messagetxt.Text + "<br/>";
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

                System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient("smtp.sendgrid.net",
                                                       Convert.ToInt32(587));
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("swaachclean", "Yajatshah@9");
                smtpClient.Credentials = credentials;

                smtpClient.Send(mailMsg);
                messagelbl.Text = "The message has been send";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                messagelbl.Text = "the error is" + ex.Message;
            }
        }

        
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            DataAccessLayer dao = new DataAccessLayer();
            StringBuilder builder = new StringBuilder();
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(txtPassword.Text));

                // Convert byte array to a string   
                
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
            }
                string name = dao.userLogin(txtUsername.Text, builder.ToString());

            if(name == null)
            {
                lblmessage.ForeColor = System.Drawing.Color.Red;
                lblmessage.Text = "Invalid username or password";

            }
            else
            {
                lblmessage.ForeColor = System.Drawing.Color.Green;
                lblmessage.Text = "Welcome " + name;
                Response.Redirect("ReviewManagement.aspx");
            }
        }
    }
}