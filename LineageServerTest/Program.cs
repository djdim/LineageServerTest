using System;
using System.Net.NetworkInformation;

namespace LineageServerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Checking for servers...");
            //Reading data form the servers.txt file
            ReadDatafromTxt();

            Console.WriteLine("Press enter to exit...");
            // Suspend the screen.
            Console.ReadLine();
        }

        public static bool ReadDatafromTxt()
        {
            int counter = 0;
            string line;

            // Read the file and display it line by line.
            System.IO.StreamReader file =
               new System.IO.StreamReader(@"servers.txt");
            while ((line = file.ReadLine()) != null)
            {
                PingHost(line);
                counter++;
            }

            file.Close();
            return true;
        }

        public static bool PingHost(string nameOrAddress)
        { 
                Ping p = new Ping();
                PingReply r;
                string s;
                s = nameOrAddress;
                r = p.Send(s);

                if (r.Status == IPStatus.Success)
                {
                    Console.WriteLine("Ping to " + s.ToString() + "[" + r.Address.ToString() + "]" + "  Server is up^^" + "\n");
                }
                else
                {
                    Console.WriteLine("Server is Down");
                }
            return true;
            
        }
    }
}
