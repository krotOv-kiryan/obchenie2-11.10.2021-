using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace obchenie2
{
    class Program //аа всё страшно. потом как-нибудь может быть когда-нибудь всё же вохможно...,,,,доделаю 1
    {//Client
        static void Main(string[] args)
        {

            TcpClient client = new TcpClient("192.168.43.64", 6667);

            Thread thread = new Thread(Listen);

            thread.Start(client);
            var stream = client.GetStream();
            var bw = new BinaryWriter(stream);

            Console.WriteLine("Ник?");
            string nick = Console.ReadLine();

               while (true)
               {
                 string message = Console.ReadLine();

                 if (message == "exit")
                    break;

                   bw.Write(message);
               }
         
        }

        static void Listen(object p)
        {
            TcpClient client = (TcpClient)p;
            var stream = client.GetStream();
            using (var br = new BinaryReader(stream))
            {
                while (true)
                {
                   
                    string message = Console.ReadLine();

                    if (message == "exit")
                    break;

                    Console.WriteLine(br.ReadString());
                    
                }
            }
        }
    }
}
