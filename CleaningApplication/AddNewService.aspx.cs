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

            callMethod();
        }

        public void callMethod()
        {
            foreach (string textboxId in TextBoxIdCollection)
            {
                var textbox = new TextBox { ID = textboxId };
                textbox.CssClass = "form-control";
                textbox.Text = "Enter option";
                phOptions.Controls.Add(textbox);
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string imagename, path = "";
           
            int categoryid = 0, serviceid = 0;
            countOption++;

            if (fpPhoto.HasFile)
            {
                imagename = fpPhoto.FileName;
                fpPhoto.SaveAs(Server.MapPath("~/images/category/") + imagename);
                path = "/images/category/" + imagename;

                try
                {

                    categoryid = dao.addCategory(txtcname.Text, path, txtcdescription.Text, Convert.ToInt32(txtcrank.Text));
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


            string filter = txtheading.Text.Replace(" ", "");
                serviceid = dao.addService(categoryid, filter);
                string query = "create table tb" + filter + " ( " + filter + "id int identity(1,1) primary key, no" + filter + " varchar(125) not null, price" + filter + " decimal not null, serviceid int not null constraint serviceidFK" + filter + countOption.ToString() + " foreign key (serviceid) references tbservices(serviceid) )";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                // StringBuilder options = new StringBuilder() ;
                List<String> options = new List<String>();
                callMethod();
                foreach (Control ctr in phOptions.Controls)
                {
                    if (ctr is TextBox)
                    {
                        string value = ((TextBox)ctr).Text;
                        options.Add(value );
                    }


                }
                StringBuilder option = new StringBuilder();
                StringBuilder price = new StringBuilder();
                string returnString="";

                foreach(string item in options)
                {
                    string[] split = item.Split('-');
                    option.Append(split[0]);
                    price.Append(split[1]);
                    returnString = dao.addOptions("tb" + filter, split[0], Convert.ToInt32(split[1].Substring(3)), serviceid);

                }

             //   lblmessage.Text = options.ToString();


                lblmessage.Text = "Success!" + returnString;

            

        

        }
    

     

        protected void rbChoices_SelectedIndexChanged(object sender, EventArgs e)
        {
            choices.Visible = false;
            if(rbChoices.SelectedItem.Value == "choice1")
            {
                multiple.Visible = true;
            }
            else if(rbChoices.SelectedItem.Value == "choice2")
            {

            }
            else
            {
                lblmessage.Text = "The category was added successfully without any filters";
            }
        }


      
        private List<string> TextBoxIdCollection
        {
            get
            {
                var collection = ViewState["TextBoxIdCollection"] as List<string>;
                return collection ?? new List<string>();
            }
            set { ViewState["TextBoxIdCollection"] = value; }
        }

     

        protected void ConfirmButton_Click(object sender, EventArgs e)
        {
            StringBuilder options = new StringBuilder();
            foreach (Control ctr in phOptions.Controls)
            {
                if (ctr is TextBox)
                {
                    string value = ((TextBox)ctr).Text;
                    options.Append(options);
                    Literal1.Text += value;
                    lblmessage.Text = "The text is reaching";
                }
                   

            }
            lblmessage.Text = "The options are" + options.ToString();
        }

        protected void btnAddOptions_Click(object sender, EventArgs e)
        {
            var collection = new List<string>();
            int total;
            if (Int32.TryParse(CounterTextBox.Text, out total))
            {
                for (int i = 1; i <= total; i++)
                {
                    var textbox = new TextBox { ID = "QuestionTextBox" + i };
                    // Collect this textbox id
                    collection.Add(textbox.ID);

                    textbox.Text = "Enter option";
                    textbox.CssClass = "form-control";
                    phOptions.Controls.Add(textbox);
                }
                TextBoxIdCollection = collection;
            }
        }
    }
}