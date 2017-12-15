using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TaFileCheck
{
    // 行情检查状态
    public enum HqStatus
    {
        异常 = -1,
        未开始 = 0,
        尝试访问源路径 = 1,
        访问源路径成功 = 2,
        无法访问源路径 = 3,
        文件移动到根目录中 = 4,
        文件移动到根目录完成 = 5,
        文件移动到根目录错误 = 6,
        文件检查中 = 7,
        文件已收齐 = 8,
        文件未收齐 = 9,
        文件拷贝中 = 10,
        文件拷贝完成 = 11,
        文件拷贝失败 = 12,
        完成 = 13
    }

    /// <summary>
    /// TA文件类
    /// </summary>
    public class Ta
    {
        private string _id;                 // ta代码
        private string _desc;               // 说明
        private string _source;             // 文件所在路径
        private bool _rootMove;             // 是否需要文件移动到根目录


        // 行情检查相关变量
        private HqStatus _hqStatus;                 // 任务状态
        private bool _isHqRunning = false;          // 行情检查运行中

        private bool _isHqSourceAvailable = false;      // 行情文件源目录是否可以访问
        private bool _isHqFileExists = false;           // 行情文件是否存在
        private List<string> _hqMissingFiles = new List<string>();  // 缺失的文件列表
        private bool _isHqRootMoveOK = false;           // 移动到根目录完成
        private bool _isHqCopyOK = false;               // 行情文件拷贝完成
        private string _hqMoveStr;          // 行情检查时需要移动(字符串，用于显示)
        private List<string> _hqMove;       // 行情检查时需要移动到的目的
        private List<string> _hqFiles;      // 行情文件名


        /// <summary>
        /// 把配置文件里的{ta}换成真实ta代码
        /// </summary>
        /// <param name="fileName"></param>
        private static string ReplaceTaFileNameWithPattern(string fileName, string taID)
        {
            string strTmp = fileName;   // 返回值
            strTmp = Regex.Replace(strTmp, @"{ta}", taID, RegexOptions.IgnoreCase);  // 1.替换yyyymmdd
            return strTmp;
        }


        public Ta(string id, string desc, string source, string rootMove, string hqMove, List<string> hqFiles)
        {
            _id = id;
            _desc = desc;
            _source = Util.Filename_Date_Convert(source);

            if (!bool.TryParse(rootMove, out _rootMove))
                _rootMove = false;

            _hqMoveStr = hqMove;
            // 检查完需要移动
            string[] arr_hqMove = hqMove.Split(new char[] { '|', ';', '；', ',', '，' });
            _hqMove = new List<string>();
            foreach (string strTmp in arr_hqMove)
            {
                if (!string.IsNullOrEmpty(strTmp.Trim()))
                    _hqMove.Add(Util.Filename_Date_Convert(strTmp.Trim()));
            }

            // 必收行情文件通用转义
            _hqFiles = new List<string>();
            foreach (string strTmp in hqFiles)
            {
                string strTmp_new = Util.Filename_Date_Convert(strTmp);     // 日期转义
                strTmp_new = ReplaceTaFileNameWithPattern(strTmp_new, _id); // {ta}通配符转义

                _hqFiles.Add(strTmp_new);
            }


            _hqStatus = HqStatus.未开始;
        }



        #region 属性
        public string Id
        {
            get { return _id; }
        }

        public string Desc
        {
            get { return _desc; }
        }

        public string Source
        {
            get { return _source; }
        }

        public bool RootMove
        {
            get { return _rootMove; }
        }

        public string HqMoveStr
        {
            get { return _hqMoveStr; }
        }

        /// <summary>
        /// 行情文件检查通过后是否需要移动
        /// </summary>
        public bool IsHqNeedMove
        {
            get
            {
                if (_hqMove.Count > 0)
                    return true;
                else
                    return false;
            }
        }

        public List<string> HqMove
        {
            get { return _hqMove; }
        }

        public List<string> HqFiles
        {
            get { return _hqFiles; }
        }

        public HqStatus HqStatus
        {
            get { return _hqStatus; }
            set { _hqStatus = value; }
        }

        public bool IsHqRunning
        {
            get { return _isHqRunning; }
            set { _isHqRunning = value; }
        }

        /// <summary>
        /// 行情文件源路径是否可访问
        /// </summary>
        public bool IsHqSourceAvailable
        {
            get { return _isHqSourceAvailable; }
            set { _isHqSourceAvailable = value; }
        }


        /// <summary>
        /// 行情移动到根目录完成
        /// </summary>
        public bool IsHqRootMoveOK
        {
            get { return _isHqRootMoveOK; }
            set { _isHqRootMoveOK = value; }
        }


        /// <summary>
        /// TA行情文件是否到齐
        /// </summary>
        public bool IsHqFileExists
        {
            get { return _isHqFileExists; }
            set { _isHqFileExists = value; }
        }


        /// <summary>
        /// 行情移动成功
        /// </summary>
        public bool IsHqCopyOK
        {
            get { return _isHqCopyOK; }
            set { _isHqCopyOK = value; }
        }


        /// <summary>
        /// 这条TA行情配置完全OK了
        /// </summary>
        public bool IsHqOK
        {
            get
            {
                if (!IsHqSourceAvailable)
                    return false;
                if (!IsHqFileExists)
                    return false;
                if (IsHqNeedMove)
                {
                    if (IsHqCopyOK)
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


        public List<string> HqMissingFiles
        {
            get { return _hqMissingFiles; }
            set { _hqMissingFiles = value; }
        }

        public string HqToolTip
        {
            get
            {
                if (HqMissingFiles.Count > 0)
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
                    return _hqStatus.ToString();

            }
        }

        #endregion 属性
    }
}
