using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TimerWindowService
{
    public partial class TimerSrv : ServiceBase
    {
        private WriteToFile file;
        private Timer timer;
        public TimerSrv()
        {
            file = new WriteToFile();
            timer  = new Timer();
            InitializeComponent();
        }

        private void OnTimeElapsed(object source, ElapsedEventArgs e)
        {
           file.Write("Time elapased!");
        }

        protected override void OnStart(string[] args)
        {
            file.Write("Service Started");
            timer.Elapsed += new ElapsedEventHandler(OnTimeElapsed);
            //ad 2: set interval to 1 minute (= 60,000 milliseconds)

            timer.Interval = 60000;

            //ad 3: enabling the timer
            timer.Enabled = true;
        }

        protected override void OnStop()
        {
            timer.Enabled = false;
            file.Write("Service Stoped");
        }
    }
}
