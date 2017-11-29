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
            this.tbCheckLog = new System.Windows.Forms.TextBox();
            this.TaID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Source = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IsOK = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.Remark = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.No = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnHqExecute = new System.Windows.Forms.Button();
            this.bwHq = new System.ComponentModel.BackgroundWorker();
            this.Desc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HqMove = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvCheckList
            // 
            this.lvCheckList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.No,
            this.TaID,
            this.Desc,
            this.Source,
            this.HqMove,
            this.Status,
            this.IsOK,
            this.Remark});
            this.lvCheckList.GridLines = true;
            this.lvCheckList.Location = new System.Drawing.Point(13, 26);
            this.lvCheckList.Name = "lvCheckList";
            this.lvCheckList.Size = new System.Drawing.Size(903, 165);
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
            this.tabPage1.Controls.Add(this.btnHqExecute);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.tbCheckLog);
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
            // tbCheckLog
            // 
            this.tbCheckLog.Location = new System.Drawing.Point(19, 226);
            this.tbCheckLog.Multiline = true;
            this.tbCheckLog.Name = "tbCheckLog";
            this.tbCheckLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbCheckLog.Size = new System.Drawing.Size(875, 94);
            this.tbCheckLog.TabIndex = 2;
            // 
            // TaID
            // 
            this.TaID.Text = "TA代码";
            // 
            // Source
            // 
            this.Source.Text = "文件路径";
            this.Source.Width = 150;
            // 
            // IsOK
            // 
            this.IsOK.Text = "是否收齐";
            // 
            // Status
            // 
            this.Status.Text = "状态";
            this.Status.Width = 100;
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
            // Remark
            // 
            this.Remark.Text = "备注";
            this.Remark.Width = 200;
            // 
            // No
            // 
            this.No.Text = "No";
            this.No.Width = 45;
            // 
            // btnHqExecute
            // 
            this.btnHqExecute.Location = new System.Drawing.Point(819, 355);
            this.btnHqExecute.Name = "btnHqExecute";
            this.btnHqExecute.Size = new System.Drawing.Size(75, 23);
            this.btnHqExecute.TabIndex = 4;
            this.btnHqExecute.Text = "检查";
            this.btnHqExecute.UseVisualStyleBackColor = true;
            // 
            // bwHq
            // 
            this.bwHq.WorkerReportsProgress = true;
            this.bwHq.WorkerSupportsCancellation = true;
            this.bwHq.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwHq_DoWork);
            this.bwHq.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwHq_ProgressChanged);
            this.bwHq.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwHq_RunWorkerCompleted);
            // 
            // Desc
            // 
            this.Desc.Text = "说明";
            this.Desc.Width = 100;
            // 
            // HqMove
            // 
            this.HqMove.Text = "拷贝路径";
            this.HqMove.Width = 150;
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
    }
}

