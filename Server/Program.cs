using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
namespace Server
{
    class Program
    {
        private static byte[] result = new byte[1024];
        static Socket serverSocket;
        static void Main(string[] args)
        {
            //This server IP(Default = 127.0.0.1[LOCAL])
            IPAddress server_ip = IPAddress.Parse("127.0.0.1");
            //This server PORT(Recommend: Using ports that the system is not using)
            int port = 8007;
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                serverSocket.Bind(new IPEndPoint(server_ip, port));
                serverSocket.Listen(10);
            }
            catch 
            {
                return;
            }

            while (true)
            {
                Socket clientSocket = serverSocket.Accept();
                Thread receive_thread = new Thread(ReceiveMessage);
                receive_thread.Start(clientSocket);
            }
            //RUN IN BACKGROUND CASE YOUR PROGRAM CONTAINS USER INTERFACE
            /*Thread server_thread = new Thread(ListenClientConnect);
            server_thread.IsBackground = true;
            server_thread.Start();*/
        }
        /*static void ListenClientConnect()
          {
               while (true)
              {
                  Socket clientSocket = serverSocket.Accept();
                  Thread receive_thread = new Thread(ReceiveMessage);
                  receive_thread.Start(clientSocket);
              }

          }*/
        static void ReceiveMessage(object clientSocket)
        {
            Socket client_socket = (Socket)clientSocket;
            while (true)
            {
                try
                {
                    int receiveNumber = client_socket.Receive(result);
                    //msg = The message recived by client;
                    string msg = Encoding.ASCII.GetString(result, 0, receiveNumber);
                    /*this.Dispatcher.Invoke(() => {
                         Execute Functions in Form or WPF Page. Example: Button Click, Void, etc...       
                    });*/
                }
                catch
                {
                    break;
                }
            }
        }
    }
}
