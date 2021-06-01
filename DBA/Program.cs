using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBA
{
    class Program
    {
        static void Main(string[] args)
        {
            Konekcija.OpenConnection();
            
            /*
            try
            {
                SqlConnection thisConnection = new SqlConnection(@"Data Source=LAPTOP-L3HCB0JI\SQLEXPRESS;Initial Catalog=RES_Projakat;Integrated Security=True");
                thisConnection.Open();

                string data = $"INSERT INTO Potrosnja VALUES (2, 300, @UCTVreme)";

                SqlCommand cmd = thisConnection.CreateCommand();
                cmd.CommandText = data;

                cmd.Parameters.AddWithValue("@UCTVreme", DateTime.Now);
                cmd.ExecuteNonQuery();

               
            }
            catch
            {
                
            }*/
            /*
            
            string conString = @"Data Source=LAPTOP-L3HCB0JI\SQLEXPRESS;Initial Catalog=RES_Projakat;Integrated Security=True";
            SqlConnection connection;

            using (connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand("INSERT INTO Potrosnja VALUES (1, 250, @UCTVreme)", connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@UCTVreme", DateTime.Now);
                command.ExecuteNonQuery();
            }
            */

            Console.ReadLine();
        }
    }
}
