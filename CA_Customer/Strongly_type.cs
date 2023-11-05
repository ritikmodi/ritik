using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_Customer
{
    internal class Strongly_type
    {
        private string _configuration;
        public Strongly_type(IConfiguration configuration)
        {
            _configuration = configuration.GetConnectionString("Default");
        }
        public SqlConnection getconnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = _configuration;
            return conn;
        }
        public int del(int id)
        {
            int no = 0;
            using (SqlConnection con = getconnection())
                try
                {
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("SP_Delete_byid", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pid", id);
                        no = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            return no;
        }
        public int Insert(Customer c)
        {
            using (SqlConnection sqlconn = getconnection())
            {
                int rec = 0;
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_InsertData",sqlconn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@pname", SqlDbType.NVarChar).Value = c.Name;
                    cmd.Parameters.Add("@paddress", SqlDbType.NVarChar).Value = c.Address;
                    cmd.Parameters.Add("@pMobno", SqlDbType.NVarChar).Value = c.Mobno;
                    sqlconn.Open();
                    rec= cmd.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return rec;

            }
        }
        public Customer Search(int id)
        {
            Customer c = null;
            try
            {
                SqlConnection con = getconnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Customer Where Id = @pid", con);
                cmd.Parameters.AddWithValue("@pid", id);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read()) 
                    { 
                        c = new Customer();
                        c.ID = (int)rdr["Id"];
                        c.Name = (string)rdr["Name"];
                        c.Address = (string)rdr["Address"];
                        c.Mobno = (string)rdr["Mobno"];
                        break;
                    }
                }
            }
            catch( Exception ex )
            {
                Console.WriteLine(ex.Message);
            }
            return c;
        }
        public List<Customer> SearchbyValue(string value)
        {
            var list = new List<Customer>();
            long f;
            try
            {
                using (SqlConnection con = getconnection())
                {
                    SqlCommand cmd = null;
                    con.Open();
                    if (long.TryParse(value,out f))
                    {
                        cmd = new SqlCommand("Select * from Customer where MobNo = @pname", con);
                        cmd.Parameters.Add("@pname",SqlDbType.NVarChar).Value = f;
                    }
                    else
                    {
                        cmd = new SqlCommand("Select * from Customer where Name = @pname", con);
                        cmd.Parameters.Add("@pname",SqlDbType.NVarChar).Value=value;
                    }
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if(rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            Customer c = new Customer();
                            c.ID = Convert.ToInt32(rdr["Id"]);
                            c.Name = (string)rdr["Name"];
                            c.Address = (string)rdr["Address"];
                            c.Mobno = (string)rdr["Mobno"];
                            list.Add(c);
                        }
                    }
                   
                }
            }
            catch( Exception ex )
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }
        public int Update(int id,String Name)
        {
            int rec = 0;
            try
            {
                using (SqlConnection con = getconnection())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Update Customer set Name = @pname where Id= @pid", con);
                    cmd.Parameters.Add("@pname", SqlDbType.NVarChar).Value = Name;
                    cmd.Parameters.Add("@pid", SqlDbType.Int).Value = id;
                    rec = cmd.ExecuteNonQuery();
                }
            }
            catch ( Exception ex )
            {
                Console.WriteLine(ex.Message);
            }
            return rec;

        }

        public List<Customer> getList()
        {
            var list = new List<Customer>();
            try
            {
                using(SqlConnection con = getconnection())
                {
                    SqlCommand cmd = new SqlCommand("SP_GetCustomerData",con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            Customer c = new Customer();
                            c.ID = (int)rdr["Id"];
                            c.Name = (string)rdr["Name"];
                            c.Address = (string)rdr["Address"];
                            c.Mobno = (string)rdr["Mobno"];
                            list.Add(c);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return list;
           

        }
    }
}
