using Microsoft.AspNetCore.ResponseCompression;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using RaceManager.Pages;

namespace RaceManager.Reading
{
    public class BoatTypesListHub : Hub
    {
        public async Task SendMessage(List<BoatType> btl)
        {
            Logger.log(LoggingLevel.DEBUG, "BoatTypesListHub", $"Server received {btl[0].ID} old was {BoatType.BoatTypesList[0].ID}");

            // Call the broadcastMessage method to update clients.
            await Clients.All.SendAsync("ReceiveMessage", btl);

        }

    }
}
