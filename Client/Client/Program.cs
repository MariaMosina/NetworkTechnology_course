using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Sockets;
using System.Net;

namespace ClientFirst
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
            socketServer.Connect(ep);
            while (true)
            {
                {
                    byte[] bytes = new byte[1024];
                    int nRecv = socketServer.Receive(bytes);

                    string question = ASCIIEncoding.
                        GetEncoding(1251).
                        GetString(bytes);

                    Console.Write("Server says: ");
                    Console.WriteLine(question);
                }
                {
                    Console.WriteLine("enter message");
                    string s = Console.ReadLine();

                    byte[] bytes = ASCIIEncoding.GetEncoding(1251).
                        GetBytes(s);
                    socketServer.Send(bytes);
                }
            }

            socketServer.Close();
        }
    }
}
