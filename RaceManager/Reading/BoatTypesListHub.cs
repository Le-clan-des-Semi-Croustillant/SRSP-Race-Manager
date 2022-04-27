﻿using Microsoft.AspNetCore.ResponseCompression;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using RaceManager.Pages;
using RaceManager.DataProcessing.Files;

namespace RaceManager.Reading
{
    public class BoatTypesListHub : Hub
    {
        private static RMLogger _logger = new RMLogger(LoggingLevel.INFO, "BoatTypesListHub");
        
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
            FileManageData.ReadBoatTypesList();
            FileManageData.UpdateAllBoatTypesList();
            FileManageData.UpdateJsonData();
            _logger.log(LoggingLevel.WARN, "BoatTypesListSending()", "Reload files");
            BoatType.logBoats(_logger, LoggingLevel.DEBUG);

        }
    }
}
