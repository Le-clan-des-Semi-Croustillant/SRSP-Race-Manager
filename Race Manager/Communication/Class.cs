using System;
using System.IO.Ports;
using System.Threading;
using System.Net.NetworkInformation;


namespace Race_Manager.Communication
{
    public class Port
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
    }
}




