using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Race_Manager.Communication
{
    public partial class AsyncServer
    {
        public class Client // : IObservable<Client>
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

            public Client()
            {
                //this.Listener  = (Socket)ar.AsyncState;
                //this.Handler = Listener.EndAccept(ar);

                //this.Nickname = "TODO";

                //this.Port = ((IPEndPoint)Listener.RemoteEndPoint).Port;
                //this.IpAddress = ((IPEndPoint)Listener.RemoteEndPoint).Address;
            }

            //void startDialog()
            //{
            //    socket.BeginReceive(buffer, 0, BufferSize, 0,
            //       new AsyncCallback(ReadCallback), state);
            //}

            //private void Subscribe(IObserver<Client> observer)
            //{
            //}

            //IDisposable IObservable<Client>.Subscribe(IObserver<Client> observer)
            //{
            //    observers.Add(observer);
            //    throw new NotImplementedException();
            //}


        }
    }
}