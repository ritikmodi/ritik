using Microsoft.Extensions.Configuration;

namespace CA_ADO_01
{
    internal class Program
    {
        private static IConfiguration _iconfiguration;


        static void Main(string[] args)
        {
           GetAppSettingsFile();
           Console.WriteLine(Directory.GetCurrentDirectory());
           PrintProduct();
           //EmpDisplay();

           Console.ReadLine();
        }
        static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("Appsettings.json", optional: false, reloadOnChange: true);
            _iconfiguration = builder.Build();
        }
        static void PrintProduct()
        {

            Likedemo lobj =new  Likedemo(_iconfiguration);
           // string s1 = "L";
            //string s = "L';delete from Product;Select * from Product where Name like 'R";

            //lobj.displayproduct(s1);
            //lobj.displayproduct_p(s);
           // lobj.displayproduct_proc(s1);

            Productlayer obj = new Productlayer(_iconfiguration);
            obj.Products();

            
        }
        static void EmpDisplay()
        {
            Customer p1 = new Customer {Name = "Raviraj", Address = "rampur", Mobno = 9456 };
            Strongly_type indata = new Strongly_type(_iconfiguration);
            int a = indata.AddData(p1);
            Console.WriteLine("{0}", a);

            Console.WriteLine("----------------------------");
           /* Customer r = indata.search(1);
            Console.WriteLine("{0}{1}{2}", r.Id, r.Name, r.Salary);*/

            Console.WriteLine("----------------------------");
            /*List<Customer> pl = indata.search("Raj");
            if (pl != null)
            {
                foreach (var x in pl)
                    Console.WriteLine("{0}{1}{2}", x.Id, x.Name, x.Salary);
            }
            else { Console.WriteLine("record with Raj not found"); }*/
            Console.WriteLine("----------------------------");


            // int no = indata.Del(3);
            // Console.WriteLine("deleted {0}", no);
            
            /*
            List<Customer> ls=indata.GetList();
            foreach (var x in ls)
                Console.WriteLine("{0}  {1}  {2}",x.Id, x.Name, x.Salary);
;
            Console.ReadLine();

            */

        }

    }

}