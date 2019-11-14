using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CleaningApplication
{
    public partial class WebForm30 : System.Web.UI.Page
    {
        int goods_id;
        decimal total_price;
        string connectionString = ConfigurationManager.ConnectionStrings["dbcleaningConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            goods_id = Convert.ToInt32(Request.QueryString["goods_id"]);

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "select name, totalPrice from tbgoods where goodid=" + goods_id;
            SqlCommand cmd = new SqlCommand(query, connection);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    txtitemname.Text = reader.GetString(0);
                    txtamount.Text = reader.GetDecimal(1).ToString();
                }
            }

            Session["goodsid"] = goods_id.ToString();
        }

        protected void ibPayPal_Click(object sender, ImageClickEventArgs e)
        {
            goods_id = Convert.ToInt32(Session["goodsid"]);
            DataAccessLayer dao = new DataAccessLayer();
            total_price = dao.returnTotalPrice(goods_id);
            int request_id = dao.createPaymentRequest(goods_id, total_price, DateTime.Now);
            Response.Redirect("Paypal.aspx?goods_id=" + goods_id);

        }

       
    }
}