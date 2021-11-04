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

            List<Thread> thread;

            public void escucha()
            {
                thread = new List<Thread>();

                //IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                IPHostEntry ipHostInfo = Dns.GetHostEntry("localhost");
            Console.WriteLine(ipHostInfo);
                IPAddress ipAddress = ipHostInfo.AddressList[0];
            Console.WriteLine(ipAddress);
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);
            Console.WriteLine(localEndPoint);


            try
            {

                Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                listener.Bind(localEndPoint);
                listener.Listen(10);

                Console.WriteLine("Waiting for a connection...");

                Socket cliente;


                while (true)
                {
                    cliente = listener.Accept();
                    Thread hilo = new Thread(disparaCliente);
                    hilo.Start(cliente);
                    thread.Add(hilo);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            }

            public void procesa1Cliente()
            {
            }

            public void disparaCliente(Object o)
            {
                Socket param = (Socket)o;
                byte[] enviar = Encoding.ASCII.GetBytes("Hola");
                param.Send(enviar);
                byte[] recibir = new byte[1];
                string recibido = "";
                param.Receive(recibir, 0);
                while (recibir[0] != 13)
                {
                    recibido += char.ConvertFromUtf32(recibir[0]);
                    param.Receive(recibir, 0);
                }
                Console.WriteLine(recibido);
                Console.ReadKey();
            }

        
    }
}

