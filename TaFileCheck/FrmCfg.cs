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
            string rootMove = string.Empty;

            string hqSource = string.Empty;
            string hqchecktype = string.Empty;
            List<string> hqFiles = new List<string>();
            List<string> hqDestPath = new List<string>();

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
                            case "rootmove":
                                rootMove = xnTaAttr.InnerText.Trim();
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

            bool bRootMove = false;
            bool.TryParse(rootMove, out bRootMove);
            if (bRootMove)
                rbRootMoveYes.Checked = true;
            else
                rbRootMoveNo.Checked = true;


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

        #endregion 文件检查模式相关

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

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("是否保存修改?", "确认", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
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

                            // rootmove
                            xeNew = doc.CreateElement("rootmove");
                            xeNew.InnerText = rbRootMoveYes.Checked ? "true" : "false";
                            xnTa.AppendChild(xeNew);

                            // hqsource
                            xeNew = doc.CreateElement("hqsource");
                            xeNew.InnerText = tbSourcePath.Text.Trim();
                            xnTa.AppendChild(xeNew);

                            // checktype
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
