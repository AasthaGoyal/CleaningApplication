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
using System.Net.Mime;

namespace CleaningApplication
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["dbcleaningConnectionString"].ConnectionString;
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {

            this.Master.aboutus = System.Drawing.Color.DeepSkyBlue;

            if (!IsPostBack)
            {
                fillData();
                FillStaffData();
                loadReviews();
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
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





        public void fillData()
        {
            conn = new SqlConnection(connectionString);

            conn.Open();
           
            string query = "select * from tbaboutUs";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    lbltagline.Text = reader.GetString(1);
                    lblline1.Text = reader.GetString(2);
                    lblline2.Text = reader.GetString(3);
                    lblvalues.Text = reader.GetString(4);
                    lblmission.Text = reader.GetString(5);
                    lblvision.Text = reader.GetString(6);
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
            repStaff.DataSource = ds;
            repStaff.DataBind();

            conn.Close();

        }

        public void loadReviews()
        {
            conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("Select TOP 3 customerName, heading, review ,stars from tbreviews", conn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            rpReviews.DataSource = ds;
            rpReviews.DataBind();
            conn.Close();
        }

        protected void btnShowReviews_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reviews.aspx");
        }
    }
}