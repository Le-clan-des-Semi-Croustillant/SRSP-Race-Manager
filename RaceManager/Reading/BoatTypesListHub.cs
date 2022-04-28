using Microsoft.AspNetCore.ResponseCompression;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using RaceManager.Pages;
using RaceManager.DataProcessing.Files;

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
            BoatType.logBoats(_logger, LoggingLevel.DEBUG);
            FileManageData.UpdateAllBoatTypesList();
            FileManageData.ReadBoatTypesList();
            FileManageData.UpdateJsonData();
            _logger.log(LoggingLevel.WARN, "BoatTypesListSending()", "Reload files");
            BoatType.logBoats(_logger, LoggingLevel.DEBUG);

        }

        public async Task BoatTypesListRemoved(BoatType bt)
        {
            _logger.log(LoggingLevel.WARN, "BoatTypesListRemoved()", $"Server received a removed boat type from {Context.ConnectionId}");
            string pathBoatDelete = FileManageData.pathDataBoat + bt.Name + "_" + bt.ID + ".json";
            FileManageData.DeleteFile(pathBoatDelete);
        }

    }
}
