using System;
using System.IO.Ports;
using System.Threading;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using RaceManager.Language;

namespace RaceManager.Communication
{
    /// <summary>
    /// Class for handling the port and ip
    /// </summary>
    public class Configuration
    {
        private static RMLogger _logger = new(LoggingLevel.DEBUG, "Configuration");
        /// <summary>
        /// Check if the port is available
        /// </summary>
        /// <param name="port">spcific port</param>
        /// <returns>True if port is available</returns>
        public static bool portIsAvailable(int port)
        {
            bool portDisponible = true;

            IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
            TcpConnectionInformation[] tcpConnInfoArray = ipGlobalProperties.GetActiveTcpConnections();
            foreach (TcpConnectionInformation tcpi in tcpConnInfoArray)
            {
                if (tcpi.LocalEndPoint.Port == port)
                {
                    portDisponible = false;

                    _logger.log(LoggingLevel.DEBUG, "portIsAvailable()", Locales.PortUnavailable + $": {port}");
                    break;
                }
            }
            return portDisponible;
        }

        /// <summary>
        /// The IPAddresses method obtains the selected server IP address information
        /// </summary>
        /// <param name="server"></param>
        /// <returns><see cref="IPAddress[]"/></returns>
        public static IPAddress[] IpAddresses(string server)
        {
            //StringBuilder sb = new StringBuilder();
            IPAddress[] ips = null;
            try
            {
                System.Text.ASCIIEncoding ASCII = new System.Text.ASCIIEncoding();

                // Allows you to obtain information about the server.
                IPHostEntry heserver = Dns.GetHostEntry(server);
                ips = heserver.AddressList;
                foreach (IPAddress address in ips)
                {
                    _logger.log(LoggingLevel.DEBUG, "IpAddresses()", $"IP: {address}");
                }
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "IpAddresses()", $"Server exception: {e}");
            }

            return ips;
        }

        /// <summary>
        /// IPAddressAdditionalInfo displays additional information about the server address.
        /// </summary>
        /// <returns>If IPv4 or IPv6 is support</returns>
        public static string IpAddressAdditionalInfo()
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                // Displays the flgas that indicate whether the server supports IPv4 or IPv6 address schemes.
                sb.AppendLine(Locales.IPV4support + Socket.SupportsIPv4);
                sb.AppendLine(Locales.IPV6support + Socket.SupportsIPv6);
                _logger.log(LoggingLevel.DEBUG, "IpAddressAdditionalInfo()", sb.ToString());
            }

            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "IpAddressAdditionalInfo()", $"Host not found exception: {e}");
            }

            return sb.ToString();
        }


    }
}