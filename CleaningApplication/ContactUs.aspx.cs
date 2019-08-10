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
    public partial class WebForm4 : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["dbcleaningConnectionString"].ConnectionString;
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {


            FillContactData();
            if (!IsPostBack)
            {

                FillStaffData();
            }


        }

        public void FillContactData()
        {

            conn = new SqlConnection(connectionString);
            string query = "select phoneNo, companyAddress, timings from tbPanel";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    lblPhone.Text = reader.GetString(0);
                    lblAddress.Text = reader.GetString(1);
                    lblTimings.Text = reader.GetString(2);

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
            string body = "<h1> Hello admin </h1> <br/>";
            body += "<br/>You have received a new message regarding 'Swaach Cleaning Services'. The details are as follows: <br/>";
            body += "<br/> Customer Name: " + txtName.Text + "<br/>";
            body += "<br/> Email Id: " + txtEmail.Text + "<br/>";
            body += "<br/> Phone No: " + txtPhoneNo.Text + "<br/>";
            body += "<br/> Message: " + txtMessage.Text + ".";


           

            try
            {
                MailMessage message = new MailMessage();
                message.To.Add("swaachclean@gmail.com");
                message.From = new MailAddress("aastha2150@gmail.com");
                message.Subject = "A new 'Request for quote' received!";
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
    }
}