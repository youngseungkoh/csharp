using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Client04
{
    // ServerHandler 클래스 선언
    class ServerHandler
    {
        // stream을 통해 들어오는 데이터를 읽을 수 있도록 StreamReader 자료형 변수 cr을 선언하고 null로 초기화
        StreamReader cr = null;

        // 인스턴스화 시점에 StreamReader 자료형 변수 cr을 파라메터로 받도록 ServerHandler 클래스 생성자 선언
        public ServerHandler(StreamReader clReader)
        {
            // 전달받은 파라메터인 StreamReader 자료형 변수 clReader을 인스턴스화 된 ServerHandler 클래스 객체의 변수 cr에 할당
            this.cr = clReader;
        }

        // 서버가 보내는 데이터를 읽어들일 수 있도록 chat 메서드를 선언
        public void chat()
        {
            try
            {
                while(true)
                {
                    // StreamReader 자료형 객체 cr 내부의 ReadLine() 메서드를 이용해서 서버측 데이터를 읽음
                    Console.WriteLine(cr.ReadLine());
                }
            }
            catch(Exception e)
            {
                // 예외가 발생할 경우 콘솔 창에 출력
                Console.WriteLine(e.ToString());
            }
        }
    }
    
    // 구동 클래스 선언
    class Program
    {
        // 구동 메서드 선언
        static void Main(string[] args)
        {
            // TcpClient 자료형 변수 client를 선언하고 값을 null로 초기화
            TcpClient client = null;

            // client가 서버와 데이터를 주고받을 수 있도록 try catch문 구동
            try
            {
                // TcpClient 자료형 객체를 인스턴스화 하고 변수 client에 할당
                client = new TcpClient();

                // 서버의 ip주소와 포트번호 5001을 파라메터로 받는 client 객체 내의 Connect 메서드를 호출 (서버와 연결됨)
                client.Connect("127.0.0.1", 5001);

                // NetworkStream 자료형 변수 stream 을 선언하고, client 객체 내의 GetStream 메서드를 호출하여 할당 (서버와 대화할 수 있는 '통로' 확보)
                NetworkStream stream = client.GetStream();

                // Encoding 자료형 변수 encode를 선언하고, System.Text.Encoding namespace에 위치한 GetEncoding 메서드를 호출하여 인코딩 방식 할당
                Encoding encode = System.Text.Encoding.GetEncoding("utf-8");

                // StreamReader 자료형 변수 reader를 선언하고, stream과 encode를 파라메터로 받아 인스턴스화 한 StreamReader 클래스를 할당 
                // 클라이언트가 '통로'의 데이터를 인코딩하여 읽을 수 있게 됨
                StreamReader cr = new StreamReader(stream, encode);

                // StreamWriter 자료형 변수 writer를 선언하고, stream과 encode를 파라메터로 받아 인스턴스화 한 StreamWriter 클래스를 할당
                // 클라이언트가 '통로'에 인코딩한 데이터를 쓸 수 있게 되고, 매번 쓸 때마다 자동으로 버퍼가 삭제됨
                StreamWriter cw = new StreamWriter(stream, encode) { AutoFlush = true };

                // cr을 파라메터로 받아 ServerHandler 클래스를 인스턴스화 (인스턴스화 된 객체명 : sh)
                ServerHandler sh = new ServerHandler(cr);

                // serverHandler 내부의 chat 메서드를 파라메터로 받아 ThreadStart 클래스를 인스턴스화 (인스턴스화 된 객체명 : ts)
                ThreadStart ts = new ThreadStart(sh.chat);

                // ts 를 파라메터로 받아 Thread 클래스를 인스턴스화 (인스턴스화 된 객체명 : th)
                Thread th = new Thread(ts);

                // 스레드 객체 t 내부의 Start 메서드를 호출하여 t를 구동
                th.Start();

                // string 자료형 변수 dataToSend 를 선언하고 콘솔에서 입력한 내용(서버에 보낼 내용)을 받아 할당
                string dataToSend = Console.ReadLine();

                // 서버와 연결되어있는 동안 수행할 작업
                while(true)
                {
                    // dataToSend에 입력된 내용을 출력
                    cw.WriteLine(dataToSend);

                    // dataToSend에 입력된 내용이 <EOF> 이면 서버와의 연결 종료
                    if (dataToSend.IndexOf("<EOF>") > -1) break;

                    // dataToSend에 콘솔에서 입력한 내용을 할당
                    dataToSend = Console.ReadLine();
                }
            }
            catch (Exception e)
            {
                // 예외가 발생할 경우 ToString 메서드를 거쳐서 출력
                Console.WriteLine(e.ToString());
            }
            finally
            {
                // client 객체 내부의 Close 메서드를 호출해 client의 스트림 종료
                client.Close();

                // client 객체에 null 을 할당함으로써 client의 스트림 제거
                client = null;
            }
        }
    }
}
