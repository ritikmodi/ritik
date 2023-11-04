using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_ADO_01
{
    internal class Likedemo { 
    
        private string _connectionString;
        public Likedemo(IConfiguration iconfiguration)
        {
            _connectionString = iconfiguration.GetConnectionString("Default");
        }

        public void displayproduct(string pname)//"T"
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {  //"v'; Delete from Product;Select * from Product where Name like 'v"

                    //Build the query dynamically, by concatenating the text, that the user has 
                    //typed into the ProductNameTextBox. This is a bad way of constructing
                    //queries. This line of code will open doors for sql injection attack
                    // Select* from Product where Name like 'T%';
                    SqlCommand cmd = new SqlCommand("Select * from Product where Name like '" + pname + "%'", connection);
                    connection.Open();
                    SqlDataReader rd = cmd.ExecuteReader();

                    while (rd.Read())
                        Console.WriteLine("{0} {1} {2}", rd["Id"], rd["Name"], rd["Price"]);
                }

                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }
            }

        }
        public void displayproduct_p(string pname)//"T"
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {  //"v'; Delete from Product;Select * from Product where Name like 'v"

                    //Build the query dynamically, by concatenating the text, that the user has 
                    //typed into the ProductNameTextBox. This is a bad way of constructing
                    //queries. This line of code will open doors for sql injection attack
                    // Select* from Product where Name like 'T%';
                    SqlCommand cmd = new SqlCommand("Select * from Product where Name like @ProductName", connection);
                    cmd.Parameters.AddWithValue("@ProductName", pname+"%");
                    connection.Open();
                    SqlDataReader rd = cmd.ExecuteReader();

                    while (rd.Read())
                        Console.WriteLine("{0} {1} {2}", rd["Id"], rd["Name"], rd["Price"]);
                }

                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }
            }

        }
        public void displayproduct_proc(string pname)//"T"
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {  //"v'; Delete from Product;Select * from Product where Name like 'v"

                    //Build the query dynamically, by concatenating the text, that the user has 
                    //typed into the ProductNameTextBox. This is a bad way of constructing
                    //queries. This line of code will open doors for sql injection attack
                    // Select* from Product where Name like 'T%';
                    SqlCommand cmd = new SqlCommand("spGetProductsByName", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductName", pname + "%");
                    connection.Open();
                    SqlDataReader rd = cmd.ExecuteReader();

                    while (rd.Read())
                        Console.WriteLine("{0} {1} {2}", rd["Id"], rd["Name"], rd["Price"]);
                }

                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }
            }

        }



    }
}
