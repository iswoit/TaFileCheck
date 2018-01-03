using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace TaFileCheck
{
    public partial class FrmHqCfg : Form
    {
        public FrmHqCfg(TaHq taHq)
        {
            InitializeComponent();

            try
            {
                InitHqForm(taHq);
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
        private void InitHqForm(TaHq taHq)
        {
            bool foundInXml = false;    // 是否在xml中找到
            string id = string.Empty;                                   // ta代码
            string desc = string.Empty;                                 // 备注（仅仅显示）
            string rootMove = string.Empty;

            string hqSource = string.Empty;
            string hqchecktype = string.Empty;
            List<string> hqFiles = new List<string>();
            List<string> hqDestPath = new List<string>();


            // 读取配置文件
            XmlDocument doc = new XmlDocument();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;     //忽略文档里面的注释
            using (XmlReader reader = XmlReader.Create(@"cfg.xml", settings))
            {
                doc.Load(reader);

                // 检查根节点
                XmlNode rootNode = doc.SelectSingleNode("config");   // 根节点
                if (rootNode == null)
                    throw new Exception("无法找到配置文件的根节点<config>，请检查配置文件格式是否正确!");


                // 直接找talist子节点。形成ta对象，加入到TaManager列表。
                XmlNode xnTa = rootNode.SelectSingleNode("//talist");
                if (xnTa != null)
                {
                    foreach (XmlNode xnTaChild in xnTa.ChildNodes) // 循环talist下的子节点
                    {
                        if (foundInXml)
                            break;

                        if (string.Equals(xnTaChild.Name.Trim().ToLower(), "ta", StringComparison.CurrentCultureIgnoreCase))   // 如果子节点名字是ta，开始遍历attribute
                        {
                            foreach (XmlNode xnTaChildAttr in xnTaChild)
                            {
                                switch (xnTaChildAttr.Name.ToLower().Trim())
                                {
                                    case "id":
                                        id = xnTaChildAttr.InnerText;
                                        break;
                                    case "desc":
                                        desc = xnTaChildAttr.InnerText;
                                        break;
                                    case "hqsource":
                                        hqSource = xnTaChildAttr.InnerText.Trim();
                                        break;
                                    case "rootmove":
                                        rootMove = xnTaChildAttr.InnerText.Trim();
                                        break;
                                    case "hqchecktype":
                                        hqchecktype = xnTaChildAttr.InnerText.Trim();
                                        break;
                                    case "hqfiles":
                                        {
                                            if (xnTaChildAttr.ChildNodes.Count > 0)
                                            {
                                                hqFiles.Clear();
                                                foreach (XmlNode xnTaChildAttrValue in xnTaChildAttr.ChildNodes)
                                                {
                                                    if (!string.IsNullOrEmpty(xnTaChildAttrValue.InnerText))
                                                        hqFiles.Add(xnTaChildAttrValue.InnerText);
                                                }
                                            }
                                            break;
                                        }
                                    case "hqdestpath":
                                        {
                                            if (xnTaChildAttr.ChildNodes.Count > 0)
                                            {
                                                hqDestPath.Clear();
                                                foreach (XmlNode xnTaChildAttrValue in xnTaChildAttr.ChildNodes)
                                                {
                                                    if (!string.IsNullOrEmpty(xnTaChildAttrValue.InnerText))
                                                        hqDestPath.Add(xnTaChildAttrValue.InnerText);
                                                }
                                            }
                                            break;
                                        }
                                }//eof switch ta attr
                            }


                            if (string.Equals(id, taHq.Id, StringComparison.CurrentCultureIgnoreCase))
                            {
                                foundInXml = true;
                                break;
                            }

                        }//eof if ta
                    }//eof foreach
                }//eof if taListNode not null

            }



            if (foundInXml == true)
            {
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

                if (taHq.HqCheckType == HqCheckType.通过索引文件)
                    rbCheckType0.Checked = true;
                else if (taHq.HqCheckType == HqCheckType.通过文件列表)
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
                boxFileList.Items.Remove(boxFileList.SelectedItem);
            }
        }

        private void btnDestPathDel_Click(object sender, EventArgs e)
        {
            if (boxDestPath.SelectedItem != null)
            {
                boxDestPath.Items.Remove(boxDestPath.SelectedItem);
            }
        }

        private void btnDestPathAdd_Click(object sender, EventArgs e)
        {
            string strPath = tbDestPathAdd.Text.Trim();
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
            DialogResult dr = MessageBox.Show("是否保存修改?", "确认", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                //
            }
        }
    }
}
