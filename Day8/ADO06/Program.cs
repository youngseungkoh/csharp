using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO06
{
    class Program
    {
        static void Main()
        {
            OracleConnection thisConnection = new OracleConnection(@"data source=topcredu; User id = scott; password = tiger");

            thisConnection.Open();

            
        }
    }
}
