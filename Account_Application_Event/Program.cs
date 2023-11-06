namespace Account_Application_Event
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Account[] arr = new Account[6];

            Message m = new Message();

            arr[0] = new Saving("Saving", 10000);
            arr[1] = new Current("Current", 5000);
            arr[2] = new Saving("Saving", 20000);
            arr[3] = new Current("Current", 2000);
            arr[4] = new Saving("Saving", 30000);
            arr[5] = new Current("Current", 4000);

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i].wdevent += m.sms;
                arr[i].wdevent += m.email;
            }

            try
            {
                arr[0].Deposit(1000);
                arr[0].withdraw(9000);

                arr[1].withdraw(10000);

                arr[2].withdraw(19500);

                arr[3].withdraw(10000);

                Saving s = arr[0] as Saving;
                //double d = s.Payinterest(arr[0]);
               // Console.WriteLine("Interst is : " + d);

               // Console.WriteLine("New balance is : " + arr[0].BALANCE);

                //  arr[].withdraw(9000);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.ReadLine();

        }
    }
}