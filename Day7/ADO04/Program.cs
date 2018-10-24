using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Threading.Tasks;

// p298 Adapter를 사용하지 않고 DB 다루는 예제
namespace ADO04
{
    class Program
    {
        static OleDbConnection cn;

        public static void Main()
        {
            OleCn();
            Openning();

            Console.WriteLine("The Original Table");

            Output();

            Console.WriteLine("Added Table");
            Adding();
            Output();

            Console.WriteLine("Modified Table");
            Modifying();
            Output();

            Console.WriteLine("Deleted Table");
            Deleting();
            Output();

            Closing();
        }
















        // 주소를 입력해서 Connect를 만듦 (데이터베이스에 연결)
        public static void OleCn()
        {
            string OleCnString = "Provider = ORAOLEDB.ORACLE; data source = topcredu; User ID = scott; Password = tiger";
            cn = new OleDbConnection(OleCnString);
        }

        // 데이터베이스를 엶
        public static void Openning() { cn.Open(); }










        public static void Output()
        {
            string sql = "SELECT empno id, ename name FROM emp";

            // 커맨드를 선언함
            OleDbCommand cmd;

            // 데이터 리더를 선언함
            OleDbDataReader dr;

            // 커맨드를 인스턴스화 함 (커맨드에 명령할 내용(sqㅣ)과 커넥트(cn)를 줌)
            cmd = new OleDbCommand(sql, cn);

            // 데이터 리더 dr을 인스턴스화 함
            dr = cmd.ExecuteReader();

            Console.Write("\n");

            // 데이터 리더 dr이 데이터를 읽게 함
            while(dr.Read())
            {
                // dr이 읽은 데이터 중 첫번쨰 요소와 두번째 요소를 string 자료형으로 바꾸고 빈 칸이 생기면 잘라서 콘솔에 띄움
                Console.WriteLine("{0,-10}\t{1,-10}", dr[0].ToString().Trim(), dr[1].ToString().Trim());
            }
            Console.Write("\n");

            // 데이터 리더 dr을 닫음
            dr.Close();
        }










        public static void Adding()
        {
            try
            {
                string sqladd = "INSERT INTO emp (empno,ename) VALUES (3335,'YOUNGSEUNG')";
                OleDbCommand cmdAdd = new OleDbCommand(sqladd, cn);

                int rowsadded = cmdAdd.ExecuteNonQuery();
                Console.WriteLine("Number of rows added: " + rowsadded);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }









        public static void Modifying()
        {
            try
            {
                string sqlmodify = "UPDATE emp SET ename = '고영승' WHERE empno = 3335";
                OleDbCommand cmdupdate = new OleDbCommand(sqlmodify, cn);
                int rows = cmdupdate.ExecuteNonQuery();
                Console.WriteLine("Number of rows modified: " + rows);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static void Deleting()
        {
            try
            {
                string sqldelete = "DELETE FROM emp WHERE empno = 3335";
                OleDbCommand cmddelete = new OleDbCommand(sqldelete, cn);
                int rows = cmddelete.ExecuteNonQuery();
                Console.WriteLine("Number of rows deleted: " + rows);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static void Closing()
        {
            cn.Close();
        }
    }
}
