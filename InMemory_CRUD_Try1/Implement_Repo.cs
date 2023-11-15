using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InMemory_CRUD_Try1
{
    public class Implement_Repo:IEmployeeRepository
    {
        public List<Employee> emplist;
        public Implement_Repo()
        {
            emplist = new List<Employee>()
            {
                new Employee() {Id = 1, Name = "Sam", Salary = 50000, Department = Dept.MKT},
                new Employee() {Id = 2, Name = "Abhir", Salary = 40000, Department= Dept.ADV},
                new Employee() {Id = 3, Name = "Meet", Salary = 35000, Department = Dept.HR}

            };
        }

        public Employee Add(Employee e1)
        {
            e1.Id = emplist.Max(e => e.Id) + 1;
            emplist.Add(e1);
            return e1;
        }

        public Employee Delete(int Id)
        {
            Employee employee = emplist.FirstOrDefault(e => e.Id == Id);
            if (employee != null)
            {
                emplist.Remove(employee);
            }

            return employee;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return emplist;
        }

        public Employee GetEmployee(int Id)
        {
            return emplist.FirstOrDefault(e => e.Id == Id);
        }

        public Employee Update(Employee e1)
        {
            Employee employee = emplist.FirstOrDefault(e=> e.Id == e1.Id);

            if(employee != null)
            {
                employee.Name = e1.Name;
                employee.Salary = e1.Salary;
                employee.Department = e1.Department;
            }

            return employee;
        }
    }
}
