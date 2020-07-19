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
using System.Net.Mime;

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
            Console.WriteLine("the connection is", con);
            con.Open();

            cmd = new SqlCommand("Select * from tbcategory order by rank asc", con);
            DataSet ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            RepterDetails.DataSource = ds;
            RepterDetails.DataBind();



            con.Close();
        }

        protected  void btnConfirm_Click(object sender, EventArgs e)
        {
           
            try
            {
                lblMessage.Text = "Sending message....please wait";
                MailMessage mailMsg = new MailMessage();

                mailMsg.To.Add(new MailAddress("swaachclean@gmail.com", "The Recipient"));

                mailMsg.From = new MailAddress("swaachclean@gmail.com", "The Sender");

                mailMsg.Subject = "A new query received from REQUEST QUOTE section";
                string text = "You have received a new query regarding swaach cleaning services.";
                string html = @"<strong> Name: </strong>" + txtname.Text + " <br/>";
                html += @"<strong> Email Id: </strong>" + txtemailid.Text + "<br/>";
                html += @"<strong>Phone no: </strong>" + txtPhone.Text + "<br/>";
                html += @"<strong>Message: </strong>" + txtmessage.Text + "<br/>";
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

                System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient("smtp.sendgrid.net",
                                                       Convert.ToInt32(587));
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("swaachclean", "Yajatshah@9");
                smtpClient.Credentials = credentials;

                smtpClient.Send(mailMsg);
                lblMessage.Text = "The message has been send";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                lblMessage.Text = "the error is" + ex.Message;
            }
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