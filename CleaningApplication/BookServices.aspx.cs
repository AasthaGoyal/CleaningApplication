using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CleaningApplication
{
    public partial class WebForm21 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string t = Session["total"].ToString();
                string col1 = Session["column1"].ToString();
                string col2 = Session["column22"].ToString();

                int price = Convert.ToInt32(t.Substring(1));
             
               
                var col1values = col1.Split(',');
                var col2values = col2.Split(',');

                for(int i=0;i<col1values.Length;i++)
                {
                    TableRow row1 = new TableRow();
                    TableCell cell1 = new TableCell();
                    cell1.Text = col1values[i].ToString();
                    TableCell cell2 = new TableCell();
                    cell2.Text = col2values[i].ToString();
                    row1.Cells.Add(cell1);
                    row1.Cells.Add(cell2);
                    myTable.Rows.Add(row1);
                }
                lblTotal.Text = t;

                this.Master.statusheading = "Book Service and payment";

                Session.Remove("column1");
                Session.Remove("total");
            }
            

        }
    }
}