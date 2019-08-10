using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CleaningApplication
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        DataAccessLayer dao = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtname.Text != "")
                {
                    dao.addReview(txtname.Text, txtHeading.Text, txtReview.Text, Convert.ToInt32(dpStars.SelectedItem.Text));

                }
                else
                {
                    dao.addReview("Anoynomous Customer", txtHeading.Text, txtReview.Text, Convert.ToInt32(dpStars.SelectedItem.Text));

                }
                lblMessage.Text = "Thanks for your feedback!";
            }
            catch(Exception ex)
            {
                lblMessage.Text = "Problem in submitting feedback" + ex.Message;
            }


        }
    }
}