using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        public static string[] arguments = Environment.GetCommandLineArgs();
        private static Socket clientSocket;

        private static void Main(string[] args)
        {
            //IP TO CONNECT
            IPAddress address = IPAddress.Parse("127.0.0.1");
            //PORT TO CONNECT
            int port = 8007;
            Program.clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                Program.clientSocket.Connect((EndPoint)new IPEndPoint(address, port));
            }
            catch
            {
                return;
            }
            while (0 == 0)
            {
                string msg = Console.ReadLine();
                if (msg != null)
                    send(msg);
            }
            /*After connect to server, you send message to server using: send("DATA TO SEND");*/
        }

        static async void send(string SendThis)
        {

            clientSocket.Send(Encoding.ASCII.GetBytes(SendThis));
            /*TO AUTO-SENT OF THE FIRST ARGUMENT
             * clientSocket.Send(Encoding.ASCII.GetBytes(Program.arguments[1]));*/
            await Task.Delay(100);
        }
    }
}
