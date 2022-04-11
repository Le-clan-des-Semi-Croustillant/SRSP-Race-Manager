using Microsoft.AspNetCore.ResponseCompression;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using RaceManager.Pages;
using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using RaceManager.Language;

namespace RaceManager.Communication
{
    public class ServerHub : Hub
    {
        private static RMLogger _logger = new RMLogger(LoggingLevel.INFO, "ServerHub");
        public static bool IsServerRunning { set; get; } = false;

        public async Task UpdateStatus()
        {
            //Logger.log(LoggingLevel.DEBUG, "BoatTypesListHub", $"Server send isServerRunning: {isServerRunning}");
            //IsServerRunning = isServerRunning;

            while (true)
            {
                //isServerRunning = !isServerRunning;
                if (Clients is not null && Clients.All is not null)
                {
                    await Clients.All.SendAsync("ServerStatusUpdate", IsServerRunning);
                    //_logger.log(LoggingLevel.DEBUG, "UpdateStatus()", $"Server send isServerRunning: {IsServerRunning}");
                }
                //Logger.log(LoggingLevel.DEBUG, "ServerHub", $"Server is {(isServerRunning? "" : "not ")}running");
                await Task.Delay(2000);
            }
        }
        
        /// <summary>
        /// Send the list of all BoatTypes to the client
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        public async Task SendPort(int port)
        {
            _logger.log(LoggingLevel.INFO, "SendPort()", "A client ask to change the port");
            AsyncServer.Stop();
            AsyncServer.Port = port;
            _logger.log(LoggingLevel.INFO, "SendPort()", $"Server port changed to : {port}");
            AsyncServer.Run();
        }
        
        /// <summary>
        /// Send the selected culture to the server
        /// </summary>
        /// <param name="culture"></param>
        /// <returns></returns>
        public async Task ChangeCulture(string culture)
        {
            _logger.log(LoggingLevel.INFO, "ChangeCulture()", $"A client ask to change the culture to : {culture}");
            LocaleManager.UpdateCulture(culture);
        }

        /// <summary>
        /// Ask the server to start the socket
        /// </summary>
        /// <returns></returns>
        public async Task TurnOn()
        {
            _logger.log(LoggingLevel.INFO, "TurnOn()", $"A client ask to turn on the server");
            AsyncServer.Run();
        }

        /// <summary>
        /// Ask the server to turn off the socket
        /// </summary>
        /// <returns></returns>
        public async Task TurnOff()
        {
            _logger.log(LoggingLevel.INFO, "TurnOff()", $"A client ask to turn off the server");
            AsyncServer.Stop();
        }

       
        public override Task OnConnectedAsync()
        {
            _logger.log(LoggingLevel.DEBUG, "OnConnectedAsync()", $"New connection {Context.ConnectionId}");
            return base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception e)
        {
            _logger.log(LoggingLevel.DEBUG, "OnDisconnectedAsync()", $"Disconnection of {Context.ConnectionId}");
            await base.OnDisconnectedAsync(e);
        }

        public static bool IsPortBusy(int port)
        {
            try
            {
                IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
                TcpConnectionInformation[] tcpConnInfoArray = ipGlobalProperties.GetActiveTcpConnections();

                foreach (TcpConnectionInformation tcpi in tcpConnInfoArray)
                {
                    if (tcpi.LocalEndPoint.Port == port)
                    {
                        return false;
                    }
                }

                Socket listener = new Socket(AddressFamily.InterNetworkV6,
                    SocketType.Stream, ProtocolType.Tcp);
                listener.SetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.IPv6Only, false);
                IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                listener.Bind(new IPEndPoint(ipAddress, port));
                listener.Close();
                _logger.log(LoggingLevel.DEBUG, "IsPortBusy()", $"Port available: {port}");
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.DEBUG, "IsPortBusy()", $"Port busy: {port}: \"{e}\"");
                return false;
            }

            return true;
        }
    }
}
