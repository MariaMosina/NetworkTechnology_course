using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Sockets;
using System.Net;

namespace ServerFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket socketServer =
               new Socket(AddressFamily.InterNetwork,
               SocketType.Stream,
               ProtocolType.Tcp);

            IPAddress address = IPAddress.Parse("172.20.10.4");
            EndPoint ep = new IPEndPoint(address, 2020);
            socketServer.Bind(ep);
            socketServer.Listen(16);

            Socket socketClient = socketServer.Accept();
            while (true)
            {
                {
                    Console.WriteLine("enter message");
                    string s = Console.ReadLine();

                    byte[] bytes = ASCIIEncoding.GetEncoding(1251).
                        GetBytes(s);
                    socketClient.Send(bytes);
                }


                {
                    byte[] bytes = new byte[1024];
                    int nRecv = socketClient.Receive(bytes);

                    string question = ASCIIEncoding.
                        GetEncoding(1251).
                        GetString(bytes);

                    Console.Write("Client says: ");
                    Console.WriteLine(question);
                }
            }
            socketClient.Close();
        }
        
    }
}
