using System;
using System.Web;
using Microsoft.AspNetCore.SignalR;

namespace RaceManager.Data
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(Data a, Data b)
        {
            // Call the broadcastMessage method to update clients.
            await Clients.All.SendAsync("ReceiveMessage", a, b);

        }
    }

    public class Data
    {
        public string Age = "ent";
        public List<int> List = new() { 1, 2, 3, 4, 5 };
        public string N = "eze";
        
    }
}