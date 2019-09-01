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
    public partial class WebForm16 : System.Web.UI.Page
    {
        int id;
        DataAccessLayer dao = new DataAccessLayer();
        string connectionString = ConfigurationManager.ConnectionStrings["dbcleaningConnectionString"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.process = System.Drawing.Color.DeepSkyBlue;
            if(!IsPostBack)
            {
                populateData();
            }
            
        }

        protected void gdProcess_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow  row = gdProcess.SelectedRow;
            id = Convert.ToInt32(row.Cells[1].Text);
            txtprocessid.Text = row.Cells[1].Text;
            txtname.Text = row.Cells[2].Text;
            txtheading.Text = row.Cells[3].Text;
            txtdescription.Text = row.Cells[4].Text;

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
          
           dao.updateProcess(Convert.ToInt32(txtprocessid.Text), txtname.Text, txtheading.Text, txtdescription.Text);
            populateData();
            lblmessage.Text = "The process has been successfully updated";
            
            
      
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            dao.deleteProcess(id);
            populateData();
            lblmessage.Text = "The process has been successfully deleted";
        }

        public void populateData()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from tbprocess", connection);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            gdProcess.DataSource = ds;
            gdProcess.DataBind();

        }
    }
}