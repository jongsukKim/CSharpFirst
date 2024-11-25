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

namespace SyncAndAsync
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        delegate void MySettingDelegate(string str);

        private void Form1_Load(object sender, EventArgs e)
        {
            string testString = "tests";

            //AsyncCallback
            //비동기 작업이 다 끝나고 나서 실행할 함수지정. 실행.
            AsyncCallback asyncCallback = new AsyncCallback(Complete);

            //비동기
            MySettingDelegate mySettingDelegate = MySetting;
            //mySettingDelegate.BeginInvoke("test", null, null);
            //mySettingDelegate.BeginInvoke("test", asyncCallback, "aaaaaaaa");//비동기
            IAsyncResult asyncResult = mySettingDelegate.BeginInvoke("test", asyncCallback, "aaaaaaaa");//비동기

            bool isSuccess = asyncResult.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(3));


            MessageBox.Show($"{isSuccess}");

            label1.Text = testString;
        }

        private void Complete(IAsyncResult asyncStatus)
        {
            //socket 객체도 사용 가능.

            string resultString = (string)(asyncStatus).AsyncState;

            MessageBox.Show(resultString);
        }

        private void MySetting(string str) 
        {

            

            //오래걸리는 함수가 다 끝나면
            Thread.Sleep(5000);

            for (int i = 0; i < 100; i++)
            {
                str += "@";
            }

            this.BeginInvoke((Action)(() =>
            {
                label1.Text = str;
            }));
        }
    }
}
