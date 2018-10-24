using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Server02
{
    // 기동 클래스 선언
    class Server
    {
        // 기동 메서드 선언
        public static void Main()
        {
            NetworkStream stream = null;
            TcpListener tcpListener = null;
            Socket clientsocket = null;
            StreamReader reader = null;
            StreamWriter writer = null;
            try
            {
                IPAddress ipAd = IPAddress.Parse("127.0.0.1");

                tcpListener = new TcpListener(ipAd, 5001);
                tcpListener.Start();

                clientsocket = tcpListener.AcceptSocket();

                stream = new NetworkStream(clientsocket);
                Encoding encode = Encoding.GetEncoding("utf-8");

                reader = new StreamReader(stream, encode);
                writer = new StreamWriter(stream, encode) { AutoFlush = true };

                while (true)
                {
                    string str = reader.ReadLine();
                    Console.WriteLine(str);

                    writer.WriteLine(str);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally { clientsocket.Close(); }
            }
        }
    }
