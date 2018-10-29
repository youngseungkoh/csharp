using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandExam
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        // INotifyPropertyChanged 인터페이스라면 해야할 일
        public event PropertyChangedEventHandler PropertyChanged;

        // Emp 클래스 자료형 변수 _SelectedEmp 선언
        public Emp _SelectedEmp;

        // _SelectedEmp 의 getter와 setter
        public Emp SelectedEmp
        {
            get
            {
                return _SelectedEmp;
            }
            set
            {
                _SelectedEmp = value;
                OnPropertyChanged("SelectedEmp");
            }
        }
        
        protected virtual void OnPropertyChanged([CallerMemberName] string Pname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Pname));
        }

        // RelayCommand 클래스 자료형 선언
        public RelayCommand AddEmpCommand { get; set; }

        // Emp 자료형 배열 ObservableCollection 선언
        public ObservableCollection<Emp> Emps { get; set; }
        
        public MainWindowViewModel()
        {
            Emps = new ObservableCollection<Emp>();

            Emps.Add(new Emp { Ename = "홍길동", Job = "Saleman" });
            Emps.Add(new Emp { Ename = "김길동", Job = "Saleman" });
            Emps.Add(new Emp { Ename = "정길동", Job = "Saleman" });
            Emps.Add(new Emp { Ename = "박길동", Job = "Saleman" });
            Emps.Add(new Emp { Ename = "성길동", Job = "Saleman" });

            AddEmpCommand = new RelayCommand(AddEmp);

        }

        public void AddEmp(object param)
        {
            Emps.Add(new Emp { Ename = param.ToString()});
        }
    }
}
