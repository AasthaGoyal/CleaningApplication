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

namespace CleaningApplication
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            string body = "<h1> Hello admin </h1> <br/>";
            body += "<br/>You have received a new message regarding 'Swaach Cleaning Services'. The details are as follows: <br/>";
            body += "<br/> Customer Name: " + nametxt.Text + "<br/>";
            body += "<br/> Email Id: " + emailidtxt.Text + "<br/>";
            body += "<br/> Phone No: " + phonetxt.Text + "<br/>";
            body += "<br/> Message: " + messagetxt.Text + ".";

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

                messagelbl.Text = "* We have received your query and would be in contact shortly";
            }
            catch (Exception ex)
            {
                messagelbl.Text = "* Error! " + ex.Message;
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