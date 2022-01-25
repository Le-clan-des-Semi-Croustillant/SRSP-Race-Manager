using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace RaceManager.Communication
{
    public partial class AsyncServer
    {
        public static void ReadCallback(IAsyncResult ar)
        {
            String content = String.Empty;

            // Retrieve the state object and the handler socket
            // from the asynchronous state object.
            Client client = (Client)ar.AsyncState;
            Socket handler = client.Handler;

            // Read data from the client socket. 
            int bytesRead = handler.EndReceive(ar);

            // Serialisation
            if (bytesRead > 0)
            {
                // There  might be more data, so store the data received so far.
                client.sb.Append(Encoding.ASCII.GetString(
                    client.buffer, 0, bytesRead));

                // Check for end-of-file tag. If it is not there, read 
                // more data.
                content = client.sb.ToString();
                if (content.IndexOf("<EOF>") > -1)
                {
                    // All the data has been read from the 
                    // client. Display it on the console.
                    Console.WriteLine("Read {0} bytes from socket. \n Data : {1}",
                        content.Length, content);

                    // SERIALISATION PSEUDOCODE
                    // ...
                    // serialisation = new Serialisation(content)
                    // switch (serialisation.MessageType){
                    // case IMessageType.CONNECT :
                    //      client.infos(serialisation.content)
                    //      clients.addOnce(client)
                    // case IMessageType.DISCONNECT :
                    //      clients.addOnce(client)
                    // 
                    // case IMessageType.INFO :


                    // Echo the data back to the client.
                    Send(handler, content);
                }
                else
                {
                    // Not all data received. Get more.
                    handler.BeginReceive(client.buffer, 0, Client.BufferSize, 0,
                    new AsyncCallback(ReadCallback), client);
                    return;
                }
            }
        }

    }
}
