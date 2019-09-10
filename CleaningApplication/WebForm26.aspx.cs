using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CleaningApplication
{
    public partial class WebForm26 : System.Web.UI.Page
    {
        List<string> controlIdList = new List<string>();
        int counter = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
        
        }


        protected override void LoadViewState(object savedState)
        {
            base.LoadViewState(savedState);
            controlIdList = (List<string>)ViewState["controlIdList"];
            foreach (string id in controlIdList)
            {
                counter++;
                TextBox tb = new TextBox();
                tb.ID = id;
                LiteralControl lineBreak = new LiteralControl("<br/>");
                PlaceHolder1.Controls.Add(tb);
                PlaceHolder1.Controls.Add(lineBreak);
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            counter++;
            TextBox tb = new TextBox();
            tb.ID = "TextBox" + counter;
            tb.Text = "new textboc";

            LiteralControl lineBreak = new LiteralControl("<br/>");
            PlaceHolder1.Controls.Add(tb);
            PlaceHolder1.Controls.Add(lineBreak);
            controlIdList.Add(tb.ID);
            ViewState["controlIdList"] = controlIdList;
        }
    }
}