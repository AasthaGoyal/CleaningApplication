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
    public partial class WebForm14 : System.Web.UI.Page
    {
        DataAccessLayer dao = new DataAccessLayer();
        string connectionString = ConfigurationManager.ConnectionStrings["dbcleaningConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
           

            if (!IsPostBack)
            {
                loadData();
            }
        }

        public void loadData()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "select * from tbaboutUs";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    txttagline.Text = reader.GetString(1);
                    txtline1.Text = reader.GetString(2);
                    txtline2.Text = reader.GetString(3);
                    txtcore.Text = reader.GetString(4);
                    txtmission.Text = reader.GetString(5);
                    txtvision.Text = reader.GetString(6);
                }
            }
            connection.Close();

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            dao.updateAboutus(txttagline.Text, txtline1.Text, txtline2.Text, txtcore.Text, txtmission.Text, txtvision.Text);
            lblmessage.Text = "The fields were updated successfully!";
            loadData();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            txttagline.Enabled = true;
            txtline1.Enabled = true;
            txtline2.Enabled = true;
            txtcore.Enabled = true;
            txtmission.Enabled = true;
            txtvision.Enabled = true;

        }
    }
}