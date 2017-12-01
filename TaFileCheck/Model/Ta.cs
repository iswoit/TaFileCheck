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
        文件移动到根目录中 = 1,
        检查中 = 2,
        文件未收齐 = 3,
        文件拷贝中 = 4,
        检查文件一致性 = 5,
        完成 = 6
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
        private List<string> _hqMove;       // 行情检查时需要移动
        private List<string> _hqFiles;      // 行情文件名
        HqStatus _hqStatus;                 // 任务状态



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
            _source = source;

            if (!bool.TryParse(rootMove, out _rootMove))
                _rootMove = false;

            // 检查完需要移动
            string[] arr_hqMove = hqMove.Split(new char[] { '|', ';', '；', ',', '，' });
            _hqMove = new List<string>();
            foreach (string strTmp in arr_hqMove)
            {
                if (!string.IsNullOrEmpty(strTmp.Trim()))
                    _hqMove.Add(strTmp.Trim());
            }

            // 必收行情文件通用转义(！！！未完成，日期和{ta}通配符都要，日期的还要加yymmdd的)
            _hqFiles = new List<string>();
            foreach (string strTmp in hqFiles)
            {
                string strTmp_new = Util.Filename_Date_Convert(strTmp);
                strTmp_new = ReplaceTaFileNameWithPattern(strTmp_new, _id);

                _hqFiles.Add(strTmp_new);
            }


            _hqStatus = HqStatus.未开始;
        }
    }
}
