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
        public class Productlayer
    {
        private string _connectionString;
        public Productlayer(IConfiguration iconfiguration)
        {
            _connectionString = iconfiguration.GetConnectionString("Default");
        }

        public void Products()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                // Pass the connection to the command object, so the command object knows on which
                // connection to execute the command
                SqlCommand cmd = new SqlCommand("Select * from Customer", con);
                // Open the connection. Otherwise you get a runtime error. An open connection is
                // required to execute the command            
                con.Open();
                //SqlDataReader rd=new SqlDataReader();
                Console.WriteLine("connected");
                SqlDataReader rdr = cmd.ExecuteReader(); //returns object of sqldatareder
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        Console.WriteLine("{0} {1} {2} {3}", rdr["Id"], rdr["Name"], rdr["Address"], rdr["Mobno"]);
                    }
                }
            }

        }
        public void product_insert()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    //Create an instance of SqlCommand class, specifying the T-SQL command 
                    //that we want to execute, and the connection object.
                    SqlCommand cmd = new SqlCommand("insert into Product values (1, 'Iphone', 750000, 2)", connection);
                    connection.Open();
                    //Since we are performing an insert operation, use ExecuteNonQuery() 
                    //method of the command object. ExecuteNonQuery() method returns an 
                    //integer, which specifies the number of rows inserted
                    int rowsAffected = cmd.ExecuteNonQuery();
                    Console.WriteLine("Inserted Rows = " + rowsAffected);

                    //Set to CommandText to the update query. We are reusing the command object, 
                    //instead of creating a new command object
                    cmd.CommandText = "update Product set Price= 15000 where Id = 2";
                    //use ExecuteNonQuery() method to execute the update statement on the database
                    rowsAffected = cmd.ExecuteNonQuery();
                    Console.WriteLine("Updated Rows = " + rowsAffected);

                    //Set to CommandText to the delete query. We are reusing the command object, 
                    //instead of creating a new command object
                    cmd.CommandText = "Delete from Product where Id = 1002";
                    //use ExecuteNonQuery() method to delete the row from the database
                    rowsAffected = cmd.ExecuteNonQuery();
                    Console.WriteLine("Deleted Rows = " + rowsAffected);
                  


                }
                catch (Exception ex)
                {
                    // Handle Exceptions, if any
                    Console.WriteLine(ex.Message);
                }
            }

        }
        public int Product_cnt
        {
            get
            {
                int TotalRows = 0;
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {

                    try
                    {
                        SqlCommand cmd = new SqlCommand("Select Count(Id) from Product", connection);
                        connection.Open();
                        //As the T-SQL statement that we want to execute return a single value, 
                        //use ExecuteScalar() method of the command object.
                        //Since the return type of ExecuteScalar() is object, we are type casting to int datatype
                        TotalRows = (int)cmd.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        // Handle Exceptions, if any
                        Console.WriteLine(ex.Message);
                    }
                }
                return TotalRows;

            }
        }

    }
}
