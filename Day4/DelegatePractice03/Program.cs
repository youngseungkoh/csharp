using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatePractice03
{
    // 기동 클래스 선언
    class PrintString
    {
        // FileStream 타입 변수 fs 선언
        static FileStream fs;
        // StreamWriter 타입 변수 sw 선언
        static StreamWriter sw;

        // 델리게이트 선언
        public delegate void printString(string w);

        // sting 자료형 str을 파라메터로 받아 콘솔화면에 출력하는 메서드 선언
        public static void WriteToScreen(string str){
            Console.WriteLine("The String is: {0}", str);
        }

        // string 자료형 s를 파라메터로 받아 파일에 출력하는 메서드 선언
        public static void WriteToFile(string s){
            fs = new FileStream("c:\\message.txt", FileMode.Append, FileAccess.Write);
            sw = new StreamWriter(fs);
            sw.WriteLine(s);
            sw.Flush();
            sw.Close();
            fs.Close();
        }
        
        // 델리게이트 자료형 객체 ps를 파라메터로 받는 메서드 선언 
        public static void sendString(printString ps){
            ps("Hello Korea~");
        }

        // 기동 메서드 선언
        static void Main(string[] args)
        {
            // WriteToScreen 메서드를 파라메터로 받는 델리게이트 ps1를 인스턴스화
            printString ps1 = new printString(WriteToScreen);
          
            // WriteToFile 메서드를 파라메터로 받는 델리게이트 ps2를 인스턴스화
            printString ps2 = new printString(WriteToFile);

            // 인스턴스화 된 델리게이트 객체 ps1과 ps2를 파라메터로 하여 sendString 메서드 호출
            sendString(ps1);
            sendString(ps2);

            Console.ReadKey();
        }
    }
}
