using System;
using System.Collections.Generic;
using System.Text;

namespace TaFileCheck
{
    public class TaQs : Ta
    {
        // 行情基本变量
        private bool _needRootMove;                    // 清算是否需要移动到根目录

        private string _sourcePath;                    // 清算源路径
        private QsCheckType _qsCheckType;              // 清算文件检查模式
        private string _idxFile;                       // 清算索引文件(模式0用得到)
        private int _idxFileCnt;                       // 清算索引对应的行号
        private Dictionary<string, bool> _qsFiles;     // 清算文件列表
        private Dictionary<string, bool> _destPaths;   // 清算文件到齐后移动的目的

        // 行情运行变量
        private QsStatus _status;                      // 任务状态
        private bool _isRunning;                       // 行情检查运行中
        private bool _isSourceAvailable;               // 行情文件源目录是否可以访问
        private bool _isIdxFileParse;                  // 行情索引文件解析完成


        public TaQs(string id, string desc, string qsSource, string needRootMove, string qsCheckType, string idxFile, int idxFileCnt, List<string> qsFiles, List<string> qsDestPath)
        {
            //********1.TA行情配置变量初始化
            _id = id;           // 代码
            _desc = desc;       // 描述
            _sourcePath = qsSource;     // 行情路径

            // 行情移动到根目录
            if (!bool.TryParse(needRootMove, out _needRootMove))
                _needRootMove = false;

            // 行情文件检查模式
            int tmpQsCheckType = 0;
            if (!int.TryParse(qsCheckType.Trim(), out tmpQsCheckType))
                throw new Exception(string.Format("ID:{0}的<qschecktype>参数非法(0-索引 1-指定文件)", id));
            _qsCheckType = (QsCheckType)tmpQsCheckType;


            // 行情索引
            idxFile = Util.ReplaceTaFileNameWithPattern(idxFile, id);
            _idxFile = idxFile;
            _idxFileCnt = idxFileCnt;

            // 行情文件列表
            _qsFiles = new Dictionary<string, bool>();
            foreach (string tmpStr in qsFiles)
                _qsFiles.Add(tmpStr, false);

            // 行情文件到齐后移动的目的
            _destPaths = new Dictionary<string, bool>();
            foreach (string tmpStr in qsDestPath)
                _destPaths.Add(tmpStr, false);


            //********2.TA行情运行时变量初始化
            _status = QsStatus.未开始;
            _isRunning = false;
            _isSourceAvailable = false;
            _isIdxFileParse = false;
        }

    }

    // 清算文件检查模式
    public enum QsCheckType
    {
        通过索引文件 = 0,
        通过文件列表 = 1
    }

    // 清算检查状态
    public enum QsStatus
    {
        异常 = -1,
        未开始 = 0,
        尝试访问源路径 = 1,
        访问源路径成功 = 2,
        访问源路径失败 = 3,
        文件移动到根目录中 = 4,
        文件移动到根目录完成 = 5,
        文件移动到根目录错误 = 6,
        索引文件不存在 = 7,
        索引文件解析中 = 8,
        文件检查中 = 9,
        文件已收齐 = 10,
        文件未收齐 = 11,
        文件拷贝中 = 12,
        文件拷贝完成 = 13,
        文件拷贝失败 = 14,
        完成 = 15
    }


}
