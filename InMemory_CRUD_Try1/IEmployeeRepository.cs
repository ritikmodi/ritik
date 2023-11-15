using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMemory_CRUD_Try1
{
    internal interface IEmployeeRepository
    {
        Employee GetEmployee(int Id);

        IEnumerable<Employee> GetAllEmployee();

        Employee Add(Employee e1);

        Employee Update(Employee e1);

        Employee Delete(int Id);
    }
}
