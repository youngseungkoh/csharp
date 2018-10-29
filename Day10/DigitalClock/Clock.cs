using System;
using System.Windows;
using System.Windows.Threading;

namespace DigitalClock
{
    public class Clock : DependencyObject
    {
        public static DependencyProperty DateTimeProperty = 
            DependencyProperty.Register("DateTime", typeof(DateTime), typeof(Clock));

        public DateTime DateTime
        {
            set { SetValue(DateTimeProperty, value); }
            get { return (DateTime)GetValue(DateTimeProperty); }
        }

        public Clock()
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
