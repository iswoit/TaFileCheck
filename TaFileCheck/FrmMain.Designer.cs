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
            this.lvCheckList = new System.Windows.Forms.ListView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnCheckExecute = new System.Windows.Forms.Button();
            this.tbCheckLog = new System.Windows.Forms.TextBox();
            this.bwCheck = new System.ComponentModel.BackgroundWorker();
            this.bwCopy = new System.ComponentModel.BackgroundWorker();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvCheckList
            // 
            this.lvCheckList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader3,
            this.columnHeader5});
            this.lvCheckList.GridLines = true;
            this.lvCheckList.Location = new System.Drawing.Point(19, 16);
            this.lvCheckList.Name = "lvCheckList";
            this.lvCheckList.Size = new System.Drawing.Size(875, 165);
            this.lvCheckList.TabIndex = 0;
            this.lvCheckList.UseCompatibleStateImageBehavior = false;
            this.lvCheckList.View = System.Windows.Forms.View.Details;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(927, 436);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.tbCheckLog);
            this.tabPage1.Controls.Add(this.btnCheckExecute);
            this.tabPage1.Controls.Add(this.lvCheckList);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(919, 410);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "TA行情文件检查";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(919, 410);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "TA清算文件拷贝";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnCheckExecute
            // 
            this.btnCheckExecute.Location = new System.Drawing.Point(819, 355);
            this.btnCheckExecute.Name = "btnCheckExecute";
            this.btnCheckExecute.Size = new System.Drawing.Size(75, 23);
            this.btnCheckExecute.TabIndex = 1;
            this.btnCheckExecute.Text = "执行检查";
            this.btnCheckExecute.UseVisualStyleBackColor = true;
            this.btnCheckExecute.Click += new System.EventHandler(this.btnCheckExecute_Click);
            // 
            // tbCheckLog
            // 
            this.tbCheckLog.Location = new System.Drawing.Point(19, 226);
            this.tbCheckLog.Multiline = true;
            this.tbCheckLog.Name = "tbCheckLog";
            this.tbCheckLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbCheckLog.Size = new System.Drawing.Size(875, 94);
            this.tbCheckLog.TabIndex = 2;
            // 
            // bwCheck
            // 
            this.bwCheck.WorkerReportsProgress = true;
            this.bwCheck.WorkerSupportsCancellation = true;
            this.bwCheck.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwCheck_DoWork);
            this.bwCheck.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwCheck_ProgressChanged);
            this.bwCheck.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwCheck_RunWorkerCompleted);
            // 
            // bwCopy
            // 
            this.bwCopy.WorkerReportsProgress = true;
            this.bwCopy.WorkerSupportsCancellation = true;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "TA代码";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "路径";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "是否收齐";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "状态";
            this.columnHeader4.Width = 100;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 330);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 48);
            this.label1.TabIndex = 3;
            this.label1.Text = "步骤\r\n1.将文件从子目录剪切到根目录（有些TA需要）\r\n2.文件拷贝（中登TA需要）\r\n3.检查文件（索引和07文件）";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "备注";
            this.columnHeader5.Width = 200;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 436);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmMain";
            this.Text = "开基文件检查";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvCheckList;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox tbCheckLog;
        private System.Windows.Forms.Button btnCheckExecute;
        private System.ComponentModel.BackgroundWorker bwCheck;
        private System.ComponentModel.BackgroundWorker bwCopy;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}

