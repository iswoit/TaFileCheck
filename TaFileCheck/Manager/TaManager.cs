using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace TaFileCheck
{
    public class TaManager
    {
        private List<Ta> _taList = new List<Ta>();                  // ta对象集合
        private List<string> _hqFilesList = new List<string>();     // 行情必收文件通配符
        private List<string> _qsFileList = new List<string>();      // 清算必收文件通配符

        public TaManager()
        {
            _taList = new List<Ta>();
            _hqFilesList = new List<string>();
            _qsFileList = new List<string>();

            // 判断配置文件是否存在，不存在抛出异常
            if (!File.Exists(Path.Combine(Environment.CurrentDirectory, "cfg.xml")))
                throw new Exception("未能找到配置文件cfg.xml，请重新配置该文件后重启程序!");

            // 读取文件
            XmlDocument doc = new XmlDocument();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;     //忽略文档里面的注释
            using (XmlReader reader = XmlReader.Create(@"cfg.xml", settings))
            {
                doc.Load(reader);

                // 根据配置文件，生成对象
                XmlNode rootNode = doc.SelectSingleNode("tas");   // 根节点
                if (rootNode == null)
                    throw new Exception("无法找到配置文件的根节点<tas>，请检查配置文件格式是否正确!");

                // 直接找hqfiles子节点。形成行情检查必收list
                XmlNode hqFilesNode = rootNode.SelectSingleNode("//hqfiles");
                _hqFilesList = new List<string>();
                if (hqFilesNode != null)
                {
                    foreach (XmlNode tmpXnl in hqFilesNode.ChildNodes)
                    {
                        _hqFilesList.Add(tmpXnl.InnerText.Trim());
                    }
                }

                // 直接找qsfiles子节点
                XmlNode qsFilesNode = rootNode.SelectSingleNode("//qsfiles");
                _qsFileList = new List<string>();
                if (qsFilesNode != null)
                {
                    foreach (XmlNode tmpXnl in qsFilesNode.ChildNodes)
                    {
                        _qsFileList.Add(tmpXnl.InnerText.Trim());
                    }
                }
                // 直接找talist子节点。形成ta对象，加入到TaManager列表。
                XmlNode taListNode = rootNode.SelectSingleNode("//talist");
                _taList = new List<Ta>();
                if (taListNode != null)
                {
                    foreach (XmlNode tmpTaXmlNode in taListNode.ChildNodes) // 循环talist下的子节点
                    {
                        if (tmpTaXmlNode.Name.Trim().ToLower() == "ta")   // 如果子节点名字是ta，开始遍历attribute
                        {
                            // 读取配置
                            string id = string.Empty;
                            string desc = string.Empty;
                            string source = string.Empty;
                            string rootmove = string.Empty;
                            string hqmove = string.Empty;
                            string qsmove = string.Empty;

                            XmlElement tmpTaXmlEle = (XmlElement)tmpTaXmlNode;
                            for (int i = 0; i < tmpTaXmlEle.ChildNodes.Count; i++)
                            {
                                switch (tmpTaXmlEle.ChildNodes[i].Name.ToLower().Trim())
                                {
                                    case "id":    // TA代码
                                        id = tmpTaXmlEle.ChildNodes[i].InnerText;
                                        break;
                                    case "desc":  // 描述
                                        desc = tmpTaXmlEle.ChildNodes[i].InnerText;
                                        break;
                                    case "source":    // 源路径
                                        source = tmpTaXmlEle.ChildNodes[i].InnerText;
                                        break;
                                    case "rootmove":    // 是否把子目录文件移动到根目录
                                        rootmove = tmpTaXmlEle.ChildNodes[i].InnerText;
                                        break;
                                    case "hqmove": // 行情文件是否需要移动
                                        hqmove = tmpTaXmlEle.ChildNodes[i].InnerText;
                                        break;
                                    case "qsmove":  // 清算文件是否需要移动
                                        qsmove = tmpTaXmlEle.ChildNodes[i].InnerText;
                                        break;
                                }
                            }


                            // 开始生成对象
                            Ta tmpTa = new Ta(id, desc, source, rootmove, hqmove, _hqFilesList);
                            _taList.Add(tmpTa);

                        }//eof if ta
                    }//eof foreach
                }//eof if taListNode not null





                //        // 生成对象
                //        FileSource tmpFileSource = new FileSource(
                //            enable,
                //            name,
                //            originPath.Trim(),
                //            destPath.Trim(),
                //            flagFiles.Trim(),
                //            filePattern.Trim(),
                //            noCopy);

                //        // 创建目标路径
                //        if (!Directory.Exists(destPath.Trim()))
                //            Directory.CreateDirectory(destPath.Trim());

                //        // 对象加入列表
                //        _fileSourceList.Add(tmpFileSource);
                //    }
                //}
            }
        }


        #region 属性
        /// <summary>
        /// 获取TA列表
        /// </summary>
        public List<Ta> TaList
        {
            get { return _taList; }
        }
        #endregion 属性
    }
}
