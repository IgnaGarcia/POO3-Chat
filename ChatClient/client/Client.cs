using ChatEntities.entities;
using ChatEntities.serializer;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace ChatClient.client
{
    public class Client
    {
        public delegate void UpdateDelegate(object o);
        public UpdateDelegate onUpdateUser;
        public UpdateDelegate onUpdateChatList;
        public UpdateDelegate onUpdateMessages;
        public UpdateDelegate onUpdateChat;

        IPHostEntry ipHostInfo;
        IPAddress ipAddress;
        IPEndPoint localEndPoint;
        Socket client;
        Thread threadListener;

        public Client()
        {
            ipHostInfo = Dns.GetHostEntry("localhost");
            ipAddress = ipHostInfo.AddressList[0];
            localEndPoint = new IPEndPoint(ipAddress, 11000);
            client = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Connect()
        {
            try
            {
                client.Connect(localEndPoint);
                threadListener = new Thread(Listen);
                threadListener.SetApartmentState(ApartmentState.STA);
                threadListener.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void Listen()
        {
            Response response;
            while (true)
            {
                
                response = (Response)Receive();
                if(response == null)
                {
                } 
                else if(response.code == 1 || response.code == 2)
                {
                    onUpdateUser(response.user);
                } 
                else if(response.code == 3)
                {
                    onUpdateChatList(response.chatList);
                } 
                else if(response.code == 4 || response.code == 5)
                {
                    if(response.messageList != null)
                        onUpdateMessages(response.messageList);            
                    else if(response.message != null) 
                        onUpdateMessages(response.message);
                }
                else if(response.code == 9)
                {
                    onUpdateChat(response.chat);
                }
            }
        }

        public void Disconnect()
        {
            try
            {
                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Send(Request req)
        {
            byte[] request = BinarySerialization.Serializate(req);
            Console.WriteLine("sending " + req.ToString());
            try
            {
                client.Send(request);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public object Receive()
        {
            byte[] response = new byte[32000];
            try
            {
                client.Receive(response);
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            object o = BinarySerialization.Deserializate(response);
            return o;
        }
    }
}
