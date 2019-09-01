using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
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