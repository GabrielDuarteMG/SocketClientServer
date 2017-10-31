using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        //Get arguments before send to server
        public static string[] arguments = Environment.GetCommandLineArgs();
        //Declare Socket client
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
                //Connect server
                Program.clientSocket.Connect((EndPoint)new IPEndPoint(address, port));
            }
            catch
            {
                //If Don't connect to server, this program return and close.
                return;
            }
            //Loop Send Message
            while (true)
            {
                string msg = Console.ReadLine();
                if (msg != null)
                    send(msg);
            }
            /*After connect to server, you send message to server using: send("DATA TO SEND");*/
        }

        static async void send(string SendThis)
        {
            //Client send the message if connection is stable
            clientSocket.Send(Encoding.ASCII.GetBytes(SendThis));
            /*TO AUTO-SENT OF THE FIRST ARGUMENT
             * clientSocket.Send(Encoding.ASCII.GetBytes(Program.arguments[1]));*/
            //Delay to bytes return and the program don't crash
            await Task.Delay(100);
        }
    }
}
