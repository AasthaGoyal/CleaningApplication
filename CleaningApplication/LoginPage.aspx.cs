using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Security.Cryptography;


namespace CleaningApplication
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            DataAccessLayer dao = new DataAccessLayer();
            StringBuilder builder = new StringBuilder();
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(txtPassword.Text));

                // Convert byte array to a string   
                
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
            }
                string name = dao.userLogin(txtUsername.Text, builder.ToString());

            if(name == null)
            {
                lblmessage.ForeColor = System.Drawing.Color.Red;
                lblmessage.Text = "Invalid username or password";

            }
            else
            {
                lblmessage.ForeColor = System.Drawing.Color.Green;
                lblmessage.Text = "Welcome " + name;
                Response.Redirect("ReviewManagement.aspx");
            }
        }
    }
}