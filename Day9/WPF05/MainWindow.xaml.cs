using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF05
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private BackgroundWorker myThread;
        int sum = 0;

        public MainWindow()
        {
            InitializeComponent();
        }



        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            myThread = new BackgroundWorker()
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };

            myThread.DoWork += myThread_DoWork;
            myThread.ProgressChanged += myThread_ProgressChanged;
            myThread.RunWorkerCompleted += myThread_RunWorkerCompleted;

            MessageBox.Show("Worker 초기화");
        }



        private void myThread_DoWork(object sender, DoWorkEventArgs e)
        {
            int count = (int)e.Argument;
            for(int i =1; i <= count; i++)
            {
                if (myThread.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                else
                {
                    Thread.Sleep(100);
                    this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate () { if (i % 2 == 0) { sum += i; e.Result = sum; lstNumber.Items.Add(i); } });
                    myThread.ReportProgress(i);
                }
            }
        }

        private void myThread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void myThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled) MessageBox.Show("작업 취소");
            else if (e.Error != null) MessageBox.Show("에러발생" + e.Error);
            else { tblkSum.Text = ((int)e.Result).ToString();
                MessageBox.Show("작업 완료");
            }
        }



        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            int num;
            if(!int.TryParse(txtNumber.Text,out num))
            {
                MessageBox.Show("숫자를 입력하세요");
                return;
            }

            progressBar.Maximum = num;
            lstNumber.Items.Clear();
            myThread.RunWorkerAsync(num);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            myThread.CancelAsync();
        }
    }
}
