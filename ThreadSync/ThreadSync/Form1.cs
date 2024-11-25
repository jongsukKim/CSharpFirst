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

namespace ThreadSync
{
    public partial class Form1 : Form
    {
        int a = 5;
        object lockObject = new object();

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
                lock (lockObject)
                {
                    a = 3;
                    MessageBox.Show($"{a}");
                }
            }
            
            
        }

        private void WorkThread2()
        {
            while (true) 
            {
                lock (lockObject)
                {
                    Thread.Sleep(3000);
                    a = 4;

                    MessageBox.Show($"{a}");
                }
            }
        }

    }
}
