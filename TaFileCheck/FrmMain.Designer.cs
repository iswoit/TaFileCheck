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
            this.tbCtl = new System.Windows.Forms.TabControl();
            this.tabHq = new System.Windows.Forms.TabPage();
            this.lbIsHqRunning = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbIsHqAllOK = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnHqExecute = new System.Windows.Forms.Button();
            this.tbHqLog = new System.Windows.Forms.TextBox();
            this.lvHqList = new TaFileCheck.DoubleBufferListView();
            this.No = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TaID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Desc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SourcePath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DestPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IsOK = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctxHq = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxHqModify = new System.Windows.Forms.ToolStripMenuItem();
            this.tabQs = new System.Windows.Forms.TabPage();
            this.lbIsQsAllOK = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.listView2 = new System.Windows.Forms.ListView();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbQsLog = new System.Windows.Forms.TextBox();
            this.btnQsExecute = new System.Windows.Forms.Button();
            this.lvQsList = new TaFileCheck.DoubleBufferListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label5 = new System.Windows.Forms.Label();
            this.bwHq = new System.ComponentModel.BackgroundWorker();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.bwQs = new System.ComponentModel.BackgroundWorker();
            this.StartTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbCtl.SuspendLayout();
            this.tabHq.SuspendLayout();
            this.ctxHq.SuspendLayout();
            this.tabQs.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbCtl
            // 
            this.tbCtl.Controls.Add(this.tabHq);
            this.tbCtl.Controls.Add(this.tabQs);
            this.tbCtl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCtl.Location = new System.Drawing.Point(0, 0);
            this.tbCtl.Name = "tbCtl";
            this.tbCtl.SelectedIndex = 0;
            this.tbCtl.Size = new System.Drawing.Size(1125, 476);
            this.tbCtl.TabIndex = 1;
            // 
            // tabHq
            // 
            this.tabHq.Controls.Add(this.lbIsHqRunning);
            this.tabHq.Controls.Add(this.label1);
            this.tabHq.Controls.Add(this.lbIsHqAllOK);
            this.tabHq.Controls.Add(this.label4);
            this.tabHq.Controls.Add(this.label3);
            this.tabHq.Controls.Add(this.label2);
            this.tabHq.Controls.Add(this.btnHqExecute);
            this.tabHq.Controls.Add(this.tbHqLog);
            this.tabHq.Controls.Add(this.lvHqList);
            this.tabHq.Location = new System.Drawing.Point(4, 22);
            this.tabHq.Name = "tabHq";
            this.tabHq.Padding = new System.Windows.Forms.Padding(3);
            this.tabHq.Size = new System.Drawing.Size(1117, 450);
            this.tabHq.TabIndex = 0;
            this.tabHq.Text = "TA行情文件检查";
            this.tabHq.UseVisualStyleBackColor = true;
            // 
            // lbIsHqRunning
            // 
            this.lbIsHqRunning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbIsHqRunning.AutoSize = true;
            this.lbIsHqRunning.Location = new System.Drawing.Point(1011, 350);
            this.lbIsHqRunning.Name = "lbIsHqRunning";
            this.lbIsHqRunning.Size = new System.Drawing.Size(41, 12);
            this.lbIsHqRunning.TabIndex = 10;
            this.lbIsHqRunning.Text = "未运行";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(946, 350);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "运行状态:";
            // 
            // lbIsHqAllOK
            // 
            this.lbIsHqAllOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbIsHqAllOK.AutoSize = true;
            this.lbIsHqAllOK.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbIsHqAllOK.Location = new System.Drawing.Point(1010, 374);
            this.lbIsHqAllOK.Name = "lbIsHqAllOK";
            this.lbIsHqAllOK.Size = new System.Drawing.Size(35, 16);
            this.lbIsHqAllOK.TabIndex = 8;
            this.lbIsHqAllOK.Text = "N/A";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(898, 378);
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
            this.label3.Location = new System.Drawing.Point(9, 331);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "日志信息:";
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
            this.btnHqExecute.Location = new System.Drawing.Point(946, 407);
            this.btnHqExecute.Name = "btnHqExecute";
            this.btnHqExecute.Size = new System.Drawing.Size(106, 29);
            this.btnHqExecute.TabIndex = 4;
            this.btnHqExecute.Text = "检查";
            this.btnHqExecute.UseVisualStyleBackColor = true;
            this.btnHqExecute.Click += new System.EventHandler(this.btnHqExecute_Click);
            // 
            // tbHqLog
            // 
            this.tbHqLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbHqLog.BackColor = System.Drawing.SystemColors.Window;
            this.tbHqLog.Location = new System.Drawing.Point(8, 346);
            this.tbHqLog.Multiline = true;
            this.tbHqLog.Name = "tbHqLog";
            this.tbHqLog.ReadOnly = true;
            this.tbHqLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbHqLog.Size = new System.Drawing.Size(864, 90);
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
            this.SourcePath,
            this.DestPath,
            this.StartTime,
            this.Status,
            this.IsOK});
            this.lvHqList.ContextMenuStrip = this.ctxHq;
            this.lvHqList.FullRowSelect = true;
            this.lvHqList.GridLines = true;
            this.lvHqList.Location = new System.Drawing.Point(8, 22);
            this.lvHqList.MultiSelect = false;
            this.lvHqList.Name = "lvHqList";
            this.lvHqList.Size = new System.Drawing.Size(1087, 298);
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
            this.TaID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TaID.Width = 55;
            // 
            // Desc
            // 
            this.Desc.Text = "描述";
            this.Desc.Width = 120;
            // 
            // SourcePath
            // 
            this.SourcePath.Text = "文件路径";
            this.SourcePath.Width = 150;
            // 
            // DestPath
            // 
            this.DestPath.Text = "拷贝目的路径";
            this.DestPath.Width = 150;
            // 
            // Status
            // 
            this.Status.Text = "状态";
            this.Status.Width = 120;
            // 
            // IsOK
            // 
            this.IsOK.Text = "是否完成";
            this.IsOK.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ctxHq
            // 
            this.ctxHq.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxHqModify});
            this.ctxHq.Name = "ctxHq";
            this.ctxHq.Size = new System.Drawing.Size(125, 26);
            this.ctxHq.Opening += new System.ComponentModel.CancelEventHandler(this.ctxHq_Opening);
            // 
            // ctxHqModify
            // 
            this.ctxHqModify.Name = "ctxHqModify";
            this.ctxHqModify.Size = new System.Drawing.Size(124, 22);
            this.ctxHqModify.Text = "修改配置";
            this.ctxHqModify.Click += new System.EventHandler(this.ctxHqModify_Click);
            // 
            // tabQs
            // 
            this.tabQs.Controls.Add(this.lbIsQsAllOK);
            this.tabQs.Controls.Add(this.label8);
            this.tabQs.Controls.Add(this.listView2);
            this.tabQs.Controls.Add(this.label7);
            this.tabQs.Controls.Add(this.label6);
            this.tabQs.Controls.Add(this.tbQsLog);
            this.tabQs.Controls.Add(this.btnQsExecute);
            this.tabQs.Controls.Add(this.lvQsList);
            this.tabQs.Controls.Add(this.label5);
            this.tabQs.Location = new System.Drawing.Point(4, 22);
            this.tabQs.Name = "tabQs";
            this.tabQs.Padding = new System.Windows.Forms.Padding(3);
            this.tabQs.Size = new System.Drawing.Size(1117, 450);
            this.tabQs.TabIndex = 1;
            this.tabQs.Text = "TA清算文件拷贝";
            this.tabQs.UseVisualStyleBackColor = true;
            // 
            // lbIsQsAllOK
            // 
            this.lbIsQsAllOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbIsQsAllOK.AutoSize = true;
            this.lbIsQsAllOK.Location = new System.Drawing.Point(1059, 369);
            this.lbIsQsAllOK.Name = "lbIsQsAllOK";
            this.lbIsQsAllOK.Size = new System.Drawing.Size(23, 12);
            this.lbIsQsAllOK.TabIndex = 16;
            this.lbIsQsAllOK.Text = "N/A";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(946, 369);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 12);
            this.label8.TabIndex = 15;
            this.label8.Text = "清算文件是否就绪:";
            // 
            // listView2
            // 
            this.listView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView2.Location = new System.Drawing.Point(155, 297);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(708, 53);
            this.listView2.TabIndex = 14;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 309);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "其他ETF退补款文件处理:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 369);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "异常信息:";
            // 
            // tbQsLog
            // 
            this.tbQsLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbQsLog.BackColor = System.Drawing.SystemColors.Window;
            this.tbQsLog.Location = new System.Drawing.Point(11, 384);
            this.tbQsLog.Multiline = true;
            this.tbQsLog.Name = "tbQsLog";
            this.tbQsLog.ReadOnly = true;
            this.tbQsLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbQsLog.Size = new System.Drawing.Size(930, 58);
            this.tbQsLog.TabIndex = 9;
            // 
            // btnQsExecute
            // 
            this.btnQsExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQsExecute.Location = new System.Drawing.Point(1020, 408);
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
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader8});
            this.lvQsList.FullRowSelect = true;
            this.lvQsList.GridLines = true;
            this.lvQsList.Location = new System.Drawing.Point(8, 22);
            this.lvQsList.MultiSelect = false;
            this.lvQsList.Name = "lvQsList";
            this.lvQsList.Size = new System.Drawing.Size(1101, 269);
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
            this.columnHeader3.Width = 100;
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
            this.columnHeader6.Text = "清算运行状态";
            this.columnHeader6.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "TA文件到齐";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 80;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "TA文件拷贝完成";
            this.columnHeader10.Width = 100;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "CIL文件到齐";
            this.columnHeader11.Width = 100;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "CIL文件拷贝完成";
            this.columnHeader12.Width = 120;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "是否完成";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.bwQs.WorkerReportsProgress = true;
            this.bwQs.WorkerSupportsCancellation = true;
            this.bwQs.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwQs_DoWork);
            this.bwQs.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwQs_ProgressChanged);
            this.bwQs.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwQs_RunWorkerCompleted);
            // 
            // StartTime
            // 
            this.StartTime.Text = "开始检查时间";
            this.StartTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.StartTime.Width = 88;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 476);
            this.Controls.Add(this.tbCtl);
            this.Name = "FrmMain";
            this.Text = "开基文件检查";
            this.tbCtl.ResumeLayout(false);
            this.tabHq.ResumeLayout(false);
            this.tabHq.PerformLayout();
            this.ctxHq.ResumeLayout(false);
            this.tabQs.ResumeLayout(false);
            this.tabQs.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DoubleBufferListView lvHqList;
        private System.Windows.Forms.TabControl tbCtl;
        private System.Windows.Forms.TabPage tabHq;
        private System.Windows.Forms.TabPage tabQs;
        private System.Windows.Forms.TextBox tbHqLog;
        private System.Windows.Forms.ColumnHeader TaID;
        private System.Windows.Forms.ColumnHeader SourcePath;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.ColumnHeader IsOK;
        private System.Windows.Forms.ColumnHeader No;
        private System.Windows.Forms.Button btnHqExecute;
        private System.ComponentModel.BackgroundWorker bwHq;
        private System.Windows.Forms.ColumnHeader Desc;
        private System.Windows.Forms.ColumnHeader DestPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTip;
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
        private System.Windows.Forms.Button btnQsExecute;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbQsLog;
        private System.ComponentModel.BackgroundWorker bwQs;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Label lbIsQsAllOK;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ContextMenuStrip ctxHq;
        private System.Windows.Forms.ToolStripMenuItem ctxHqModify;
        private System.Windows.Forms.Label lbIsHqRunning;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader StartTime;
    }
}

