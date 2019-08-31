using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.SessionState;

namespace CleaningApplication
{
    public class DataAccessLayer
    {
        public SqlConnection connection = null;
        String connectionString = null;


        public void openConnection()
        {
            connectionString = ConfigurationManager.ConnectionStrings["dbcleaningConnectionString"].ConnectionString;
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public string getCatName(int id)
        {
            openConnection();

            string query = "select categoryName from tbcategory where categoryid='" + id + "'";
            SqlCommand cmd = new SqlCommand(query, connection);
            string name = cmd.ExecuteScalar().ToString();

            return name;
        }

        public int getCatid(string name)
        {
            openConnection();

            string query = "select categoryid from tbcategory where categoryName='" + name + "'";
            SqlCommand cmd = new SqlCommand(query, connection);

            int id = Convert.ToInt32(cmd.ExecuteScalar());
            return id;
        }

        public void addReview(string name, string heading, string review, int stars)
        {
            openConnection();

            string query = "insert into tbreviews values ('" + name + "','" + heading + "','" + review + "','" + stars + "')";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }

        public string userLogin(string username, string password)
        {
            openConnection();

            string query = "select fullname from tbstaff where (username ='" + username + "' and password='" + password + "')";
            SqlCommand cmd = new SqlCommand(query, connection);

            string name = cmd.ExecuteScalar().ToString();
            return name;
        }

        public void editCategories(int id,string name, string desc, string photo, int rank)
        {
            openConnection();

            string query = "update tbcategory set categoryName='" + name + "', categoryDesc='" + desc + "',categoryPhoto='" + photo + "', rank ='" + rank + "' where categoryid='" + id + "'";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.ExecuteNonQuery();

        }

        public void updateProcess(int id, string name, string heading, string desc)
        {
            openConnection();

            string query = "update tbprocess set processName='" + name + "',processDesc='" + desc + "', heading='" + heading + "' where processid =" + id ;
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.ExecuteNonQuery();
            
        }

        public void deleteProcess(int id)
        {
            openConnection();

            string query = "delete from tbprocess where processid=" + id;
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.ExecuteNonQuery();
        }

        public int getserviceid(string name, int categoryid)
        {
            openConnection();

            string query = "select serviceid from tbservices where serviceDesc='" + name + "' and categoryId ='" + categoryid + "'";
               SqlCommand cmd = new SqlCommand(query, connection);

            int id = Convert.ToInt32(cmd.ExecuteScalar());
            return id;

        }

        public void updateReview(int id, string heading, string review, string customerName, int stars)
        {
            openConnection();

            string query = "update tbreviews set customerName='" + customerName + "', heading='" + heading + "',review ='" + review + "',stars ='" + stars + "' where reviewid =" + id;
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.ExecuteNonQuery();
            
        }

        public void deleteReview(int id)
        {
            openConnection();

            string query = "delete from tbreviews where reviewid=" + id;
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.ExecuteNonQuery();

        }

        public void updatePanel(string name, string phoneNo, string address, string timings , string aboutUs, string email, string logo, string suburb, string phoneno2)
        {
            openConnection();

            string query = "update tbpanel set companyName ='" + name + "', phoneNo='" + phoneNo + "',companyAddress='" + address + "', timings ='" + timings + "',aboutUs='" + aboutUs + "',companyEmail='" + email + "',logo='" + logo + "',suburb='" + suburb + "',phoneNo2 ='" + phoneno2 + "' where panelid =1";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.ExecuteNonQuery();
        }

        public void updateAboutus(string tagline, string line1, string line2, string core, string mission, string vision)
        {
            openConnection();

            string query = "update tbaboutUs set tagline='" + tagline + "', line1='" + line1 + "',line2='" + line2 + "', coreValues ='" + core + "',mission='" + mission + "',vision='" + vision + "' where aboutusid=1";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.ExecuteNonQuery();
        }

        public void updateService(int id,string name, string photo, string description, int rank)
        {
            openConnection();

            string query = "update tbcategory set categoryName='" + name + "',categoryPhoto='" + photo + "',categoryDesc='" + description + "',rank ='" + rank + "' where categoryid=" + id;
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.ExecuteNonQuery();
        }

        public void deleteService(int id)
        {
            openConnection();

            string query = "delete from tbcategory where categoryid=" + id;
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.ExecuteNonQuery();
        }

        public void registerUser(string name, string address, string phoneNo, string emailid, string position, string photo, string username, string password)
        {
            openConnection();

            string query = "insert into tbstaff values('" + name + "','" + address + "','" + phoneNo + "','" + emailid + "','" + position + "','" + photo + "','" + username + "','" + password + "')";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.ExecuteNonQuery();
        }

        public void updateStaff(int id, string name, string address, int phoneno, string emailid, string position, string photo, string username)
        {
            openConnection();

            string query = "update tbstaff set fullname='" + name + "',staffAddress='" + address + "',phoneNo='" + phoneno + "',photo ='" + photo + "', username ='" + username + "' where staffid=" + id;
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.ExecuteNonQuery();
        }

        public void deleteStaff(int id)
        {
            openConnection();

            string query = "delete from tbstaff where staffid =" + id;
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.ExecuteNonQuery();
        }
    }
}