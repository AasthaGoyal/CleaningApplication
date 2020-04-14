using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CleaningApplication
{
    public partial class WebForm25 : System.Web.UI.Page
    {
        DataAccessLayer dao = new DataAccessLayer();
        List<string> controlIdList = new List<string>();
      
        string connectionString = ConfigurationManager.ConnectionStrings["dbcleaningConnectionString"].ConnectionString;
        int countOption = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            int rank = dao.getMaxRank();
            txtcrank.Text = (rank + 1).ToString();
            this.Master.services = System.Drawing.Color.DeepSkyBlue;

        }


        protected void btnaddCategory_Click(object sender, EventArgs e)
        {
            string imagename, path = "";

            int categoryid = 0;
            countOption++;

            if (fpPhoto.HasFile)
            {
                imagename = fpPhoto.FileName;
                fpPhoto.SaveAs(Server.MapPath("~/images/category/") + imagename);
                path = "/images/category/" + imagename;

                try
                {

                    categoryid = dao.addCategory(txtcname.Text, path, txtcdescription.Text, Convert.ToInt32(txtcrank.Text));
                    Session["categoryid"] = categoryid.ToString();
                    lblmessage.Text = "The service has been successfully created";
                }
                catch (Exception ex)
                {
                    lblmessage.Text = "Error:" + ex.Message;
                }
            }
            else
            {
                lblmessage.Text = "Please upload a category logo image";
            }
           
        }

        protected void btnaddOptions_Click(object sender, EventArgs e)
        {
            string categoryid = Session["categoryid"].ToString();
            Response.Redirect("AddChecklist.aspx?categoryid =" + categoryid);
        }
    }
}