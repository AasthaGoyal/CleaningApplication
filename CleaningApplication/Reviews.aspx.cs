using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CleaningApplication
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["dbcleaningConnectionString"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;

        protected void Page_Load(object sender, EventArgs e)
        {
            connectionString = ConfigurationManager.ConnectionStrings["dbcleaningConnectionString"].ConnectionString;
            con = new SqlConnection(connectionString);

            if (!IsPostBack)
            {

                loadReviews();
            }

        }

        public void loadReviews()
        {
            con.Open();

            cmd = new SqlCommand("Select * from tbreviews", con);
            DataSet ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            rpReviews.DataSource = ds;
            rpReviews.DataBind();
            con.Close();
        }


    }
}