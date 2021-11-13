using System.Net;
using System.Net.Sockets;

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

        public void Connect()
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

        public byte[] Send(Request req)
        {
            byte[] request = BinarySerialization.Serializate(req);
            Console.WriteLine("sending " + req.ToString());
            client.Send(request);

            return Receive();
        }

        public byte[] Receive()
        {
            byte[] response = new byte[1024];
            client.Receive(response);
            return response;
        }
    }
}


