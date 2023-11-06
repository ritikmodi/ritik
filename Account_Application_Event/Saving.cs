using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account_Application_Event
{
    internal class Saving:Account
    {
        const double minbal = 1000;
        static double roi = 0.05;

        static Saving()
        {
            Console.WriteLine("in Saving - Bank of Baroda");
        }
        public Saving(string Name, double Balance):base(Name, Balance)
        {

        }

        public override void withdraw(double amt)
        {
            Console.WriteLine("in withdraw");

            try
            {
                if (BALANCE - amt < minbal)
                {
                    throw new Exception("Kuch toh chod de Minimum Balance");
                }
                else
                {
                    BALANCE = BALANCE - amt;
                    OnWithDraw(BALANCE, amt, NAME);
                }

            }
            

            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            
            
        }

        /*
        public static double Payinterest(Account a)
        {
            double interest = roi * a.BALANCE;
            double  a.BALANCE = a.BALANCE + interest;
            return interest;

        }
        */
        
    }
}
