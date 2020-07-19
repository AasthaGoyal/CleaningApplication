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
using System.Net.Mime;
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

        protected  void btnConfirm_Click(object sender, EventArgs e)
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