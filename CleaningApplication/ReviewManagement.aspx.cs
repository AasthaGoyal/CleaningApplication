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
    public partial class WebForm15 : System.Web.UI.Page
    {
        
        DataAccessLayer dao = new DataAccessLayer();
        string connectionString = ConfigurationManager.ConnectionStrings["dbcleaningConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                populateData();
            }
        }

        public void populateData()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from tbreviews", connection);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            gdReviews.DataSource = ds;
            gdReviews.DataBind();
        }

        protected void gdReviews_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gdReviews.SelectedRow;
            txtreviewid.Text = row.Cells[1].Text;
            txtname.Text = row.Cells[2].Text;
            txtheading.Text = row.Cells[3].Text;
            txtreview.Text = row.Cells[4].Text;
            txtstars.Text = row.Cells[5].Text;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            dao.updateReview(Convert.ToInt32(txtreviewid.Text), txtheading.Text, txtreview.Text, txtname.Text,Convert.ToInt32(txtstars.Text));

            populateData();
        
           lblmessage.Text = "The review has been successfully updated";
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            dao.deleteReview(Convert.ToInt32(txtreviewid.Text));
            populateData();
            lblmessage.Text = "The review has been successfully deleted";
        }
    }
}