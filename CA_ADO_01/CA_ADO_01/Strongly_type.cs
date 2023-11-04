using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace CA_ADO_01
{
    internal class Strongly_type
    {
        private string _connectionString;
        public Strongly_type(IConfiguration iconfiguration)
        {
            _connectionString = iconfiguration.GetConnectionString("Default");
        }
        public SqlConnection getconnection()
        {
            SqlConnection sqlconn = new SqlConnection();
            sqlconn.ConnectionString = _connectionString;
            return sqlconn;
        }

        public int AddData(Customer e)
        {
            SqlConnection sqlconn = null;
            SqlCommand sqlcmd;
            int record = 0;
            try
            {
                sqlconn = getconnection();
                sqlcmd = new SqlCommand("storedata", sqlconn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
              
                sqlcmd.Parameters.Add("@pName", SqlDbType.NVarChar).Value = e.Name;
                sqlcmd.Parameters.AddWithValue("@pAddress", SqlDbType.NVarChar).Value = e.Address;
                sqlcmd.Parameters.Add("@pMobno", SqlDbType.Int).Value = e.Mobno;
                sqlconn.Open();
                record = sqlcmd.ExecuteNonQuery();
            }
            catch (SqlException se)
            { Console.WriteLine(se.Message); }
            finally
            {
                sqlconn.Close();
                 }
            return record;

        }
        public Customer search(int id)
        {
            SqlConnection sqlconn = null;
            SqlCommand sqlcmd;
           Customer p = null;
            try
            {
                sqlconn = getconnection();
                sqlconn.Open();
                sqlcmd = new SqlCommand("select * from Customer where id=@pid", sqlconn);
                sqlcmd.Parameters.AddWithValue("@pid", id);
                SqlDataReader rd = sqlcmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        // int.TryParse("rd[Id"]", out r) ;
                        p = new Customer();
                        p.Id = Convert.ToInt32(rd["Id"]);
                        p.Name = rd["Name"].ToString();
                        p.Address = rd["Address"].ToString();
                        p.Mobno = Convert.ToInt32(rd["Mobno"]);
                        break;
                    }
                }
            }
            catch (SqlException se)
            { Console.WriteLine(se.Message); }
            finally
            {
                sqlconn.Close();
            }

            return p;
        }
        public List<Customer> search(string name)
        {
            SqlConnection sqlconn = null;
            SqlCommand sqlcmd;
            List<Customer> pl = null;
            try
            {

                sqlconn = getconnection();
                sqlconn.Open();
                sqlcmd = new SqlCommand("select * from Customer where name=@pid", sqlconn);
                sqlcmd.Parameters.AddWithValue("@pid", name);
                SqlDataReader rd = sqlcmd.ExecuteReader();
                if (rd.HasRows)
                {
                    pl = new List<Customer>();
                    while (rd.Read())
                    {
                        Customer p = new Customer();
                        p.Id = Convert.ToInt32(rd["Id"]);
                        p.Name = rd["Name"].ToString();
                        p.Address = rd["Address"].ToString();
                        pl.Add(p);
                    }
                }
            }
            catch (SqlException se)
            { Console.WriteLine(se.Message); }
            finally
            {
                sqlconn.Close();

            }

            return pl;
        }
        public int Del(int id)
        {
            SqlConnection sqlconn = null;
            SqlCommand sqlcmd;
            int no = 0;

            using (sqlconn = getconnection())
            {
                try
                {
                    sqlconn.Open();
                    sqlcmd = new SqlCommand("delete from Customer where id=@pid", sqlconn);
                    sqlcmd.Parameters.AddWithValue("@pid", id);
                    no = sqlcmd.ExecuteNonQuery();
                }
                catch (SqlException se)
                { Console.WriteLine(se.Message); }
            }


            return no;
        }
        public List<Customer> GetList()
        {
            var listCustomer = new List<Customer>();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_emp_GET_LIST", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        listCustomer.Add(new Customer
                        {
                            Id = Convert.ToInt32(rdr["Id"]),
                            Name = rdr["Name"].ToString(),
                            Address = rdr["Address"].ToString(),
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listCustomer;
        }
    }
}

