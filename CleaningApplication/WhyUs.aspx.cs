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