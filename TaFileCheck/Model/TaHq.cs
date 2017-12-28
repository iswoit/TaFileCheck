using System;
using System.Collections.Generic;
using System.Text;

namespace TaFileCheck
{
    public class TaHq : Ta
    {
        // 行情基本变量
        private string _path;                                       // ta行情路径
        private bool _needRootMove;                                 // ta文件是否移动到根目录
        private HqFileCheckType _hqFileCheckType;                   // 行情文件检查模式
        private List<string> _hqFiles;                              // 行情文件
        private List<string> _destPaths;                            // 文件到齐后移动的目的

        // 行情运行变量
        private HqStatus _status;                                   // 任务状态
        private bool _isRunning = false;                            // 行情检查运行中
        private bool _isPathAvailable = false;                      // 行情文件源目录是否可以访问
        private bool _isAllFilesExist = false;                      // 所有行情文件都存在
        private List<string> _existsFiles = new List<string>();     // 存在的文件列表
        private List<string> _missingFiles = new List<string>();    // 缺失的文件列表
        private bool _isCopyOK = false;                             // 行情文件拷贝完成


        public TaHq(string id, string desc, string hqPath, bool hqRootMove, List<string> hqFiles, string hqMove)
        {
            _id = id;           // ta代码
            _desc = desc;       // ta描述
            _path = hqPath;     // ta行情路径
            _needRootMove = hqRootMove;     

        }
    }


    // 行情文件检查模式
    public enum HqFileCheckType
    {
        通过索引文件 = 0,
        指定文件 = 1
    }


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
}
