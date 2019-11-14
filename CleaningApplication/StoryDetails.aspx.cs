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
    public partial class WebForm27 : System.Web.UI.Page
    {
        String connectionString = ConfigurationManager.ConnectionStrings["dbcleaningConnectionString"].ConnectionString;

        DataAccessLayer dao = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.stories = System.Drawing.Color.DeepSkyBlue;

            int storyid = Convert.ToInt32(Request.QueryString["storyid"]);
            string name = dao.getStoryName(storyid);


            Session["id"] = storyid.ToString();
            lblheading.Text = "Stories/" + name;

            if (!IsPostBack)
            {

                loadBeforeImages();
                loadAfterImages();
                loadDetails();

            }

           
        }

        public void loadBeforeImages()
        {
            int id = Convert.ToInt32(Session["id"]);
          
            SqlConnection conn = new SqlConnection(connectionString);


            DataSet ds = new DataSet();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "select imagePhoto, imageid from tbimages where storyid = " + id;
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "image");

                string query2 = "select imageid from tbimages where storyid =" + id + " and imageType='Before'";
                SqlCommand cmd2 = new SqlCommand(query2, con);
                 id = Convert.ToInt32(cmd2.ExecuteScalar());

                ViewState["ImageData"] = ds;
                ViewState["ImageDisplayed"] = id;
            }


            DataRow imageDataRow = ds.Tables["image"].Select().FirstOrDefault(x => x["imageid"].ToString() == id.ToString());

            Image1.ImageUrl = imageDataRow["imagePhoto"].ToString();
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            int i = (int)ViewState["ImageDisplayed"];
            i = i + 1;
            ViewState["ImageDisplayed"] = i;

            DataRow imageDataRow = ((DataSet)ViewState["ImageData"]).Tables["image"].Select().FirstOrDefault(x => x["imageid"].ToString() == i.ToString());
            if (imageDataRow != null)
            {
                Image1.ImageUrl = imageDataRow["imagePhoto"].ToString();

            }
            else
            {
                loadBeforeImages();
            }


        }

        public void loadDetails()
        {
            int id = Convert.ToInt32(Session["id"]);

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string query = "select storyDesc from tbstory where storyid =" + id;
            SqlCommand cmd = new SqlCommand(query, conn);

            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.HasRows)
            {
                while(reader.Read())
                {
                   
                    lbldesc.Text = reader.GetString(0);

                }
            }
            conn.Close();
        }

        //for after images
        public void loadAfterImages()
        {
            int id = Convert.ToInt32(Session["id"]);
           
            SqlConnection conn = new SqlConnection(connectionString);


            DataSet ds = new DataSet();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "select imagePhoto, imageid from tbimages where storyid = " + id;
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "image");

                string query2 = "select imageid from tbimages where storyid =" + id + " and imageType='After'";
                SqlCommand cmd2 = new SqlCommand(query2, con);
                id = Convert.ToInt32(cmd2.ExecuteScalar());

                ViewState["ImageData"] = ds;
                ViewState["ImageDisplayed"] = id;
            }


            DataRow imageDataRow = ds.Tables["image"].Select().FirstOrDefault(x => x["imageid"].ToString() == id.ToString());

            Image2.ImageUrl = imageDataRow["imagePhoto"].ToString();
        }

        protected void Timer2_Tick(object sender, EventArgs e)
        {
            int i = (int)ViewState["ImageDisplayed"];
            i = i + 1;
            ViewState["ImageDisplayed"] = i;

            DataRow imageDataRow = ((DataSet)ViewState["ImageData"]).Tables["image"].Select().FirstOrDefault(x => x["imageid"].ToString() == i.ToString());
            if (imageDataRow != null)
            {
                Image2.ImageUrl = imageDataRow["imagePhoto"].ToString();

            }
            else
            {
                loadAfterImages();
            }


        }

    }
}