using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account_Application_Event
{
    internal class Message
    {
        public void email(double Balance, double amt, string Name)
        {
            Console.WriteLine("Email - Account Type : {0} Withdrawn Amount : {1} Current Balance : {2}",Name,amt,Balance);
        }

        public void sms(double Balance, double amt, string Name)
        {
            Console.WriteLine("SMS - Account Type : {0} Withdrawn Amount : {1} Current Balance : {2}", Name, amt, Balance);
        }
    }
}
