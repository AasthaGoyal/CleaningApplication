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
    public partial class WebForm20 : System.Web.UI.Page
    {
        DataAccessLayer dao = new DataAccessLayer();
        string connectionString = ConfigurationManager.ConnectionStrings["dbcleaningConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.staff = System.Drawing.Color.DeepSkyBlue;
            if(!IsPostBack)
            {
                populateData();
            }
        }

        public void populateData()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from tbstaff", connection);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            gdStaff.DataSource = ds;
            gdStaff.DataBind();
        }

        protected void gdStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gdStaff.SelectedRow;
            txtid.Text = row.Cells[1].Text;
            txtname.Text = row.Cells[2].Text;
            txtaddress.Text = row.Cells[7].Text;
            txtphone.Text = row.Cells[6].Text;
            txtemail.Text = row.Cells[5].Text;
            txtPosition.Text = row.Cells[4].Text;
            imgPhoto.ImageUrl = row.Cells[3].Text;
            txtusername.Text = row.Cells[8].Text;
            txtphoto.Text = row.Cells[3].Text;
         

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string  path;
            if(fpImage.HasFile)
            {
                string filename = fpImage.FileName;
                fpImage.SaveAs(Server.MapPath("~/images/main-slider") + filename);
                path = "~/images/main-slider/" + filename;
            }
            else
            {
                path = txtphoto.Text;
            }
            dao.updateStaff(Convert.ToInt32(txtid.Text), txtname.Text, txtaddress.Text, Convert.ToInt32(txtphone.Text), txtemail.Text, txtPosition.Text, path, txtusername.Text);
            lblmessage.Text = "The staff information has been updated successfully";

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            dao.deleteStaff(Convert.ToInt32(txtid.Text));
            lblmessage.Text = "The staff has been successfully deleted";
        }
    }
}