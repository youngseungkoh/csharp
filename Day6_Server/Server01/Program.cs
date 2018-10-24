using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Server01
{
    // 서버 클래스 선언
    class Server
    {
        static void Main(string[] args)
        {
            NetworkStream stream = null;
            TcpListener tcpListener = null;
            Socket clientsocket = null;
            StreamReader reader = null;

            try
            {
                IPAddress ipAd = IPAddress.Parse("127.0.0.1");

                tcpListener = new TcpListener(ipAd, 5001);

                // 서버 소켓 생성
                tcpListener.Start();

                // 이 위치에 while(true) 로 무한루프

                // clientsocket을 대기 시켜놓음
                clientsocket = tcpListener.AcceptSocket();

                stream = new NetworkStream(clientsocket);
                Encoding encode = Encoding.GetEncoding("utf-8");

                reader = new StreamReader(stream, encode);

                while (true)
                {
                    string str = reader.ReadLine();
                    Console.WriteLine(str);
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