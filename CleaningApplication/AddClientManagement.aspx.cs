using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CleaningApplication
{
    public partial class WebForm22 : System.Web.UI.Page
    {
        DataAccessLayer dao = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.client = System.Drawing.Color.DeepSkyBlue;
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            string imagename, path = "";

            if (fpLogo.HasFile)
            {
                imagename = fpLogo.FileName;
                fpLogo.SaveAs(Server.MapPath("~/images/main-slider/") + imagename);
                path = "/images/main-slider/" + imagename;

                try
                {
                    dao.addClient(path, txtcname.Text);
                    lblmessage.Text = "The client was added successfully";
                }
                catch(Exception ex)
                {
                    lblmessage.Text = "Error:" + ex.Message;
                }
              
                
            }
            else
            {
                lblmessage.Text = "Please upload a client logo image";
            }

            }
        }
}