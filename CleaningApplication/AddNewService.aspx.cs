using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CleaningApplication
{
    public partial class WebForm25 : System.Web.UI.Page
    {
        DataAccessLayer dao = new DataAccessLayer();
        List<string> controlIdList = new List<string>();
        int counter = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            int rank = dao.getMaxRank();
            txtcrank.Text = (rank + 1).ToString();
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(rboptions.SelectedItem.Value == "option1")
            {
                Panel1.Visible = true;
                Panel2.Visible = false;
            }
            else
            {
                Panel1.Visible = false;
                Panel2.Visible = true;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string imagename, path = "";
           

            if (fpPhoto.HasFile)
            {
                 imagename = fpPhoto.FileName;
                fpPhoto.SaveAs(Server.MapPath("~/images/category/") + imagename);
                path = "/images/category/" + imagename;

                try
                {
                    dao.addCategory(txtcname.Text, path, txtcdescription.Text, Convert.ToInt32(txtcrank.Text));
                    lblmessage.Text = "The category was added successfully";
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

        protected override void LoadViewState(object savedState)
        {
            base.LoadViewState(savedState);
            controlIdList = (List<string>) ViewState["controlIdList"];
            foreach(string id in controlIdList)
            {
                counter++;
                TextBox tb = new TextBox();
                tb.ID = id;
                LiteralControl lineBreak = new LiteralControl("<br/>");
                PlaceHolder1.Controls.Add(tb);
                PlaceHolder1.Controls.Add(lineBreak);
            }
        }

       

        protected void btnaddnew_Click(object sender, EventArgs e)
        {
            counter++;
            TextBox tb = new TextBox();
            tb.ID = "txtcriteria" + counter;
            tb.Text = "New Text box";

            LiteralControl lineBreak = new LiteralControl("<br/>");
            PlaceHolder1.Controls.Add(tb);
            PlaceHolder1.Controls.Add(lineBreak);
            controlIdList.Add(tb.ID);
            ViewState["controlIdList"] = controlIdList;
        }

        protected void rbChoices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(rbChoices.SelectedItem.Value == "choice1")
            {

            }
            else if(rbChoices.SelectedItem.Value == "choice2")
            {

            }
            else
            {
                lblmessage.Text = "The category was added successfully without any filters";
            }
        }
    }
}