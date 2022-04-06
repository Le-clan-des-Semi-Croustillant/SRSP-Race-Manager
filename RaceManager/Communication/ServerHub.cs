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
        private static RMLogger _logger = new RMLogger(LoggingLevel.DEBUG, "ServerHub");
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

        public async Task SendPort(int port)
        {
            _logger.log(LoggingLevel.DEBUG, "SendPort()", $"Server changed port to : {port}");
            AsyncServer.Port = port;
        }

        public async Task ChangeCulture(string culture)
        {
            _logger.log(LoggingLevel.DEBUG, "ChangeCulture()", $"Server changed culture to : {culture}");
            LocaleManager.UpdateCulture(culture);
        }

        public async Task TurnOn()
        {
            _logger.log(LoggingLevel.INFO, "TurnOn()", $"Server turned on");
            AsyncServer.Run();
        }

        public async Task TurnOff()
        {
            _logger.log(LoggingLevel.INFO, "TurnOff()", $"Server turned off");
            AsyncServer.Stop();
        }

        public override Task OnConnectedAsync()
        {
            _logger.log(LoggingLevel.DEBUG, "OnConnectedAsync()", $"New connection {Context.ConnectionId}");

            return base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception e)
        {
            _logger.log(LoggingLevel.DEBUG, "OnDisconnectedAsync()", $"New connection {Context.ConnectionId}");
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
