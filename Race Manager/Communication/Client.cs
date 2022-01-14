using System.Net;
using System.Net.Sockets;

namespace Race_Manager.Communication
{
    public class Client : IObservable<>
    {
        private IPAddress ipAddress { get; }
        private int port { set; get; }
        private string nickname { get; }
        private Socket socket { set; get; }

        Client(Socket socket)
        {
            this.socket = socket;
            nickname = "TODO";
            port = ((IPEndPoint)socket.RemoteEndPoint).Port;
        }



    }
}