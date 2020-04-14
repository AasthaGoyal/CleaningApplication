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
    public partial class WebForm26 : System.Web.UI.Page
    {
        DataAccessLayer dao = new DataAccessLayer();
        string connectionString = ConfigurationManager.ConnectionStrings["dbcleaningConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.stories = System.Drawing.Color.DeepSkyBlue;
            if (!IsPostBack)
            {
                populateData();
            }

        }

        protected void gdStories_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gdStories.SelectedRow;
            txtid.Text = row.Cells[1].Text;
        }

        public void populateData()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from tbstory", connection);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            gdStories.DataSource = ds;
            gdStories.DataBind();
        }


        protected void btnDelete_Click(object sender, EventArgs e)
        {
            dao.deleteStory(Convert.ToInt32(txtid.Text));
            populateData();
            lblmessage.Text = "The story with the Id " + txtid.Text + " has been successfully deleted";

        }
    }
}