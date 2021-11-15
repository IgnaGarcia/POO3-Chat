using ChatEntities.entities;
using ChatEntities.serializer;
using System.Net;
using System.Net.Sockets;

namespace ChatServer.server
{
    public class ChatProtocol
    {
        private static ChatProtocol? instance;

        IPHostEntry host;
        IPAddress ipAddr;
        IPEndPoint localEndPoint;

        Socket server;
        Thread threadListener;

        //public Dictionary<int, Dictionary<User, Socket>> usersInChats;
        RequestResolver requestResolver;

        private ChatProtocol()
        {
            requestResolver = new RequestResolver();
            host = Dns.GetHostEntry("localhost");
            ipAddr = host.AddressList[0];
            localEndPoint = new IPEndPoint(ipAddr, 11000);

            server = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(localEndPoint);
            server.Listen(10);
            
            threadListener = new Thread(Listen);
            threadListener.Start();

            /*usersInChats = new Dictionary<int, Dictionary<user.User, Socket>>();
            new ChatTable().GetAll().ForEach(chat => 
                usersInChats.Add(chat.GetId(), new Dictionary<user.User, Socket>())
            );*/
        }

        private static void CreateInstance()
        {
            if(instance == null) instance = new ChatProtocol();
        }

        public static ChatProtocol GetInstance()
        {
            if(instance == null) CreateInstance();
            return instance!;
        }

        public void Listen()
        {
            try
            {
                Console.WriteLine("Waiting for a connection...");
                Socket clientSocket;

                while (true)
                {
                    clientSocket = server.Accept();
                    Console.WriteLine("Client connected...");
                    threadListener = new Thread(RunClient);
                    threadListener.Start(clientSocket);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void RunClient(object? o)
        {
            Socket client = (Socket)o!;
            object request;
            while (true)
            {
               try
                {
                    request = Receive(client);
                    if (request is Request)
                    {
                        requestResolver.Resolve(client, (Request)request);
                    } else
                    {
                        Console.WriteLine("error: request != Request");
                    }
                } catch (Exception e)
                {
                    e.ToString();
                }
            }           
        }        

        private object Receive(Socket client)
        {
            byte[] request = new byte[1024];
            client.Receive(request);
            object serialized = BinarySerialization.Deserializate(request);
            return serialized;
        }
    }
}

