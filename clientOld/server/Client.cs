using entities;
using serializer;
using System.Net;
using System.Net.Sockets;

namespace client.server
{
    class Client
    {
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
                Console.WriteLine(response.ToString());
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
            client.Send(request);
        }

        public object Receive()
        {
            byte[] response = new byte[1024];
            client.Receive(response);
            return BinarySerialization.Deserializate(response); ;
        }
    }
}


