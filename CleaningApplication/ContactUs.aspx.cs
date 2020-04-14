using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using Newtonsoft.Json;

namespace CleaningApplication
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["dbcleaningConnectionString"].ConnectionString;
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {

            this.Master.contactus = System.Drawing.Color.DeepSkyBlue;
            FillContactData();
            if (!IsPostBack)
            {

                FillStaffData();
               
            }


        }

        protected async void btnConfirm_Click(object sender, EventArgs e)
        {
            await GetResponse(Environment.GetEnvironmentVariable("MyApikey"), txtname2.Text, txtemailid.Text, txtPhone.Text, txtmessage2.Text);
            lblmsg.Text = "The message has been successfully sent";
        }

     
       
      
          

         public void FillContactData()
        {

            conn = new SqlConnection(connectionString);
            string query = "select phoneNo, companyAddress, timings, companyEmail, phoneNo2 from tbPanel";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    lblPhone.Text = "(p)" + reader.GetString(0);
                    lblAddress.Text = reader.GetString(1);
                    lblTimings.Text = reader.GetString(2);
                    lblEmail.Text = reader.GetString(3);
                    lblphone2.Text = reader.GetString(4);

                }
            }
            conn.Close();
        }

        public void FillStaffData()
        {
            conn = new SqlConnection(connectionString);

            conn.Open();
            SqlDataAdapter da;
            string query = "select * from tbStaff";
            SqlCommand cmd = new SqlCommand(query, conn);
            DataSet ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            RepStaff.DataSource = ds;
            RepStaff.DataBind();

        }




        protected async void btnSubmit_Click(object sender, EventArgs e)
        {
            //  Execute(Environment.GetEnvironmentVariable("MyApiKey"), ).Wait();
           await GetResponse(Environment.GetEnvironmentVariable("MyApikey"), txtName.Text, txtEmail.Text, txtPhoneNo.Text, txtMessage.Text);
           lblMessage.Text = "The message has been successfully sent";
        }

        public static async Task GetResponse(string apikey, string name, string email,string phoneno, string message )
        {
            // Retrieve the API key from the environment variables. See the project README for more info about setting this up.
            //   var apiKey = Environment.GetEnvironmentVariable("MyApikey");

            var client = new SendGridClient(apikey);
            string body = "<h1> Hello admin </h1> <br/>";
            body += "<br/>You have received a new message regarding 'Swaach Cleaning Services'. The details are as follows: <br/>";
            body += "<br/> Customer Name: " + name + "<br/>";
            body += "<br/> Email Id: " +email + "<br/>";
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
    }
}