using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CleaningApplication
{
    public partial class WebForm19 : System.Web.UI.Page
    {
        DataAccessLayer dao = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string imagename, path="";
            string hashedpassword = "";

            if(fpImage.HasFile)
            {
                imagename = fpImage.FileName;
                fpImage.SaveAs(Server.MapPath("~/images/main-slider") + imagename);
                path = "~/images/main-slider/" + imagename;

                using (SHA256 sha256Hash = SHA256.Create())
                {
                    // ComputeHash - returns byte array  
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(txtpassword.Text));

                    // Convert byte array to a string   
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(bytes[i].ToString("x2"));
                    }
                    hashedpassword = builder.ToString();
                }

                dao.registerUser(txtname.Text, txtaddress.Text, txtphone.Text, txtemail.Text, txtposition.Text, path, txtusername.Text, hashedpassword);
                lblmessage.Text = "The staff has been successfully added";
            }
            else
            {
                lblmessage.Text = "Staff image is required";
            }
          
        }
    }
}