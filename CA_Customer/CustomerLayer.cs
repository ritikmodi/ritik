using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_Customer
{
    public class CustomerLayer
    {
        private string _connectionString;
        public CustomerLayer(IConfiguration iconfiguration)
        {
            _connectionString = iconfiguration.GetConnectionString("Default");
        }
        public void Customer()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                try
                {                   
                    SqlCommand cmd = new SqlCommand("insert into Customer values ('sid', 'efe', 8962)",con);
                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    Console.WriteLine("Inserted Rows = " + rowsAffected);

                    cmd.CommandText = "update Customer set Name= 'Aaku' where Id = 2";
                  
                    rowsAffected = cmd.ExecuteNonQuery();
                    Console.WriteLine("Updated Rows = " + rowsAffected);

                    cmd.CommandText = "Delete from Customer where Id in (10)";

                    rowsAffected = cmd.ExecuteNonQuery();
                    Console.WriteLine("Deleted Rows = " + rowsAffected);
                    cmd.CommandText = "Select * from Customer";
                    Console.WriteLine("**********Connected*************");
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            Console.WriteLine("{0} {1} {2} {3}", rdr["Id"], rdr["Name"], rdr["Address"], rdr["Mobno"]);
                        }

                    }
                }
                catch (Exception ex)
                {
                    // Handle Exceptions, if any
                    Console.WriteLine(ex.Message);
                }
            }

        }



        
    }
}
