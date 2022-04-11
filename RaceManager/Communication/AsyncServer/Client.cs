using System.Net;
using System.Net.Sockets;
using System.Text;

namespace RaceManager.Communication
{
    public partial class AsyncServer
    {
        private class Client // : IObservable<Client>
        {
            //public List<IObserver<Client>> Observers = new List<System.IObserver<Client>>();
            public IPAddress IpAddress { set; get; }
            public int Port { set; get; }
            public string Nickname { set; get; }
            public Socket Handler { set; get; }
            public Socket Listener { set; get; }

            public const int BufferSize = 1024;
            // Receive buffer.
            public byte[] buffer = new byte[BufferSize];
            // Received data string. 
            public StringBuilder sb = new StringBuilder();

        }
    }
}