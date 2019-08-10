using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CleaningApplication
{
    public partial class WebForm17 : System.Web.UI.Page
    {
        DataAccessLayer dao = new DataAccessLayer();
        string connectionString = ConfigurationManager.ConnectionStrings["dbcleaningConnectionString"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                loadData();
            }
        }

        public void loadData()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "select * from tbpanel";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    txtcname.Text = reader.GetString(0);
                    txtphoneno.Text = reader.GetString(1);
                    txtstreetAddress.Text = reader.GetString(2);
                    txttimings.Text = reader.GetString(3);
                    txtAboutus.Text = reader.GetString(4);
                    txtemail.Text = reader.GetString(5);
                 // txtphoneno.Text = reader.GetString(6);
                    imgLogo.ImageUrl = "~/" + reader.GetString(6);
                    txtsuburb.Text = reader.GetString(7);
                }
            }


        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string path = "";
            if(fpLogo.HasFile)
            {
                string filename = fpLogo.FileName;
                fpLogo.SaveAs(Server.MapPath("~/images/main-slider") + filename);
                 path = "~/images/main-slider/" + filename;
            }

            dao.updatePanel(txtcname.Text, txtphoneno.Text, txtstreetAddress.Text, txttimings.Text, txtAboutus.Text, txtemail.Text, path, txtsuburb.Text);
            lblmessage.Text = "The panel has been updated successfully";
            loadData();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            txtcname.Enabled = true;
            txtphoneno.Enabled = true;
            txtstreetAddress.Enabled = true;
            txttimings.Enabled = true;
            txtAboutus.Enabled = true;
            txtemail.Enabled = true;
        //    txtclogo.Enabled = true;
            txtsuburb.Enabled = true;
        }
    }
}