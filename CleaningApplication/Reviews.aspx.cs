using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
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