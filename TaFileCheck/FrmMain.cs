using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TaFileCheck
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 开基文件检查执行按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheckExecute_Click(object sender, EventArgs e)
        {
            if (!bwHq.IsBusy)
                bwHq.RunWorkerAsync();
        }


        #region 行情检查逻辑
        private void bwHq_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bgWorker = sender as BackgroundWorker;
            

            e.Result = true;
        }

        private void bwHq_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void bwHq_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        #endregion 行情检查逻辑


    }
}
