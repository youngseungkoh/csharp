using System;
using System.Data.OleDb;

using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO01
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = @"Data Source=(DESCRIPTION =
              (ADDRESS = (PROTOCOL = TCP)(HOST =192.168.0.27)(PORT = 1521))
              (CONNECT_DATA =
                (SERVER = DEDICATED)
                (SERVICE_NAME = topcredu)
              )
            );User Id = scott; Password = tiger; Provider=OraOleDB.Oracle";

            // string str = "data source=topcredu;user id=scott; password=tiget";

            OleDbConnection Conn = new OleDbConnection(str);
            OleDbCommand Comm = new OleDbCommand();
            Comm.Connection = Conn;
            try
            {
                Conn.Open();
                Comm.CommandText = "SELECT ENAME FROM EMP";
                OleDbDataReader reader = Comm.ExecuteReader();
                while(reader.Read())
                {
                    Console.WriteLine(reader.GetString(reader.GetOrdinal("ENAME")));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally { Conn.Close(); }
        }
    }
}
