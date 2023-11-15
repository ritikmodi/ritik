using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMemory_CRUD_Try1
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Salary { get; set; }

        public Dept Department { get; set; }  
    }

    public enum Dept
    {
        MKT, ADV, HR
    }
}
