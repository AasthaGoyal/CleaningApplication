using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Configuration;
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
    public partial class WebForm12 : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["dbcleaningConnectionString"].ConnectionString;
       

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.process = System.Drawing.Color.DeepSkyBlue;

            getProcess();
        }

        public  void btnConfirm_Click(object sender, EventArgs e)
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