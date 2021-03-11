using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

namespace WorkingWithNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri uri = new Uri("http://Sanay.co");
            Console.WriteLine(uri.Host);
            Console.WriteLine(uri.Scheme);
            Console.WriteLine(uri.LocalPath);
            Console.WriteLine(uri.Port);

            var builder = new UriBuilder();
            builder.Scheme = "HTTP";
            builder.Host = "Sanay.co";
            builder.Path = "/";

            var uri2 = builder.Uri;
            Console.WriteLine(uri2.AbsoluteUri);

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://Sanay.co");
            var response = (HttpWebResponse)httpWebRequest.GetResponse();
            var stream = response.GetResponseStream();
            var reader = new StreamReader(stream);
            var data = reader.ReadToEnd();
            Console.WriteLine(data);

            var hostName = Dns.GetHostName();
            Console.WriteLine(hostName);

            var host = Dns.GetHostEntry("Sanay.co");
            var addresses = host.AddressList;
            foreach (var item in addresses)
            {
                Console.WriteLine(item);
            }

            var ping = new Ping();
            var reply = ping.Send("192.168.120.220");

            if (reply.Status == IPStatus.Success)
            {
                Console.WriteLine(reply.Status + "===>" + reply.RoundtripTime);
            }
            else
            {
                Console.WriteLine(reply.Status);
            }
            string server = "sanay.co";
            int port = 80;
            string request = "Get / HTTP/1.1\r\nHost: " + server + "\r\nConnection: Close\r\n\r\n";
            var requestBytes = Encoding.ASCII.GetBytes(request);
            var bytesReceived = new byte[256];

            var hostEntry = Dns.GetHostEntry(server);
            var ipe = new IPEndPoint(hostEntry.AddressList[0], port);

            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(ipe);
            if (socket.Connected)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("Failed");
                return;
            }

            socket.Send(requestBytes);

            int bytes = 0;
            var sb = new StringBuilder();
            do
            {
                bytes = socket.Receive(bytesReceived, bytesReceived.Length, 0);
                sb.Append(Encoding.ASCII.GetString(bytesReceived));
            } while (bytes > 0);

            Console.WriteLine(sb.ToString());


            HttpClient client = new HttpClient();
            var res = client.GetAsync("http://sanay.co");
            Console.WriteLine(res.Result.Content.ReadAsStringAsync().Result);


        }
    }
}
