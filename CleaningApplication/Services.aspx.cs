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
    public partial class WebForm2 : System.Web.UI.Page
    {
        public SqlConnection con = null;
        String connectionString = null;
        SqlCommand cmd;
     
        SqlDataAdapter da;
        protected void Page_Load(object sender, EventArgs e)
        {
            connectionString = ConfigurationManager.ConnectionStrings["dbcleaningConnectionString"].ConnectionString;
            con = new SqlConnection(connectionString);

            if (!IsPostBack)
            {

                RepeterData();



            }

            con.Close();
        }

        public void RepeterData()
        {
            con.Open();

            cmd = new SqlCommand("Select * from tbcategory order by rank asc", con);
            DataSet ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            RepterDetails.DataSource = ds;
            RepterDetails.DataBind();



            con.Close();
        }
    }
}