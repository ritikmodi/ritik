

namespace InMemory_CRUD_Try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Implement_Repo db = new Implement_Repo();

            Display(db);
            Console.WriteLine();

            db.Add(new Employee() { Name = "Ritik", Salary = 50000, Department = Dept.MKT });
            
            Display(db);
            Console.WriteLine();

            Employee e = db.GetEmployee(2);
            Console.WriteLine("From GetEmployee : {0}, {1}, {2}, {3}", e.Id, e.Name, e.Salary, e.Department);

            Console.WriteLine();

            db.Delete(3);

            Display(db);

            Console.WriteLine();

            Employee e2 = new Employee { Id = 1, Name = "Sam", Salary = 55000, Department = Dept.HR };
            db.Update(e2);

            Display(db);

            Console.ReadLine();




        }

        public static void Display(Implement_Repo db)
        {
            foreach(Employee e in db.GetAllEmployee())
            {
                Console.WriteLine("{0}, {1}, {2}, {3}",e.Id, e.Name, e.Salary, e.Department);
            }
        }
    }
}