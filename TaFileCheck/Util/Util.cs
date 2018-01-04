using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace TaFileCheck
{
    public static class Util
    {
        private static char[] arr_mdd_convert;  // mdd格式的字典数组
        static Util()
        {
            arr_mdd_convert = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c' };
        }

        /// <summary>
        /// 将yyyymmdd，mmdd，mdd替换成当天
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string Filename_Date_Convert(string fileName)
        {
            string strTmp = fileName;   // 返回值

            DateTime dtNow = DateTime.Now;

            string yyyymmdd_replacement = dtNow.ToString("yyyyMMdd");
            string yymmdd_replacement = dtNow.ToString("yyMMdd");
            string mmdd_replacement = string.Format("{0}{1}", dtNow.Month.ToString().PadLeft(2, '0'), dtNow.Day.ToString().PadLeft(2, '0'));
            string mdd_replacement = string.Format("{0}{1}", arr_mdd_convert[dtNow.Month - 1], dtNow.Day.ToString().PadLeft(2, '0'));

            strTmp = Regex.Replace(strTmp, "yyyymmdd", yyyymmdd_replacement, RegexOptions.IgnoreCase);  // 1.替换yyyymmdd
            strTmp = Regex.Replace(strTmp, "yymmdd", yymmdd_replacement, RegexOptions.IgnoreCase);      // 2.替换yymmdd
            strTmp = Regex.Replace(strTmp, "mmdd", mmdd_replacement, RegexOptions.IgnoreCase);          // 3.替换mmdd
            strTmp = Regex.Replace(strTmp, "mdd", mdd_replacement, RegexOptions.IgnoreCase);            // 4.替换mdd
            return strTmp;
        }



        /// <summary>
        /// 用流进行文件拷贝
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="destPath"></param>
        public static void CopyFileWithStream(string sourcePath, string destPath)
        {
            int eachReadLength = 1024;  // 每次拷贝文件大小

            //将源文件 读取成文件流  
            using (FileStream fromFile = new FileStream(sourcePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                //已追加的方式 写入文件流  
                using (FileStream toFile = new FileStream(destPath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    //实际读取的文件长度  
                    int toCopyLength = 0;
                    //如果每次读取的长度小于 源文件的长度 分段读取  
                    if (eachReadLength < fromFile.Length)
                    {
                        byte[] buffer = new byte[eachReadLength];
                        long copied = 0;
                        while (copied <= fromFile.Length - eachReadLength)
                        {
                            toCopyLength = fromFile.Read(buffer, 0, eachReadLength);
                            
                            toFile.Write(buffer, 0, eachReadLength);
                            toFile.Flush();
                            //流的当前位置  
                            toFile.Position = fromFile.Position;
                            copied += toCopyLength;
                        }
                        int left = (int)(fromFile.Length - copied);
                        toCopyLength = fromFile.Read(buffer, 0, left);

                        toFile.Write(buffer, 0, left);
                        toFile.Flush();
                    }
                    else
                    {
                        //如果每次拷贝的文件长度大于源文件的长度 则将实际文件长度直接拷贝  
                        byte[] buffer = new byte[fromFile.Length];
                        fromFile.Read(buffer, 0, buffer.Length);
                        toFile.Write(buffer, 0, buffer.Length);
                        toFile.Flush();
                    }
                }
            }
        }
    }
}
