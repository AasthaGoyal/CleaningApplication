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
    public partial class WebForm18 : System.Web.UI.Page
    {
        DataAccessLayer dao = new DataAccessLayer();
        string connectionString = ConfigurationManager.ConnectionStrings["dbcleaningConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.services = System.Drawing.Color.DeepSkyBlue;

            if (!IsPostBack)
            {
                loadData();
            }
        }

         

        public void loadData()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from tbcategory", connection);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            dao.deleteService(Convert.ToInt32(txtcategoryid.Text));
            lblmessage.Text = "The service is deleted successfully";
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string path = "";
            if(fpImage.HasFile)
            {
                string filename = fpImage.FileName;
                fpImage.SaveAs(Server.MapPath("~/images/main-slider") + filename);
                path = "~/images/main-slider/" + filename;
            }
            else
            {
                path = txtPhoto.Text;
            }

            dao.updateService(Convert.ToInt32(txtcategoryid.Text), txtname.Text, path, txtdescription.Text, Convert.ToInt32(txtrank.Text));
            lblmessage.Text = "The service has been successfully updated";
        }

      

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            txtcategoryid.Text = row.Cells[1].Text;
            txtname.Text = row.Cells[2].Text;
            imgPhoto.ImageUrl = "~" + row.Cells[3].Text;
            txtPhoto.Text = row.Cells[3].Text;
            txtdescription.Text = row.Cells[4].Text;
            txtrank.Text = row.Cells[5].Text;

        }

       
    }
}