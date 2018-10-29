﻿using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfOracleTest
{
    public class EmpViewModel
    {
        int empno = 0;
        string ename = string.Empty;
        string job = string.Empty;

        public int Empno
        {
            get { return empno; }
            set { this.empno = value; }
        }

        public string Ename
        {
            get { return ename; }
            set { this.ename = value; }
        }

        public string Job
        {
            get { return job; }
            set { this.job = value; }
        }
    }
}
