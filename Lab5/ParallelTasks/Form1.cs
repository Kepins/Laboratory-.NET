using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ParallelTasks
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_tasks_Click(object sender, EventArgs e)
        {
            int N;
            int K;
            try
            {
                var NK = getNK();
                N = NK.Item1;
                K = NK.Item2;
            }catch (Exception)
            {
                return;
            }
            Task<int> numeratorTask = Task.Factory.StartNew(
                (obj) => BinominalTheorem.CalcNumerator(N, K),
                100
                );
            Task<int> denominatorTask = Task.Factory.StartNew(
                (obj) => BinominalTheorem.CalcDenominator(N, K),
                100
                );
            numeratorTask.Wait();
            denominatorTask.Wait();
            int binominalTheoremResult = numeratorTask.Result / denominatorTask.Result;

            tbx_tasksResult.Text = binominalTheoremResult.ToString();
        }

        private void btn_delegates_Click(object sender, EventArgs e)
        {
            int N;
            int K;
            try
            {
                var NK = getNK();
                N = NK.Item1;
                K = NK.Item2;
            }
            catch (Exception)
            {
                return;
            }

            Func<int,int,int> numeratorFunc = BinominalTheorem.CalcNumerator;
            Func<int,int,int> denominatorFunc = BinominalTheorem.CalcDenominator;

            IAsyncResult numeratorResult = numeratorFunc.BeginInvoke(N, K,null,null);
            IAsyncResult denominatorResult = denominatorFunc.BeginInvoke(N, K, null, null);
            while(!numeratorResult.IsCompleted && !denominatorResult.IsCompleted)
            {
            }
            int binominalTheoremResult = numeratorFunc.EndInvoke(numeratorResult) 
                / denominatorFunc.EndInvoke(denominatorResult);

            tbx_delegatesResult.Text = binominalTheoremResult.ToString();
        }

        private async void btn_asyncAwait_Click(object sender, EventArgs e)
        {
            int N;
            int K;
            try
            {
                var NK = getNK();
                N = NK.Item1;
                K = NK.Item2;
            }
            catch (Exception)
            {
                return;
            }
            var numeratorTask = BinominalTheorem.CalcNumeratorAsync(N, K);
            var denominatorTask = BinominalTheorem.CalcDenominatorAsync(N, K);

            int numerator = await numeratorTask;
            int denominator = await denominatorTask;

            int binominalTheoremResult = numerator / denominator;

            tbx_asyncAwaitResult.Text = binominalTheoremResult.ToString();
        }

        private (int, int) getNK() 
        {
            int N;
            int K;
            try
            {
                N = int.Parse(tbx_n.Text);
                K = int.Parse(tbx_k.Text);
                if (N <= 0 || K <= 0 || N < K)
                {
                    throw new Exception();
                }
                return (N, K);
            }
            catch (Exception)
            {
                MessageBox.Show("K or N is not a valid positive integer or N<K");
                throw new Exception();
            }
        }

        private void btn_fibGet_Click(object s, EventArgs e)
        {
            int i_tbx;
            try
            {
                i_tbx = int.Parse(tbx_fibI.Text);
                if(i_tbx < 1)
                {
                    throw new Exception();
                }
            }catch (Exception){
                MessageBox.Show("i is not a valid positive integer");
                return;
            }
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += ((object sender, DoWorkEventArgs args) => {
                BackgroundWorker worker = sender as BackgroundWorker;
                int i = (int)args.Argument; //Extract the argument
                ulong prev_result = 0;
                ulong result = 1;
                if (i == 1)
                {
                    worker.ReportProgress(100);
                    result = 0;
                }
                else if(i==2)
                {
                    prev_result = 0;
                    worker.ReportProgress(100);
                    result = 1;
                }
                //Perform long running process
                for (int t = 2; t < i; t++)
                {
                    ulong temp = result;
                    result = prev_result + result;
                    prev_result = temp;

                    int progress = t * 100 / i;
                    Thread.Sleep(20);
                    worker.ReportProgress(progress);
                }
                worker.ReportProgress(100);
                args.Result = result;
            });
            bw.ProgressChanged += ((object sender, ProgressChangedEventArgs args) => {
                //Update label in UI with progress
                
                pbar_fib.Value = args.ProgressPercentage;
            });
            bw.RunWorkerCompleted += ((object sender, RunWorkerCompletedEventArgs args) => {
                //Update the user interface
                tbx_fibResult.Text = args.Result.ToString();
                
            });
            bw.WorkerReportsProgress = true;
            bw.RunWorkerAsync(i_tbx);

        }

        private void btn_compress_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string path = folderBrowserDialog.SelectedPath;
                DirectoryInfo dir = new DirectoryInfo(path);
                Compressor.Compress(dir);
            }
        }

        private void btn_decompress_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string path = folderBrowserDialog.SelectedPath;
                DirectoryInfo dir = new DirectoryInfo(path);
                Compressor.Decompress(dir);
            }
        }

        public static readonly string[] hostNames = { "www.microsoft.com", "www.apple.com",
"www.google.com", "www.ibm.com", "cisco.netacad.net",
"www.oracle.com", "www.nokia.com", "www.hp.com", "www.dell.com",
"www.samsung.com", "www.toshiba.com", "www.siemens.com",
"www.amazon.com", "www.sony.com", "www.canon.com", "www.alcatel-lucent.com", "www.acer.com", "www.motorola.com" };

        private void btn_dnsResolve_Click(object sender, EventArgs e)
        {
            var resolved = ipFromHostNames.Resolve(hostNames);
            var strings = from r in resolved
                          select r.Key +" => " + r.Value.ToString();

            listBox_dns.Items.Clear();
            foreach (string str in strings) {
                listBox_dns.Items.Add(str);
            }
        }
    }
}
