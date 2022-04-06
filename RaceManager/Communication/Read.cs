using RaceManager.DataProcessing.Files;
using RaceManager.DataProcessing.Json;
using RaceManager.Reading;
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
                //if (content.IndexOf("<EOF>") > -1)
                if (true)
                {
                    // All the data has been read from the 
                    // client. Display it on the console.
          
                    _logger.log(LoggingLevel.INFO, "ReadCallback()",$"Read {content.Length} bytes from socket. \nData : {content}");

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
                    dynamic serialisation = JsonParse.JsonDeserialize(content);
                    string SendAtt = JsonManage.JsonType(content);
                    _logger.log(LoggingLevel.DEBUG, "ReadCallback()", "Send att" + SendAtt);
                    //Send(handler, SendAtt);

                    switch ((IMessageType)serialisation.TypeMessage)
                    {
                        case IMessageType.CONNECTION:
                            _logger.log(LoggingLevel.INFO, "ReadCallback()", "CONNECTION");
                            break;

                        case IMessageType.DISCONNECTION:
                            _logger.log(LoggingLevel.INFO, "ReadCallback()", "DISCONNECTION");
                            break;

                        case IMessageType.PLAYERINFO:
                            _logger.log(LoggingLevel.INFO, "ReadCallback()", "PLAYERINFO");
                            break;

                        case IMessageType.BOATSELECT:
                            _logger.log(LoggingLevel.INFO, "ReadCallback()", "BOATSELECT");
                            break;

                        case IMessageType.BOATLISTREQUEST:
                            _logger.log(LoggingLevel.INFO, "ReadCallback()", "BOATLISTREQUEST");
                            SendAtt = FileManageData.ReadFilePath(FileManageData.pathJsonData);
                            _logger.log(LoggingLevel.DEBUG, "ReadCallback()", "Send att" + SendAtt);
                            break;

                        case IMessageType.ENDRACE:
                            _logger.log(LoggingLevel.INFO, "ReadCallback()", "ENDRACE");
                            break;

                        case IMessageType.RACELISTUPDATE:
                            _logger.log(LoggingLevel.INFO, "ReadCallback()", "RACELISTUPDATE");
                            break;

                        default:
                            _logger.log(LoggingLevel.WARN, "ReadCallback()", "Unknown message type");
                            break;
                    }


                    // Echo the data back to the client.
                    _logger.log(LoggingLevel.DEBUG, "ReadCallback()", "Send to client");
                    Send(handler, SendAtt);
 
                    //SendFile(handler);



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
