using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Race_Manager.Communication;
using Race_Manager.locales;

namespace consoleTests
{
    class serveurConfigTest
    {
        //Ici c'est un bout de code permettant de tester le code ci-dessus
        public static void Main(string[] args)
        {
            string server = null;


            if (args.Length < 1)
            {
                server = Dns.GetHostName();
                Console.WriteLine("Adresse courante : " + server);
            }
            else

                server = args[0];


            IPAddress[] ips = Configuration.IpAddresses(server);

            Configuration.IpAddressAdditionalInfo();
            for (int i = 0; i < 10000; i++)
            {
                Configuration.portIsAvailable(i);
            }
        }
    }
}