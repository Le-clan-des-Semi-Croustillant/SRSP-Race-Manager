using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Microsoft.AspNetCore.SignalR;

namespace RaceManager.Communication
{
    // https://docs.microsoft.com/en-us/dotnet/framework/network-programming/asynchronous-server-socket-example?redirectedfrom=MSDN
    // State object for reading client data asynchronously
    //public class StateObject
    //{
    //    // Client  socket.
    //    public Socket workSocket = null;
    //    // Size of receive buffer.
    //    public const int BufferSize = 1024;
    //    // Receive buffer.
    //    public byte[] buffer = new byte[BufferSize];
    //    // Received data string. 
    //    public StringBuilder sb = new StringBuilder();
    //}

    public partial class AsyncServer
    {

        private static List<Client> clients = new List<Client>();

        private static Thread thread = new Thread(new ThreadStart(StartListening));
        public static int Port { get; set; } = 45879;

        // Semaphore
        public static ManualResetEvent allDone = new ManualResetEvent(false);

        public AsyncServer()
        {

        }

        public static void Run()
        {
            /// <summary>
            /// Start listening for connections
            /// </summary>
            thread.Start();
        }

        public static void Stop()
        {
            thread.Interrupt();
        }


        public static void StartListening()
        {
            // Data buffer for incoming data.
            byte[] bytes = new byte[1024];

            // Réservation du port d'écoute selon l'ip du serveur.
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            //Console.WriteLine("Adresse de l'hote : " + ipAddress);
            Logger.log(LoggingLevel.INFO,"AsyncServer.StartListening()", $"Host address : {ipAddress}");
            
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, Port);
            Socket listener = new Socket(AddressFamily.InterNetworkV6,
                SocketType.Stream, ProtocolType.Tcp);
            listener.SetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.IPv6Only, false);
            // Bind the socket to the local endpoint and listen for incoming connections.
            try
            {

                listener.Bind(localEndPoint);
                listener.Listen(100);

                while (true)
                {
                    // Set the event to nonsignaled state.
                    allDone.Reset();

                    // Start an asynchronous socket to listen for connections.
                    Logger.log(LoggingLevel.DEBUG, "AsyncServer.StartListening()", $"Waiting for a connection... {Port}");
                    //Console.WriteLine("Waiting for a connection...");
                    listener.BeginAccept(
                        new AsyncCallback(AcceptCallback),
                        listener);

                    // Wait until a connection is made before continuing.
                    allDone.WaitOne();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }


            //Console.WriteLine("\nPress ENTER to continue...");
            //Console.Read();
            Logger.log(LoggingLevel.INFO, "AsyncServer.StartListening()", $"Listen is over.");

        }

        /// <summary>
        /// Here we treat if the new client already exists or not, 
        /// then create a new one or update the existing one
        /// </summary>
        /// <param name="ar"></param>
        public static void AcceptCallback(IAsyncResult ar)
        {
            // Signal the main thread to continue.
            allDone.Set();


            // Get the socket that handles the client request.
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            // read

            Client client = new Client();
            client.Handler = handler;
            //clients.Add(client);
            // Create the state object.
            //StateObject state = new StateObject();
            //state.workSocket = handler;
            handler.BeginReceive(client.buffer, 0, Client.BufferSize, 0,
                new AsyncCallback(ReadCallback), client);
        }





    }
}
