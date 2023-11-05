using CA_Customer;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

internal class Program
{
    private static IConfiguration _iconfiguration;
    static void Main(string[] args)
    {
        GetAppSettingsFile();
        //PrintProduct();
        EmpDisplay();
    }
    static void GetAppSettingsFile()
    {
        var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("CustomerData.json", optional: false, reloadOnChange: true);
        _iconfiguration = builder.Build();
    }
    static void PrintProduct()
    {
        CustomerLayer obj = new CustomerLayer(_iconfiguration);
        obj.Customer();


    }
    static void EmpDisplay()
    {
        Strongly_type indata = new Strongly_type(_iconfiguration);
        /*Console.WriteLine("************************************");
        Console.WriteLine("Enter id you want to delete record for");
         int r = Convert.ToInt32(Console.ReadLine());
         int no = indata.del(r);
        Console.WriteLine("deleted {0}", no);*/
        /*Console.WriteLine("************************************");
        Customer customer = new Customer { Name = "Amar",Address = "bjhgf",MobNo = "98765"};
        int rec= indata.Insert(customer);
        Console.WriteLine("Inserted Record {0}", rec);*/
        Console.WriteLine("************************************");
        Customer customer1 = indata.Search(4);
        Console.WriteLine("Data Found \n {0} {1} {2} {3}",customer1.ID,customer1.Name,customer1.Address,customer1.Mobno);
        Console.WriteLine("************************************");
        List<Customer> ls1 = indata.SearchbyValue("rutu");
        if(ls1 != null)
            {
            foreach (var x in ls1)
                Console.WriteLine("{0} {1} {2} {3}", x.ID, x.Name, x.Address,x.Mobno);
        }
            else {
            Console.WriteLine("record with Rutu not found"); 
        }
        Console.WriteLine("************************************");
        int rec4 = indata.Update(2, "rutu");
        Console.WriteLine("Update done {0} rows",rec4);
        Console.WriteLine("************************************");
        List<Customer> ls = indata.getList();
        foreach (var x in ls)
            Console.WriteLine("{0}  {1} {2} {3}", x.ID, x.Name, x.Address,x.Mobno);
        Console.ReadLine();
    }
}



