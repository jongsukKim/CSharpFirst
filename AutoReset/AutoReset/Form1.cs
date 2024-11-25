using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoReset
{
    public partial class Form1 : Form
    {
        int a = 5;
        object lockObject = new object();

        AutoResetEvent autoResetEvent = new AutoResetEvent(true);

        Thread thread1 = null;
        Thread thread2 = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            thread1 = new Thread(new ThreadStart(WorkThread));
            thread1.IsBackground = true;
            thread1.Priority = ThreadPriority.Normal;
            thread1.Start();

            thread2 = new Thread(new ThreadStart(WorkThread2));
            thread2.IsBackground = true;
            thread2.Priority = ThreadPriority.Normal;
            thread2.Start();
        }

        private void WorkThread()
        {
            while (true)
            {
                //MessageBox.Show("신호 받기전");
                autoResetEvent.WaitOne();

                MessageBox.Show("신호 받은 후 출력!");
            }


        }

        private void WorkThread2()
        {
            while (true)
            {
                //MessageBox.Show("신호 주기전");

                Thread.Sleep(5000);
                autoResetEvent.Set();
                //MessageBox.Show("신호 준다");
            }
        }
    }
}
