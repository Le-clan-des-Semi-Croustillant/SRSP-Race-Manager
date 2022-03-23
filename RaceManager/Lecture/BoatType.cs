using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Xml;
using Microsoft.AspNetCore.ResponseCompression;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using RaceManager.Pages;

namespace RaceManager.Lecture
{
    public class BoatType
    {

        public static List<BoatType> BoatTypesList = new();
        public int IDTypeBateau { get; set; }
        public string Name { get; set; }
        public float LongueurCoque { get; set; }
        public float LongueurHorsTout { get; set; }
        public float LargeurCoque { get; set; }
        public float LargeurHorsTout { get; set; }
        public float TirantEeau { get; set; }
        public float TirantAir { get; set; }
        public float Poids { get; set; }

        public Polaire polaire = new Polaire();

        public BoatType(string name)
        {
            Name = name;
        }


    }

    public class BoatTypesListHub : Hub
    {
        public async Task SendMessage(List<BoatType> btl)
        {
            Logger.log(LoggingLevel.DEBUG, "BoatTypesListHub", $"Server received {btl[0].IDTypeBateau} old was {BoatType.BoatTypesList[0].IDTypeBateau}");
            BoatType.BoatTypesList[0].IDTypeBateau = btl[0].IDTypeBateau -10;
            btl[0].IDTypeBateau++;
            // Call the broadcastMessage method to update clients.
            await Clients.All.SendAsync("ReceiveMessage", btl);

        }


    }
}