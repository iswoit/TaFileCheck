﻿namespace TaFileCheck
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
            this.tbHqLog = new System.Windows.Forms.TextBox();
            this.ctxHq = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxHqShow = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lbIsQsAllOK = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.listView2 = new System.Windows.Forms.ListView();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbQsLog = new System.Windows.Forms.TextBox();
            this.btnQsExecute = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.bwHq = new System.ComponentModel.BackgroundWorker();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.bwQs = new System.ComponentModel.BackgroundWorker();
            this.lvHqList = new TaFileCheck.DoubleBufferListView();
            this.No = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TaID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Desc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SourcePath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DestPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IsOK = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.ctxHq.SuspendLayout();
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
            this.tabControl1.Size = new System.Drawing.Size(1125, 476);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lbIsHqAllOK);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btnHqExecute);
            this.tabPage1.Controls.Add(this.tbHqLog);
            this.tabPage1.Controls.Add(this.lvHqList);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1117, 450);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "TA行情文件检查";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lbIsHqAllOK
            // 
            this.lbIsHqAllOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbIsHqAllOK.AutoSize = true;
            this.lbIsHqAllOK.Location = new System.Drawing.Point(1046, 378);
            this.lbIsHqAllOK.Name = "lbIsHqAllOK";
            this.lbIsHqAllOK.Size = new System.Drawing.Size(23, 12);
            this.lbIsHqAllOK.TabIndex = 8;
            this.lbIsHqAllOK.Text = "N/A";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(933, 378);
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
            this.label3.Location = new System.Drawing.Point(9, 343);
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
            this.btnHqExecute.Location = new System.Drawing.Point(965, 404);
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
            this.tbHqLog.Location = new System.Drawing.Point(8, 358);
            this.tbHqLog.Multiline = true;
            this.tbHqLog.Name = "tbHqLog";
            this.tbHqLog.ReadOnly = true;
            this.tbHqLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbHqLog.Size = new System.Drawing.Size(919, 78);
            this.tbHqLog.TabIndex = 2;
            // 
            // ctxHq
            // 
            this.ctxHq.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxHqShow});
            this.ctxHq.Name = "ctxHq";
            this.ctxHq.Size = new System.Drawing.Size(125, 26);
            this.ctxHq.Opening += new System.ComponentModel.CancelEventHandler(this.ctxHq_Opening);
            // 
            // ctxHqShow
            // 
            this.ctxHqShow.Name = "ctxHqShow";
            this.ctxHqShow.Size = new System.Drawing.Size(124, 22);
            this.ctxHqShow.Text = "显示详情";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lbIsQsAllOK);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.listView2);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.tbQsLog);
            this.tabPage2.Controls.Add(this.btnQsExecute);
            this.tabPage2.Controls.Add(this.lvQsList);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1117, 450);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "TA清算文件拷贝";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 476);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmMain";
            this.Text = "开基文件检查";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ctxHq.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem ctxHqShow;
    }
}

