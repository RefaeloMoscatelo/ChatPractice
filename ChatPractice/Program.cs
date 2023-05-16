using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ChatPractice
{
    class Program
    {
        const string KEYWORD = "stop";
        static void Main(string[] args)
        {
           
            Console.Title = "Server";
            Console.ReadLine();
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 851);
            TcpListener server = new TcpListener(endPoint);
            server.Start();
            Console.WriteLine("server up...");

            TcpClient connectClient = server.AcceptTcpClient();
            Console.WriteLine("client connected, send message...");

            NetworkStream ns = connectClient.GetStream();
            BinaryWriter writer = new BinaryWriter(ns);
            BinaryReader reader = new BinaryReader(ns);
            do
            {
                string msg = Console.ReadLine();
                writer.Write(msg);
                if (msg==KEYWORD)
                {
                    break;
                }
                string msgFromClient = reader.ReadString();
                Console.WriteLine("Client: {0}",msgFromClient);

            } while (true);
            writer.Close();
            connectClient.Close();
            server.Stop();

        }
    }
}
