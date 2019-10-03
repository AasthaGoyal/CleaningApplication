using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CleaningApplication
{
    public partial class WebForm24 : System.Web.UI.Page
    {
        
        

        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (string textboxId in TextBoxIdCollection)
            {
                var textbox = new TextBox { ID = textboxId };
                textbox.CssClass = "form-control";
                textbox.Text = "Enter option";
                TextBoxPlaceHolder.Controls.Add(textbox);
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

        protected void CounterTextBox_TextChanged(object sender, EventArgs e)
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
                    TextBoxPlaceHolder.Controls.Add(textbox);
                }
                TextBoxIdCollection = collection;
            }
        }

        protected void ConfirmButton_Click(object sender, EventArgs e)
        {
            foreach (Control ctr in TextBoxPlaceHolder.Controls)
            {
                if (ctr is TextBox)
                {
                    string value = ((TextBox)ctr).Text;
                    ResultLiteral.Text += value;
                }


            }
        }
    
    }
}