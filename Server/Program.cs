using System;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
namespace Server
{
    class Program
    {
        const int port = 8007;
        const string server_ip = "127.0.0.1";
        public static IPAddress andress = IPAddress.Parse(server_ip);
        public static TcpListener serverSocket = new TcpListener(andress, port);
        static void Main(string[] args)
        {
            serverSocket.Start();
            //IF YOU WANT RUN THIS SERVER IN BACKGROUND, COMMENT THIS CODE IN LINE 18 EVEN LINE 29(Remove comment from line 31 until line 33)
            TcpClient client = serverSocket.AcceptTcpClient();
            while (true)
            {
                NetworkStream nwStream = client.GetStream();
                byte[] buffer = new byte[client.ReceiveBufferSize];

                int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);

                string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Console.WriteLine(dataReceived);
                nwStream.Write(buffer, 0, bytesRead);
            }
            //RUN IN BACKGROUND CASE YOUR PROGRAM CONTAINS USER INTERFACE
            //Thread server_thread = new Thread(Method);
            //server_thread.IsBackground = true;
            //server_thread.Start();
        }
        static void Method()
        {
            TcpClient cliente = serverSocket.AcceptTcpClient();
            ListenClientConnect(cliente);

        }
        static void ListenClientConnect(TcpClient client)
        {
            while (true)
            {
                NetworkStream nwStream = client.GetStream();
                byte[] buffer = new byte[client.ReceiveBufferSize];

                int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);

                string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Console.WriteLine(dataReceived);
                nwStream.Write(buffer, 0, bytesRead);
            }
          }
      }
    }

