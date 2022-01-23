using System;
using System.IO.Ports;
using System.Threading;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;


namespace Race_Manager.Communication
{
    public class Config
    {
        void Portdispo(int port)
        {
            bool portDisponible = true;

            IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
            TcpConnectionInformation[] tcpConnInfoArray = ipGlobalProperties.GetActiveTcpConnections();
            foreach (TcpConnectionInformation tcpi in tcpConnInfoArray)
            {

                if (tcpi.LocalEndPoint.Port == port)
                {
                    portDisponible = false;
                    Console.WriteLine("Le port numero {0} est non disponible", port);
                    break;
                }

            }
            Console.WriteLine("Le port numero {0} est disponible", port);

        }
        private static void IPAddresses(string server)
        {
            try
            {
                System.Text.ASCIIEncoding ASCII = new System.Text.ASCIIEncoding();

                // Permet d'obtenir des informations relatives au serveur.
                IPHostEntry heserver = Dns.GetHostEntry(server);
                foreach (IPAddress adresse in heserver.AddressList)
                {
                    Console.WriteLine("Address: " + adresse.ToString());
                    Console.WriteLine("\r\n");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Probleme avec le server Exception: " + e.ToString());
            }
        }
        //IPAddressAdditionalInfo affiche des informations supplémentaires sur l'adresse du serveur.
        private static void IPAddressAdditionalInfo()
        {
            try
            {
                // Affiche les flgas qui indiquent si le serveur prend en charge les schémas d'adresse IPv4 ou IPv6.
                Console.WriteLine("\r\n Le serveur prend en charge les adresses IPv4: " + Socket.SupportsIPv4);
                Console.WriteLine("Le serveur prend en charge les adresses IPv6: " + Socket.SupportsIPv6);


            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur adresse ip non trouver Exception: " + e.ToString());
            }
        }
        //Ici c'est un bout de code permettant de tester le code ci-dessus
        /**
         *  public static void Main(string[] args)
        {
            string server = null;

            // Ici on définit une expression régulière pour analyser l'entrée de l'utilisateur.
            // Il s'agit d'un contrôle de sécurité. Il ne permet qu'une chaîne alphanumérique de 2 à 40 caractères.
            Regex rex = new Regex(@"^[a-zA-Z]\w{1,39}$");
            if (args.Length < 1)
            {           
                server = Dns.GetHostName();
                Console.WriteLine("Adresse courante : " + server);
            }
            else
            {
                server = args[0];
                if (!(rex.Match(server)).Success)
                {
                    Console.WriteLine("Le format de la chaîne d'entrée n'est pas autorisé .");
                    return;
                }
            }        
            IPAddresses(server);
            IPAddr
        }*/

    }
}