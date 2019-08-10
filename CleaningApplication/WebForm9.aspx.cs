using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CleaningApplication
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            saveRating();
        }

        public void saveRating()
        {
            string val = hdfRatingValue.Value;
            lblrating.Text = val;
        }
    }
}