using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace ChatClient
{
    // string 자료형 파라메터 s를 받는 SetTextCallback 델리게이트 선언
    delegate void SetTextCallback(string s);

    // Form 클래스를 상속하는 partial class Form1 선언
    public partial class Form1 : Form
    {
        // Form1 클래스 생성자 선언 (Form1.Designer.cs에 선언되어 디자인적 요소를 다루는 InitializeComponent 메서드를 호출)
        public Form1()
        {
            InitializeComponent();
        }




        // 클라이언트측 전송제어프로토콜인 TcpClient 자료형 객체 c 를 선언하고 값을 null로 초기화
        TcpClient c = null;

        // 서버와의 대화를 위한 통로인 NetworkStream을 선언하고 값을 null로 초기화
        NetworkStream ns = null;

        // Chat_Class를 선언하고 인스턴스화 (인스턴스화 된 객체명 : cc)
        Chat_Class cc = new Chat_Class();




        // 폼 이벤트 관련 메서드 ========================================================================================




        // 전송 내용 입력용 텍스트박스(이름 : txt_Msg_KeyPress)를 눌렀을 때 기동될 메서드 선언
        private void txt_Msg_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 엔터키를 누르면
            if (e.KeyChar == 13)
            {
                // conn.Text에 Logout이 입력되어 있으면 (즉, 로그인 상태이면)
                if (conn.Text == "Logout")
                {
                    // Message_Snd 메서드를 실행해서 txt_Msg.Text에 담긴 내용을 보냄
                    Message_Snd("<" + txt_Name.Text + ">" + txt_Msg.Text, true);
                }
                // 매번 보낼때마다 txt_Msg.Text에 담긴 내용을 지움 (빈 문자열로 만듦)
                txt_Msg.Text = "";

                // ???
                e.Handled = true;
            }
        }

        // 로그인/로그아웃 관리용 버튼(이름 : conn)을 눌렀을 때 기동될 메서드 선언
        private void cmd_Connect_Click(object sender, EventArgs e)
        {
            // 로그인/로그아웃 관리용 버튼의 Text 속성이 "Login"이면 (즉, 로그아웃 상태에서 이 버튼을 누르면)
            if(conn.Text == "Login")
            {
                try
                {
                    // IPAddress 자료형 변수 ipaAddress를 선언하고, 텍스트txt_Server_IP의 Text를 할당
                    IPAddress ip = IPAddress.Parse(txt_Server_IP.Text);

                    // TcpClient를 인스턴스화 해서 변수 tcpClient에 할당
                    c = new TcpClient();

                    // tcpClient에 서버의 ip주소와 포트 번호를 주고 서버에 연결
                    c.Connect(ip, 5001);

                    // 서버와 연결된 stream을 찾아 ns 변수에 할당
                    ns = c.GetStream();

                    // 채팅창, 채팅 기능, 종료 기능 생성을 위해 Chat_Class_Setup 메서드를 호출
                    cc.Chat_Class_Setup(this, ns, this.txt_Chat);

                    // Thread 자료형 변수 thd_Receive를 선언하고, ThreadStart 객체를 파라메터로 주어 인스턴스화
                    Thread th = new Thread(new ThreadStart(cc.Chat_Process));

                    // Thread(이름 : th) 기동
                    th.Start();

                    // Message_Snd 메서드 호출
                    Message_Snd("<" + txt_Name.Text + "> is in this chatting room.", true);

                    // (Login 이었던) 버튼의 Text 속성을 "Logout"으로 바꿔서 사용자에게 로그인 되었음을 알려줌
                    conn.Text = "Logout";
                }
                catch(System.Exception Err)
                {
                    // 에러가 발생하면 윈도우 메세지 창을 띄워서 에러 메세지를 보여줌 (콘솔에 보여주는 것 아님)
                    MessageBox.Show("Chatting Server Error has occured or the server has not started yet Or\n\n" + Err.Message, "Client");
                }
            }
            // 로그인/로그아웃 관리용 버튼의 Text 속성이 "Login"이 아니면 (즉, 로그인 상태에서 이 버튼을 누르면)
            else
            {
                // Message_Snd 메서드를 호출해서 사용자가 로그아웃 했다는 메세지를 서버에 보여줌
                Message_Snd("<" + txt_Name.Text + "> is not here anymore", false);

                // (Logout 이었던) 버튼의 Text 속성을 "Login"으로 바꿔서 사용자에게 로그아웃 되었음을 알려줌
                conn.Text = "Login";

                // Chat_Close 메서드를 호출하여 연결을 끊음
                cc.Chat_Close();

                // Close 메서드를 호출하여 네트워크 스트림을 닫음
                ns.Close();

                // Close 메서드를 호출하여 클라이언트를 닫음 (클라이언트의 존재를 없앰)
                c.Close();
            }
        }

        // 폼을 닫는 이벤트가 발생했을 때 기동될 메서드 선언
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 로그인/로그아웃 관리용 버튼의 Text 속성이 "Login"이면 (즉, 로그아웃 상태이면)
            if(conn.Text == "Login")
            {
                // 암것도 안함
                return;
            }
            
            // 로그인/로그아웃 관리용 버튼의 Text 속성이 "Login"이 아니면 (즉, 로그인 상태이면)
            // Message_Snd 메서드를 사용해서 서버에 클라이언트와의 연결이 끊어졌다는 메세지를 보냄
            Message_Snd("<" + txt_Name.Text + "> is not here anymore", false);

            // Chat_Close 메서드를 호출하여 연결을 끊음 <---------------------------------------------------------------------- !!
            cc.Chat_Close();

            // Close 메서드를 호출하여 네트워크 스트림을 닫음
            ns.Close();

            // Close 메서드를 호출하여 클라이언트를 닫음 (클라이언트의 존재를 없앰)
            c.Close();
        }

        


        // 그 외의 메서드 ==============================================================================================



        // streamReader가 읽은 string 자료형 변수 text를 파라메터로 하는 SetText 메서드를 선언
        public void SetText(string text)
        {
            // 만약 form1 클래스가 인스턴스화된 객체 내의 txt_Chat이 InvokeRequired의 상태라면 ------------------------------- ?
            if(this.txt_Chat.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            // 아니라면
            else
            {
                // 파라메터로 받은 변수 text를 txt_Chat에 덧붙임
                this.txt_Chat.AppendText(text);
            }
        }

        // string 자료형 변수 lstMessage, Boolean 자료형 변수 Msg를 파라메터로 받는 Message_Snd 메서드 선언
        private void Message_Snd(string lstMessage, Boolean Msg)
        {
            try
            {
                // string 자료형 변수 dataToSend를 선언하고, lstMesage를 할당했다가 지우고 한 줄 띄움 <----------------------- ?
                string dataToSend = lstMessage + "\r\n";

                // byte 자료형 배열 data를 선언하고, dataToSend를 파라메터로 받아 GetBytes 메서드를 호출해서 선언 ------------ ?
                byte[] data = Encoding.Default.GetBytes(dataToSend);

                // 배열 data, 0, 배열 data의 길이를 파라메터로 받아 ntwStream의 write 메서드를 호출
                // write 메서드의 파라메터 ==> byte 자료형 buffer, int 자료형 offset, int 자료형 size
                ns.Write(data, 0, data.Length);
            }
            catch(System.Exception Err)
            {
                // 메서드 Message_Snd 호출시 받은 파라메터 Msg가 true 이면 
                if (Msg == true)
                {
                    // 정해진 메세지를 출력하는 윈도우 창을 띄움
                    MessageBox.Show("Chatting Server Error has occured or the server has not started yet Or\n\n" + Err.Message, "Client");

                    // 로그인/로그아웃 관리용 버튼의 Text 속성을 "Login"으로 바꿈
                    conn.Text = "Login";

                    // Chat_Close 메서드를 호출하여 연결을 끊음
                    cc.Chat_Close();

                    // Close 메서드를 호출하여 네트워크 스트림을 닫음
                    ns.Close();

                    // Close 메서드를 호출하여 클라이언트를 닫음 (클라이언트의 존재를 없앰)
                    c.Close();
                }
            }
        }
    }

    // 채팅기능 셋업 및 안전한 종료 기능을 지원하는 Chat_Class 클래스 선언
    public class Chat_Class
    {
        // NetworkStream의 데이터를 한글로 인코딩 할 수 있도록 Encoding 자료형 변수 ecd_Encode를 선언하고, "KS_C_5601-1987"로 초기화
        private Encoding ecd_Encode = Encoding.GetEncoding("KS_C_5601-1987");

        // TextBox 자료형 변수 txt_Chat을 선언
        private TextBox txt_Chat;

        // NetworkStream 자료형 변수 netStream을 선언
        private NetworkStream netStream;

        // StreamReader 자료형 변수 strReader를 선언
        private StreamReader strReader;

        // Form1 클래스를 인스턴스화 한 객체를 담을 변수 form1을 선언
        private Form1 form1;

        
        // Form1 객체, NetworkStream 객체, TextBox 객체를 파라메터로 받아 채팅 박스를 초기화하는 Chat_Class_Setup 메서드를 선언
        public void Chat_Class_Setup(Form1 form1, NetworkStream netStream, TextBox txt_Chat)
        {
            this.txt_Chat = txt_Chat;
            this.netStream = netStream;
            this.strReader = new StreamReader(netStream, ecd_Encode);
            this.form1 = form1;
        }

        // 서버와 연결된 상태일 때 반복적으로 처리될 Chat_Process 메서드를 선언
        public void Chat_Process()
        {
            while (true)
            {
                try
                {
                    // strReader의 ReadLine메서드를 이용해 stream 상의 데이터를 읽은 후 string 자료형 변수 lstMessage에 할당
                    string lstMessage = strReader.ReadLine();

                    // 만약 lstMessage에 할당된 값이 null이 아니고 빈 문자열도 아니라면
                    if(lstMessage != null && lstMessage != "")
                    {
                        // lstMessage에 할당된 값과 두 번의 줄바꿈을 파라메터로 하여 객체 form1의 SetText 메서드를 호출
                        form1.SetText(lstMessage + "\n\n");
                    }
                }
                catch (Exception)
                {
                    // 예외가 발생하면 Chat_Process 메서드를 중단
                    break;
                }
            }
        }

        // NetworkStream과 StreamReader를 닫는 Chat_Close 메서드를 선언
        public void Chat_Close()
        {
            // 실행중인 NetworStream인 netStream을 닫음
            netStream.Close();
            // 실행중인 StreamReader인 strReader를 닫음
            strReader.Close();
        }
    }
}
