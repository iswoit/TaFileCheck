using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TaFileCheck
{
    public class TaHq : Ta
    {
        // 行情基本变量
        private string _sourcePath;                          // 行情路径
        private bool _needRootMove;                    // 行情移动到根目录
        private HqCheckType _hqCheckType;              // 行情文件检查模式
        private string _idxFile;                       // 行情索引文件(模式0和模式1用得到)
        private Dictionary<string, bool> _hqFiles;     // 行情文件列表
        private Dictionary<string, bool> _destPaths;   // 行情文件到齐后移动的目的

        // 行情运行变量
        private HqStatus _status;                      // 任务状态
        private bool _isRunning;                       // 行情检查运行中
        private bool _isSourceAvailable;                 // 行情文件源目录是否可以访问
        private bool _isIdxFileParse;                  // 行情索引文件解析完成
        private bool _isAllFilesExist;                 // 所有行情文件都存在(可省略)
        private bool _isCopyOK;                        // 行情文件拷贝完成(可省略)


        private List<string> _hqMissingFiles = new List<string>();  // 缺失的文件列表




        #region***************************方法



        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="desc"></param>
        /// <param name="hqSource"></param>
        /// <param name="hqRootMove"></param>
        /// <param name="hqCheckType"></param>
        /// <param name="idxFile"></param>
        /// <param name="hqFiles"></param>
        /// <param name="hqDestPath"></param>
        public TaHq(string id, string desc, string hqSource, string hqRootMove, string hqCheckType, string idxFile, List<string> hqFiles, List<string> hqDestPath)
        {
            //********1.TA行情配置变量初始化
            _id = id;           // 代码
            _desc = desc;       // 描述
            _sourcePath = hqSource;     // 行情路径

            // 行情移动到根目录
            if (!bool.TryParse(hqRootMove, out _needRootMove))
                _needRootMove = false;

            // 行情文件检查模式
            int tmpHqCheckType = 0;
            if (!int.TryParse(hqCheckType.Trim(), out tmpHqCheckType))
                throw new Exception(string.Format("hqCheckType参数非法(请参照配置文件注释修改)"));
            _hqCheckType = (HqCheckType)tmpHqCheckType;


            // 行情索引
            idxFile = Ta.ReplaceTaFileNameWithPattern(idxFile, id);
            _idxFile = idxFile;

            // 行情文件列表
            _hqFiles = new Dictionary<string, bool>();
            foreach (string tmpStr in hqFiles)
                _hqFiles.Add(tmpStr, false);

            // 行情文件到齐后移动的目的
            _destPaths = new Dictionary<string, bool>();
            foreach (string tmpStr in hqDestPath)
                _destPaths.Add(tmpStr, false);


            //********2.TA行情运行时变量初始化
            _isRunning = false;
            _isSourceAvailable = false;
            _isIdxFileParse = false;
            _isAllFilesExist = false;
            _isCopyOK = false;
        }



        /// <summary>
        /// 把子文件移至根目录
        /// </summary>
        public void MoveFilesToRoot()
        {
            DirectoryInfo dirRoot = new DirectoryInfo(_sourcePath);

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
                        // 只处理txt和dbf结尾的文件
                        if (tmpSubFile.Extension.ToLower() == ".txt" || tmpSubFile.Extension.ToLower() == ".dbf")
                        {
                            // 已经存在就删除，覆盖拷贝
                            if (File.Exists(System.IO.Path.Combine(dirRoot.FullName, tmpSubFile.Name)))
                                File.Delete(System.IO.Path.Combine(dirRoot.FullName, tmpSubFile.Name));

                            tmpSubFile.MoveTo(System.IO.Path.Combine(dirRoot.FullName, tmpSubFile.Name));
                        }
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
        /// 解析索引文件
        /// </summary>
        public void ParseIdxFile()
        {
            _hqFiles.Clear();
            string idxFilePath = Path.Combine(_sourcePath, _idxFile);
            _hqFiles.Add(idxFilePath, true);

            using (FileStream fs = new FileStream(idxFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    int idx = 0;        // 行索引
                    string strContent;  // 行内容
                    int fileCount = -1;  // 文件个数

                    while ((strContent = sr.ReadLine()) != null)
                    {
                        if (fileCount > 0)
                        {
                            _hqFiles.Add(strContent.Trim(), false);
                            fileCount--;
                        }
                        else if (fileCount == 0)
                            break;

                        if (idx == 5)  // 第5行，数量
                        {
                            fileCount = int.Parse(strContent);
                        }


                        idx++;
                    }

                }
            }

        }



        /// <summary>
        /// 更新每个文件的存在状态
        /// </summary>
        public void UpdateFileExistsStatus()
        {
            List<string> tmpList = new List<string>();
            tmpList.AddRange(_hqFiles.Keys);
            foreach (string tmp in tmpList)
            {
                if (File.Exists(Path.Combine(_sourcePath, tmp)))
                    _hqFiles[tmp] = true;
                else
                    _hqFiles[tmp] = false;
            }
        }



        /// <summary>
        /// 移动文件
        /// </summary>
        public void FileMove()
        {
            foreach (KeyValuePair<string, bool> kvDestPath in _destPaths)  // 遍历目的地
            {
                if (Directory.Exists(kvDestPath.Key))
                {
                    foreach (KeyValuePair<string, bool> kvFile in _hqFiles)
                    {
                        File.Copy(Path.Combine(_sourcePath, kvFile.Key),
                            Path.Combine(kvDestPath.Key, kvFile.Key),
                            true);
                    }
                }
                else
                {
                    throw new Exception(string.Format("路径{0}不存在", kvDestPath.Key));
                }
            }
        }


        #endregion************************方法


        #region********************************属性

        /// <summary>
        /// 行情源路径
        /// </summary>
        public string SourcePath
        {
            get { return _sourcePath; }
        }

        /// <summary>
        /// 行情是否需要文件移动到根目录
        /// </summary>
        public bool NeedRootMove
        {
            get { return _needRootMove; }
        }

        /// <summary>
        /// 行情检查模式
        /// </summary>
        public HqCheckType HqCheckType
        {
            get { return _hqCheckType; }
        }

        /// <summary>
        /// 行情索引文件
        /// </summary>
        public string IdxFile
        {
            get { return _idxFile; }
        }

        /// <summary>
        /// 行情文件列表（解析完的）
        /// </summary>
        public Dictionary<string, bool> HqFiles
        {
            get { return _hqFiles; }
        }


        /// <summary>
        /// 返回行情复制目的地字符串
        /// </summary>
        public string DestPathsString
        {
            get
            {
                StringBuilder sbReturn = new StringBuilder();

                foreach (KeyValuePair<string, bool> tmDic in _destPaths)
                {
                    if (sbReturn.Length != 0)
                        sbReturn.Append(";");
                    sbReturn.Append(tmDic.Key);
                }

                return sbReturn.ToString();
            }
        }

        /// <summary>
        /// 行情文件复制目的路径列表
        /// </summary>
        public Dictionary<string, bool> DestPaths
        {
            get { return _destPaths; }
        }

        /// <summary>
        /// TA行情状态
        /// </summary>
        public HqStatus HqStatus
        {
            get { return _status; }
            set { _status = value; }
        }

        /// <summary>
        /// TA行情是否在运行中
        /// </summary>
        public bool IsRunning
        {
            get { return _isRunning; }
            set { _isRunning = value; }
        }


        /// <summary>
        /// 源路径是否可访问
        /// </summary>
        public bool IsSourceAvailable
        {
            get { return _isSourceAvailable; }
            set { _isSourceAvailable = value; }
        }


        /// <summary>
        /// 行情索引文件解析是否完成
        /// </summary>
        public bool IsIdxFileParse
        {
            get { return _isIdxFileParse; }
            set { _isIdxFileParse = value; }
        }


        /// <summary>
        /// 所有文件是否到齐
        /// </summary>
        public bool IsAllFileArrived
        {
            get
            {
                foreach (KeyValuePair<string, bool> tmp in _hqFiles)
                {
                    if (tmp.Value == false)
                        return false;
                }

                return true;
            }
        }


        /// <summary>
        /// 文件拷贝完成
        /// </summary>
        public bool IsCopyOK
        {
            get { return _isCopyOK; }
            set { _isCopyOK = value; }
        }


        public string HqToolTip
        {
            get
            {
                if (_hqMissingFiles.Count > 0)
                {
                    string strReturn = "缺以下文件：";
                    foreach (string strTmp in _hqMissingFiles)
                    {
                        strReturn += System.Environment.NewLine;
                        strReturn += strTmp;
                    }

                    return strReturn;
                }
                else
                    return string.Empty;

            }
        }





        /// <summary>
        /// 这条TA行情配置完全OK了
        /// </summary>
        public bool IsOK
        {
            get
            {
                if (!_isSourceAvailable)
                    return false;
                if (!_isAllFilesExist)
                    return false;
                if (_destPaths.Count > 0)
                {
                    if (_isCopyOK)
                        return true;
                    else
                        return false;
                }
                else
                {
                    return true;
                }
            }
        }
        #endregion******************************属性

    }


    // 行情文件检查模式
    public enum HqCheckType
    {
        通过通用索引文件 = 0,
        通过指定索引文件 = 1,
        通过文件列表 = 2
    }


    // 行情检查状态
    public enum HqStatus
    {
        异常 = -1,
        未开始 = 0,
        尝试访问源路径 = 1,
        访问源路径成功 = 2,
        访问源路径失败 = 3,
        文件移动到根目录中 = 4,
        文件移动到根目录完成 = 5,
        文件移动到根目录错误 = 6,
        行情索引文件不存在 = 7,
        行情索引文件解析中 = 8,
        文件检查中 = 9,
        文件已收齐 = 10,
        文件未收齐 = 11,
        文件拷贝中 = 12,
        文件拷贝完成 = 13,
        文件拷贝失败 = 14,
        完成 = 15
    }
}
