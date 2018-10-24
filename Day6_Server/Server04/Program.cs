using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Server04
{
    // ClientHandler 클래스 선언
    class ClientHandler
    {
        // NetworkStream 자료형 변수 n을 선언하고, 값을 null로 초기화 
        // (server와 client의 소켓을 연결하는 '통로'인 네트워크스트림을 만듦. 통로 이름은 n)
        NetworkStream n = null;

        // Socket 자료형 변수 s를 선언하고, 값을 null로 초기화
        // (통로가 연결되는 '문'인 소켓을 만듦. 문 이름은 s)
        Socket s = null;

        // StreamReader 자료형 변수 r를 선언하고, 값을 null로 초기화
        // (통로를 통해 클라이언트로부터 넘어오는 데이터를 읽는 서버측 '통역관'인 스트림리더를 만듦. 통역관 이름은 sr)
        StreamReader sr = null;

        // StreamWriter 자료형 변수 w를 선언하고, 값을 null로 초기화
        // (통로를 통해 클라이언트에게 데이터를 써서 보내는 '사신'인 스트림라이터를 만듦. 사신 이름은 w)
        StreamWriter w = null;
      
        // 소켓을 파라메터로 받는 생성자 선언
        public ClientHandler(Socket socket)
        {
            // 파라메터로 받은 Socket 자료형 socket을 이 클래스의 변수 d에 할당
            // (요청한 클라이언트에게 알려준 문 주소를 기록) 
            this.s = socket;

            // 파라메터로 받은 Socket 자료형 cSocket을 구동 클래스인 Server가 가지고 있는 Socket 자료형 제네릭 배열인 list에 추가
            // (요청한 클라이언트에게 알려준 문 주소를 받아서 혼선 방지를 위해 만들어둔 명단에 등록)
            Server.list.Add(socket);
        }

        // 클라이언트와 데이터를 주고받을 수 있게 하는 메서드 chat을 선언
        public void chat()
        {
            // 소켓 s을 파라메터로 받아 NetworkStream 클래스를 인스턴스화 하고, 변수 n에 할당
            // (클라이언트 측 문을 찾아 통로를 연결)
            n = new NetworkStream(s);

            // 클라이언트와 주고받는 데이터를 인코딩 할 수 있도록 Encoding 자료형 변수 e를 선언하고 초기화
            // (통역관 r이 클라이언트 측이 보내는 데이터를 이해할 수 있도록 번역기 e를 만듦)
            Encoding e = Encoding.GetEncoding("utf-8");

            // n과 e를 파라메터로 받아 StreamReader 클래스를 인스턴스화 하고, 변수 sr에 할당
            // (통역관 sr에게 번역기 e를 주고, 일할 통로 n이 어디인지 알려줌)
            sr = new StreamReader(n, e);

            // 포트에 연결된 모든 클라이언트 소켓에 대해 반복적으로 데이터를 주고받고 확인할 수 있도록 try catch 문 구현
            try
            {
                while(true)
                {
                    // string 자료형 변수 str을 선언하고 reader가 읽는 데이터를 할당
                    // (통역관 sr이 통역한 데이터를 서고 str에 저장)
                    string str = sr.ReadLine();

                    // 콘솔 화면에 변수 str이 참조하는 값을 출력
                    // (서고 str에 저장한 데이터를 서버측 콘솔에 출력)
                    Console.WriteLine(str);

                    // 서버 클래스 Server가 가지고 있는 배열 list 내부의 모든 Socket 자료형 변수 s에 대해 반복문 구동 (이 때 s는 각 클라이언트의 소켓)
                    // (명단에 적혀있는 모든 클라이언트들의 문 주소를 사용해서 같은 작업을 수행)
                    foreach(Socket s in Server.list)
                    {
                        // 소켓 s를 파라메터로 받아 NetworkStream 클래스를 인스턴스화 하고 변수 n에 할당
                        // (문 주소를 찾아 통로를 연결)
                        n = new NetworkStream(s);

                        // 변수 n과 e를 파라메터로 받아 StreamWriter 클래스를 인스턴스화 하고 변수 w에 할당
                        // (사신 w에게 번역기 e를 주고, 일할 통로 n이 어디인지 알려줌)
                        w = new StreamWriter(n, e) { AutoFlush = true }; // AutoFlush 값을 ture로 설정함으로써 이 stream 내의 버퍼를 매번 삭제함

                        // 변수 str을 파라메터로 받아 WriteLine 메서드를 호출
                        // (서고 str에 저장된 데이터를 사신 w에게 주고 다시 클라이언트에게 되돌려 보냄)
                        w.WriteLine(str);
                    }
                }
            }
            catch (Exception ex)
            {
                // 예외가 발생하면 발생한 예외를 문자열로 출력
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                // 접속이 끝나면 Server 자료형 객체가 가지고 있는 배열 list에서 이 클라이언트의 소켓 s를 삭제
                // (대화가 끝난 클라이언트에게 열렸던 문 주소 s는 모든 클라이언트들의 문 주소가 적힌 명단에서 삭제)
                Server.list.Remove(s);

                // 접속이 끝난 클라이언트의 소켓 s를 폐쇄
                // (대화가 끝난 클라이언트에게 열었던 문을 폐쇄)
                s.Close();

                // 접속이 끝난 클라이언트의 소켓 s에 null 값을 할당
                // (대화가 끝난 클라이언트에게 열었던 문 주소를 삭제)
                s = null;
            }
        }
    }
    
    // 구동 클래스 선언
    class Server
    {
        // List<Socket> 자료형 변수 list를 선언하고 인스턴스화
        // (여러 클라이언트와 동시에 교류할 때의 혼선 방지를 위해 문 주소를 기록해놓은 명단을 만듦)
        public static List<Socket> list = new List<Socket>();

        // 구동 메서드 선언
        static void Main(string[] args)
        {
            // TcpListener 자료형 변수 t를 선언하고 null로 초기화
            // (클라이언트 측 요청이 있는지 늘 예의주시하는 '경비대'인 TcpListener를 만듦. 경비대 이름은 t)
            TcpListener t = null;

            // Socket 자료형 변수 clSocket을 선언하고 null로 초기화
            // (문 주소를 기록할 저장소를 만듦)
            Socket clSocket = null;

            try
            {
                // IPaddress 자료형 ipAd를 선언하고 서버의 IP 주소를 파라메터로 받는 Parse 메서드를 호출하여 IP 주소 할당
                // (서버가 위치가 그려진 지도를 만듦)
                IPAddress ipAd = IPAddress.Parse("127.0.0.1");

                // 변수 ipAd, 포트번호 5001을 파라메터로 받는 클래스 TcpListener를 인스턴스화 하여 변수 t에 할당
                // (경비대 t에게 지도 ipAd를 주고, 경비를 서야 할 장소 5001을 알려줌)
                t = new TcpListener(ipAd, 5001);

                // Start 메서드를 이용하여 변수 t를 구동
                // (경비대 t가 활동을 시작하게 함)
                t.Start();

                while(true)
                {
                    // TcpListenr 자료형 변수 t 내의 AcceptSocket 메서드를 호출하고 변수 clSocket에 할당
                    // (경비대 t가 클라이언트 측 요청을 확인하면 그 클라이언트와 통하는 문 주소를 clSocket에 기록)
                    clSocket = t.AcceptSocket();

                    // clSocket을 파라메터로 받아 ClientHandler 클래스를 인스턴스화 (인스턴스화 된 객체명 : ch)
                    // (클라이언트를 담당할 부대(통역관, 사신)를 만들고, 부대가 담당할 클라이언트를 지정함. 부대 이름은 ch)
                    ClientHandler ch = new ClientHandler(clSocket);

                    // cHandler.chat을 파라메터로 받아 Threading namespace의 ThreadStart 클래스를 인스턴스화 (인스턴스화 된 객체명 : ts)
                    // (ch 부대가 활동을 시작하게 함)
                    ThreadStart ts = new ThreadStart(ch.chat);

                    // ts를 파라메터로 받아 Threading namespace의 Thread 클래스를 인스턴스화 (인스턴스화 된 객체명 : th)
                    // (ts 부대를 인솔할 장군을 만들고 부대를 넘겨줌. 장군 이름은 th)
                    Thread th = new Thread(ts);

                    // Start 메서드를 사용하여 스레드 th 가동
                    // (th 장군이 활동을 시작하게 함)
                    th.Start();
                }
            }
            catch (Exception ex)
            {
                // 예외가 발생할 경우 에러를 출력
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                // 접속이 끝난 클라이언트의 소켓 clSocket을 폐쇄
                // (대화가 끝난 클라이언트에게 열었던 문을 폐쇄)
                clSocket.Close();
            }
        }
    }
}
