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
    public partial class WebForm10 : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["dbcleaningConnectionString"].ConnectionString;
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {



            if (!IsPostBack)
            {
                fillData();
                FillStaffData();
                loadReviews();
            }
        }

        public void fillData()
        {
            conn = new SqlConnection(connectionString);

            conn.Open();
           
            string query = "select * from tbaboutUs";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    lbltagline.Text = reader.GetString(1);
                    lblline1.Text = reader.GetString(2);
                    lblline2.Text = reader.GetString(3);
                    lblvalues.Text = reader.GetString(4);
                    lblmission.Text = reader.GetString(5);
                    lblvision.Text = reader.GetString(6);
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
            repStaff.DataSource = ds;
            repStaff.DataBind();

            conn.Close();

        }

        public void loadReviews()
        {
            conn.Open();

            SqlCommand cmd2 = new SqlCommand("Select * from tbreviews", conn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            da.Fill(ds);
            rpReviews.DataSource = ds;
            rpReviews.DataBind();
            conn.Close();
        }
    }
}