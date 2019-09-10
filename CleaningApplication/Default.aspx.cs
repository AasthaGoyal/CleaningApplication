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

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            string body = "<h1> Hello admin </h1> <br/>";
            body += "<br/>You have received a new message regarding 'Swaach Cleaning Services'. The details are as follows: <br/>";
            body += "<br/> Customer Name: " + txtname.Text + "<br/>";
            body += "<br/> Email Id: " + txtemailid.Text + "<br/>";
            body += "<br/> Phone No: " + txtPhone.Text + "<br/>";
            body += "<br/> Message: " + txtmessage.Text + ".";


            lblMessage.Text = "Code reaching";

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

                lblMessage.Text = "* We have received your query and would be in contact shortly";
            }
            catch (Exception ex)
            {
                lblMessage.Text = "* Error! " + ex.Message;
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