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

namespace CleaningApplication
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        
        String connectionString =  ConfigurationManager.ConnectionStrings["dbcleaningConnectionString"].ConnectionString;


        SqlCommand cmd;
       
        SqlDataAdapter da;


        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.home = System.Drawing.Color.DeepSkyBlue;
           
            if (!IsPostBack)
            {

                RepeterData();
                getReviews();

                loadProcess();
            }
            

          
        }

      

        public void RepeterData()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            cmd = new SqlCommand("Select * from tbcategory order by rank asc", con);
            DataSet ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            RepterDetails.DataSource = ds;
            RepterDetails.DataBind();



            con.Close();
        }

        protected async void btnConfirm_Click(object sender, EventArgs e)
        {
            await GetResponse(Environment.GetEnvironmentVariable("MyApikey"), txtname.Text, txtemailid.Text, txtPhone.Text, txtmessage.Text);
            lblMessage.Text = "The message has been successfully sent";
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
        public void loadProcess()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "select * from tbprocess";
            SqlCommand cmd = new SqlCommand(query, connection);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (Convert.ToInt32(reader["processid"]) == 1)
                    {
                       
                        lblhead1.Text = reader.GetString(3);
                    }
                    else if (Convert.ToInt32(reader["processid"]) == 2)
                    {
                        
                        lblhead2.Text = reader.GetString(3);
                    }
                    else if (Convert.ToInt32(reader["processid"]) == 3)
                    {
                        
                        lblhead3.Text = reader.GetString(3);
                    }
                    else
                    {
                       
                        lblhead4.Text = reader.GetString(3);
                    }
                }
            }
        }

        public void getReviews()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
           

            cmd = new SqlCommand("Select TOP 3 customerName, heading, review ,stars from tbreviews", con);
            DataSet ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            rpReviews.DataSource = ds;
            rpReviews.DataBind();
            con.Close();

        }

        protected void btnShowReviews_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reviews.aspx");
        }
    }
}