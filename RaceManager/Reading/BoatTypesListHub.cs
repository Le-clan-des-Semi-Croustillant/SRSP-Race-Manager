using Microsoft.AspNetCore.ResponseCompression;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using RaceManager.Pages;

namespace RaceManager.Reading
{
    public class BoatTypesListHub : Hub
    {
        private static RMLogger _logger = new RMLogger(LoggingLevel.DEBUG, "BoatTypesListHub");
        
        //public async Task BoatTypesListRequest()
        //{
        //    _logger.log(LoggingLevel.DEBUG, "BoatTypesListRequest()", $"Server received a BoatTypesListRequest from {Context.ConnectionId}");
        //    await Clients.Caller.SendAsync("ReceiveBoatTypeList ",BoatType.BoatTypesList);
        //}

        public async Task BoatTypesListSending(List<BoatType> btl)
        {
            _logger.log(LoggingLevel.INFO, "BoatTypesListSending()", $"Server received a list of {btl.Count} boat types from {Context.ConnectionId}");
            BoatType.BoatTypesList = btl;
        }
    }
}
