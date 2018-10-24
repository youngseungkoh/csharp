using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace ChatServer
{
    // string 자료형 파라메터 s를 받는 델리게이트 SetTextCallback 선언
    delegate void SetTextCallback(string s);

    // Form 클래스를 상속하는 partial class Form1 선언
    public partial class Form1 : Form
    {
        // 서버의 IP와 포트 번호를 주고 TcpListener 인스턴스화
        TcpListener lit_Listener = new TcpListener(IPAddress.Parse("127.0.0.1"),5001);

        // 클라이언트의 소켓을 기록할 ArrayList 인스턴스화
        public static ArrayList socketArray = new ArrayList();

        // Form1 클래스 생성자 선언(InitializeComponent 메서드를 호출하여 Form1.Designer.cs의 모든 디자인적 요소들을 인스턴스화)
        public Form1()
        {
            InitializeComponent();
        }

        // string 자료형 파라메터 text를 받아 SetText 메서드 호출
        public void SetText(string text)
        {
            if (this.txt_Chat.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                // 파라메터로 받은 text를 인스턴스화 된 Form1 객체의 txt_Chat에 덧붙임
                this.txt_Chat.AppendText(text);
            }
        }

        // 서버 온/오프 버튼을 눌렀을 때의 기능을 담당하는 메서드 선언
        private void cmd_Start_Click(object sender, EventArgs e)
        {
            // lbl_Message의 Tag 속성이 Stop일 때(즉, 서버가 닫혀있는 상태일 떄) 누르면
            if(lbl_Message.Tag.ToString() == "Stop")
            {
                // 인스턴스화 된 tcpListener 기동 시작
                lit_Listener.Start();

                // ThreadStart 인스턴스화
                ThreadStart thStart = new ThreadStart(Wait_Socket);

                // Thread 인스턴스화
                Thread thd_WaitSocket = new Thread(thStart);

                // 인스턴스화 된 Thread 기동 시작
                thd_WaitSocket.Start();

                // lbl_Message의 Text 속성에 "Server opened now." 메세지를 부여해서 사용자에게 서버가 열렸음을 알림 
                lbl_Message.Text = "Server is opened now.";

                // lbl_Message의 Tag 속성에 문자열 "Start"를 할당하여 서버가 열려있는 상태를 기록
                lbl_Message.Tag = "Start";

                // cmd_start의 Text 속성에 "Close Server"를 할당하여 사용자가 서버를 닫기를 원할 때 누르도록 유도
                cmd_start.Text = "Close Server";
            }
            // lbl_Message의 Tag 속성이 Stop이 아닐 때(즉, 서버가 열려있는 상태일 때) 누르면
            else
            {
                // 인스턴스화 된 tcpListener 기동 종료
                lit_Listener.Stop();

                // 클라이언트의 소켓을 보관하는 배열 socketArray의 모든 소켓을 종료
                foreach(Socket socket in Form1.socketArray)
                {
                    socket.Close();
                }

                // 클라이언트의 소켓을 보관하는 배열 socketArray를 삭제
                Form1.socketArray.Clear();

                // lbl_Message의 Text 속성에 "Server is closed now." 메세지를 부여해서 사용자에게 서버가 닫혔음을 알림
                lbl_Message.Text = "Server is closed now.";

                // lbl_Message의 Tag 속성에 문자열 "Stop"을 할당하여 서버가 닫혀있는 상태를 기록
                lbl_Message.Tag = "Stop";

                // cmd_start의 Text 속성에 "Open Server"를 할당하여 사용자가 서버를 열기를 원할 때 누르도록 유도
                cmd_start.Text = "Open Server";
            }
        }

        // 클라이언트 소켓을 관리하기 위한 클래스 선언
        private void Wait_Socket()
        {
            // 소켓 선언
            Socket sktClient = null;
            while(true)
            {
                try
                {
                    // 인스턴스화 된 tcpListener의 AcceptSocket 메서드를 이용해 해당 클라이언트의 소켓에 할당
                    sktClient = lit_Listener.AcceptSocket();

                    // 채팅 기능을 구현한 클래스 Chat_Class를 인스턴스화
                    Chat_Class cht_Class = new Chat_Class();

                    // 인스턴스화 된 Chat_Class 클래스에서 채팅 기능 초기화를 구현한 메서드 Chat_Class_Setup을 호출 
                    cht_Class.Chat_Class_Setup(this, sktClient, this.txt_Chat);

                    // 인스턴스화 된 Chat_Class 클래스의 Chat_Process를 파라메터로 받아 ThreadStart 인스턴스화
                    ThreadStart ts = new ThreadStart(cht_Class.Chat_Process);

                    // Thread 인스턴스화
                    Thread thd_ChatProcess = new Thread(ts);

                    // 인스턴스화 된 Thread 기동
                    thd_ChatProcess.Start();
                }
                catch(System.Exception)
                {
                    // 예외가 발생할 경우 소켓을 보관하는 배열 socketArray에서 해당 클라이언트의 소켓을 삭제하고 반복문 종료
                    Form1.socketArray.Remove(sktClient); break;
                }
            }
        }

        // 폼이 닫힐 때 작동할 기능을 구현하기 위한 클래스 선언
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 어플리케이션 종료
            Application.Exit();

            // 인스턴스화 된 tcpListener 종료
            lit_Listener.Stop();
        }
    }

    // 채팅 기능을 구현한 Chat_Class 선언
    public class Chat_Class
    {
        // 인코더 선언
        private Encoding ecd_Encode = Encoding.GetEncoding("KS_C_5601-1987");

        // 채팅 내용을 담을 TextBox 선언
        private TextBox txt_Chat;

        // 클라이언트의 소켓을 나타낼 Socket 선언
        private Socket sktClient;

        // 클라이언트와의 데이터 교환을 위한 NetworkStream(데이터통로) 선언
        private NetworkStream netStream;

        // NetworkStream에서 데이터를 읽어올 StreamReader 선언
        private StreamReader strReader;

        // partial class Form1 선언
        private Form1 form1;


        // 채팅 기능을 초기화 할 메서드 선언
        public void Chat_Class_Setup(Form1 form1, Socket sktClient, System.Windows.Forms.TextBox txt_Chat)
        {
            this.txt_Chat = txt_Chat;
            this.sktClient = sktClient;
            this.netStream = new NetworkStream(sktClient);
            Form1.socketArray.Add(sktClient);
            this.strReader = new StreamReader(netStream, ecd_Encode);
            this.form1 = form1;
        }

        // 채팅 진행 시 사용될 기능을 담을 메서드 선언
        public void Chat_Process()
        {
            while(true)
            {
                try
                {
                    // string 자료형 lstMessage를 선언하고, StreamReader가 읽어온 데이터를 할당
                    string lstMessage = strReader.ReadLine();

                    // StreamReader가 읽어온 데이터가 null이 아니고 빈 문자열이 아닐 경우에 한하여
                    if(lstMessage != null && lstMessage !="")
                    {
                        // 읽어온 데이터를 form1 객체의 SetText에 삽입
                        form1.SetText(lstMessage + "\r\n");

                        // byte 자료형 배열을 선언하고 StreamReader가 읽어온 데이터의 Byte를 추출한 후 인코딩한 값을 할당
                        byte[] bytSand_Data = Encoding.Default.GetBytes(lstMessage + "\r\n");

                        // lock 문을 사용해 소켓을 보관하는 배열에 여러 클라이언트가 동시에 접근할 수 없게 함  
                        lock(Form1.socketArray)
                        {
                            // 인스턴스화 된 객체 Form1의 배열 socketArray의 모든 socket에 대해
                            foreach (Socket socket in Form1.socketArray)
                            {
                                // NetworkStream 인스턴스화
                                NetworkStream stream = new NetworkStream(socket);

                                // NetworkStream의 Write 메서드를 사용해서 StreamReader가 읽어온 데이터 를 출력
                                stream.Write(bytSand_Data, 0, bytSand_Data.Length);
                            }
                        }
                    }
                }
                catch (System.Exception e)
                {
                    // 에러가 발생하면 윈도우 창을 띄워 에러 메세지를 출력
                    // MessageBox.Show(e.ToString());
                    
                    // 클라이언트의 socket을 소켓 보관 배열에서 삭제
                    Form1.socketArray.Remove(sktClient);

                    // 반복문 종료
                    break;
                }
            }
        }
    }
}
