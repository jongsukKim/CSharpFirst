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

namespace MultiThread
{
    public partial class Form1 : Form
    {
        Thread thread = null;
        Thread thread2 = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            thread = new Thread(new ThreadStart(WorkThread));
            thread.IsBackground = true;
            thread.Priority = ThreadPriority.Normal;
            thread.Start();

            thread2 = new Thread(new ThreadStart(WorkThread2));
            thread2.IsBackground = true;
            thread2.Priority = ThreadPriority.Normal;
            thread2.Start();

            Form2 form2 = new Form2();
            form2.Show();

            Thread.Sleep(5000);
            //Thread.Sleep(5000);
            //MessageBox.Show("aaatest");
        }

        /// <summary>
        /// thread가 사용할 함수
        /// </summary>
        private void WorkThread()
        {
            Thread.Sleep(2000);
            MessageBox.Show("bbbtest");
        }

        private void WorkThread2()
        {
            Thread.Sleep(5000);
            MessageBox.Show("aaatest");
        }
    }
}
