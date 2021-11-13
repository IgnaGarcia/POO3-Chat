using System.Net;
using System.Net.Sockets;

namespace server.server
{
    public class ChatProtocol
    {
        private static ChatProtocol instance = null;
        IPHostEntry ipHostInfo;
        IPAddress ipAddress;
        IPEndPoint localEndPoint;
        Socket listener;
        Thread threadListener;

        List<Thread> threads;
        //public Dictionary<int, Dictionary<User, Socket>> usersInChats;

        RequestResolver requestResolver;

        private ChatProtocol()
        {
            threads = new List<Thread>();
            requestResolver = new RequestResolver();
            ipHostInfo = Dns.GetHostEntry("localhost");
            ipAddress = ipHostInfo.AddressList[0];
            localEndPoint = new IPEndPoint(ipAddress, 11000);

            listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(localEndPoint);
            listener.Listen(10);
            
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
            return instance;
        }

        public void Listen()
        {
            try
            {
                Console.WriteLine("Waiting for a connection...");
                Socket clientSocket;

                while (true)
                {
                    clientSocket = listener.Accept();
                    Console.WriteLine("Client connected...");
                    Thread clientListener = new Thread(RunClient);
                    threads.Add(clientListener);
                    clientListener.Start(clientSocket);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void RunClient(Object o)
        {
            Socket clientSocket = (Socket)o;
            byte[] request;
            while (true)
            {
               try
                {
                    request = Receive(clientSocket);
                    requestResolver.Resolve(clientSocket, request);
                } catch (Exception e)
                {
                    e.ToString();
                }
            }           

            Console.ReadKey();
        }        

        private byte[] Receive(Socket client)
        {
            byte[] request = new byte[1024];
            client.Receive(request);
            return request;
        }
    }
}

