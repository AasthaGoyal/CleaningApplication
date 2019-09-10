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
    public partial class WebForm24 : System.Web.UI.Page
    {
        
        String connectionString =  ConfigurationManager.ConnectionStrings["dbcleaningConnectionString"].ConnectionString;

        

        protected void Page_Load(object sender, EventArgs e)
        {
             int storyid = Convert.ToInt32(Request.QueryString["storyid"]);

            Session["id"] = storyid.ToString();
            lblheading.Text = "Stories/" +  storyid.ToString();

            show_data();
        }

        public void show_data()
        {
            int id = Convert.ToInt32(Session["id"]);
            txtbox.Text = id.ToString();
            //SqlConnection conn = new SqlConnection(connectionString);

            //SqlCommand cmd = new SqlCommand("select imagePhoto from tbimages where storyid = " + id, conn);
            //conn.Open();

            //SqlDataReader dr = cmd.ExecuteReader();
            //DataTable dt = new DataTable();
            //dt.Load(dr);
            //dr.Close();
            //conn.Close();

            //Repeater1.DataSource = dt;
            //Repeater1.DataBind();


        }

     



    }
}