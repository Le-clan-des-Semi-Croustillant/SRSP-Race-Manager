using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace RaceManager.Communication
{
    //public class ClientTest
    //{
    //    // Client socket.  
    //    public Socket workSocket = null;
    //    // Size of receive buffer.  
    //    public const int BufferSize = 256;
    //    // Receive buffer.  
    //    public byte[] buffer = new byte[BufferSize];
    //    // Received data string.  
    //    public StringBuilder sb = new StringBuilder();
    //}

    public class StateObject
    {
        // Client socket.  
        public Socket workSocket = null;
        // Size of receive buffer.  
        public const int BufferSize = 256;
        // Receive buffer.  
        public byte[] buffer = new byte[BufferSize];
        // Received data string.  
        public StringBuilder sb = new StringBuilder();
    }

    public class AsynchronousClient
    {
        // The port number for the remote device.  

        // ManualResetEvent instances signal completion.  
        private static ManualResetEvent connectDone =
            new ManualResetEvent(false);
        private static ManualResetEvent sendDone =
            new ManualResetEvent(false);
        private static ManualResetEvent receiveDone =
            new ManualResetEvent(false);

        // The response from the remote device.  
        private static String response = String.Empty;

        private static void StartClient(int port, int num)
        {
            // Connect to a remote device.  
            try
            {
                // Establish the remote endpoint for the socket.  
                // The name of the
                // remote device is "host.contoso.com".  
                IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

                // Create a TCP/IP socket.  
                Socket client = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect to the remote endpoint.  
                client.BeginConnect(remoteEP,
                    new AsyncCallback(ConnectCallback), client);
                connectDone.WaitOne();

                // Send test data to the remote device.
                //IMessageType TypeMessage;
                //string SendMessage;
                //if (num == 0)
                //{
                //    TypeMessage = IMessageType.CONNECTION;
                //    SendMessage = JsonParse.JsonSerialiseIConnection(TypeMessage);

                //}
                //else if (num == 1)
                //{
                //    TypeMessage = IMessageType.DISCONNECTION;
                //    SendMessage = JsonParse.JsonSerialiseIDisconnection(TypeMessage);
                //}
                //else if (num == 2)
                //{
                //    TypeMessage = IMessageType.PLAYERINFO;
                //    SendMessage = JsonParse.JsonSerialiseIPlayerInfo(TypeMessage);
                //}
                //else if (num == 3)
                //{
                //    TypeMessage = IMessageType.BOATSELECT;
                //    SendMessage = JsonParse.JsonSerialiseIBoatSelect(TypeMessage);
                //}
                //else if (num == 4)
                //{
                //    TypeMessage = IMessageType.BOATLISTREQUEST;
                //    SendMessage = JsonParse.JsonSerialiseIBoatListRequest(TypeMessage);
                //}
                //else /*if (num == 5)*/
                //{
                //    TypeMessage = IMessageType.ENDRACE;
                //    SendMessage = JsonParse.JsonSerialiseIEndRace(TypeMessage);
                //}
                //long Id = 4242;
                //long IdGame = 01;
                //string NMEA = "NMEA";
                //string Boat = "0";
                //int IdPlayer = 123;
                //string NamePlayer = "Sky";

                //string test = JsonParse.JsonSerialiseConnection(TypeMessage, Id, IdGame, NMEA, Boat, IdPlayer, NamePlayer);
                var serialiseJsonInfo = new JsonIConnection
                {
                    TypeMessage = IMessageType.BOATLISTREQUEST,
                };
                string SendMessage = System.Text.Json.JsonSerializer.Serialize(serialiseJsonInfo);

                Console.WriteLine("Message send : " + SendMessage);
                Send(client, SendMessage);
                //Send(client, "This is a test<EOF>");
                sendDone.WaitOne();

                // Receive the response from the remote device.  
                Receive(client);
                receiveDone.WaitOne();

                // Write the response to the console.  
                Console.WriteLine("Response received : {0}\n", response);

                // Release the socket.  
                Console.WriteLine("Je suis là");
                client.Shutdown(SocketShutdown.Both);
                Console.WriteLine("Je Passe");
                client.Close();
                Console.WriteLine("Je fini");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        class JsonIConnection
        {
            public IMessageType TypeMessage { get; set; }
        }

        private static void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket client = (Socket)ar.AsyncState;

                // Complete the connection.  
                client.EndConnect(ar);

                Console.WriteLine("Socket connected to {0}",
                    client.RemoteEndPoint.ToString());

                // Signal that the connection has been made.  
                connectDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void Receive(Socket client)
        {
            try
            {
                // Create the state object.  
                StateObject state = new StateObject();
                state.workSocket = client;

                // Begin receiving the data from the remote device.  
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the state object and the client socket
                // from the asynchronous state object.  
                StateObject state = (StateObject)ar.AsyncState;
                Socket client = state.workSocket;

                // Read data from the remote device.  
                int bytesRead = client.EndReceive(ar);

                if (bytesRead > 0)
                {
                    // There might be more data, so store the data received so far.  
                    state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));

                    // Get the rest of the data.  
                    client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReceiveCallback), state);
                }
                else
                {
                    // All the data has arrived; put it in response.  
                    if (state.sb.Length > 1)
                    {
                        response = state.sb.ToString();
                        Console.WriteLine(response);
                    }
                    // Signal that all bytes have been received.  
                    receiveDone.Set();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void Send(Socket client, String data)
        {
            // Convert the string data to byte data using ASCII encoding.  
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            // Begin sending the data to the remote device.  
            client.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), client);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket client = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.  
                int bytesSent = client.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to server.", bytesSent);

                // Signal that all bytes have been sent.  
                sendDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
            
        public static int Main(String[] args)
        {
            for (int i = 0; i < 6; i++)
            {
                StartClient(45678, i);
                Thread.Sleep(3000);
            }
            Thread.Sleep(10000);
            return 0;
        }
    }
}