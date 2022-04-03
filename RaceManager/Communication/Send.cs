using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace RaceManager.Communication
{
    public partial class AsyncServer
    {
        private static void Send(Socket handler, String data)
        {
            // Convert the string data to byte data using ASCII encoding.


            byte[] byteData = Encoding.ASCII.GetBytes(data);

            // Begin sending the data to the remote device.
            handler.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), handler);
        }

        private static void SendFile(Socket handler)
        {
            // Convert the string data to byte data using ASCII encoding.


            //byte[] byteData = Encoding.ASCII.GetBytes(data);
            string data = @"C:\Users\Sky\Documents\GitHub\LCSC-dev\SRSP-Race-Manager\RaceManager\dataResources\data.json";
            // Begin sending the data to the remote device.
            //handler.SendFileAsync(data, 0, data.Length, 0,
            //    new AsyncCallback(SendCallback), handler);
            handler.SendFile(data);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket handler = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.
                int bytesSent = handler.EndSend(ar);
                _logger.log(LoggingLevel.INFO, "SendCallback()", $"Sent {bytesSent} bytes to client." );

                handler.Shutdown(SocketShutdown.Both);
                handler.Close();

            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "SendCallback()", e.ToString());
            }
        }
    }
}
