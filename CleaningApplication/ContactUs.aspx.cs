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
using Newtonsoft.Json;
using System.Net.Mime;

namespace CleaningApplication
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["dbcleaningConnectionString"].ConnectionString;
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {

            this.Master.contactus = System.Drawing.Color.DeepSkyBlue;
            FillContactData();
            if (!IsPostBack)
            {

                FillStaffData();
               
            }


        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {

            try
            {
                lblmsg.Text = "Sending message....please wait";
                MailMessage mailMsg = new MailMessage();

                mailMsg.To.Add(new MailAddress("swaachclean@gmail.com", "The Recipient"));

                mailMsg.From = new MailAddress("swaachclean@gmail.com", "The Sender");

                mailMsg.Subject = "A new query received from REQUEST QUOTE section";
                string text = "You have received a new query regarding swaach cleaning services.";
                string html = @"<strong> Name: </strong>" + txtname2.Text + " <br/>";
                html += @"<strong> Email Id: </strong>" + txtemailid.Text + "<br/>";
                html += @"<strong>Phone no: </strong>" + txtPhone.Text + "<br/>";
                html += @"<strong>Message: </strong>" + txtmessage2.Text + "<br/>";
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

                SmtpClient smtpClient = new SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587));
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("swaachclean", "Yajatshah@9");
                smtpClient.Credentials = credentials;

                smtpClient.Send(mailMsg);
                lblmsg.Text = "The message has been send";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                lblmsg.Text = "the error is" + ex.Message;
            }

        }  
            
         public void FillContactData()
        {

            conn = new SqlConnection(connectionString);
            string query = "select phoneNo, companyAddress, timings, companyEmail, phoneNo2 from tbPanel";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    lblPhone.Text = "(p)" + reader.GetString(0);
                    lblAddress.Text = reader.GetString(1);
                    lblTimings.Text = reader.GetString(2);
                    lblEmail.Text = reader.GetString(3);
                    lblphone2.Text = reader.GetString(4);

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
            RepStaff.DataSource = ds;
            RepStaff.DataBind();

        }




        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            btnSubmit.BackColor = System.Drawing.Color.Gray;
        

            try
            {
                lblMessage.Text = "Sending message....please wait";
                MailMessage mailMsg = new MailMessage();

                mailMsg.To.Add(new MailAddress("swaachclean@gmail.com", "The Recipient"));

                mailMsg.From = new MailAddress("swaachclean@gmail.com", "The Sender");

                mailMsg.Subject = "A new query received from CONTACT US page";
                string text = "You have received a new query regarding swaach cleaning services.";
                string html = @"<strong> Name: </strong>" + txtName.Text + " <br/>";
                html += @"<strong> Email Id: </strong>" + txtEmail.Text + "<br/>";
                html += @"<strong>Phone no: </strong>" + txtPhoneNo.Text + "<br/>";
                html += @"<strong>Message: </strong>" + txtMessage.Text + "<br/>";
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

                SmtpClient smtpClient = new SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587));
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

      
    }
}