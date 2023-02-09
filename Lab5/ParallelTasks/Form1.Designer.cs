
namespace ParallelTasks
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbx_k = new System.Windows.Forms.TextBox();
            this.tbx_n = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_tasks = new System.Windows.Forms.Button();
            this.btn_delegates = new System.Windows.Forms.Button();
            this.btn_asyncAwait = new System.Windows.Forms.Button();
            this.tbx_tasksResult = new System.Windows.Forms.TextBox();
            this.tbx_delegatesResult = new System.Windows.Forms.TextBox();
            this.tbx_asyncAwaitResult = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_fibGet = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbx_fibI = new System.Windows.Forms.TextBox();
            this.tbx_fibResult = new System.Windows.Forms.TextBox();
            this.pbar_fib = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_compress = new System.Windows.Forms.Button();
            this.btn_decompress = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_dnsResolve = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.listBox_dns = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // tbx_k
            // 
            this.tbx_k.Location = new System.Drawing.Point(101, 91);
            this.tbx_k.Name = "tbx_k";
            this.tbx_k.Size = new System.Drawing.Size(100, 20);
            this.tbx_k.TabIndex = 0;
            // 
            // tbx_n
            // 
            this.tbx_n.Location = new System.Drawing.Point(101, 65);
            this.tbx_n.Name = "tbx_n";
            this.tbx_n.Size = new System.Drawing.Size(100, 20);
            this.tbx_n.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "K";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "N";
            // 
            // btn_tasks
            // 
            this.btn_tasks.Location = new System.Drawing.Point(244, 50);
            this.btn_tasks.Name = "btn_tasks";
            this.btn_tasks.Size = new System.Drawing.Size(75, 23);
            this.btn_tasks.TabIndex = 4;
            this.btn_tasks.Text = "Tasks";
            this.btn_tasks.UseVisualStyleBackColor = true;
            this.btn_tasks.Click += new System.EventHandler(this.btn_tasks_Click);
            // 
            // btn_delegates
            // 
            this.btn_delegates.Location = new System.Drawing.Point(244, 72);
            this.btn_delegates.Name = "btn_delegates";
            this.btn_delegates.Size = new System.Drawing.Size(75, 23);
            this.btn_delegates.TabIndex = 5;
            this.btn_delegates.Text = "Delegates";
            this.btn_delegates.UseVisualStyleBackColor = true;
            this.btn_delegates.Click += new System.EventHandler(this.btn_delegates_Click);
            // 
            // btn_asyncAwait
            // 
            this.btn_asyncAwait.Location = new System.Drawing.Point(244, 94);
            this.btn_asyncAwait.Name = "btn_asyncAwait";
            this.btn_asyncAwait.Size = new System.Drawing.Size(75, 23);
            this.btn_asyncAwait.TabIndex = 6;
            this.btn_asyncAwait.Text = "Async/Await";
            this.btn_asyncAwait.UseVisualStyleBackColor = true;
            this.btn_asyncAwait.Click += new System.EventHandler(this.btn_asyncAwait_Click);
            // 
            // tbx_tasksResult
            // 
            this.tbx_tasksResult.Location = new System.Drawing.Point(325, 52);
            this.tbx_tasksResult.Name = "tbx_tasksResult";
            this.tbx_tasksResult.ReadOnly = true;
            this.tbx_tasksResult.Size = new System.Drawing.Size(100, 20);
            this.tbx_tasksResult.TabIndex = 7;
            // 
            // tbx_delegatesResult
            // 
            this.tbx_delegatesResult.Location = new System.Drawing.Point(325, 73);
            this.tbx_delegatesResult.Name = "tbx_delegatesResult";
            this.tbx_delegatesResult.ReadOnly = true;
            this.tbx_delegatesResult.Size = new System.Drawing.Size(100, 20);
            this.tbx_delegatesResult.TabIndex = 8;
            // 
            // tbx_asyncAwaitResult
            // 
            this.tbx_asyncAwaitResult.Location = new System.Drawing.Point(325, 94);
            this.tbx_asyncAwaitResult.Name = "tbx_asyncAwaitResult";
            this.tbx_asyncAwaitResult.ReadOnly = true;
            this.tbx_asyncAwaitResult.Size = new System.Drawing.Size(100, 20);
            this.tbx_asyncAwaitResult.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Fibonacci";
            // 
            // btn_fibGet
            // 
            this.btn_fibGet.Location = new System.Drawing.Point(78, 248);
            this.btn_fibGet.Name = "btn_fibGet";
            this.btn_fibGet.Size = new System.Drawing.Size(61, 23);
            this.btn_fibGet.TabIndex = 11;
            this.btn_fibGet.Text = "GET";
            this.btn_fibGet.UseVisualStyleBackColor = true;
            this.btn_fibGet.Click += new System.EventHandler(this.btn_fibGet_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(78, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(9, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "i";
            // 
            // tbx_fibI
            // 
            this.tbx_fibI.Location = new System.Drawing.Point(94, 225);
            this.tbx_fibI.Name = "tbx_fibI";
            this.tbx_fibI.Size = new System.Drawing.Size(87, 20);
            this.tbx_fibI.TabIndex = 13;
            // 
            // tbx_fibResult
            // 
            this.tbx_fibResult.Location = new System.Drawing.Point(145, 250);
            this.tbx_fibResult.Name = "tbx_fibResult";
            this.tbx_fibResult.ReadOnly = true;
            this.tbx_fibResult.Size = new System.Drawing.Size(100, 20);
            this.tbx_fibResult.TabIndex = 14;
            // 
            // pbar_fib
            // 
            this.pbar_fib.Location = new System.Drawing.Point(81, 286);
            this.pbar_fib.Name = "pbar_fib";
            this.pbar_fib.Size = new System.Drawing.Size(164, 14);
            this.pbar_fib.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(322, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Kompresja";
            // 
            // btn_compress
            // 
            this.btn_compress.Location = new System.Drawing.Point(325, 248);
            this.btn_compress.Name = "btn_compress";
            this.btn_compress.Size = new System.Drawing.Size(75, 23);
            this.btn_compress.TabIndex = 17;
            this.btn_compress.Text = "Compress";
            this.btn_compress.UseVisualStyleBackColor = true;
            this.btn_compress.Click += new System.EventHandler(this.btn_compress_Click);
            // 
            // btn_decompress
            // 
            this.btn_decompress.Location = new System.Drawing.Point(409, 247);
            this.btn_decompress.Name = "btn_decompress";
            this.btn_decompress.Size = new System.Drawing.Size(75, 23);
            this.btn_decompress.TabIndex = 18;
            this.btn_decompress.Text = "Decompress";
            this.btn_decompress.UseVisualStyleBackColor = true;
            this.btn_decompress.Click += new System.EventHandler(this.btn_decompress_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(72, 342);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "DNS";
            // 
            // btn_dnsResolve
            // 
            this.btn_dnsResolve.Location = new System.Drawing.Point(117, 332);
            this.btn_dnsResolve.Name = "btn_dnsResolve";
            this.btn_dnsResolve.Size = new System.Drawing.Size(75, 23);
            this.btn_dnsResolve.TabIndex = 20;
            this.btn_dnsResolve.Text = "Resolve";
            this.btn_dnsResolve.UseVisualStyleBackColor = true;
            this.btn_dnsResolve.Click += new System.EventHandler(this.btn_dnsResolve_Click);
            // 
            // listBox_dns
            // 
            this.listBox_dns.FormattingEnabled = true;
            this.listBox_dns.Location = new System.Drawing.Point(81, 386);
            this.listBox_dns.Name = "listBox_dns";
            this.listBox_dns.Size = new System.Drawing.Size(403, 160);
            this.listBox_dns.TabIndex = 21;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 609);
            this.Controls.Add(this.listBox_dns);
            this.Controls.Add(this.btn_dnsResolve);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_decompress);
            this.Controls.Add(this.btn_compress);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pbar_fib);
            this.Controls.Add(this.tbx_fibResult);
            this.Controls.Add(this.tbx_fibI);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_fibGet);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbx_asyncAwaitResult);
            this.Controls.Add(this.tbx_delegatesResult);
            this.Controls.Add(this.tbx_tasksResult);
            this.Controls.Add(this.btn_asyncAwait);
            this.Controls.Add(this.btn_delegates);
            this.Controls.Add(this.btn_tasks);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbx_n);
            this.Controls.Add(this.tbx_k);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbx_k;
        private System.Windows.Forms.TextBox tbx_n;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_tasks;
        private System.Windows.Forms.Button btn_delegates;
        private System.Windows.Forms.Button btn_asyncAwait;
        private System.Windows.Forms.TextBox tbx_tasksResult;
        private System.Windows.Forms.TextBox tbx_delegatesResult;
        private System.Windows.Forms.TextBox tbx_asyncAwaitResult;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_fibGet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbx_fibI;
        private System.Windows.Forms.TextBox tbx_fibResult;
        private System.Windows.Forms.ProgressBar pbar_fib;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_compress;
        private System.Windows.Forms.Button btn_decompress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_dnsResolve;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ListBox listBox_dns;
    }
}

