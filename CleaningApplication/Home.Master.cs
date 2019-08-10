using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CleaningApplication
{
    public partial class Home : System.Web.UI.MasterPage
    {
        string connectionString = ConfigurationManager.ConnectionStrings["dbcleaningConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            FillContactData();
            

        }

        public void FillContactData()
        {
            SqlConnection conn = new SqlConnection(connectionString);

            string query = "select logo, companyName, phoneNo, companyAddress, timings, aboutUs, companyEmail, suburb from tbPanel";

            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //logoImage.ImageUrl = reader.GetString(0);
                    //lblname.Text = reader.GetString(1);
                    lblphone.Text = reader.GetString(2);
                    lbladdress.Text = reader.GetString(3);
                    lbltime.Text = reader.GetString(4);

                    lblfphone.Text = reader.GetString(2);
                    lblfemail.Text = reader.GetString(6);
                    lblfaddress.Text = reader.GetString(3);
                    footerImage.ImageUrl = reader.GetString(0);
                    lblAboutus.Text = reader.GetString(5);
                    lblsuburb.Text = reader.GetString(7);
                }
            }
        }

    }
}