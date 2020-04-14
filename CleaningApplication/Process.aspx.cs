using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CleaningApplication
{
    public partial class WebForm12 : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["dbcleaningConnectionString"].ConnectionString;
       

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.process = System.Drawing.Color.DeepSkyBlue;

            getProcess();
        }

        public async void btnConfirm_Click(object sender, EventArgs e)
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

        public void getProcess()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "select * from tbprocess";
            SqlCommand cmd = new SqlCommand(query, connection);

            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.HasRows)
            {
                while (reader.Read())
                {
                    if (Convert.ToInt32(reader["processid"]) == 1)
                    {
                        lblname1.Text = reader.GetString(1);
                        lblprocess1.Text = reader.GetString(2);
                        lblhead1.Text = reader.GetString(3);
                    }
                    else if (Convert.ToInt32(reader["processid"]) == 2)
                    {
                        lblname2.Text = reader.GetString(1);
                        lblProcess2.Text = reader.GetString(2);
                        lblhead2.Text = reader.GetString(3);
                    }
                    else if (Convert.ToInt32(reader["processid"]) == 3)
                    {
                        lblname3.Text = reader.GetString(1);
                        lblprocess3.Text = reader.GetString(2);
                        lblhead3.Text = reader.GetString(3);
                    }
                    else
                    {
                        lblname4.Text = reader.GetString(1);
                        lblprocess4.Text = reader.GetString(2);
                        lblhead4.Text = reader.GetString(3);
                    }
                }
            }
        }

        protected void btnProcess1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ContactUs.aspx");
        }

        protected void btnProcess2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Services.aspx");
        }

        protected void btnProcess3_Click(object sender, EventArgs e)
        {
            Response.Redirect("AboutUs.aspx");
        }

        protected void btnProcess4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reviews.aspx");
        }
    }
}