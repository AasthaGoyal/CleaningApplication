using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
    public partial class WebForm5 : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["dbcleaningConnectionString"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.reviews = System.Drawing.Color.DeepSkyBlue;

            connectionString = ConfigurationManager.ConnectionStrings["dbcleaningConnectionString"].ConnectionString;
            con = new SqlConnection(connectionString);

            if (!IsPostBack)
            {

                loadReviews();
                
            }

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
        public void loadReviews()
        {
            con.Open();

            cmd = new SqlCommand("Select customerName, heading, review ,stars from tbreviews", con);
            DataSet ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
          
            rpReviews.DataSource = ds;
            rpReviews.DataBind();
            con.Close();
        }


    }
}