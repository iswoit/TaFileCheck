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



        #region 方法


        /// <summary>
        /// 构造函数
        /// </summary>
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
                            string id = string.Empty;                                   // ta代码
                            string desc = string.Empty;                                 // 备注（仅仅显示）
                            string source = string.Empty;                               // 源路径
                            string rootmove = string.Empty;                             // 是否需要把文件移动到根目录

                            List<string> _hqFilesList_tmp = new List<string>();         // 行情全局变量先往临时list里填，如果发现替换节点，后续会清空替换
                            foreach (string strTmp in _hqFilesList)                     // 
                            {
                                _hqFilesList_tmp.Add(strTmp);
                            }
                            string hqmove = string.Empty;                               // 行情文件检查后是否需要移动

                            List<string> _qsFilesList_tmp = new List<string>();          // 清算全局变量先往临时list里填，如果发现替换节点，后续会清空替换
                            foreach (string strTmp in _qsFileList)
                            {
                                _qsFilesList_tmp.Add(strTmp);
                            }
                            string qsmove = string.Empty;                               // 清算文件检查后是否需要移动




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
                                    case "hqfiles":     // 行情文件替换(用来替换全局)
                                        {
                                            XmlNode hqFilesNode_substitute = tmpTaXmlEle.ChildNodes[i];
                                            if (hqFilesNode_substitute.ChildNodes.Count > 0)
                                            {
                                                _hqFilesList_tmp.Clear();
                                                foreach (XmlNode tmpXnl in hqFilesNode_substitute.ChildNodes)
                                                {
                                                    _hqFilesList_tmp.Add(tmpXnl.InnerText.Trim());
                                                }
                                            }
                                            break;
                                        }
                                    case "hqmove": // 行情文件是否需要移动
                                        hqmove = tmpTaXmlEle.ChildNodes[i].InnerText;
                                        break;
                                    case "qsfiles":     // 清算文件替换(用来替换全局)
                                        {
                                            XmlNode qsFilesNode_substitute = tmpTaXmlEle.ChildNodes[i];
                                            if (qsFilesNode_substitute.ChildNodes.Count > 0)
                                            {
                                                _qsFilesList_tmp.Clear();
                                                foreach (XmlNode tmpXnl in qsFilesNode_substitute.ChildNodes)
                                                {
                                                    _qsFilesList_tmp.Add(tmpXnl.InnerText.Trim());
                                                }
                                            }
                                            break;
                                        }
                                    case "qsmove":  // 清算文件是否需要移动
                                        qsmove = tmpTaXmlEle.ChildNodes[i].InnerText;
                                        break;
                                }
                            }


                            // 开始生成对象
                            Ta tmpTa = new Ta(id, desc, source, rootmove, _hqFilesList_tmp, hqmove, _qsFilesList_tmp, qsmove);
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

        /// <summary>
        /// 源路径是否可以访问
        /// </summary>
        /// <param name="ta"></param>
        /// <returns></returns>
        public bool IsSourcePathAvailabel(string strPath)
        {
            if (Directory.Exists(Util.Filename_Date_Convert(strPath)))
            {
                return true;
            }
            else
                return false;
        }



        /// <summary>
        /// 把子目录的文件都移动到根目录
        /// </summary>
        /// <param name="path"></param>
        private void MoveFilesToRoot(DirectoryInfo dirRoot)
        {
            Queue<DirectoryInfo> queue = new Queue<DirectoryInfo>();

            dirRoot.GetFiles();
            dirRoot.GetDirectories();

            queue.Enqueue(dirRoot);
            while (queue.Count != 0)
            {
                DirectoryInfo tmpDir = queue.Dequeue();

                // 对于文件，移到根目录（但是排除根目录的文件）
                if (!string.Equals(dirRoot.FullName, tmpDir.FullName, StringComparison.CurrentCultureIgnoreCase))
                {
                    FileInfo[] tmpSubFiles = tmpDir.GetFiles();
                    foreach (FileInfo tmpSubFile in tmpSubFiles)
                    {
                        // 已经存在就删除，覆盖拷贝
                        if (File.Exists(Path.Combine(dirRoot.FullName, tmpSubFile.Name)))
                            File.Delete(Path.Combine(dirRoot.FullName, tmpSubFile.Name));

                        tmpSubFile.MoveTo(Path.Combine(dirRoot.FullName, tmpSubFile.Name));
                    }
                }

                // 对于文件夹，加入队列进行循环
                DirectoryInfo[] tmpSubDirs = tmpDir.GetDirectories();
                foreach (DirectoryInfo tmpSubDir in tmpSubDirs)
                {
                    queue.Enqueue(tmpSubDir);
                }
            }
        }



        /// <summary>
        /// 文件移动到根目录
        /// </summary>
        /// <param name="ta"></param>
        public void RootMove(Ta ta)
        {
            if (ta.RootMove == true)
            {
                DirectoryInfo di = new DirectoryInfo(Util.Filename_Date_Convert(ta.Source));
                MoveFilesToRoot(di);
            }
        }



        /// <summary>
        /// 行情标志文件是否存在
        /// </summary>
        /// <param name="ta"></param>
        /// <returns></returns>
        public bool IsHqFlagFileExists(Ta ta)
        {
            bool bIsArrived = true;
            ta.HqMissingFiles.Clear();
            foreach (string strTmpFile in ta.HqFiles)
            {
                if (!File.Exists(Path.Combine(ta.Source, strTmpFile)))
                {
                    bIsArrived = false;
                    ta.HqMissingFiles.Add(strTmpFile);
                }
            }

            return bIsArrived;
        }



        /// <summary>
        /// 行情文件检查后移动
        /// </summary>
        /// <param name="ta"></param>
        public void HqMove(Ta ta)
        {
            foreach (string strTmpDestPath in ta.HqMove)  // 遍历目的地
            {
                if (Directory.Exists(strTmpDestPath))
                {
                    foreach (string strTmpFile in ta.HqFiles)
                    {
                        File.Copy(Path.Combine(ta.Source, strTmpFile),
                            Path.Combine(strTmpDestPath, strTmpFile),
                            true);
                    }
                }
                else
                {
                    throw new Exception(string.Format("路径{0}不存在", strTmpDestPath));
                }
            }
        }




        public bool IsQsFlagFileExists(Ta ta)
        {
            bool bIsArrived = true;
            ta.QsMissingFiles.Clear();
            foreach (string strTmpFile in ta.QsFiles)
            {
                if (!File.Exists(Path.Combine(ta.Source, strTmpFile)))
                {
                    bIsArrived = false;
                    ta.QsMissingFiles.Add(strTmpFile);
                }
            }

            return bIsArrived;
        }



        #endregion 方法




        #region 属性
        /// <summary>
        /// 获取TA列表
        /// </summary>
        public List<Ta> TaList
        {
            get { return _taList; }
        }


        /// <summary>
        /// TA行情文件全就绪
        /// </summary>
        public bool IsHqAllOK
        {
            get
            {
                foreach (Ta tmpTa in TaList)
                {
                    if (!tmpTa.IsHqOK)
                        return false;
                }

                return true;
            }
        }


        public void QsMove(Ta ta)
        {
            foreach (string strTmpDestPath in ta.QsMove)  // 遍历目的地
            {
                if (Directory.Exists(strTmpDestPath))
                {
                    foreach (string strTmpFile in ta.QsFiles)
                    {
                        File.Copy(Path.Combine(ta.Source, strTmpFile),
                            Path.Combine(strTmpDestPath, strTmpFile),
                            true);
                    }
                }
                else
                {
                    throw new Exception(string.Format("路径{0}不存在", strTmpDestPath));
                }
            }
        }


        public bool IsQsAllOK
        {
            get
            {
                foreach (Ta tmpTa in TaList)
                {
                    if (!tmpTa.IsQsOK)
                        return false;
                }

                return true;
            }
        }

        #endregion 属性
    }
}
