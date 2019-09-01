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
    public partial class WebForm13 : System.Web.UI.Page
    {
        DataAccessLayer dao = new DataAccessLayer();
        string connectionString = ConfigurationManager.ConnectionStrings["dbcleaningConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.client = System.Drawing.Color.DeepSkyBlue;
            if(!IsPostBack)
            {
                loadData();
            }
        }

        public void loadData()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from tbclient", connection);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

       


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string path = "";

            if (fpLogo.HasFile)
            {
                string filename = fpLogo.FileName;
                fpLogo.SaveAs(Server.MapPath("~/images/main-slider") + filename);
                path = "~/images/main-slider/" + filename;
            }
            else
            {
                path = Session["logoimage"].ToString();
            }
            dao.updateClient(Convert.ToInt32(txtclientid.Text), path, txtcname.Text);
            lblmessage.Text = "The client has been updated successfully";
            loadData();
        }


        protected void btnDelete_Click(object sender, EventArgs e)
        {
            dao.deleteClient(Convert.ToInt32(txtclientid.Text));
            loadData();
            lblmessage.Text = "The client has been successfully deleted";
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            txtclientid.Text = row.Cells[1].Text;
           imgLogo.ImageUrl = "~" + row.Cells[2].Text;
            txtcname.Text = row.Cells[3].Text;

            Session["logoImage"] = "~" + row.Cells[2].Text;

        }
    }
}