using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account_Application_Event
{
    internal class Current:Account
    {
        

        public Current(string Name, double Balance) : base(Name, Balance)
        {

        }

        public override void withdraw(double amt)
        {
            Console.WriteLine("in withdraw");

            try
            {
                if (BALANCE - amt < 0)
                {
                    throw new Exception("Account me jitne paise hai usse jyada kaise nikal sakta hai");
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
    }
}
