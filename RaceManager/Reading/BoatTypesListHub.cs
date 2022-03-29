using Microsoft.AspNetCore.ResponseCompression;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using RaceManager.Pages;

namespace RaceManager.Reading
{
    public class BoatTypesListHub : Hub
    {
        RMLogger logger = new RMLogger(LoggingLevel.DEBUG, "BoatTypesListHub");
        
        public async Task BoatTypesListRequest()
        {
            logger.log(LoggingLevel.DEBUG, "BoatTypesListRequest()", $"Server received a BoatTypesListRequest from {Context.ConnectionId}");
            await Clients.Caller.SendAsync("ReceiveBoatTypeList ",BoatType.BoatTypesList);
        }

        public async Task BoatTypesListSending(List<BoatType> btl)
        {
            logger.log(LoggingLevel.INFO, "BoatTypesListSending()", $"Server received a list of {btl.Count} boat types from {Context.ConnectionId}");
            BoatType.BoatTypesList = btl;
            //await Clients.All.SendAsync("ReceiveBoatTypeList ", btl);
        }
    }
}
