using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CleaningApplication
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["dbcleaningConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Butpass_Click(object sender, EventArgs e)
        {
            
                 SqlConnection sqlconn = new SqlConnection(connectionString);
                string sqlquery = "select firstName, emailid  from tbperson where emailid=@emailid";
                SqlCommand sqlComm = new SqlCommand(sqlquery, sqlconn);
                sqlComm.Parameters.AddWithValue("@emailid", TxtEmail.Text);
                sqlconn.Open();
                SqlDataReader sdr = sqlComm.ExecuteReader();
                if (sdr.Read())
                {
                    string firstname = sdr.GetString(0);
                    string emailid = sdr.GetString(1);
                    string link = "http://localhost:7278/ResetPassword.aspx";

                    MailMessage mm = new MailMessage("aastha2150@gmail.com", TxtEmail.Text);
                    mm.Subject = "Reset password confirmation email !";
                    mm.Body = string.Format("Hello <h2> {0} </h2>: <br/> We receieved a request to rest your password of the account registered with the email id: {1}. <br/>Click on the link below to reset your password <br/> <h2>{2}</h2>", firstname, emailid, link);
                    mm.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential nc = new NetworkCredential();
                    nc.UserName = "aastha2150@gmail.com";
                    nc.Password = "Goyal0412aastha";
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = nc;
                    smtp.Port = 587;
                    smtp.Send(mm);
                    lblmsg.Text = "The Reset password link has been sent to " + TxtEmail.Text;
                    lblmsg.ForeColor = Color.Green;


                }
                else
                {
                    lblmsg.Text = TxtEmail.Text + "The email id is not already registered!";
                    lblmsg.ForeColor = Color.Red;

                }
            
        }
    }
}