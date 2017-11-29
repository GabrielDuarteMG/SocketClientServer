using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;

namespace ConsoleApp1
{
    internal class Program
    {
        //Get arguments before send to server
        public static string[] arguments = Environment.GetCommandLineArgs();
        static TcpClient Client = new TcpClient();
       static IPAddress address = IPAddress.Parse("127.0.0.1");
        static int port = 8007;
        private  static void Main(string[] args)
        {
            Client.Connect(address, port);
            while (true)
            {
                Stream stream;
                string msg = Console.ReadLine();
                byte[] buffer = Encoding.ASCII.GetBytes(msg);
                stream = Client.GetStream();
                byte[] by = Encoding.UTF8.GetBytes(msg.ToCharArray(), 0, msg.Length);
                stream.Write(by, 0, by.Length);
                stream.Flush();
            }
        }
    }
}
