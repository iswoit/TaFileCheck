using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace TaFileCheck
{
    public partial class FrmCfg : Form
    {
        string _taID;       // 暂存taId

        public FrmCfg(string taId)
        {
            InitializeComponent();

            try
            {
                _taID = taId;
                InitHqForm(taId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// 初始化界面元素
        /// </summary>
        /// <param name="taHq"></param>
        private void InitHqForm(string taId)
        {
            string id = string.Empty;                                   // ta代码
            string desc = string.Empty;                                 // 备注（仅仅显示）
            string rootMove = string.Empty;                             // 文件移动到根目录
            List<string> rootMovePath = new List<string>();             // 针对rootMove=2的，存路径

            string hqSource = string.Empty;
            string hqchecktype = string.Empty;
            List<string> hqFiles = new List<string>();
            List<string> hqDestPath = new List<string>();
            string hqStartTime = string.Empty;                          // 行情开始检查时间

            XmlDocument doc = new XmlDocument();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;     //忽略文档里面的注释
            using (XmlReader reader = XmlReader.Create(@"cfg.xml", settings))
            {
                doc.Load(reader);

                XmlNode xnTa = doc.SelectSingleNode(string.Format(@"/config/talist/ta[id='{0}']", taId));
                if (xnTa != null)
                {
                    foreach (XmlNode xnTaAttr in xnTa)
                    {
                        switch (xnTaAttr.Name.ToLower().Trim())
                        {
                            case "id":
                                id = xnTaAttr.InnerText;
                                break;
                            case "desc":
                                desc = xnTaAttr.InnerText;
                                break;
                            case "hqsource":
                                hqSource = xnTaAttr.InnerText.Trim();
                                break;
                            case "hqrootmove":
                                rootMove = xnTaAttr.InnerText.Trim();
                                break;
                            case "hqrootmovepath":
                                if (xnTaAttr.ChildNodes.Count > 0)
                                {
                                    rootMovePath.Clear();
                                    foreach (XmlNode xnTaChildAttrValue in xnTaAttr.ChildNodes)
                                    {
                                        if (!string.IsNullOrEmpty(xnTaChildAttrValue.InnerText))
                                            rootMovePath.Add(xnTaChildAttrValue.InnerText);
                                    }
                                }
                                break;

                            case "hqchecktype":
                                hqchecktype = xnTaAttr.InnerText.Trim();
                                break;
                            case "hqfiles":
                                {
                                    if (xnTaAttr.ChildNodes.Count > 0)
                                    {
                                        hqFiles.Clear();
                                        foreach (XmlNode xnTaChildAttrValue in xnTaAttr.ChildNodes)
                                        {
                                            if (!string.IsNullOrEmpty(xnTaChildAttrValue.InnerText))
                                                hqFiles.Add(xnTaChildAttrValue.InnerText);
                                        }
                                    }
                                    break;
                                }
                            case "hqdestpath":
                                {
                                    if (xnTaAttr.ChildNodes.Count > 0)
                                    {
                                        hqDestPath.Clear();
                                        foreach (XmlNode xnTaChildAttrValue in xnTaAttr.ChildNodes)
                                        {
                                            if (!string.IsNullOrEmpty(xnTaChildAttrValue.InnerText))
                                                hqDestPath.Add(xnTaChildAttrValue.InnerText);
                                        }
                                    }
                                    break;
                                }
                            case "hqstarttime":
                                hqStartTime = xnTaAttr.InnerText.Trim();
                                break;
                        }//eof switch ta attr
                    }
                }
                else
                {
                    throw new Exception("配置文件未找到此TA");
                }
            }




            // 改成通过xml文件读取与保存

            tbID.Text = id;
            tbDesc.Text = desc;
            tbSourcePath.Text = hqSource;

            int iRootMove;
            int.TryParse(rootMove, out iRootMove);
            if (iRootMove == 0)
                rbRootMoveNo.Checked = true;
            else if (iRootMove == 1)
                rbRootMoveYes.Checked = true;
            else if (iRootMove == 2)
                rbRootMoveSpecified.Checked = true;

            // 针对rootMove类型是2:自定义的
            foreach (string str in rootMovePath)
            {
                boxRootMovePath.Items.Add(str);
            }


            HqCheckType _hqCheckType;
            int tmpHqCheckType = 0;
            if (!int.TryParse(hqchecktype.Trim(), out tmpHqCheckType))
                throw new Exception(string.Format("hqCheckType参数非法(请参照配置文件注释修改)"));
            _hqCheckType = (HqCheckType)tmpHqCheckType;

            if (_hqCheckType == HqCheckType.通过索引文件)
                rbCheckType0.Checked = true;
            else if (_hqCheckType == HqCheckType.通过文件列表)
            {
                rbCheckType1.Checked = true;

                // 填入listbox
                foreach (string str in hqFiles)
                {
                    boxFileList.Items.Add(str);
                }
            }


            foreach (string str in hqDestPath)
            {
                boxDestPath.Items.Add(str);
            }


            // 20180710-hq检查时间
            DateTime tmpDT;
            if (DateTime.TryParse(hqStartTime, out tmpDT))
            {
                rbSpecificTime.Checked = true;
                nCheckHour.Enabled = true;
                nCheckMinute.Enabled = true;

                nCheckHour.Value = tmpDT.Hour;
                nCheckMinute.Value = tmpDT.Minute;
            }
            else
            {
                rbAnyTime.Checked = true;
                nCheckHour.Enabled = false;
                nCheckMinute.Enabled = false;
            }



        }


        #region 文件检查模式相关

        /// <summary>
        /// 切换文件检查模式事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbCheckType_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCheckType0.Checked)
            {
                boxFileList.Enabled = false;
                tbFileAdd.Enabled = false;
                btnFileAdd.Enabled = false;
                btnFileDel.Enabled = false;
            }
            else if (rbCheckType1.Checked)
            {
                boxFileList.Enabled = true;
                tbFileAdd.Enabled = true;
                btnFileAdd.Enabled = true;
                btnFileDel.Enabled = true;
            }
        }

        private void rbRootMove_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRootMoveNo.Checked || rbRootMoveYes.Checked)
            {
                boxRootMovePath.Enabled = false;
                tbRootMovePathAdd.Enabled = false;
                btnRootMovePathAdd.Enabled = false;
                btnRootMovePathDel.Enabled = false;
            }
            else if (rbRootMoveSpecified.Checked)
            {
                boxRootMovePath.Enabled = true;
                tbRootMovePathAdd.Enabled = true;
                btnRootMovePathAdd.Enabled = true;
                btnRootMovePathDel.Enabled = true;
            }
        }


        /// <summary>
        /// 切换指定检查时间按钮的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbCheckTime(object sender, EventArgs e)
        {
            if (rbAnyTime.Checked)
            {
                nCheckHour.Enabled = false;
                nCheckMinute.Enabled = false;
            }
            else if (rbSpecificTime.Checked)
            {
                nCheckHour.Enabled = true;
                nCheckMinute.Enabled = true;
            }
        }


        private void btnFileAdd_Click(object sender, EventArgs e)
        {
            string strFile = tbFileAdd.Text.Trim();
            if (string.IsNullOrEmpty(strFile))
                return;

            foreach (object x in boxFileList.Items)
            {
                if (string.Compare(x.ToString(), strFile, true) == 0)
                {
                    MessageBox.Show("已经存在同名文件，无法添加!");
                    return;
                }
            }

            boxFileList.Items.Add(strFile);
            tbFileAdd.Text = string.Empty;
        }



        private void btnFileDel_Click(object sender, EventArgs e)
        {
            if (boxFileList.SelectedItem != null)
            {
                DialogResult dr = MessageBox.Show("确定移除?", "确认", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                    boxFileList.Items.Remove(boxFileList.SelectedItem);
            }
        }

        private void btnDestPathDel_Click(object sender, EventArgs e)
        {
            if (boxDestPath.SelectedItem != null)
            {
                DialogResult dr = MessageBox.Show("确定移除?", "确认", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                    boxDestPath.Items.Remove(boxDestPath.SelectedItem);
            }
        }

        private void btnDestPathAdd_Click(object sender, EventArgs e)
        {
            string strPath = tbDestPathAdd.Text.Trim();
            if (string.IsNullOrEmpty(strPath))
                return;

            foreach (object x in boxDestPath.Items)
            {
                if (string.Compare(x.ToString(), strPath, true) == 0)
                {
                    MessageBox.Show("已经存在同名路径，无法添加!");
                    return;
                }
            }

            boxDestPath.Items.Add(strPath);
            tbDestPathAdd.Text = string.Empty;
        }

        private void btnRootMovePathAdd_Click(object sender, EventArgs e)
        {
            string strPath = tbRootMovePathAdd.Text.Trim();
            if (string.IsNullOrEmpty(strPath))
                return;

            // 必须是【路径】字段的子目录
            if (string.IsNullOrEmpty(tbSourcePath.Text.Trim()))
            {
                MessageBox.Show("请先设置\"路径\"后再添加本项目!");
                return;
            }
            else
            {
                if (!strPath.Contains(tbSourcePath.Text.Trim()))
                {
                    MessageBox.Show("设置的路径必须是\"路径\"的子目录!");
                    return;
                }
                else if (string.Compare(strPath, tbSourcePath.Text.Trim(), true) == 0)
                {
                    MessageBox.Show("不能设为根目录!");
                    return;
                }
            }

            // 重复判断
            foreach (object x in boxRootMovePath.Items)
            {
                if (string.Compare(x.ToString(), strPath, true) == 0)
                {
                    MessageBox.Show("已经存在同名路径，无法重复添加!");
                    return;
                }
            }

            boxRootMovePath.Items.Add(strPath);
            tbRootMovePathAdd.Text = string.Empty;
        }

        private void btnRootMovePathDel_Click(object sender, EventArgs e)
        {
            if (boxRootMovePath.SelectedItem != null)
            {
                DialogResult dr = MessageBox.Show("确定移除根目录移动路劲?", "确认", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                    boxRootMovePath.Items.Remove(boxRootMovePath.SelectedItem);
            }
        }

        #endregion 文件检查模式相关

        /// <summary>
        /// 确定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("是否保存修改?", "确认", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    // 逻辑检查
                    // 如果设为2，但是一个路径都没填，报错
                    if (rbRootMoveSpecified.Checked)
                    {
                        if (boxRootMovePath.Items.Count <= 0)
                        {
                            MessageBox.Show("请添加至少一个子文件目录!");
                            return;
                        }
                    }


                    XmlDocument doc = new XmlDocument();
                    XmlReaderSettings settings = new XmlReaderSettings();
                    settings.IgnoreComments = true;     //忽略文档里面的注释
                    using (XmlReader reader = XmlReader.Create(@"cfg.xml", settings))
                    {
                        doc.Load(reader);

                        XmlNode xnTa = doc.SelectSingleNode(string.Format(@"/config/talist/ta[id='{0}']", _taID));
                        if (xnTa != null)
                        {
                            // 清空子节点
                            xnTa.RemoveAll();

                            XmlElement xeNew;  // 临时节点


                            // id
                            xeNew = doc.CreateElement("id");
                            xeNew.InnerText = _taID;
                            xnTa.AppendChild(xeNew);

                            // desc
                            xeNew = doc.CreateElement("desc");
                            xeNew.InnerText = tbDesc.Text.Trim();
                            xnTa.AppendChild(xeNew);

                            // rootmove(0:不移动 1:全部移动 2:指定)
                            xeNew = doc.CreateElement("hqrootmove");
                            int tmpRootMoveValue = 0;
                            if (rbRootMoveNo.Checked)
                                tmpRootMoveValue = 0;
                            else if (rbRootMoveYes.Checked)
                                tmpRootMoveValue = 1;
                            else if (rbRootMoveSpecified.Checked)
                                tmpRootMoveValue = 2;
                            xeNew.InnerText = tmpRootMoveValue.ToString();
                            xnTa.AppendChild(xeNew);

                            // rootmovepath
                            xeNew = doc.CreateElement("hqrootmovepath");
                            if (tmpRootMoveValue == 2)
                            {
                                foreach (object x in boxRootMovePath.Items)
                                {
                                    XmlElement xeNewChild = doc.CreateElement("file");
                                    xeNewChild.InnerText = x.ToString();        // 子路径
                                    xeNew.AppendChild(xeNewChild);
                                }
                            }
                            xnTa.AppendChild(xeNew);


                            // hqsource
                            xeNew = doc.CreateElement("hqsource");
                            xeNew.InnerText = tbSourcePath.Text.Trim();
                            xnTa.AppendChild(xeNew);

                            // hqchecktype
                            string strhqchecktype = string.Empty;
                            if (rbCheckType0.Checked)
                                strhqchecktype = "0";
                            else if (rbCheckType1.Checked)
                                strhqchecktype = "1";
                            xeNew = doc.CreateElement("hqchecktype");
                            xeNew.InnerText = strhqchecktype;
                            xnTa.AppendChild(xeNew);

                            // hqfiles
                            xeNew = doc.CreateElement("hqfiles");
                            foreach (object x in boxFileList.Items)
                            {
                                XmlElement xeNewChild = doc.CreateElement("file");
                                xeNewChild.InnerText = x.ToString();
                                xeNew.AppendChild(xeNewChild);
                            }
                            xnTa.AppendChild(xeNew);

                            // hqdestpath
                            xeNew = doc.CreateElement("hqdestpath");
                            foreach (object x in boxDestPath.Items)
                            {
                                XmlElement xeNewChild = doc.CreateElement("path");
                                xeNewChild.InnerText = x.ToString();
                                xeNew.AppendChild(xeNewChild);
                            }
                            xnTa.AppendChild(xeNew);


                            // hqstarttime（开始检查时间）
                            xeNew = doc.CreateElement("hqstarttime");
                            string strHqStartTime = string.Empty;
                            if (rbAnyTime.Checked)
                            {
                                strHqStartTime = String.Empty;
                            }
                            else if (rbSpecificTime.Checked)
                            {
                                strHqStartTime = string.Format("{0}:{1}", nCheckHour.Value.ToString(), nCheckMinute.Value.ToString());
                            }

                            xeNew.InnerText = strHqStartTime;
                            xnTa.AppendChild(xeNew);

                        }
                        else
                        {
                            throw new Exception("配置文件未找到此TA");
                        }
                    }


                    doc.Save(Path.Combine(Environment.CurrentDirectory, "cfg.xml"));
                    MessageBox.Show("修改完成，请重启程序使配置生效.");
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
