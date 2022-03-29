using Microsoft.AspNetCore.ResponseCompression;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using RaceManager.Pages;


namespace RaceManager.Communication
{
    public class ServerHub : Hub
    {
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
                    Logger.log(LoggingLevel.DEBUG, "ServerHub", $"Server send isServerRunning: {IsServerRunning}");
                }
                //Logger.log(LoggingLevel.DEBUG, "ServerHub", $"Server is {(isServerRunning? "" : "not ")}running");

                await Task.Delay(2000);
                
            }
            
        }


        
        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"{Context.ConnectionId} connected");
            return base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception e)
        {
            Console.WriteLine($"Disconnected {e?.Message} {Context.ConnectionId}");
            await base.OnDisconnectedAsync(e);
        }
    }

}
