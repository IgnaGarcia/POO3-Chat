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

        public object Send(Request req)
        {
            byte[] request = BinarySerialization.Serializate(req);
            Console.WriteLine("sending " + req.ToString());
            client.Send(request);

            return Receive();
        }

        public object Receive()
        {
            byte[] response = new byte[1024];
            client.Receive(response);
            return BinarySerialization.Deserializate(response); ;
        }
    }
}


