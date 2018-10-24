using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
//using System.Data.OleDb;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO05
{
    class Program
    {
        static void Main()
        {
            string str = "data source=topcredu; User id = scott; password=tiger";

            OracleConnection Conn = new OracleConnection(str);
            //OleDbConnection Conn = new OleDbConnection(str);
            Conn.Open();

            OracleDataAdapter adapter = new OracleDataAdapter("select * from emp", Conn);
            DataSet ds = new DataSet("myemp");
            adapter.Fill(ds, "사원");

            foreach(DataRow r in ds.Tables["사원"].Rows)
            {
                Console.WriteLine("Empno : {0}, Ename : {1}, Sal : {2}", r["empno"], r["ename"], r["sal"]);
            }

            ds.Tables["사원"].Rows[0]["ename"] = "홍길동";

            OracleCommandBuilder thisBuilder = new OracleCommandBuilder(adapter);

            adapter.Update(ds, "사원");

            Console.WriteLine();
            foreach(DataRow r in ds.Tables["사원"].Rows)
            {
                Console.WriteLine("Empno : {0}, Ename : {1}, Sal : {2}", r["empno"], r["ename"], r["sal"]);
            }

            DataRow row = ds.Tables["사원"].NewRow();
            row["empno"] = 8788;
            row["ename"] = "87길동";
            row["sal"] = 7777;

            ds.Tables["사원"].Rows.Add(row);

            adapter.Update(ds, "사원");

            adapter = new OracleDataAdapter("select * from emp", Conn);
            adapter.Fill(ds, "사원");

            Console.WriteLine();
            foreach(DataRow r in ds.Tables["사원"].Rows)
            {
                Console.WriteLine("Empno : {0}, Ename : {1}, Sal : {2}", r["enmpno"], r["ename"], r["sal"]);
            }
            Console.WriteLine(" 총 {0} 건 입니다.", ds.Tables["사원"].Rows.Count);
        }
    }
}
