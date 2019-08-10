using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CleaningApplication
{
    public partial class WebForm11 : System.Web.UI.Page
    {
        DataAccessLayer dao = new DataAccessLayer();
        string connectionString = ConfigurationManager.ConnectionStrings["dbcleaningConnectionString"].ConnectionString;
        List<String> colnames = new List<String>();

        protected void Page_Load(object sender, EventArgs e)
        {
           


        }

        protected void dpcategory_SelectedIndexChanged(object sender, EventArgs e)
        {


            dpdetails.Items.Clear();
            string input = dpcategory.SelectedValue;
            int id = dao.getCatid(input);


            //      lblMessage.Text = id.ToString();

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "select serviceDesc from tbservices where categoryid =" + id;
            //  lblMessage.Text = query;
            SqlCommand cmd = new SqlCommand(query, connection);

            dpdetails.DataSource = cmd.ExecuteReader();

            dpdetails.DataTextField = "serviceDesc";
            dpdetails.DataValueField = "serviceDesc";
            dpdetails.DataBind();
            loadDetailsData();
            loadExtraData();
        }

      

        public void loadExtraData()
        {
            string input = dpcategory.SelectedItem.Text;
            int id = dao.getCatid(input);
            int serviceid = dao.getserviceid(dpdetails.SelectedItem.Text, id);

       //    lblMessage.Text = serviceid.ToString();

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from tbExtras where serviceid = " + serviceid, connection);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            gdExtras.DataSource = ds;
            gdExtras.DataBind();

        }
    

        protected void dpdetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                loadDetailsData();
              
            }

            loadExtraData();

        }

       
        public void loadDetailsData()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string input = dpcategory.SelectedItem.Text;
            int id = dao.getCatid(input);


            if (!string.IsNullOrEmpty(dpdetails.SelectedValue))
            {
                if(id == 9 || id == 12 )
                {
                    gdExtras.Visible = false;
                    GridView1.Visible = false;
                    lblMessage.Text = "No details exist";
                }
                else
                {
                    var cmd = "select * from tb" + dpdetails.SelectedValue;

                    var dt = new DataTable();
                    var da = new SqlDataAdapter(cmd, connection);
                    da.Fill(dt);

                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                // var dbPath = Server.MapPath(@"\App_Data\Database1.mdf");
                //  var scon = "Data Source=aago001;Initial catalog=dbcleaning; Integrated Security=True";
              
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            txtid.Text = row.Cells[1].Text;
            txtname.Text = row.Cells[2].Text;
            txtprice.Text = row.Cells[3].Text;
            

            foreach (DataControlFieldCell cell in row.Cells)
            {
                if (cell.ContainingField is BoundField)
                {
                    colnames.Add(((BoundField)cell.ContainingField).DataField);
                   

                }
                    
            }


            StringBuilder query = new StringBuilder();
            //for(int i=0;i<colnames.Count;i++)
            //{
            //    TableRow row2 = new TableRow();
            //    TableCell cell1 = new TableCell();
            //    TableCell cell2 = new TableCell();
            //    cell1.Text = colnames[i];
            //    TextBox txt = new TextBox();
            //    txt.Text = row.Cells[i+1].Text;
            //    row2.Cells.Add(cell1);
            //    row2.Cells.Add(cell2);
            //}

            foreach (string item in colnames)
            {
                query.Append("," + item);
            }
            lblMessage.Text = query.ToString();

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            if(GridView1.SelectedIndex >=0)
            {
                string[] getcolns = lblMessage.Text.Split(',');

                string query = "update tb" + dpdetails.SelectedValue + " set " + getcolns[2] + "='" + txtname.Text + "', " + getcolns[3] + "='" + txtprice.Text + "' where " + getcolns[1] + "= '" + txtid.Text + "'";
                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.ExecuteNonQuery();
                lblfeedback.Text = "The service was updated successfully";
                loadExtraData();
                loadDetailsData();

            }
            else if(gdExtras.SelectedIndex >=0)
            {
                string query2 = "update tbExtras set extraName='" + txtextraname.Text + "', eprice='" + txtextraprice.Text + "' where extraid =" + txtextraid.Text;
                SqlCommand cmd2 = new SqlCommand(query2, connection);
                cmd2.ExecuteNonQuery();

                lblfeedback.Text = "The service was updated successfully";
                loadExtraData();
                loadDetailsData();

            }

            
            else
            {
                lblfeedback.Text = "Please select a service to update";
            }


        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string[] getcolns = lblMessage.Text.Split(',');

            string query = "delete from tb" + dpdetails.SelectedValue + " where " + getcolns[1] + "= '" + txtid.Text + "'";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.ExecuteNonQuery();
            loadExtraData();
            loadDetailsData();
            lblfeedback.Text = "The service was deleted successfully";

        }

        protected void gdExtras_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gdExtras.SelectedRow;
            txtextraid.Text = row.Cells[1].Text;
            txtextraname.Text = row.Cells[2].Text;
            txtextraprice.Text = row.Cells[3].Text;

        }
    }
}