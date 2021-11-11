using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace server.server
{
    public class ChatProtocol
    {

        List<Thread> threads;

        public void listen()
        {
            threads = new List<Thread>();

            IPHostEntry ipHostInfo = Dns.GetHostEntry("localhost");
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

            try
            {
                Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                listener.Bind(localEndPoint);
                listener.Listen(10);

                Console.WriteLine("Waiting for a connection...");

                Socket clientSocket;
                while (true)
                {
                    clientSocket = listener.Accept();
                    Thread clientThread = new Thread(runClient);
                    clientThread.Start(clientSocket);
                    threads.Add(clientThread);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void runClient(Object o)
        {
            Socket clientSocket = (Socket)o;
            while (true)
            {
                byte[] request = new byte[1024], response;
                try
                {
                    clientSocket.Receive(request);
                    response = RequestResolver.resolve(request);
                    if(response == null) clientSocket.Close();
                    else clientSocket.Send(response);
                } catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }           

            Console.ReadKey();
        }        
    }
}

