using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace TaFileCheck
{
    public class TaManager
    {
        private List<TaHq> _taHqList;    // ta行情对象列表
        //private List<TaQs> _taQsList = new List<TaQs>();    // ta清算对象列表
        private string _taHqIdx;                                    // ta行情索引文件
        private string _taQsIdx;                                    // ta清算索引文件

        private DateTime _dtNow = DateTime.Now;    // 当前时间

        #region 方法


        /// <summary>
        /// 构造函数
        /// </summary>
        public TaManager()
        {
            _taHqList = new List<TaHq>();

            // 判断配置文件是否存在，不存在抛出异常
            if (!File.Exists(Path.Combine(Environment.CurrentDirectory, "cfg.xml")))
                throw new Exception("未能找到配置文件cfg.xml，请重新配置该文件后重启程序!");

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

                // 找TA行情通配索引
                XmlNode xnHqIdx = rootNode.SelectSingleNode("//hqidx");
                if (xnHqIdx != null)
                    _taHqIdx = Util.Filename_Date_Convert(xnHqIdx.InnerText.Trim());
                else
                    throw new Exception("无法找到配置文件节点<hqidx>(行情索引文件名)，请检查配置文件格式是否正确!");



                // 找TA清算通配索引
                XmlNode xnQsIdx = rootNode.SelectSingleNode("//qsidx");
                if (xnQsIdx != null)
                    _taQsIdx = Util.Filename_Date_Convert(xnQsIdx.InnerText.Trim());
                else
                    throw new Exception("无法找到配置文件节点<qsidx>(清算索引文件名)，请检查配置文件格式是否正确!");


                // 直接找talist子节点。形成ta对象，加入到TaManager列表。
                XmlNode xnTa = rootNode.SelectSingleNode("//talist");
                _taHqList = new List<TaHq>();
                //_taQsList = new List<TaQs>();
                if (xnTa != null)
                {
                    foreach (XmlNode xnTaChild in xnTa.ChildNodes) // 循环talist下的子节点
                    {
                        if (string.Equals(xnTaChild.Name.Trim().ToLower(), "ta", StringComparison.CurrentCultureIgnoreCase))   // 如果子节点名字是ta，开始遍历attribute
                        {
                            // Part1.行情配置
                            string id = string.Empty;                                   // ta代码
                            string desc = string.Empty;                                 // 备注（仅仅显示）
                            string rootMove = string.Empty;

                            string hqSource = string.Empty;
                            string hqchecktype = string.Empty;
                            string hqIdx = _taHqIdx;
                            List<string> hqFiles = new List<string>();
                            List<string> hqDestPath = new List<string>();


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
                                        hqSource = Util.Filename_Date_Convert(xnTaChildAttr.InnerText.Trim());
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
                                                    string tmpValue = Util.Filename_Date_Convert(xnTaChildAttrValue.InnerText.Trim());
                                                    tmpValue = Ta.ReplaceTaFileNameWithPattern(tmpValue, id);
                                                    if (!string.IsNullOrEmpty(tmpValue))
                                                        hqFiles.Add(tmpValue);
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
                                                    string tmpValue = Util.Filename_Date_Convert(xnTaChildAttrValue.InnerText.Trim());
                                                    if (!string.IsNullOrEmpty(tmpValue))
                                                        hqDestPath.Add(tmpValue);
                                                }
                                            }
                                            break;
                                        }
                                }//eof switch ta attr
                            }//eof foreach ta

                            _taHqList.Add(new TaHq(id, desc, hqSource, rootMove, hqchecktype, hqIdx, hqFiles, hqDestPath));


                            // Part2.清算配置（还没写）



                        }//eof if ta
                    }//eof foreach
                }//eof if taListNode not null






            }
        }

        /// <summary>
        /// 源路径是否可以访问
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool IsPathAvailabel(string path)
        {
            if (Directory.Exists(path))
                return true;
            else
                return false;
        }




        #endregion 方法




        #region 属性

        /// <summary>
        /// 获取TA列表
        /// </summary>
        public List<TaHq> TaHqList
        {
            get { return _taHqList; }
        }


        /// <summary>
        /// TA行情文件全就绪
        /// </summary>
        public bool IsHqAllOK
        {
            get
            {
                foreach (TaHq tmpTa in _taHqList)
                {
                    if (!tmpTa.IsOK)
                        return false;
                }

                return true;
            }
        }




        /// <summary>
        /// 当前处理日期
        /// </summary>
        public DateTime DateNow
        {
            get { return _dtNow; }
        }

        #endregion 属性
    }
}
