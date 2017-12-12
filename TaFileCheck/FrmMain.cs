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
                lvi.Tag = _taManager.TaList[i];

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

        private void UpdateHqList()
        {
            lvHqList.BeginUpdate();
            // 进度列表
            try
            {
                for (int i = 0; i < _taManager.TaList.Count; i++)
                {
                    Ta tmpTa = (Ta)lvHqList.Items[i].Tag;   // 配置对象
                    lvHqList.Items[i].SubItems[5].Text = tmpTa.HqStatus.ToString();        // 状态
                    lvHqList.Items[i].SubItems[6].Text = tmpTa.IsHqCheckedOK ? "√" : "×";        // 标志到齐


                    if (tmpTa.IsHqRunning)
                    {
                        lvHqList.Items[i].BackColor = Color.LightBlue;
                        lvHqList.Items[i].EnsureVisible();
                    }
                    else
                    {
                        lvHqList.Items[i].BackColor = SystemColors.Window;
                    }

                }
            }
            catch (Exception)
            {
                // ui异常过滤
            }

            lvHqList.EndUpdate();

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

            try
            {
                BackgroundWorker bgWorker = sender as BackgroundWorker;

                foreach (Ta tmpTa in _taManager.TaList)
                {
                    tmpTa.IsHqRunning = true;


                    // 1.源路径是否可访问
                    tmpTa.HqStatus = HqStatus.尝试访问源路径;
                    bgWorker.ReportProgress(1);

                    CheckFilePathTimeout timeout = new CheckFilePathTimeout(new DoHandler(_taManager.IsSourcePathAvailabel)); // 委托
                    bool isTimeout = timeout.DoWithTimeout(new TimeSpan(0, 0, 0, 10), tmpTa.Source);       // 超过10秒失败
                    bool isAvailable = timeout.bReturn;     // 是否可访问
                    if (isTimeout == true || isAvailable == false)
                    {
                        tmpTa.IsHqRunning = false;

                        tmpTa.HqStatus = HqStatus.无法访问源路径;
                        bgWorker.ReportProgress(1);

                        continue;
                    }

                    //bool isAvailable = _taManager.IsSourcePathAvailabel(tmpTa);
                    //if (!isAvailable)
                    //{
                    //    tmpTa.IsHqRunning = false;

                    //    tmpTa.HqStatus = HqStatus.无法访问源路径;
                    //    bgWorker.ReportProgress(1);

                    //    continue;
                    //}

                    //// 日志报警
                    //UserState us = new UserState(true, string.Format("文件源[{0}]，源路径[{1}]无法访问!", tmpFileSource.Name, Util.Filename_Date_Convert(tmpFileSource.OriginPath)));
                    //bgWorker.ReportProgress(1, us);


                    // 2.按照rootmove配置移动文件（把子目录中的文件都移动到根目录）
                    tmpTa.HqStatus = HqStatus.文件移动到根目录中;
                    bgWorker.ReportProgress(1);

                    _taManager.RootMove(tmpTa);

                    tmpTa.HqStatus = HqStatus.文件移动到根目完成;
                    bgWorker.ReportProgress(1);



                    // 3.拼接文件路径，判断文件是否存在
                    tmpTa.HqStatus = HqStatus.检查中;
                    bgWorker.ReportProgress(1);

                    tmpTa.IsHqCheckedOK = _taManager.IsHqFlagFileExists(tmpTa);

                    tmpTa.HqStatus = tmpTa.IsHqCheckedOK == true ? HqStatus.文件已收齐 : HqStatus.文件未收齐;
                    bgWorker.ReportProgress(1);
                    if (!tmpTa.IsHqCheckedOK)
                    {
                        tmpTa.IsHqRunning = false;

                        bgWorker.ReportProgress(1);
                        continue;
                    }

                    // 4.如果需要拷贝，则拷贝(多目的地)

                    tmpTa.HqStatus = HqStatus.文件拷贝中;
                    bgWorker.ReportProgress(1);

                    _taManager.HqMove(tmpTa);

                    tmpTa.HqStatus = HqStatus.文件拷贝完成;
                    bgWorker.ReportProgress(1);



                    // 结束
                    tmpTa.IsHqRunning = false;

                    tmpTa.HqStatus = HqStatus.完成;
                    bgWorker.ReportProgress(1);


                }


                e.Result = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void bwHq_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState != null)
            {
                UserState us = (UserState)e.UserState;
                if (us.HasError)
                    Print_Hq_Error_Message(us.ErrorMsg);
            }


            try
            {
                UpdateHqList();
            }
            catch (Exception ex)
            {
                Print_Hq_Error_Message(ex.Message);
            }

        }

        private void bwHq_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)    // 未处理的异常，需要弹框
            {
                Print_Hq_Error_Message(e.Error.Message);
                MessageBox.Show(e.Error.Message);

                //lbStatus.Text = "异常停止";
                //lbStatus.BackColor = Color.Red;
            }
            else if (e.Cancelled)
            {
                Print_Hq_Error_Message("任务被手工取消");

                //lbStatus.Text = "手工停止";
                //lbStatus.BackColor = Color.Red;

                // 状态清空
                for (int i = 0; i < _taManager.TaList.Count; i++)
                {
                    _taManager.TaList[i].IsHqRunning = false;
                }
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

        private void Print_Hq_Error_Message(string message)
        {
            tbHqLog.Text = string.Format("{0}:{1}", DateTime.Now.ToString("HH:mm:ss"), message) + System.Environment.NewLine + tbHqLog.Text;
        }



        #endregion 行情检查逻辑


    }
}
