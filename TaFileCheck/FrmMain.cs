﻿using System;
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
                //InitQsList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // 临时屏蔽清算
            this.tbCtl.TabPages[1].Parent = null;
        }




        #region 行情检查逻辑

        private void InitHqList()
        {
            lvHqList.Items.Clear();
            for (int i = 0; i < _taManager.TaHqList.Count; i++)
            {
                ListViewItem lvi = new ListViewItem((i + 1).ToString());
                lvi.SubItems.Add(_taManager.TaHqList[i].Id);
                lvi.SubItems.Add(_taManager.TaHqList[i].Desc);
                lvi.SubItems.Add(_taManager.TaHqList[i].SourcePath);
                lvi.SubItems.Add(_taManager.TaHqList[i].DestPathsString);
                lvi.SubItems.Add(_taManager.TaHqList[i].HqStartTime.HasValue ? _taManager.TaHqList[i].HqStartTime.Value.ToString("HH:mm") : "任意");
                lvi.SubItems.Add(_taManager.TaHqList[i].HqStatus.ToString());
                lvi.SubItems.Add(string.Empty);
                lvi.Tag = _taManager.TaHqList[i];

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
                for (int i = 0; i < _taManager.TaHqList.Count; i++)
                {
                    TaHq tmpTaHq = (TaHq)lvHqList.Items[i].Tag;   // 配置对象
                    lvHqList.Items[i].SubItems[6].Text = tmpTaHq.HqStatus.ToString();             // 状态
                    lvHqList.Items[i].SubItems[7].Text = tmpTaHq.IsOK ? "√" : "×";              // 标志到齐


                    if (tmpTaHq.IsRunning)
                    {
                        lvHqList.Items[i].BackColor = Color.LightBlue;
                        lvHqList.Items[i].EnsureVisible();
                    }
                    else
                    {
                        if (tmpTaHq.IsOK == false)
                        {
                            if (tmpTaHq.IsRequired == false)   // 时间点未到
                            {
                                lvHqList.Items[i].BackColor = Color.LightYellow;
                            }
                            else
                                lvHqList.Items[i].BackColor = Color.Pink;
                        }
                        else
                        {
                            lvHqList.Items[i].BackColor = SystemColors.Window;
                        }
                    }
                }

                if (_taManager.IsHqAllOK)
                {
                    lbIsHqAllOK.Text = "是";
                    lbIsHqAllOK.ForeColor = Color.Green;
                }
                else
                {
                    lbIsHqAllOK.Text = "否";
                    lbIsHqAllOK.ForeColor = Color.Red;
                }

            }
            catch (Exception)
            {
                // ui异常过滤
            }

            lvHqList.EndUpdate();

        }

        private void btnHqExecute_Click(object sender, EventArgs e)
        {
            if (!bwHq.IsBusy)
            {
                lbIsHqRunning.Text = "正在运行...";
                bwHq.RunWorkerAsync();
                btnHqExecute.Text = "检查中...";
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
             * 3.根据索引获取文件列表
             * 4.判断文件是否存在
             * 5.如果需要拷贝，则拷贝(多目的地)
             */

            try
            {
                BackgroundWorker bgWorker = sender as BackgroundWorker;

                foreach (TaHq tmpTa in _taManager.TaHqList)
                {
                    if (true == bgWorker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }



                    // 0.开始
                    tmpTa.IsRunning = true;
                    bgWorker.ReportProgress(1);
                    Thread.Sleep(50);

                    if (tmpTa.IsOK)
                    {
                        tmpTa.IsRunning = false;
                        bgWorker.ReportProgress(1);
                        continue;
                    }


                    // 如果项有时间，更新是否检查标志
                    if (tmpTa.HqStartTime.HasValue)
                    {
                        DateTime dtNow = DateTime.Now;
                        DateTime dtTmp = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, tmpTa.HqStartTime.Value.Hour, tmpTa.HqStartTime.Value.Minute, tmpTa.HqStartTime.Value.Second);
                        if (dtNow >= dtTmp)
                        {
                            tmpTa.IsRequired = true;
                        }
                        else
                        {
                            tmpTa.IsRequired = false;
                        }
                    }
                    else
                        tmpTa.IsRequired = true;



                    // 1.源路径是否可访问
                    try
                    {
                        tmpTa.HqStatus = HqStatus.尝试访问源路径;
                        bgWorker.ReportProgress(1);

                        CheckFilePathTimeout timeout = new CheckFilePathTimeout(new DoHandler(_taManager.IsPathAvailabel)); // 委托
                        bool isTimeout = timeout.DoWithTimeout(new TimeSpan(0, 0, 0, 15), tmpTa.SourcePath);       // 超过15秒失败
                        bool isAvailable = timeout.bReturn;     // 是否可访问
                        if (isTimeout == true || isAvailable == false)
                        {
                            tmpTa.IsSourceAvailable = false;
                            tmpTa.HqStatus = HqStatus.访问源路径失败;
                            bgWorker.ReportProgress(1);
                            tmpTa.IsRunning = false;
                            continue;
                        }
                        else
                        {
                            tmpTa.IsSourceAvailable = true;
                            tmpTa.HqStatus = HqStatus.访问源路径成功;
                            bgWorker.ReportProgress(1);
                        }
                    }
                    catch (Exception ex)
                    {
                        tmpTa.IsSourceAvailable = false;
                        tmpTa.HqStatus = HqStatus.访问源路径失败;
                        tmpTa.IsRunning = false;

                        UserState us = new UserState(true, string.Format("TA {0}尝试访问源路径出错: {1}", tmpTa.Id, ex.Message));
                        bgWorker.ReportProgress(1, us);
                        continue;
                    }



                    // 2.按照hqrootmove配置移动文件（0:不移动 1:根目录都移动 2:指定子文件夹移动到根目录）
                    try
                    {
                        tmpTa.HqStatus = HqStatus.文件移动到根目录中;
                        bgWorker.ReportProgress(1);

                        tmpTa.MoveFilesToRoot();

                        tmpTa.HqStatus = HqStatus.文件移动到根目录完成;
                        bgWorker.ReportProgress(1);
                    }
                    catch (Exception ex)
                    {
                        tmpTa.HqStatus = HqStatus.文件移动到根目录错误;
                        tmpTa.IsRunning = false;

                        UserState us = new UserState(true, string.Format("TA {0}文件移动到根目录出错: {1}", tmpTa.Id, ex.Message));
                        bgWorker.ReportProgress(1, us);
                        continue;
                    }




                    // 3.解析索引文件，获取文件列表
                    try
                    {
                        switch (tmpTa.HqCheckType)
                        {
                            case HqCheckType.通过索引文件:
                                {
                                    // 判断索引文件是否存在，然后解析文件列表
                                    string idxFilePath = Path.Combine(tmpTa.SourcePath, tmpTa.IdxFile);
                                    if (!File.Exists(idxFilePath))
                                    {
                                        tmpTa.HqStatus = HqStatus.行情索引文件不存在;
                                        tmpTa.IsRunning = false;
                                        bgWorker.ReportProgress(1);
                                        continue;
                                    }
                                    else
                                    {
                                        // 清空hqFiles，解析文件，填入
                                        tmpTa.ParseIdxFile();
                                    }

                                    break;
                                }

                            case HqCheckType.通过文件列表:
                                {
                                    // 什么都不用做，构造函数已经填进去了
                                    break;
                                }
                        }

                        tmpTa.IsIdxFileParse = true;
                    }
                    catch (Exception ex)
                    {
                        tmpTa.IsIdxFileParse = false;
                        UserState us = new UserState(true, string.Format("TA {0}解析索引文件出错: {1}", tmpTa.Id, ex.Message));
                        tmpTa.IsRunning = false;
                        bgWorker.ReportProgress(1, us);
                        continue;
                    }



                    // 4.判断行情文件是否到齐
                    tmpTa.HqStatus = HqStatus.文件检查中;
                    bgWorker.ReportProgress(1);

                    tmpTa.UpdateFileExistsStatus();

                    if (!tmpTa.IsAllFileArrived)
                    {
                        tmpTa.IsRunning = false;
                        tmpTa.HqStatus = HqStatus.文件未收齐;
                        bgWorker.ReportProgress(1);
                        continue;
                    }
                    else
                    {
                        tmpTa.HqStatus = HqStatus.文件已收齐;
                        bgWorker.ReportProgress(1);
                    }



                    // 5.如果需要拷贝，则拷贝(多目的地)
                    if (tmpTa.DestPaths.Count > 0)
                    {
                        try
                        {
                            tmpTa.HqStatus = HqStatus.文件拷贝中;
                            bgWorker.ReportProgress(1);

                            tmpTa.FileMove();

                            tmpTa.HqStatus = HqStatus.文件拷贝完成;
                            bgWorker.ReportProgress(1);
                        }
                        catch (Exception ex)
                        {
                            tmpTa.HqStatus = HqStatus.文件拷贝失败;
                            UserState us = new UserState(true, string.Format("TA {0}文件拷贝出错: {1}", tmpTa.Id, ex.Message));
                            bgWorker.ReportProgress(1, us);
                        }
                    }



                    // 最终
                    if (tmpTa.IsOK)
                    {
                        tmpTa.HqStatus = HqStatus.完成;
                    }

                    // 结束
                    tmpTa.IsRunning = false;
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
                for (int i = 0; i < _taManager.TaHqList.Count; i++)
                {
                    _taManager.TaHqList[i].IsRunning = false;
                }
            }
            else
            {
                UpdateHqList();


                //// 处理状态标签
                //lbStatus.Text = "完成，等待下一轮";
                //lbStatus.BackColor = Color.ForestGreen;
            }

            // 输出日志(进度百分数)
            Print_Hq_Error_Message(string.Format(@"检查完毕: 全部进度({0}/{1}), 必收进度({0}/{3}), 是否完成: {2}.",
                _taManager.TaHqOKCnt,
                _taManager.TaHqList.Count,
                _taManager.IsHqAllOK ? "是" : "否",
                _taManager.TaHqRequiredOKCnt
                ));


            // 输出日志(未就绪文件)
            string strMissedTas = string.Empty;
            StringBuilder sb = new StringBuilder();
            sb.Append("以下TA行情未就绪:");
            foreach (TaHq taHq in _taManager.TaHqNotPreparedList)
            {
                sb.Append(" " + taHq.Id);
                if (taHq.IsRequired == false)
                    sb.Append("(时间未到)");
            }
            if (sb.Length > 0)
                strMissedTas = "以下TA行情未就绪:" + sb.ToString();

            if (strMissedTas.Length > 0)
                Print_Hq_Error_Message(sb.ToString());



            lbIsHqRunning.Text = "运行完毕";
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
                // 防止闪烁
                if (preToolTipPoint.X != e.X || preToolTipPoint.Y != e.Y)
                {
                    ListViewItem lvi = lvHqList.GetItemAt(e.X, e.Y);
                    if (lvi != null)
                        toolTip.Show(((TaHq)lvi.Tag).HqToolTip, lvHqList, new Point(e.X + 30, e.Y + 20), 200000);
                    else
                        toolTip.Hide(lvHqList);
                }

                preToolTipPoint = e.Location;
            }
            catch
            { }
        }

        private void ctxHq_Opening(object sender, CancelEventArgs e)
        {
            // 右键没选中不弹出
            int i = lvHqList.SelectedItems.Count;
            if (i <= 0)
                e.Cancel = true;
        }

        private void ctxHqModify_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = lvHqList.SelectedItems[0];
            if (lvi != null)
            {
                string taId = ((TaHq)lvi.Tag).Id;
                FrmCfg frmHqCfg = new FrmCfg(taId);
                frmHqCfg.ShowDialog();
            }
        }

        #endregion 行情检查逻辑







        #region 清算处理逻辑

        private void InitQsList()
        {
            //lvQsList.Items.Clear();
            //for (int i = 0; i < _taManager.TaList.Count; i++)
            //{
            //    ListViewItem lvi = new ListViewItem((i + 1).ToString());
            //    lvi.SubItems.Add(_taManager.TaList[i].Id);
            //    lvi.SubItems.Add(_taManager.TaList[i].Desc);
            //    lvi.SubItems.Add(_taManager.TaList[i].Source);
            //    lvi.SubItems.Add(_taManager.TaList[i].QsMoveStr);
            //    lvi.SubItems.Add(_taManager.TaList[i].QsStatus.ToString());
            //    lvi.SubItems.Add(string.Empty);
            //    lvi.SubItems.Add(string.Empty);
            //    lvi.SubItems.Add(string.Empty);
            //    lvi.Tag = _taManager.TaList[i];

            //    lvQsList.Items.Add(lvi);


            //    lvQsList.Columns[0].Width = -1;
            //    //lvQsList.Columns[1].Width = -1;
            //    //lvQsList.Columns[2].Width = -1;
            //    //lvQsList.Columns[3].Width = -1;
            //    //lvQsList.Columns[4].Width = -1;
            //    //lvQsList.Columns[5].Width = -1;
            //    //lvQsList.Columns[6].Width = -1;
            //}
        }

        private void UpdateQsList()
        {
            //lvQsList.BeginUpdate();
            //// 进度列表
            //try
            //{
            //    for (int i = 0; i < _taManager.TaList.Count; i++)
            //    {
            //        Ta tmpTa = (Ta)lvQsList.Items[i].Tag;   // 配置对象
            //        lvQsList.Items[i].SubItems[5].Text = tmpTa.QsStatus.ToString();             // 状态
            //        lvQsList.Items[i].SubItems[6].Text = tmpTa.IsQsFileExists ? "√" : "×";      // 行情文件到齐
            //        lvQsList.Items[i].SubItems[7].Text = tmpTa.IsQsOK ? "√" : "×";              // 标志到齐


            //        if (tmpTa.IsQsRunning)
            //        {
            //            lvQsList.Items[i].BackColor = Color.LightBlue;
            //            lvQsList.Items[i].EnsureVisible();
            //        }
            //        else
            //        {
            //            lvQsList.Items[i].BackColor = SystemColors.Window;
            //        }
            //    }

            //    lbIsQsAllOK.Text = _taManager.IsQsAllOK ? "是" : "否";
            //}
            //catch (Exception)
            //{
            //    // ui异常过滤
            //}

            //lvQsList.EndUpdate();

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
            /* 1.源路径是否可访问
             * 2.按照rootmove配置移动文件
             * 3.拼接文件路径，判断文件是否存在
             * 4.如果需要拷贝，则拷贝(多目的地)
             * 5.处理CIL文件
             */

            //try
            //{
            //    BackgroundWorker bgWorker = sender as BackgroundWorker;

            //    foreach (Ta tmpTa in _taManager.TaList)
            //    {

            //        if (true == bgWorker.CancellationPending)
            //        {
            //            e.Cancel = true;
            //            return;
            //        }



            //        // 0.开始
            //        tmpTa.IsQsRunning = true;
            //        bgWorker.ReportProgress(1);
            //        Thread.Sleep(50);

            //        // 1.源路径是否可访问
            //        try
            //        {
            //            tmpTa.QsStatus = QsStatus.尝试访问源路径;
            //            bgWorker.ReportProgress(1);

            //            CheckFilePathTimeout timeout = new CheckFilePathTimeout(new DoHandler(_taManager.IsSourcePathAvailabel)); // 委托
            //            bool isTimeout = timeout.DoWithTimeout(new TimeSpan(0, 0, 0, 10), tmpTa.Source);       // 超过10秒失败
            //            bool isAvailable = timeout.bReturn;     // 是否可访问
            //            if (isTimeout == true || isAvailable == false)
            //            {
            //                tmpTa.IsQsSourceAvailable = false;
            //                tmpTa.QsStatus = QsStatus.无法访问源路径;
            //                bgWorker.ReportProgress(1);
            //            }
            //            else
            //            {
            //                tmpTa.IsQsSourceAvailable = true;
            //                tmpTa.QsStatus = QsStatus.访问源路径成功;
            //                bgWorker.ReportProgress(1);
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            UserState us = new UserState(true, string.Format("TA {0}尝试访问源路径出错: {1}", tmpTa.Id, ex.Message));
            //            bgWorker.ReportProgress(1, us);
            //        }



            //        // 2.按照rootmove配置移动文件（把子目录中的文件都移动到根目录）
            //        if (tmpTa.IsQsSourceAvailable)
            //        {
            //            try
            //            {
            //                tmpTa.QsStatus = QsStatus.文件移动到根目录中;
            //                bgWorker.ReportProgress(1);

            //                _taManager.RootMove(tmpTa);

            //                tmpTa.QsStatus = QsStatus.文件移动到根目录完成;
            //                tmpTa.IsQsRootMoveOK = true;
            //                bgWorker.ReportProgress(1);
            //            }
            //            catch (Exception ex)
            //            {
            //                tmpTa.QsStatus = QsStatus.文件移动到根目录错误;
            //                tmpTa.IsQsRootMoveOK = false;
            //                UserState us = new UserState(true, string.Format("TA {0}文件移动到根目录出错: {1}", tmpTa.Id, ex.Message));
            //                bgWorker.ReportProgress(1, us);
            //            }
            //        }



            //        // 3.拼接文件路径，判断行情文件是否到齐
            //        if (tmpTa.IsQsSourceAvailable)
            //        {
            //            tmpTa.QsStatus = QsStatus.文件检查中;
            //            bgWorker.ReportProgress(1);

            //            tmpTa.IsQsFileExists = _taManager.IsQsFlagFileExists(tmpTa);
            //            tmpTa.QsStatus = tmpTa.IsQsFileExists == true ? QsStatus.文件已收齐 : QsStatus.文件未收齐;
            //            bgWorker.ReportProgress(1);
            //            if (!tmpTa.IsQsFileExists)
            //            {
            //                tmpTa.IsQsRunning = false;
            //                tmpTa.QsStatus = QsStatus.文件未收齐;
            //                bgWorker.ReportProgress(1);
            //                continue;
            //            }
            //            else
            //            {
            //                tmpTa.QsStatus = QsStatus.文件已收齐;
            //                bgWorker.ReportProgress(1);
            //            }
            //        }



            //        // 4.如果需要拷贝，则拷贝(多目的地)
            //        if (tmpTa.IsQsSourceAvailable && tmpTa.IsQsNeedMove)
            //        {
            //            try
            //            {
            //                tmpTa.QsStatus = QsStatus.文件拷贝中;
            //                bgWorker.ReportProgress(1);

            //                _taManager.QsMove(tmpTa);

            //                tmpTa.QsStatus = QsStatus.文件拷贝完成;
            //                tmpTa.IsQsCopyOK = true;
            //                bgWorker.ReportProgress(1);
            //            }
            //            catch (Exception ex)
            //            {
            //                tmpTa.QsStatus = QsStatus.文件拷贝失败;
            //                tmpTa.IsQsCopyOK = false;
            //                UserState us = new UserState(true, string.Format("TA {0}文件拷贝出错: {1}", tmpTa.Id, ex.Message));
            //                bgWorker.ReportProgress(1, us);
            //            }
            //        }



            //        // 5.CIL文件是否到齐


            //        // 6.CIL文件修改文件日期
            //        foreach (string strTmpFile in tmpTa.QsCILFiles)
            //        {
            //            try
            //            {
            //                string strTmpPath = Path.Combine(tmpTa.Source, strTmpFile);
            //                if (!File.Exists(strTmpPath))
            //                {
            //                    UserState us = new UserState(true, string.Format(@"TA {0}修改ETF退补款文件出错: 文件{1}不存在.", tmpTa.Id, strTmpFile));
            //                    bgWorker.ReportProgress(1, us);
            //                }
            //                else
            //                {
            //                    File.SetLastWriteTime(strTmpPath, _taManager.DateNow);
            //                }
            //            }
            //            catch (Exception ex)
            //            {
            //                UserState us = new UserState(true, string.Format("TA {0}修改ETF退补款{1}文件出错: {2}", tmpTa.Id, strTmpFile, ex.Message));
            //                bgWorker.ReportProgress(1, us);
            //            }
            //        }



            //        // 7.CIL文件拷贝



            //        // 最终
            //        if (tmpTa.IsQsOK)
            //        {
            //            tmpTa.QsStatus = QsStatus.完成;
            //        }

            //        // 结束
            //        tmpTa.IsQsRunning = false;
            //        bgWorker.ReportProgress(1);
            //    }


            //    e.Result = true;
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}
        }

        private void bwQs_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState != null)
            {
                UserState us = (UserState)e.UserState;
                if (us.HasError)
                    Print_Qs_Error_Message(us.ErrorMsg);
            }


            try
            {
                UpdateQsList();
            }
            catch (Exception ex)
            {
                Print_Qs_Error_Message(ex.Message);
            }
        }

        private void bwQs_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)    // 未处理的异常，需要弹框
            {
                Print_Qs_Error_Message(e.Error.Message);
                MessageBox.Show(e.Error.Message);

                //lbStatus.Text = "异常停止";
                //lbStatus.BackColor = Color.Red;
            }
            else if (e.Cancelled)
            {
                Print_Qs_Error_Message("任务被手工取消");

                //lbStatus.Text = "手工停止";
                //lbStatus.BackColor = Color.Red;

                // 状态清空
                //for (int i = 0; i < _taManager.TaList.Count; i++)
                //{
                //    _taManager.TaList[i].IsQsRunning = false;
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

            btnQsExecute.Text = "执行";
        }

        private void Print_Qs_Error_Message(string message)
        {
            tbQsLog.Text = string.Format("{0}:{1}", DateTime.Now.ToString("HH:mm:ss"), message) + System.Environment.NewLine + tbQsLog.Text;
        }






        #endregion 清算处理逻辑






    }
}
