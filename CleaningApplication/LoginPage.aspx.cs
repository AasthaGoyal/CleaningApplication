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

namespace CleaningApplication
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected async void btnConfirm_Click(object sender, EventArgs e)
        {
            await GetResponse(Environment.GetEnvironmentVariable("MyApikey"), nametxt.Text, emailidtxt.Text, phonetxt.Text, messagetxt.Text);
            messagelbl.Text = "The message has been successfully sent";
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