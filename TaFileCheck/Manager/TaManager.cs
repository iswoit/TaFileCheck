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
                foreach (XmlNode tmpXnl in hqFilesNode.ChildNodes)
                {
                    _hqFilesList.Add(tmpXnl.InnerText.Trim());
                }

                // 直接找qsfiles子节点
                XmlNode qsFilesNode = rootNode.SelectSingleNode("//qsfiles");
                foreach (XmlNode tmpXnl in qsFilesNode.ChildNodes)
                {
                    _qsFileList.Add(tmpXnl.InnerText.Trim());
                }

                // 直接找talist子节点。形成ta对象，加入到TaManager列表。
                XmlNode taListNode = rootNode.SelectSingleNode("//talist");
                foreach (XmlNode tmpXnl in taListNode.ChildNodes)
                {
                    // 开始生成对象
                }



                //foreach (XmlNode tmpXnl in rootNode.ChildNodes)     // 遍历每一个子节点
                //{

                //    if (tmpXnl.Name.ToLower().Trim() == "file_source")  // 只能是file_source节点
                //    {
                //        string enable = string.Empty;
                //        string name = string.Empty;
                //        string originPath = string.Empty;
                //        string destPath = string.Empty;
                //        string flagFiles = string.Empty;
                //        string filePattern = string.Empty;
                //        string noCopy = string.Empty;


                //        XmlElement xe = (XmlElement)tmpXnl;
                //        enable = xe.GetAttribute("enable");     // 启用标志（只要不是enable="false"，都算启用）
                //        for (int i = 0; i < xe.ChildNodes.Count; i++)
                //        {
                //            switch (xe.ChildNodes[i].Name.ToLower().Trim())
                //            {
                //                case "name":    // 配置名
                //                    name = xe.ChildNodes[i].InnerText;
                //                    break;
                //                case "source":  // 源路径
                //                    originPath = xe.ChildNodes[i].InnerText;
                //                    break;
                //                case "dest":    // 目标路径
                //                    destPath = xe.ChildNodes[i].InnerText;
                //                    break;
                //                case "flag":    // 标志文件
                //                    flagFiles = xe.ChildNodes[i].InnerText;
                //                    break;
                //                case "pattern": // 拷贝文件
                //                    filePattern = xe.ChildNodes[i].InnerText;
                //                    break;
                //                case "nocopy":
                //                    noCopy = xe.ChildNodes[i].InnerText;
                //                    break;
                //            }
                //        }


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
    }
}
