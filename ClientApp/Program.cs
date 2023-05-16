using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace ClientApp
{
    class Program
    {
        const string KEYWORD = "stop";
        static void Main(string[] args)
        {
            Console.Title = "Client";
            Console.ReadLine();
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 851);
            TcpClient client = new TcpClient();
            client.Connect(endPoint);
            Console.WriteLine("connected..");
            NetworkStream ns = client.GetStream();
            BinaryWriter writer = new BinaryWriter(ns);
            BinaryReader reader = new BinaryReader(ns);
            do
            {
                string valueFromServer = reader.ReadString();
                Console.WriteLine(valueFromServer);
                if (valueFromServer == KEYWORD)
                {
                    break;
                }
                string msg = Console.ReadLine();
                writer.Write(msg);

            } while (true);
            reader.Close();
            client.Close();
            


        }
    }
}
