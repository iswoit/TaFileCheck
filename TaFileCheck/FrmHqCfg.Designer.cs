﻿namespace TaFileCheck
{
    partial class FrmHqCfg
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDesc = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbRootMoveNo = new System.Windows.Forms.RadioButton();
            this.rbRootMoveYes = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.tbSourcePath = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.boxDestPath = new System.Windows.Forms.ListBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbFileAdd = new System.Windows.Forms.TextBox();
            this.btnFileDel = new System.Windows.Forms.Button();
            this.btnFileAdd = new System.Windows.Forms.Button();
            this.rbCheckType1 = new System.Windows.Forms.RadioButton();
            this.rbCheckType0 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.boxFileList = new System.Windows.Forms.ListBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.tbDestPathAdd = new System.Windows.Forms.TextBox();
            this.btnDestPathDel = new System.Windows.Forms.Button();
            this.btnDestPathAdd = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "TA代码:";
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(77, 41);
            this.tbID.Name = "tbID";
            this.tbID.ReadOnly = true;
            this.tbID.Size = new System.Drawing.Size(140, 21);
            this.tbID.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "描述:";
            // 
            // tbDesc
            // 
            this.tbDesc.Location = new System.Drawing.Point(77, 65);
            this.tbDesc.Name = "tbDesc";
            this.tbDesc.Size = new System.Drawing.Size(140, 21);
            this.tbDesc.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbRootMoveNo);
            this.groupBox1.Controls.Add(this.rbRootMoveYes);
            this.groupBox1.Location = new System.Drawing.Point(427, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(160, 42);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "子目录文件移动到根目录:";
            // 
            // rbRootMoveNo
            // 
            this.rbRootMoveNo.AutoSize = true;
            this.rbRootMoveNo.Checked = true;
            this.rbRootMoveNo.Location = new System.Drawing.Point(91, 17);
            this.rbRootMoveNo.Name = "rbRootMoveNo";
            this.rbRootMoveNo.Size = new System.Drawing.Size(35, 16);
            this.rbRootMoveNo.TabIndex = 1;
            this.rbRootMoveNo.TabStop = true;
            this.rbRootMoveNo.Text = "否";
            this.rbRootMoveNo.UseVisualStyleBackColor = true;
            // 
            // rbRootMoveYes
            // 
            this.rbRootMoveYes.AutoSize = true;
            this.rbRootMoveYes.Location = new System.Drawing.Point(33, 17);
            this.rbRootMoveYes.Name = "rbRootMoveYes";
            this.rbRootMoveYes.Size = new System.Drawing.Size(35, 16);
            this.rbRootMoveYes.TabIndex = 0;
            this.rbRootMoveYes.Text = "是";
            this.rbRootMoveYes.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "路径:";
            // 
            // tbSourcePath
            // 
            this.tbSourcePath.Location = new System.Drawing.Point(77, 92);
            this.tbSourcePath.Name = "tbSourcePath";
            this.tbSourcePath.Size = new System.Drawing.Size(295, 21);
            this.tbSourcePath.TabIndex = 8;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(646, 13);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(742, 13);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // boxDestPath
            // 
            this.boxDestPath.FormattingEnabled = true;
            this.boxDestPath.ItemHeight = 12;
            this.boxDestPath.Location = new System.Drawing.Point(23, 43);
            this.boxDestPath.Name = "boxDestPath";
            this.boxDestPath.Size = new System.Drawing.Size(260, 88);
            this.boxDestPath.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(21, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 12);
            this.label12.TabIndex = 26;
            this.label12.Text = "目标路径:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbDesc);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.tbSourcePath);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(841, 133);
            this.panel1.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "总体设置:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(83, 12);
            this.label14.TabIndex = 6;
            this.label14.Text = "行情检查设置:";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.btnDestPathDel);
            this.groupBox9.Controls.Add(this.btnDestPathAdd);
            this.groupBox9.Controls.Add(this.tbDestPathAdd);
            this.groupBox9.Controls.Add(this.label12);
            this.groupBox9.Controls.Add(this.boxDestPath);
            this.groupBox9.Location = new System.Drawing.Point(473, 43);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(354, 190);
            this.groupBox9.TabIndex = 27;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "检查后复制文件:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.groupBox9);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 133);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(841, 332);
            this.panel3.TabIndex = 30;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.tbFileAdd);
            this.groupBox2.Controls.Add(this.btnFileDel);
            this.groupBox2.Controls.Add(this.btnFileAdd);
            this.groupBox2.Controls.Add(this.rbCheckType1);
            this.groupBox2.Controls.Add(this.rbCheckType0);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.boxFileList);
            this.groupBox2.Location = new System.Drawing.Point(14, 43);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(453, 190);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "检查模式:";
            // 
            // tbFileAdd
            // 
            this.tbFileAdd.Location = new System.Drawing.Point(133, 137);
            this.tbFileAdd.Name = "tbFileAdd";
            this.tbFileAdd.Size = new System.Drawing.Size(260, 21);
            this.tbFileAdd.TabIndex = 29;
            // 
            // btnFileDel
            // 
            this.btnFileDel.Location = new System.Drawing.Point(400, 106);
            this.btnFileDel.Name = "btnFileDel";
            this.btnFileDel.Size = new System.Drawing.Size(35, 23);
            this.btnFileDel.TabIndex = 28;
            this.btnFileDel.Text = "-";
            this.btnFileDel.UseVisualStyleBackColor = true;
            this.btnFileDel.Click += new System.EventHandler(this.btnFileDel_Click);
            // 
            // btnFileAdd
            // 
            this.btnFileAdd.Location = new System.Drawing.Point(400, 135);
            this.btnFileAdd.Name = "btnFileAdd";
            this.btnFileAdd.Size = new System.Drawing.Size(35, 23);
            this.btnFileAdd.TabIndex = 27;
            this.btnFileAdd.Text = "+";
            this.btnFileAdd.UseVisualStyleBackColor = true;
            this.btnFileAdd.Click += new System.EventHandler(this.btnFileAdd_Click);
            // 
            // rbCheckType1
            // 
            this.rbCheckType1.AutoSize = true;
            this.rbCheckType1.Location = new System.Drawing.Point(21, 43);
            this.rbCheckType1.Name = "rbCheckType1";
            this.rbCheckType1.Size = new System.Drawing.Size(107, 16);
            this.rbCheckType1.TabIndex = 1;
            this.rbCheckType1.TabStop = true;
            this.rbCheckType1.Text = "自定义文件列表";
            this.rbCheckType1.UseVisualStyleBackColor = true;
            this.rbCheckType1.CheckedChanged += new System.EventHandler(this.rbCheckType_CheckedChanged);
            // 
            // rbCheckType0
            // 
            this.rbCheckType0.AutoSize = true;
            this.rbCheckType0.Location = new System.Drawing.Point(21, 21);
            this.rbCheckType0.Name = "rbCheckType0";
            this.rbCheckType0.Size = new System.Drawing.Size(71, 16);
            this.rbCheckType0.TabIndex = 0;
            this.rbCheckType0.TabStop = true;
            this.rbCheckType0.Text = "索引文件";
            this.rbCheckType0.UseVisualStyleBackColor = true;
            this.rbCheckType0.CheckedChanged += new System.EventHandler(this.rbCheckType_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(132, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 26;
            this.label3.Text = "文件列表:";
            // 
            // boxFileList
            // 
            this.boxFileList.FormattingEnabled = true;
            this.boxFileList.ItemHeight = 12;
            this.boxFileList.Location = new System.Drawing.Point(133, 43);
            this.boxFileList.Name = "boxFileList";
            this.boxFileList.Size = new System.Drawing.Size(260, 88);
            this.boxFileList.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnOK);
            this.panel4.Controls.Add(this.btnCancel);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 408);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(841, 57);
            this.panel4.TabIndex = 32;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(132, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(227, 12);
            this.label7.TabIndex = 31;
            this.label7.Text = "*支持yyyymmdd、yymmdd、mmdd日期通配符";
            // 
            // tbDestPathAdd
            // 
            this.tbDestPathAdd.Location = new System.Drawing.Point(23, 137);
            this.tbDestPathAdd.Name = "tbDestPathAdd";
            this.tbDestPathAdd.Size = new System.Drawing.Size(260, 21);
            this.tbDestPathAdd.TabIndex = 30;
            // 
            // btnDestPathDel
            // 
            this.btnDestPathDel.Location = new System.Drawing.Point(289, 106);
            this.btnDestPathDel.Name = "btnDestPathDel";
            this.btnDestPathDel.Size = new System.Drawing.Size(35, 23);
            this.btnDestPathDel.TabIndex = 32;
            this.btnDestPathDel.Text = "-";
            this.btnDestPathDel.UseVisualStyleBackColor = true;
            this.btnDestPathDel.Click += new System.EventHandler(this.btnDestPathDel_Click);
            // 
            // btnDestPathAdd
            // 
            this.btnDestPathAdd.Location = new System.Drawing.Point(289, 137);
            this.btnDestPathAdd.Name = "btnDestPathAdd";
            this.btnDestPathAdd.Size = new System.Drawing.Size(35, 23);
            this.btnDestPathAdd.TabIndex = 31;
            this.btnDestPathAdd.Text = "+";
            this.btnDestPathAdd.UseVisualStyleBackColor = true;
            this.btnDestPathAdd.Click += new System.EventHandler(this.btnDestPathAdd_Click);
            // 
            // FrmHqCfg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(841, 465);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "FrmHqCfg";
            this.Text = "TA行情配置";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDesc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbRootMoveNo;
        private System.Windows.Forms.RadioButton rbRootMoveYes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbSourcePath;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListBox boxDestPath;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbCheckType1;
        private System.Windows.Forms.RadioButton rbCheckType0;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox boxFileList;
        private System.Windows.Forms.Button btnFileDel;
        private System.Windows.Forms.Button btnFileAdd;
        private System.Windows.Forms.TextBox tbFileAdd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnDestPathDel;
        private System.Windows.Forms.Button btnDestPathAdd;
        private System.Windows.Forms.TextBox tbDestPathAdd;
    }
}