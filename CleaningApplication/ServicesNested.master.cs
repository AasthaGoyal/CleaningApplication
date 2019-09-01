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
    public partial class ServicesNested : System.Web.UI.MasterPage
    {
        DataAccessLayer dao = new DataAccessLayer();
       

        string connectionString = ConfigurationManager.ConnectionStrings["dbcleaningConnectionString"].ConnectionString;
        SqlConnection connection;
        SqlDataAdapter da;
       
        int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.services = System.Drawing.Color.DeepSkyBlue;
             id = Convert.ToInt32(Request.QueryString["categoryid"]);
             connection = new SqlConnection(connectionString);

            categoryDetails();
            if (!IsPostBack)
            {
                getAllcategories();
            }

          
            
            
        }

      



        public void categoryDetails()
        {
            string name="", desc="", image = "";
            connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "select categoryName, categoryDesc, categoryPhoto from tbcategory where categoryid ='" + id + "'";

            SqlCommand cmd = new SqlCommand(query, connection);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    name = reader.GetString(0);
                    desc = reader.GetString(1);
                    image = reader.GetString(2);
                }
            }
            lblname.Text = name;
            lblname2.Text = name;
            lblDesc.Text = desc;
            img.ImageUrl = image;
            connection.Close();
        }

        public void getAllcategories()
        {
            connection.Open();

           SqlCommand cmd = new SqlCommand("Select categoryid,categoryName from tbcategory", connection);
            DataSet ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            repeaterCatg.DataSource = ds;
            repeaterCatg.DataBind();



            connection.Close();
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            string body = "<h1> Hello admin </h1> <br/>";
            body += "<br/>You have received a new message regarding 'Swaach Cleaning Services'. The details are as follows: <br/>";
            body += "<br/> Customer Name: " + txtname.Text + "<br/>";
            body += "<br/> Email Id: " + txtemail.Text + "<br/>";
            body += "<br/> Phone No: " + txtPhoneNo.Text + "<br/>";
            body += "<br/> Message: " + txtMessage.Text + ".";




            try
            {
                MailMessage message = new MailMessage();
                message.To.Add("aastha2150@gmail.com");
                message.From = new MailAddress("aastha2150@gmail.com");
                message.Subject = "A new message received!";
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

                lblmessage.Text = "* We have received your query and would be in contact shortly";
            }
            catch (Exception ex)
            {
                lblmessage.Text = "* Error! " + ex.Message;
            }
        }

        public string statusheading
        {
            get
            {
                return lblcustomize.Text;
            }

            set
            {
                lblcustomize.Text = value;
            }
        }
    }
}