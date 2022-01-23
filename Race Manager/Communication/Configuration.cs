using System;
using System.IO.Ports;
using System.Threading;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using Race_Manager.locales;

namespace Race_Manager.Communication
{
    public class Configuration
    {
        public static  bool portIsAvailable(int port)
        {
            bool portDisponible = true;

            IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
            TcpConnectionInformation[] tcpConnInfoArray = ipGlobalProperties.GetActiveTcpConnections();
            foreach (TcpConnectionInformation tcpi in tcpConnInfoArray)
            {
                if (tcpi.LocalEndPoint.Port == port)
                {
                    portDisponible = false;
                    Console.WriteLine(text.PortUnavailable, port);
                    break;
                }
            }
            return portDisponible;
        }

        public static IPAddress[] IpAddresses(string server)
        {
            //StringBuilder sb = new StringBuilder();
            IPAddress[] ips = null;
            try
            {
                System.Text.ASCIIEncoding ASCII = new System.Text.ASCIIEncoding();

                // Permet d'obtenir des informations relatives au serveur.
                IPHostEntry heserver = Dns.GetHostEntry(server);
                ips = heserver.AddressList;
                foreach (IPAddress address in ips)
                {
                    Console.WriteLine("Address: " + address);
                    //Console.WriteLine("\r\n");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Server exception" + e);
            }

            return ips;
        }

        //IPAddressAdditionalInfo affiche des informations supplémentaires sur l'adresse du serveur.
        public static string IpAddressAdditionalInfo()
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                // Affiche les flgas qui indiquent si le serveur prend en charge les schémas d'adresse IPv4 ou IPv6.
                sb.AppendLine(text.IPV4support + Socket.SupportsIPv4);
                sb.AppendLine(text.IPV6support + Socket.SupportsIPv6);
                Console.WriteLine(sb);
            }

            catch (Exception e)
            {
                Console.WriteLine("ERROR : Host not found exception: " + e);
            }

            return sb.ToString();
        }
 

    }
}