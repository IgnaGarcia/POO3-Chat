using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    class Client
    {
        IPHostEntry ipHostInfo;
        IPAddress ipAddress;
        IPEndPoint localEndPoint;
        Socket client;

        public Client()
        {
            ipHostInfo = Dns.GetHostEntry("localhost");
            ipAddress = ipHostInfo.AddressList[0];
            localEndPoint = new IPEndPoint(ipAddress, 11000);
            client = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }

        public void connect()
        {
            try
            {
                client.Connect(localEndPoint);              
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void send(string msg)
        {
            byte[] request = Encoding.ASCII.GetBytes(msg);
            client.Send(request);
        }

        public string receive()
        {
            byte[] response = new byte[1024];
            client.Receive(response);
            return Encoding.ASCII.GetString(response);
        }


    }
}


