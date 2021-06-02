using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBA
{
    public class Konekcija
    {
        
        public static string GetConnectionStrings()
        {
            //string strConString = ConfigurationManager.ConnectionStrings["conString"].ToString();
            string strConString = @"Data Source=LAPTOP-L3HCB0JI\SQLEXPRESS;Initial Catalog=RES_Projakat;Integrated Security=True";
            return strConString;

        }

        public static string sql;
        public static SqlConnection con = new SqlConnection();
        public static SqlCommand cmd = new SqlCommand("", con);
        public static SqlDataReader rd;
        public static DataTable dt;
        public static SqlDataAdapter da;

        
        public static void OpenConnection()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.ConnectionString = GetConnectionStrings();
                    con.Open();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("The system failed to establish a connection." + Environment.NewLine +
                    "Descriptions: " + ex.Message.ToString());
            }
        }

        public static void CloseConnection()
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception)
            {
                //
            }
        }

    }
}
