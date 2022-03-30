using Microsoft.AspNetCore.ResponseCompression;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using RaceManager.Pages;
using System;
using System.Net.Sockets;

namespace RaceManager.Communication
{
    public class ServerHub : Hub
    {
        private static RMLogger logger = new RMLogger(LoggingLevel.DEBUG, "ServerHub");
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
                    //logger.log(LoggingLevel.DEBUG, "UpdateStatus()", $"Server send isServerRunning: {IsServerRunning}");
                }
                //Logger.log(LoggingLevel.DEBUG, "ServerHub", $"Server is {(isServerRunning? "" : "not ")}running");
                await Task.Delay(2000);
            }
        }

        public override Task OnConnectedAsync()
        {
            logger.log(LoggingLevel.DEBUG, "OnConnectedAsync()", $"New connection {Context.ConnectionId}");

            return base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception e)
        {
            logger.log(LoggingLevel.DEBUG, "OnDisconnectedAsync()", $"New connection {Context.ConnectionId}");
            await base.OnDisconnectedAsync(e);
        }

        public static bool IsPortBusy(int port)
        {
            // Call with an int variable.
            using (TcpClient tcpClient = new TcpClient())
            {
                try
                {
                    tcpClient.Connect("127.0.0.1", port);
                    logger.log(LoggingLevel.DEBUG, "IsPortBusy()", $"Port available: {port}");
                    return true;
                }
                catch (Exception)
                {
                    logger.log(LoggingLevel.ERROR, "IsPortBusy()", $"Port busy: {port}");
                    return false;
                }
            }
        }
    }

}
