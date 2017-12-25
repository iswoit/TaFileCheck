namespace TaFileCheck
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lbIsHqAllOK = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnHqExecute = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbHqLog = new System.Windows.Forms.TextBox();
            this.lvHqList = new TaFileCheck.DoubleBufferListView();
            this.No = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TaID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Desc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Source = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HqMove = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IsFileExists = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IsOK = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Remark = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnQsExecute = new System.Windows.Forms.Button();
            this.lvQsList = new TaFileCheck.DoubleBufferListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label5 = new System.Windows.Forms.Label();
            this.bwHq = new System.ComponentModel.BackgroundWorker();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.bwQs = new System.ComponentModel.BackgroundWorker();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(961, 436);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lbIsHqAllOK);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btnHqExecute);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.tbHqLog);
            this.tabPage1.Controls.Add(this.lvHqList);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(953, 410);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "TA行情文件检查";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lbIsHqAllOK
            // 
            this.lbIsHqAllOK.AutoSize = true;
            this.lbIsHqAllOK.Location = new System.Drawing.Point(914, 288);
            this.lbIsHqAllOK.Name = "lbIsHqAllOK";
            this.lbIsHqAllOK.Size = new System.Drawing.Size(23, 12);
            this.lbIsHqAllOK.TabIndex = 8;
            this.lbIsHqAllOK.Text = "N/A";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(801, 288);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "行情文件是否就绪:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 270);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "异常信息:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "TA列表:";
            // 
            // btnHqExecute
            // 
            this.btnHqExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHqExecute.Location = new System.Drawing.Point(874, 320);
            this.btnHqExecute.Name = "btnHqExecute";
            this.btnHqExecute.Size = new System.Drawing.Size(71, 23);
            this.btnHqExecute.TabIndex = 4;
            this.btnHqExecute.Text = "检查";
            this.btnHqExecute.UseVisualStyleBackColor = true;
            this.btnHqExecute.Click += new System.EventHandler(this.btnHqExecute_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 355);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 48);
            this.label1.TabIndex = 3;
            this.label1.Text = "步骤:\r\n1.将文件从子目录剪切到根目录（有些TA需要）\r\n2.检查文件（索引和07文件）\r\n3.文件拷贝（中登TA、多金需要）";
            // 
            // tbHqLog
            // 
            this.tbHqLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbHqLog.BackColor = System.Drawing.SystemColors.Window;
            this.tbHqLog.Location = new System.Drawing.Point(8, 285);
            this.tbHqLog.Multiline = true;
            this.tbHqLog.Name = "tbHqLog";
            this.tbHqLog.ReadOnly = true;
            this.tbHqLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbHqLog.Size = new System.Drawing.Size(766, 58);
            this.tbHqLog.TabIndex = 2;
            // 
            // lvHqList
            // 
            this.lvHqList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvHqList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.No,
            this.TaID,
            this.Desc,
            this.Source,
            this.HqMove,
            this.Status,
            this.IsFileExists,
            this.IsOK,
            this.Remark});
            this.lvHqList.FullRowSelect = true;
            this.lvHqList.GridLines = true;
            this.lvHqList.Location = new System.Drawing.Point(8, 22);
            this.lvHqList.Name = "lvHqList";
            this.lvHqList.Size = new System.Drawing.Size(937, 229);
            this.lvHqList.TabIndex = 0;
            this.lvHqList.UseCompatibleStateImageBehavior = false;
            this.lvHqList.View = System.Windows.Forms.View.Details;
            this.lvHqList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lvHqList_MouseMove);
            // 
            // No
            // 
            this.No.Text = "No";
            this.No.Width = 45;
            // 
            // TaID
            // 
            this.TaID.Text = "TA代码";
            this.TaID.Width = 55;
            // 
            // Desc
            // 
            this.Desc.Text = "说明";
            this.Desc.Width = 120;
            // 
            // Source
            // 
            this.Source.Text = "文件路径";
            this.Source.Width = 150;
            // 
            // HqMove
            // 
            this.HqMove.Text = "拷贝路径";
            this.HqMove.Width = 150;
            // 
            // Status
            // 
            this.Status.Text = "状态";
            this.Status.Width = 100;
            // 
            // IsFileExists
            // 
            this.IsFileExists.Text = "文件到齐";
            this.IsFileExists.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // IsOK
            // 
            this.IsOK.Text = "是否完成";
            this.IsOK.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Remark
            // 
            this.Remark.Text = "备注";
            this.Remark.Width = 200;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.btnQsExecute);
            this.tabPage2.Controls.Add(this.lvQsList);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(953, 410);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "TA清算文件拷贝";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 272);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "异常信息:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 357);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(257, 48);
            this.label7.TabIndex = 10;
            this.label7.Text = "清算步骤:\r\n1.将文件从子目录剪切到根目录（有些TA需要）\r\n2.检查必收文件\r\n3.文件拷贝至清算机、结算部机器";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.Location = new System.Drawing.Point(11, 287);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(766, 58);
            this.textBox1.TabIndex = 9;
            // 
            // btnQsExecute
            // 
            this.btnQsExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQsExecute.Location = new System.Drawing.Point(855, 313);
            this.btnQsExecute.Name = "btnQsExecute";
            this.btnQsExecute.Size = new System.Drawing.Size(71, 23);
            this.btnQsExecute.TabIndex = 8;
            this.btnQsExecute.Text = "处理";
            this.btnQsExecute.UseVisualStyleBackColor = true;
            this.btnQsExecute.Click += new System.EventHandler(this.btnQsExecute_Click);
            // 
            // lvQsList
            // 
            this.lvQsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvQsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.lvQsList.FullRowSelect = true;
            this.lvQsList.GridLines = true;
            this.lvQsList.Location = new System.Drawing.Point(8, 22);
            this.lvQsList.Name = "lvQsList";
            this.lvQsList.Size = new System.Drawing.Size(937, 229);
            this.lvQsList.TabIndex = 7;
            this.lvQsList.UseCompatibleStateImageBehavior = false;
            this.lvQsList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "No";
            this.columnHeader1.Width = 45;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "TA代码";
            this.columnHeader2.Width = 55;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "说明";
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "文件路径";
            this.columnHeader4.Width = 150;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "拷贝路径";
            this.columnHeader5.Width = 150;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "状态";
            this.columnHeader6.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "文件到齐";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "是否完成";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "备注";
            this.columnHeader9.Width = 200;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "TA列表:";
            // 
            // bwHq
            // 
            this.bwHq.WorkerReportsProgress = true;
            this.bwHq.WorkerSupportsCancellation = true;
            this.bwHq.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwHq_DoWork);
            this.bwHq.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwHq_ProgressChanged);
            this.bwHq.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwHq_RunWorkerCompleted);
            // 
            // bwQs
            // 
            this.bwQs.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwQs_DoWork);
            this.bwQs.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwQs_ProgressChanged);
            this.bwQs.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwQs_RunWorkerCompleted);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 436);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmMain";
            this.Text = "开基文件检查";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DoubleBufferListView lvHqList;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox tbHqLog;
        private System.Windows.Forms.ColumnHeader TaID;
        private System.Windows.Forms.ColumnHeader Source;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.ColumnHeader IsOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader Remark;
        private System.Windows.Forms.ColumnHeader No;
        private System.Windows.Forms.Button btnHqExecute;
        private System.ComponentModel.BackgroundWorker bwHq;
        private System.Windows.Forms.ColumnHeader Desc;
        private System.Windows.Forms.ColumnHeader HqMove;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ColumnHeader IsFileExists;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbIsHqAllOK;
        private System.Windows.Forms.Label label5;
        private DoubleBufferListView lvQsList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Button btnQsExecute;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.ComponentModel.BackgroundWorker bwQs;
    }
}

