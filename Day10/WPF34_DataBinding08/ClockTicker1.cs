using System;
using System.Windows;
using System.Windows.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalClock
{
    public class ClockTicker1 : DependencyObject
    {
        public static DependencyProperty DateTimeProperty = DependencyProperty.Register("DateTime", typeof(DateTime), typeof(ClockTicker1));

        public DateTime DateTime
        {
            set { SetValue(DateTimeProperty, value); }
            get { return (DateTime)GetValue(DateTimeProperty); }
        }

        public ClockTicker1()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += TimerOnTick;
            timer.Interval = TimeSpan.FromSeconds(0.1);
            timer.Start();
        }

        void TimerOnTick(object sender, EventArgs args)
        {
            DateTime = DateTime.Now;
        }
    }
}
