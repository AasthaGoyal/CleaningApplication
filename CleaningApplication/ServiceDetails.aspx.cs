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
    public partial class WebForm3 : System.Web.UI.Page
    {
        DataAccessLayer dao = new DataAccessLayer();
        int subsubtotal = 0;
        int id ;
        string connectionString = ConfigurationManager.ConnectionStrings["dbcleaningConnectionString"].ConnectionString;
        SqlConnection connection;
        StringBuilder column1, column2;
        private const string StartTimeCol1 = "StartTimeSessionKey1";
        private const string StartTimeCol2 = "StartTimeSessionKey2";

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Convert.ToInt32(Request.QueryString["categoryid"]);
            if(id == 1)
            {
                pnEndoftenancy.Visible = true;
                getBedrooms();
                getBathrooms();
                getCeiling();
                getWindows();
                getGarage();
                getExtras();

                //  Response.Redirect("EndOfTenancy.aspx");
            }
            else if(id == 2)
            {
               ovenDetails();
            }
            else if(id == 3)
            {
                pncarpet.Visible = true;
                loadData();
                loadExtra();
              
                // Response.Redirect("Carpet.aspx");   
            }
            else if(id == 4)
            {
              blindCleaning();

            }
            else if(id == 5)
            {
                curtainCleaning();
            }
            else if(id == 6)
            {
                sofaCleaning();
            }
            else if(id == 7)
            {
                vinylCleaning();
            }
            else if(id == 8)
            {
                mouldCleaning();
            }
            else if(id == 13)
            {
                rugCleaning();
            }
            else
            {
                
                //remove the heading of customizing
            }
        }


        public void loadData()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string name;
            decimal price;
            string query = "select top 2 name,price from tbcarpet";
            SqlCommand cmd = new SqlCommand(query, connection);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    name = reader.GetString(0);
                    price = reader.GetDecimal(1);
                    dpCarpet.Items.Add(name + " - (per sq met.)$" + price.ToString());
                }
            }


        }

        public void loadExtra()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string name;
            int price;
            string query = "select extraName,eprice from tbextras where serviceid =7";
            SqlCommand cmd = new SqlCommand(query, connection);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    name = reader.GetString(0);
                    price = reader.GetInt32(1);
                    cbCarpetExtras.Items.Add (name + "- $" + price);
                }
            }


        }

        public void getBedrooms()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();


            string query = "select noOfBedrooms, bprice from tbBedrooms";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    dpBedrooms.Items.Add(reader.GetInt32(0).ToString() + " Bedroom(s) - $ " + reader.GetDecimal(1).ToString());

                }
            }

        }

        public void getBathrooms()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();


            string query = "select noOfBathrooms, bathprice from tbBathrooms";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    dpBathrooms.Items.Add(reader.GetInt32(0).ToString() + " Bathroom(s) - $ " + reader.GetDecimal(1).ToString());

                }
            }
            reader.Close();

            string query2 = "select extraName, eprice from tbExtras where serviceid =2";
            SqlCommand cmd2 = new SqlCommand(query2, connection);
            SqlDataReader reader2 = cmd2.ExecuteReader();

            if (reader2.HasRows)
            {
                while (reader2.Read())
                {

                    cbBathroomExtras.Items.Add(reader2.GetString(0) + " - $ " + reader2.GetInt32(1));

                }
            }

        }

        public void getGarage()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();


            string query = "select noOfGarage, gPrice from tbGarage";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    dpGarages.Items.Add(reader.GetInt32(0).ToString() + " Garage(s) - $ " + reader.GetDecimal(1).ToString());

                }
            }

        }

        public void getCeiling()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();


            string query = "select noBeds, cPrice from tbCeiling";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    dpCeiling.Items.Add(reader.GetInt32(0).ToString() + " Bedroom(s) - $ " + reader.GetDecimal(1).ToString());

                }
            }

        }

        public void getWindows()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();


            string query = "select side, noOfBedrooms, wPrice from tbWindows";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    cbWindows.Items.Add(reader.GetInt32(1).ToString() + " Bedrooms(s) side (" + reader.GetString(0) + ") - $ " + reader.GetDecimal(2).ToString());

                }
            }

            reader.Close();

            string query2 = "select extraName, eprice from tbExtras where serviceid =4";
            SqlCommand cmd2 = new SqlCommand(query2, connection);
            SqlDataReader reader2 = cmd2.ExecuteReader();

            if (reader2.HasRows)
            {
                while (reader2.Read())
                {

                    cbWindows.Items.Add(reader2.GetString(0) + "- $ " + reader2.GetInt32(1));

                }
            }
        }

        public void getExtras()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();


            string query = "select extraName, eprice from tbExtras where serviceid =6";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    cbExtras.Items.Add(reader.GetString(0) + " - $ " + reader.GetInt32(1).ToString());

                }
            }

        }


        protected void btnclick_Click(object sender, EventArgs e)
        {
            //the list to store the selected options
          
            List<int> totalPrice = new List<int>();
            List<string> col1 = new List<string>();
            List<string> col2 = new List<string>();

            StringBuilder db = new StringBuilder();
           
            if (id == 1)
            {
                List<int> tenancyPrice = new List<int>();

                TableRow row = new TableRow();
                TableCell cell1 = new TableCell();
                string[] name = dpBedrooms.SelectedItem.Text.Split('-');
                cell1.Text = name[0];
                col1.Add(name[0]);
                TableCell cell2 = new TableCell();               
                tenancyPrice.Add(Convert.ToInt32(name[1].Substring(3)));
                cell2.Text = name[1];
                col2.Add(name[1]);
                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
               
                myTable.Rows.Add(row);

               
                TableRow row2 = new TableRow();
                string[] bath = dpBathrooms.SelectedItem.Text.Split('-');
                TableCell cell3 = new TableCell();
                cell3.Text = bath[0];
                col1.Add(bath[0]);
                TableCell cell4 = new TableCell();
                tenancyPrice.Add(Convert.ToInt32(bath[1].Substring(3)));
                cell4.Text = bath[1];
                col2.Add(bath[1]);
                row2.Cells.Add(cell3);
                row2.Cells.Add(cell4);
                myTable.Rows.Add(row2);

              

           

                List<ListItem> batExt = new List<ListItem>();
                foreach (ListItem item in cbBathroomExtras.Items)
                {
                    if (item.Selected)
                    {
                        batExt.Add(item);
                      
                    }
                }

                foreach (ListItem item in batExt)
                {
                    TableRow roww = new TableRow();
                    string[] extraToilet = cbBathroomExtras.Text.Split('-');
                    TableCell celll = new TableCell();
                    celll.Text = extraToilet[0];
                    TableCell celll2 = new TableCell();
                    tenancyPrice.Add(Convert.ToInt32(extraToilet[1].Substring(3)));
                    celll2.Text = extraToilet[1];
                    col1.Add(extraToilet[0]);
                    col2.Add(extraToilet[1]);
                    roww.Cells.Add(celll);
                    roww.Cells.Add(celll2);
                    myTable.Rows.Add(roww);
                }

                TableRow row3 = new TableRow();
                string[] garage = dpGarages.SelectedItem.Text.Split('-');
                TableCell cell5 = new TableCell();
                cell5.Text = garage[0];
                TableCell cell6 = new TableCell();
                tenancyPrice.Add(Convert.ToInt32(garage[1].Substring(3)));
                cell6.Text = garage[1];
                col1.Add(garage[0]);
                col2.Add(garage[1]);
                row3.Cells.Add(cell5);
                row3.Cells.Add(cell6);
                myTable.Rows.Add(row3);


                List<ListItem> selected = new List<ListItem>();
                foreach (ListItem item in cbWindows.Items)
                {
                    if (item.Selected)
                    {
                        selected.Add(item);
                    }
                }

                foreach (ListItem item in selected)
                {
                    TableRow rw = new TableRow();
                    string[] windows = item.ToString().Split('-');
                    TableCell cell7 = new TableCell();
                    cell7.Text = windows[0];
                    TableCell cell8 = new TableCell();
                    tenancyPrice.Add(Convert.ToInt32(windows[1].Substring(3)));
                    cell8.Text = windows[1];
                    col1.Add(windows[0]);
                    col2.Add(windows[1]);
                    rw.Cells.Add(cell7);
                    rw.Cells.Add(cell8);
                    myTable.Rows.Add(rw);
                }

                TableRow crow = new TableRow();
                string[] ceiling = dpCeiling.SelectedItem.Text.Split('-');
                TableCell ccell1 = new TableCell();
                ccell1.Text = ceiling[0];
                TableCell ccell2 = new TableCell();
                tenancyPrice.Add(Convert.ToInt32(ceiling[1].Substring(3)));
                ccell2.Text = ceiling[1];
                col1.Add(ceiling[0]);
                col2.Add(ceiling[1]);
                crow.Cells.Add(ccell1);
                crow.Cells.Add(ccell2);
                myTable.Rows.Add(crow);


                List<ListItem> extraSelected = new List<ListItem>();
                foreach (ListItem item in cbExtras.Items)
                {
                    if (item.Selected)
                    {
                        extraSelected.Add(item);
                    }
                }

                foreach (ListItem item in extraSelected)
                {
                    TableRow erow = new TableRow();
                    string[] extras = item.ToString().Split('-');
                    TableCell ecell1 = new TableCell();
                    ecell1.Text = extras[0];
                    TableCell ecell2 = new TableCell();
                    tenancyPrice.Add(Convert.ToInt32(extras[1].Substring(3)));
                    ecell2.Text = extras[1];
                    col1.Add(extras[0]);
                    col2.Add(extras[1]);
                    erow.Cells.Add(ecell1);
                    erow.Cells.Add(ecell2);
                    myTable.Rows.Add(erow);
                }


                int tenancySubtotal = 0;
                foreach (int item in tenancyPrice)
                {
                    tenancySubtotal = tenancySubtotal + item;
                }
                lblTotal.Text = "$" + tenancySubtotal.ToString();
                column1 = new StringBuilder();
                column2 = new StringBuilder();

                foreach (string item in col1)
                {
                    column1.Append(item + ",");

                }

                foreach(string item in col2)
                {
                    column2.Append(item + ",");
                }

                Session[StartTimeCol1] = column1.ToString();
                Session[StartTimeCol2] = column2.ToString();

            }
            else if (id == 3)
            {
                List<int> carpetPrice = new List<int>();

                int area = Convert.ToInt32(txtarea.Text);


                string[] carpet = dpCarpet.SelectedItem.Text.Split('$');
                // int price = Convert.ToInt32(garage[1].Substring(3));
                int price = Convert.ToInt32(carpet[1]);
                int catPrice = area * price;
                TableRow row = new TableRow();
                TableCell cell1 = new TableCell();

                cell1.Text = dpCarpet.SelectedItem.Text;
                TableCell cell2 = new TableCell();

                carpetPrice.Add(catPrice);
                cell2.Text = "$ " + catPrice.ToString();
                col1.Add(cell1.Text);
                col2.Add(cell2.Text);
                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                myTable.Rows.Add(row);

                List<ListItem> carpetSelected = new List<ListItem>();
                foreach (ListItem item in cbCarpetExtras.Items)
                {
                    if (item.Selected)
                    {
                        carpetSelected.Add(item);
                    }
                }

                foreach (ListItem item in carpetSelected)
                {
                    
                    string[] extra = cbCarpetExtras.Text.Split('-');
                   

                    TableRow rowq = new TableRow();
                    TableCell cell1q = new TableCell();

                    cell1q.Text = extra[0];
                    TableCell cell2q = new TableCell();

                    carpetPrice.Add(Convert.ToInt32(extra[1].Substring(2)));
                    cell2q.Text = extra[1];
                    col1.Add(extra[0]);
                    col2.Add(extra[1]);
                    rowq.Cells.Add(cell1q);
                    rowq.Cells.Add(cell2q);
                    myTable.Rows.Add(rowq);

                }

                int subCarpet = 0;
                foreach (int item in carpetPrice)
                {
                    subCarpet = subCarpet + item;
                
                    
                }
                lblTotal.Text = "$" + subCarpet.ToString();

                column1 = new StringBuilder();
                column2 = new StringBuilder();

                foreach (string item in col1)
                {
                    column1.Append(item + ",");

                }

                foreach (string item in col2)
                {
                    column2.Append(item + ",");
                }

                Session[StartTimeCol1] = column1.ToString();
                Session[StartTimeCol2] = column2.ToString();
            }

            else
            {


                TableRow row2 = new TableRow();
                string[] random = dpFilter.SelectedItem.Text.Split('-');
                TableCell cell3 = new TableCell();
                cell3.Text = random[0];
                TableCell cell4 = new TableCell();
                totalPrice.Add(Convert.ToInt32(random[1].Substring(2)));
                cell4.Text = random[1];
                col1.Add(random[0]);
                col2.Add(random[1]);
                row2.Cells.Add(cell3);
                row2.Cells.Add(cell4);
                myTable.Rows.Add(row2);

                int subtotal = 0;
                foreach (int item in totalPrice)
                {
                    subtotal = subtotal + item;
                }
                lblTotal.Text = "$" + subtotal.ToString();

                List<ListItem> selected = new List<ListItem>();
                foreach (ListItem item in cbExtras.Items)
                {
                    if (item.Selected)
                    {
                        selected.Add(item);
                    }
                }

                foreach (ListItem item in selected)
                {
                    TableRow rw = new TableRow();
                    string[] extras = item.ToString().Split('-');
                    TableCell cell7 = new TableCell();
                    cell7.Text = extras[0];
                    TableCell cell8 = new TableCell();
                    totalPrice.Add(Convert.ToInt32(extras[1].Substring(3)));
                    cell8.Text = extras[1];
                    col1.Add(extras[0]);
                    col2.Add(extras[1]);
                    rw.Cells.Add(cell7);
                    rw.Cells.Add(cell8);
                    myTable.Rows.Add(rw);
                }

            
                foreach (int item in totalPrice)
                {
                    subsubtotal = subsubtotal + item;
                }
                lblTotal.Text = "$" + subsubtotal.ToString();

                column1 = new StringBuilder();
                column2 = new StringBuilder();

                foreach (string item in col1)
                {
                    column1.Append(item + ",");

                }

                foreach (string item in col2)
                {
                    column2.Append(item + ",");
                }

                Session[StartTimeCol1] = column1.ToString();
                Session[StartTimeCol2] = column2.ToString();



            }



        }
    

        public void ovenDetails()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            string query2 = "select ovenName, oPrice from tbOven";
            string name="";
            decimal price=0;
            SqlCommand cmd = new SqlCommand(query2, connection);

            SqlDataReader reader = cmd.ExecuteReader();
            dpFilter.Visible = true;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    name = reader.GetString(0);
                    price = reader.GetDecimal(1);

                    dpFilter.Items.Add(name + "- $" + price.ToString());
                }
            }

           

        }

      public void blindCleaning()
      {

            connection = new SqlConnection(connectionString);
            connection.Open();
            string query2 = "select bname, bprice from tbBlind";
            string name = "";
            decimal price = 0;
            SqlCommand cmd = new SqlCommand(query2, connection);

            SqlDataReader reader = cmd.ExecuteReader();
            dpFilter.Visible = true;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    name = reader.GetString(0);
                    price = reader.GetDecimal(1);

                    dpFilter.Items.Add(name + "- $" + price.ToString());
                }
            }
            reader.Close();

            string query3 = "select extraName, eprice from tbExtras where serviceid =8";
            SqlCommand cmd3 = new SqlCommand(query3, connection);

            SqlDataReader reader2 = cmd3.ExecuteReader();

            if(reader2.HasRows)
            {
                while(reader2.Read())
                {
                    cbExtras.Items.Add(reader2.GetString(0) + "- $ " + reader2.GetInt32(1));
                }
            }
            reader2.Close();
      }

      public void curtainCleaning()
      {
            connection = new SqlConnection(connectionString);
            connection.Open();
            string query2 = "select cname, cprice from tbcurtain";
            string name = "";
            decimal price = 0;
            SqlCommand cmd = new SqlCommand(query2, connection);

            SqlDataReader reader = cmd.ExecuteReader();
            dpFilter.Visible = true;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    name = reader.GetString(0);
                    price = reader.GetDecimal(1);

                    dpFilter.Items.Add(name + "- $" + price.ToString());
                }
            }
            reader.Close();

            string query3 = "select extraName, eprice from tbExtras where serviceid =9";
            SqlCommand cmd3 = new SqlCommand(query3, connection);

            SqlDataReader reader2 = cmd3.ExecuteReader();

            if (reader2.HasRows)
            {
                while (reader2.Read())
                {
                    cbExtras.Items.Add(reader2.GetString(0) + "- $ " + reader2.GetInt32(1));
                }
            }
            reader2.Close();
        }

        public void sofaCleaning()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            string query2 = "select sname, sprice from tbsofa";
            string name = "";
            decimal price = 0;
            SqlCommand cmd = new SqlCommand(query2, connection);

            SqlDataReader reader = cmd.ExecuteReader();
            dpFilter.Visible = true;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    name = reader.GetString(0);
                    price = reader.GetDecimal(1);

                    dpFilter.Items.Add(name + "- $" + price.ToString());
                }
            }
            reader.Close();

            string query3 = "select extraName, eprice from tbExtras where serviceid =10";
            SqlCommand cmd3 = new SqlCommand(query3, connection);

            SqlDataReader reader2 = cmd3.ExecuteReader();

            if (reader2.HasRows)
            {
                while (reader2.Read())
                {
                    cbExtras.Items.Add(reader2.GetString(0) + "- $ " + reader2.GetInt32(1));
                }
            }
            reader2.Close();
        }

        public void vinylCleaning()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            string query2 = "select vname, vprice from tbvinyl";
            string name = "";
            decimal price = 0;
            SqlCommand cmd = new SqlCommand(query2, connection);

            SqlDataReader reader = cmd.ExecuteReader();
            dpFilter.Visible = true;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    name = reader.GetString(0);
                    price = reader.GetDecimal(1);

                    dpFilter.Items.Add(name + "- $" + price.ToString());
                }
            }
            reader.Close();

            string query3 = "select extraName, eprice from tbExtras where serviceid =11";
            SqlCommand cmd3 = new SqlCommand(query3, connection);

            SqlDataReader reader2 = cmd3.ExecuteReader();

            if (reader2.HasRows)
            {
                while (reader2.Read())
                {
                    cbExtras.Items.Add(reader2.GetString(0) + "- $ " + reader2.GetInt32(1));
                }
            }
            reader2.Close();
        }

        public void mouldCleaning()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            string query2 = "select mname, mprice from tbmould";
            string name = "";
            decimal price = 0;
            SqlCommand cmd = new SqlCommand(query2, connection);

            SqlDataReader reader = cmd.ExecuteReader();
            dpFilter.Visible = true;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    name = reader.GetString(0);
                    price = reader.GetDecimal(1);

                    dpFilter.Items.Add(name + "- $" + price.ToString());
                }
            }
            reader.Close();

            string query3 = "select extraName, eprice from tbExtras where serviceid =12";
            SqlCommand cmd3 = new SqlCommand(query3, connection);

            SqlDataReader reader2 = cmd3.ExecuteReader();

            if (reader2.HasRows)
            {
                while (reader2.Read())
                {
                    cbExtras.Items.Add(reader2.GetString(0) + "- $ " + reader2.GetInt32(1));
                }
            }
            reader2.Close();
        }

        public void rugCleaning()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            string query2 = "select rname, rprice from tbrug";
            string name = "";
            decimal price = 0;
            SqlCommand cmd = new SqlCommand(query2, connection);

            SqlDataReader reader = cmd.ExecuteReader();
            dpFilter.Visible = true;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    name = reader.GetString(0);
                    price = reader.GetDecimal(1);

                    dpFilter.Items.Add(name + "- $" + price.ToString());
                }
            }
            reader.Close();

            string query3 = "select extraName, eprice from tbExtras where serviceid =13";
            SqlCommand cmd3 = new SqlCommand(query3, connection);

            SqlDataReader reader2 = cmd3.ExecuteReader();

            if (reader2.HasRows)
            {
                while (reader2.Read())
                {
                    cbExtras.Items.Add(reader2.GetString(0) + "- $ " + reader2.GetInt32(1));
                }
            }
            reader2.Close();
        }

        

        protected void btnBookService_Click(object sender, EventArgs e)
        {
          
           Session["total"] = lblTotal.Text;
            String col1value = Session[StartTimeCol1].ToString();
            Session["column1"] = col1value;

            String col2value = Session[StartTimeCol2].ToString();
            Session["column22"] = col2value;
         
           Server.Transfer("BookServices.aspx");
      //    Response.Redirect("BookService.aspx?totalprice =" + txtdemo.Text);

        }   
    }
}