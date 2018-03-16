using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TaFileCheck
{


    // 清算检查状态
    public enum QsStatus
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
        protected string _id;                 // ta代码
        protected string _desc;               // ta说明
        



        /// <summary>
        /// 把配置文件里的{ta}换成真实ta代码
        /// </summary>
        /// <param name="fileName"></param>
        public static string ReplaceTaFileNameWithPattern(string fileName, string taID)
        {
            string strTmp = fileName;   // 返回值
            strTmp = Regex.Replace(strTmp, @"{ta}", taID, RegexOptions.IgnoreCase);  // 1.替换yyyymmdd
            return strTmp;
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













        #endregion 属性
    }
}
