using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TaFileCheck
{
    public partial class FrmMain : Form
    {
        TaManager _taManager = null;


        public FrmMain()
        {
            InitializeComponent();

            try
            {
                _taManager = new TaManager();
                InitHqList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// 初始化行情ListView
        /// </summary>
        private void InitHqList()
        {
            lvHqList.Items.Clear();
            for (int i = 0; i < _taManager.TaList.Count; i++)
            {
                ListViewItem lvi = new ListViewItem((i + 1).ToString());
                lvi.SubItems.Add(_taManager.TaList[i].Id);
                lvi.SubItems.Add(_taManager.TaList[i].Desc);
                lvi.SubItems.Add(_taManager.TaList[i].Source);
                lvi.SubItems.Add(_taManager.TaList[i].HqMoveStr);
                lvi.SubItems.Add(_taManager.TaList[i].HqStatus.ToString());
                lvi.SubItems.Add(string.Empty);
                lvi.SubItems.Add(string.Empty);

                lvHqList.Items.Add(lvi);


                lvHqList.Columns[0].Width = -1;
                //lvHqList.Columns[1].Width = -1;
                //lvHqList.Columns[2].Width = -1;
                //lvHqList.Columns[3].Width = -1;
                //lvHqList.Columns[4].Width = -1;
                //lvHqList.Columns[5].Width = -1;
                //lvHqList.Columns[6].Width = -1;
            }
        }



        /// <summary>
        /// 开基文件检查执行按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHqExecute_Click(object sender, EventArgs e)
        {
            if (!bwHq.IsBusy)
            {
                bwHq.RunWorkerAsync();
                btnHqExecute.Text = "点击停止";
            }
        }


        #region 行情检查逻辑
        private void bwHq_DoWork(object sender, DoWorkEventArgs e)
        {
            /* 1.源路径是否可访问
             * 2.按照rootmove配置移动文件
             * 3.拼接文件路径，判断文件是否存在
             * 4.如果需要拷贝，则拷贝(多目的地)
             */

            BackgroundWorker bgWorker = sender as BackgroundWorker;

            foreach (Ta tmpTa in _taManager.TaList)
            {
                // 1.源路径是否可访问
                if (!Directory.Exists(Util.Filename_Date_Convert(tmpTa.Source)))
                {
                    tmpTa.HqStatus = HqStatus.异常;

                    //// 日志报警
                    //UserState us = new UserState(true, string.Format("文件源[{0}]，源路径[{1}]无法访问!", tmpFileSource.Name, Util.Filename_Date_Convert(tmpFileSource.OriginPath)));
                    tmpFileSource.IsRunning = false;
                    //bgWorker.ReportProgress(1, us);

                    continue;
                }
                Thread.Sleep(100);



                Thread.Sleep(2000);
            }


            e.Result = true;
        }

        private void bwHq_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void bwHq_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)    // 未处理的异常，需要弹框
            {
                //Print_Error_Message(e.Error.Message);
                //MessageBox.Show(e.Error.Message);

                //lbStatus.Text = "异常停止";
                //lbStatus.BackColor = Color.Red;
            }
            else if (e.Cancelled)
            {
                //Print_Error_Message("任务被手工取消");

                //lbStatus.Text = "手工停止";
                //lbStatus.BackColor = Color.Red;

                //// 状态清空
                //for (int i = 0; i < _manager.FileSourceList.Count; i++)
                //{
                //    _manager.FileSourceList[i].IsRunning = false;
                //}
            }
            else
            {
                //UpdateFileSourceInfo();
                //UpdateFileListInfo();

                //// 处理状态标签
                //lbStatus.Text = "完成，等待下一轮";
                //lbStatus.BackColor = Color.ForestGreen;
            }

            btnHqExecute.Text = "检查";
        }


        #endregion 行情检查逻辑


    }
}
