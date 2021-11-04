using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace server.server
{
    internal class TcpIp
    {
        List<Thread>? threads;

        public void listen()
        {
            threads = new List<Thread>();

            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

            Console.WriteLine("Start Server");

            Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(localEndPoint);
            listener.Listen(100);

            Socket client;
            while (true)
            {
                Console.WriteLine("Waiting...");
                client = listener.Accept();
                Thread thread = new Thread(runClient);
                thread.Start(client);
                threads.Add(thread);
            }
        }

        public void runClient(Object o)
        {
            Console.WriteLine("Client Thread");

            Socket clientSocket = (Socket) o;
            byte[] msgToSend = Encoding.ASCII.GetBytes("Hola");

            clientSocket.Send(msgToSend);
            byte[] msgRecived = new byte[1];
            string strRecived = "";
            clientSocket.Receive(msgRecived, 0);

            while (msgRecived[0] != 13)
            {
                strRecived += char.ConvertFromUtf32(msgRecived[0]);
                clientSocket.Receive(msgRecived, 0);
            }

            Console.WriteLine(strRecived);
            Console.ReadKey();
        }
    }
}