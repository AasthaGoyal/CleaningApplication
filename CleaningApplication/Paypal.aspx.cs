using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;

namespace CleaningApplication
{
    public partial class WebForm31 : System.Web.UI.Page
    {
        public string business = "swaachclean@gmail.com";
        public string item_name = "Payment of goods";
        public string cmd = "_xclick";
        public string no_shipping = "1";
        public string URL, request_id, rm;
        public decimal totalPrice;
        public string currency_code = "NZD";
        public string return_url = System.Configuration.ConfigurationManager.AppSettings["ReturnUrl"];
        public string notify_url = System.Configuration.ConfigurationManager.AppSettings["NotifyUrl"];
        public string cancel_url = System.Configuration.ConfigurationManager.AppSettings["CancelUrl"];


        private static readonly HttpClient client = new HttpClient();





        DataAccessLayer dao = new DataAccessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            int goods_id = Convert.ToInt32(Request.QueryString["goods_id"]);
            totalPrice = dao.returnTotalPrice(goods_id);

            //if (System.Configuration.ConfigurationManager.AppSettings["UseSandbox"].ToString() == "true")
            //{
            //    URL = "https://www.sandbox.paypal.com/cgi-bin/webscr";



            //}
            //else
            //{
            //    URL = "https://www.paypal.com/cgi-bin/webscr";
            //}


            if (System.Configuration.ConfigurationManager.AppSettings["SendToReturnUrl"].ToString() == "true")
            {
                rm = "2";
            }
            else
            {
                rm = "1";
            }

            request_id = dao.getRequestid(goods_id).ToString();
            Session["totalPrice"] = totalPrice.ToString();
            Session["request_id"] = request_id.ToString();
 




        }

        protected void PayPalBtn_Click(object sender, ImageClickEventArgs e)
        {
            //string business = "Swaach Cleaning Services";
            //string itemName = "Carpet Cleaning";
            //double itemAmount = 20.00;
            //string currencyCode = "NZD";
            string totalPrice = "20.00";
            string request_id = Session["request_id"].ToString();
            StringBuilder ppHref = new StringBuilder();

            ppHref.Append("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick");
            ppHref.Append("&business=" + business);
            ppHref.Append("&item_name=" + item_name);
            ppHref.Append("&amount=" + totalPrice);
            ppHref.Append("&currency_code=" + currency_code);
            ppHref.Append("&no_shipping=" + "1");
            ppHref.Append("&rm=" + rm);
            ppHref.Append("&notify_url=" + "url");
            ppHref.Append("&cancel_return=" + "url");
            ppHref.Append("&return=" + "Default.aspx");
            ppHref.Append("&custom=" + request_id);


            Response.Redirect(ppHref.ToString(), true);
        }
    }
}