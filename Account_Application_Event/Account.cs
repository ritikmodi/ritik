using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account_Application_Event
{
    public delegate void wd(double Balance, double amt, string Name);
    abstract class Account
    {
        public event wd wdevent;
        static int count_id;
        int Id;
        string Name;
        double Balance;
        static int count_obj;

        public Account(string Name, double Balance) 
        {
            count_obj++;
            
            try
            {
                if (count_obj > 5)
                    throw new Exception("More than 5 objects not allowed");

                else
                    Console.WriteLine("{0} object created", count_obj);

                if (Name.Length < 2 && Name.Length > 15)
                {
                    throw new Exception("Name Length is Invalid");
                }
            }

            catch (Exception e )
            {
                Console.WriteLine(e.Message);
            }
            



            Id = ++count_id;
            this.NAME = Name;
            this.BALANCE = Balance;

            

        }

        static Account()
        {
            Console.WriteLine("Bank of Baroda");
        }

        public int ID
        {
            get { return Id; }
        }

        public string NAME
        {
            get
            {
                return Name;
            }

            set
            {
                Name = value;
            }
        }

        public double BALANCE
        {
            get { return Balance; }

            protected set
            {
                Balance = value;
            }
        }


        public void Deposit(double amt)
        {
            Console.WriteLine("in Deposit");
            BALANCE = BALANCE + amt;
        }

        public abstract void withdraw(double amt);

        public void OnWithDraw(double Balance, double amt, string Name)
        {
            if(wdevent != null) 
            {
                wdevent(Balance,amt,Name);
            }
        }

    }
}
