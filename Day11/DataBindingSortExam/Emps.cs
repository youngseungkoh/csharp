using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBindingSortExam
{
    class Emps : ObservableCollection<Emp>
    {
        public Emps()
        {
            Add(new Emp() { Empno = 1, Ename = "김길동", Job = " Salesman" });
        }
    }
}
