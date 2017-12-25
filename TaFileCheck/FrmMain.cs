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
        TaManager _taManager = null;                            // 管理类
        private Point preToolTipPoint = new Point(-1, -1);      // 提示框坐标

        public FrmMain()
        {
            InitializeComponent();

            try
            {
                _taManager = new TaManager();
                InitHqList();
                InitQsList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }





        #region 行情检查逻辑

        /// <summary>
        /// 行情Lv初始化
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


        /// <summary>
        /// 行情Lv更新
        /// </summary>
        private void UpdateHqList()
        {
            lvHqList.BeginUpdate();
            // 进度列表
            try
            {
                for (int i = 0; i < _taManager.TaList.Count; i++)
                {
                    Ta tmpTa = (Ta)lvHqList.Items[i].Tag;   // 配置对象
                    lvHqList.Items[i].SubItems[5].Text = tmpTa.HqStatus.ToString();             // 状态
                    lvHqList.Items[i].SubItems[6].Text = tmpTa.IsHqFileExists ? "√" : "×";      // 行情文件到齐
                    lvHqList.Items[i].SubItems[7].Text = tmpTa.IsHqOK ? "√" : "×";              // 标志到齐


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

                lbIsHqAllOK.Text = _taManager.IsHqAllOK ? "是" : "否";
            }
            catch (Exception)
            {
                // ui异常过滤
            }

            lvHqList.EndUpdate();

        }


        /// <summary>
        /// 行情检查执行按钮
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
            else
            {
                bwHq.CancelAsync();
                btnHqExecute.Text = "检查";
            }
        }

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
                    if (true == bgWorker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }



                    // 0.开始
                    tmpTa.IsHqRunning = true;



                    // 1.源路径是否可访问
                    try
                    {
                        tmpTa.HqStatus = HqStatus.尝试访问源路径;
                        bgWorker.ReportProgress(1);

                        CheckFilePathTimeout timeout = new CheckFilePathTimeout(new DoHandler(_taManager.IsSourcePathAvailabel)); // 委托
                        bool isTimeout = timeout.DoWithTimeout(new TimeSpan(0, 0, 0, 10), tmpTa.Source);       // 超过10秒失败
                        bool isAvailable = timeout.bReturn;     // 是否可访问
                        if (isTimeout == true || isAvailable == false)
                        {
                            tmpTa.IsHqSourceAvailable = false;
                            tmpTa.HqStatus = HqStatus.无法访问源路径;
                            bgWorker.ReportProgress(1);
                        }
                        else
                        {
                            tmpTa.IsHqSourceAvailable = true;
                            tmpTa.HqStatus = HqStatus.访问源路径成功;
                            bgWorker.ReportProgress(1);
                        }
                    }
                    catch (Exception ex)
                    {
                        UserState us = new UserState(true, string.Format("TA {0}尝试访问源路径出错: {1}", tmpTa.Id, ex.Message));
                        bgWorker.ReportProgress(1, us);
                    }



                    // 2.按照rootmove配置移动文件（把子目录中的文件都移动到根目录）
                    if (tmpTa.IsHqSourceAvailable)
                    {
                        try
                        {
                            tmpTa.HqStatus = HqStatus.文件移动到根目录中;
                            bgWorker.ReportProgress(1);

                            _taManager.RootMove(tmpTa);

                            tmpTa.HqStatus = HqStatus.文件移动到根目录完成;
                            tmpTa.IsHqRootMoveOK = true;
                            bgWorker.ReportProgress(1);
                        }
                        catch (Exception ex)
                        {
                            tmpTa.HqStatus = HqStatus.文件移动到根目录错误;
                            tmpTa.IsHqRootMoveOK = false;
                            UserState us = new UserState(true, string.Format("TA {0}文件移动到根目录出错: {1}", tmpTa.Id, ex.Message));
                            bgWorker.ReportProgress(1, us);
                        }
                    }



                    // 3.拼接文件路径，判断行情文件是否到齐
                    if (tmpTa.IsHqSourceAvailable)
                    {
                        tmpTa.HqStatus = HqStatus.文件检查中;
                        bgWorker.ReportProgress(1);

                        tmpTa.IsHqFileExists = _taManager.IsHqFlagFileExists(tmpTa);
                        tmpTa.HqStatus = tmpTa.IsHqFileExists == true ? HqStatus.文件已收齐 : HqStatus.文件未收齐;
                        bgWorker.ReportProgress(1);
                        if (!tmpTa.IsHqFileExists)
                        {
                            tmpTa.IsHqRunning = false;
                            tmpTa.HqStatus = HqStatus.文件未收齐;
                            bgWorker.ReportProgress(1);
                            continue;
                        }
                        else
                        {
                            tmpTa.HqStatus = HqStatus.文件已收齐;
                            bgWorker.ReportProgress(1);
                        }
                    }



                    // 4.如果需要拷贝，则拷贝(多目的地)
                    if (tmpTa.IsHqSourceAvailable && tmpTa.IsHqNeedMove)
                    {
                        try
                        {
                            tmpTa.HqStatus = HqStatus.文件拷贝中;
                            bgWorker.ReportProgress(1);

                            _taManager.HqMove(tmpTa);

                            tmpTa.HqStatus = HqStatus.文件拷贝完成;
                            tmpTa.IsHqCopyOK = true;
                            bgWorker.ReportProgress(1);
                        }
                        catch (Exception ex)
                        {
                            tmpTa.HqStatus = HqStatus.文件拷贝失败;
                            tmpTa.IsHqCopyOK = false;
                            UserState us = new UserState(true, string.Format("TA {0}文件拷贝出错: {1}", tmpTa.Id, ex.Message));
                            bgWorker.ReportProgress(1, us);
                        }
                    }



                    // 最终
                    if (tmpTa.IsHqOK)
                    {
                        tmpTa.HqStatus = HqStatus.完成;
                    }

                    // 结束
                    tmpTa.IsHqRunning = false;
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

        private void lvHqList_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (preToolTipPoint.X != e.X || preToolTipPoint.Y != e.Y)//防止闪烁
                {
                    ListViewItem lvi = lvHqList.GetItemAt(e.X, e.Y);
                    if (lvi != null)
                        toolTip.Show(((Ta)lvi.Tag).HqToolTip, lvHqList, new Point(e.X + 30, e.Y + 20), 200000);
                    else
                        toolTip.Hide(lvHqList);
                }

                preToolTipPoint = e.Location;
            }
            catch
            { }
        }


        #endregion 行情检查逻辑







        #region 清算处理逻辑


        private void InitQsList()
        {
            lvQsList.Items.Clear();
            for (int i = 0; i < _taManager.TaList.Count; i++)
            {
                ListViewItem lvi = new ListViewItem((i + 1).ToString());
                lvi.SubItems.Add(_taManager.TaList[i].Id);
                lvi.SubItems.Add(_taManager.TaList[i].Desc);
                lvi.SubItems.Add(_taManager.TaList[i].Source);
                lvi.SubItems.Add(_taManager.TaList[i].QsMoveStr);
                lvi.SubItems.Add(_taManager.TaList[i].QsStatus.ToString());
                lvi.SubItems.Add(string.Empty);
                lvi.SubItems.Add(string.Empty);
                lvi.SubItems.Add(string.Empty);
                lvi.Tag = _taManager.TaList[i];

                lvQsList.Items.Add(lvi);


                lvQsList.Columns[0].Width = -1;
                //lvQsList.Columns[1].Width = -1;
                //lvQsList.Columns[2].Width = -1;
                //lvQsList.Columns[3].Width = -1;
                //lvQsList.Columns[4].Width = -1;
                //lvQsList.Columns[5].Width = -1;
                //lvQsList.Columns[6].Width = -1;
            }
        }


        private void btnQsExecute_Click(object sender, EventArgs e)
        {
            if (!bwQs.IsBusy)
            {
                bwQs.RunWorkerAsync();
                btnQsExecute.Text = "点击停止";
            }
            else
            {
                bwQs.CancelAsync();
                btnQsExecute.Text = "处理";
            }
        }

        private void bwQs_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                BackgroundWorker bgWorker = sender as BackgroundWorker;
            }
            catch (Exception ex)
            {

            }
        }

        private void bwQs_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void bwQs_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }


        #endregion 清算处理逻辑


    }
}
