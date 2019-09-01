using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CleaningApplication
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public System.Drawing.Color panel
        {
            get
            {
                return navpanel.ForeColor;
            }

            set
            {
                navpanel.ForeColor = value;
            }
        }

        public System.Drawing.Color aboutus
        {
            get
            {
                return navabtus.ForeColor;
            }

            set
            {
                navabtus.ForeColor = value;
            }
        }

        public System.Drawing.Color process
        {
            get
            {
                return navProcess.ForeColor;
            }

            set
            {
                navProcess.ForeColor = value;
            }
        }

        public System.Drawing.Color review
        {
            get
            {
                return navReview.ForeColor;
            }

            set
            {
                navReview.ForeColor = value;
            }
        }

        public System.Drawing.Color services
        {
            get
            {
                return navservices.ForeColor;
            }

            set
            {
                navservices.ForeColor = value;
            }
        }

        public System.Drawing.Color staff
        {
            get
            {
                return navStaff.ForeColor;
            }

            set
            {
                navStaff.ForeColor = value;
            }
        }

        public System.Drawing.Color client
        {
            get
            {
                return navClient.ForeColor;
            }

            set
            {
                navClient.ForeColor = value;
            }
        }

        public System.Drawing.Color stories
        {
            get
            {
                return navStories.ForeColor;
            }

            set
            {
                navStories.ForeColor = value;
            }
        }
    }
}