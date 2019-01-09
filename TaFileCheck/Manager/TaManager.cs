using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;

namespace TaFileCheck
{
    public class TaManager
    {
        private List<TaHq> _taHqList;    // ta行情对象列表
        //private List<TaQs> _taQsList = new List<TaQs>();    // ta清算对象列表
        private string _taHqIdx;                                    // ta行情索引文件
        private int _taHqIdxCnt;                                    // ta行情数的行数
        private string _taQsIdx;                                    // ta清算索引文件




        private MarketDbConn _marketDbConn;         // 交易日连接串对象
        private DateTime _dtJYR = DateTime.Now;     // 当前交易日
        private DateTime _dtLastJYR;                // 上一个交易日

        #region 方法



        private void LoadMarketDbConn()
        {
            if (!File.Exists(Path.Combine(Environment.CurrentDirectory, "cfg.xml")))
                throw new FileNotFoundException("未能找到配置文件cfg.xml, 请重新配置该文件后重启程序!");

            // 读取配置文件
            XmlDocument doc = new XmlDocument();
            XmlReaderSettings settings = new XmlReaderSettings() { IgnoreComments = true };     //忽略文档里面的注释
            using (XmlReader reader = XmlReader.Create(@"cfg.xml", settings))
            {
                doc.Load(reader);

                // 检查根节点
                XmlNode rootXN = doc.SelectSingleNode("config");
                if (rootXN == null)
                    throw new Exception("无法找到根配置节点<config>, 请检查配置文件格式是否正确!");

                // 获取MarketDbConn节点
                XmlNode marketDbConnXN = rootXN.SelectSingleNode("MarketDbConn");
                if (marketDbConnXN == null)
                    throw new Exception("无法找到节点<MarketDbConn>, 请检查配置文件格式是否正确!");

                // 开始获取数据
                string ip = string.Empty;
                string port = string.Empty;
                string service = string.Empty;
                string acc = string.Empty;
                string pwd = string.Empty;
                string table = string.Empty;
                string colDate = string.Empty;
                string colMarket = string.Empty;
                string colStatus = string.Empty;
                XmlNode valueXN;

                valueXN = marketDbConnXN.SelectSingleNode("Ip");
                if (valueXN != null)
                    ip = valueXN.InnerText.Trim();

                valueXN = marketDbConnXN.SelectSingleNode("Port");
                if (valueXN != null)
                    port = valueXN.InnerText.Trim();

                valueXN = marketDbConnXN.SelectSingleNode("Service");
                if (valueXN != null)
                    service = valueXN.InnerText.Trim();

                valueXN = marketDbConnXN.SelectSingleNode("Acc");
                if (valueXN != null)
                    acc = valueXN.InnerText.Trim();

                valueXN = marketDbConnXN.SelectSingleNode("Pwd");
                if (valueXN != null)
                    pwd = valueXN.InnerText.Trim();

                valueXN = marketDbConnXN.SelectSingleNode("Table");
                if (valueXN != null)
                    table = valueXN.InnerText.Trim();

                valueXN = marketDbConnXN.SelectSingleNode("ColDate");
                if (valueXN != null)
                    colDate = valueXN.InnerText.Trim();

                valueXN = marketDbConnXN.SelectSingleNode("ColMarket");
                if (valueXN != null)
                    colMarket = valueXN.InnerText.Trim();

                valueXN = marketDbConnXN.SelectSingleNode("ColStatus");
                if (valueXN != null)
                    colStatus = valueXN.InnerText.Trim();


                this._marketDbConn = new MarketDbConn(ip, port, service, acc, pwd, table, colDate, colMarket, colStatus);
            }//eof using
        }


        private void GetLastMarketDay()
        {
            /*连接数据库，更新dicMarketStatus
             */

            string connString = string.Format(@"User ID={0};Password={1};Data Source=(DESCRIPTION = (ADDRESS_LIST= (ADDRESS = (PROTOCOL = TCP)(HOST = {2})(PORT = {3}))) (CONNECT_DATA = (SERVICE_NAME = {4})))",
                _marketDbConn.acc,
                _marketDbConn.pwd,
                _marketDbConn.ip,
                _marketDbConn.port,
                _marketDbConn.service);
            using (OracleCommand cmd = new OracleCommand())
            {
                using (OracleConnection conn = new OracleConnection(connString))
                {
                    conn.Open();
                    cmd.Connection = conn;


                    //bool tmpValue = dicMarketStatus[tmpKey];
                    cmd.CommandText = string.Format(@"select {2} from {1} where {2} < '{3}' and {4} = '{5}' order by {2} desc", _marketDbConn.colStatus, _marketDbConn.table, _marketDbConn.colDate, _dtJYR.ToString("yyyyMMdd"), _marketDbConn.colMarket, "1");
                    object result = cmd.ExecuteScalar();
                    if (result == null)
                    {
                        throw new Exception("无法从数据库获取上一个交易日!");
                    }
                    else
                    {
                        DateTime.TryParseExact(result.ToString(), "yyyyMMdd", new CultureInfo("zh-CN", true), DateTimeStyles.None, out _dtLastJYR);
                    }
                }
            }
        }


        /// <summary>
        /// 构造函数
        /// </summary>
        public TaManager()
        {
            // 获取当天以及上一交易日
            LoadMarketDbConn();
            GetLastMarketDay();


            _taHqList = new List<TaHq>();

            // 判断配置文件是否存在，不存在抛出异常
            if (!File.Exists(Path.Combine(Environment.CurrentDirectory, "cfg.xml")))
                throw new Exception("未能找到配置文件cfg.xml，请重新配置该文件后重启程序!");

            // 读取配置文件
            XmlDocument doc = new XmlDocument();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;     //忽略文档里面的注释
            using (XmlReader reader = XmlReader.Create(@"cfg.xml", settings))
            {
                doc.Load(reader);

                // 检查根节点
                XmlNode rootNode = doc.SelectSingleNode("config");   // 根节点
                if (rootNode == null)
                    throw new Exception("无法找到配置文件的根节点<config>，请检查配置文件格式是否正确!");

                // 找TA行情通配索引
                XmlNode xnHqIdx = rootNode.SelectSingleNode("//hqidx");
                if (xnHqIdx != null)
                    _taHqIdx = Util.Filename_Date_Convert(xnHqIdx.InnerText.Trim(), _dtJYR, _dtLastJYR);
                else
                    throw new Exception("无法找到配置文件节点<hqidx>(行情索引文件名)，请检查配置文件格式是否正确!");

                // 找TA行情通配索引
                XmlNode xnHqIdxCnt = rootNode.SelectSingleNode("//hqidxcnt");
                if (xnHqIdxCnt != null)
                {
                    if (!int.TryParse(xnHqIdxCnt.InnerText.Trim(), out _taHqIdxCnt))
                    {
                        throw new Exception("请确定节点<hqidxcnt>(行情索引文件中文件数量所在行)为数字!");
                    }
                }
                else
                    throw new Exception("无法找到配置文件节点<hqidxcnt>(行情索引文件中文件数量所在行)，请检查配置文件格式是否正确!");


                // 找TA清算通配索引
                XmlNode xnQsIdx = rootNode.SelectSingleNode("//qsidx");
                if (xnQsIdx != null)
                    _taQsIdx = Util.Filename_Date_Convert(xnQsIdx.InnerText.Trim(), _dtJYR, _dtLastJYR);
                else
                    throw new Exception("无法找到配置文件节点<qsidx>(清算索引文件名)，请检查配置文件格式是否正确!");


                // 直接找talist子节点。形成ta对象，加入到TaManager列表。
                XmlNode xnTa = rootNode.SelectSingleNode("//talist");
                _taHqList = new List<TaHq>();
                //_taQsList = new List<TaQs>();
                if (xnTa != null)
                {
                    foreach (XmlNode xnTaChild in xnTa.ChildNodes) // 循环talist下的子节点
                    {
                        if (string.Equals(xnTaChild.Name.Trim().ToLower(), "ta", StringComparison.CurrentCultureIgnoreCase))   // 如果子节点名字是ta，开始遍历attribute
                        {
                            // Part1.行情配置
                            string id = string.Empty;                                   // ta代码
                            string desc = string.Empty;                                 // 备注（仅仅显示）
                            string hqRootMove = string.Empty;
                            List<string> hqRootMovePath = new List<string>();

                            string hqSource = string.Empty;
                            string hqchecktype = string.Empty;
                            string hqIdx = _taHqIdx;
                            List<string> hqFiles = new List<string>();
                            List<string> hqDestPath = new List<string>();
                            string hqStartTime = string.Empty;


                            foreach (XmlNode xnTaChildAttr in xnTaChild)
                            {
                                switch (xnTaChildAttr.Name.ToLower().Trim())
                                {
                                    case "id":
                                        id = xnTaChildAttr.InnerText;
                                        break;
                                    case "desc":
                                        desc = xnTaChildAttr.InnerText;
                                        break;
                                    case "hqsource":
                                        hqSource = Util.Filename_Date_Convert(xnTaChildAttr.InnerText.Trim(), _dtJYR, _dtLastJYR);
                                        break;
                                    case "hqrootmove":
                                        hqRootMove = xnTaChildAttr.InnerText.Trim();
                                        break;
                                    case "hqrootmovepath":
                                        if (xnTaChildAttr.ChildNodes.Count > 0)
                                        {
                                            hqRootMovePath.Clear();
                                            foreach (XmlNode xnTaChildAttrValue in xnTaChildAttr.ChildNodes)
                                            {
                                                string tmpValue = Util.Filename_Date_Convert(xnTaChildAttrValue.InnerText.Trim(), _dtJYR, _dtLastJYR);
                                                tmpValue = Ta.ReplaceTaFileNameWithPattern(tmpValue, id);
                                                if (!string.IsNullOrEmpty(tmpValue))
                                                    hqRootMovePath.Add(tmpValue);
                                            }
                                        }
                                        break;
                                    case "hqchecktype":
                                        hqchecktype = xnTaChildAttr.InnerText.Trim();
                                        break;
                                    case "hqfiles":
                                        {
                                            if (xnTaChildAttr.ChildNodes.Count > 0)
                                            {
                                                hqFiles.Clear();
                                                foreach (XmlNode xnTaChildAttrValue in xnTaChildAttr.ChildNodes)
                                                {
                                                    string tmpValue = Util.Filename_Date_Convert(xnTaChildAttrValue.InnerText.Trim(), _dtJYR, _dtLastJYR);
                                                    tmpValue = Ta.ReplaceTaFileNameWithPattern(tmpValue, id);
                                                    if (!string.IsNullOrEmpty(tmpValue))
                                                        hqFiles.Add(tmpValue);
                                                }
                                            }
                                            break;
                                        }
                                    case "hqdestpath":
                                        {
                                            if (xnTaChildAttr.ChildNodes.Count > 0)
                                            {
                                                hqDestPath.Clear();
                                                foreach (XmlNode xnTaChildAttrValue in xnTaChildAttr.ChildNodes)
                                                {
                                                    string tmpValue = Util.Filename_Date_Convert(xnTaChildAttrValue.InnerText.Trim(), _dtJYR, _dtLastJYR);
                                                    if (!string.IsNullOrEmpty(tmpValue))
                                                        hqDestPath.Add(tmpValue);
                                                }
                                            }
                                            break;
                                        }
                                    case "hqstarttime":
                                        hqStartTime = xnTaChildAttr.InnerText.Trim();
                                        break;
                                }//eof switch ta attr
                            }//eof foreach ta

                            _taHqList.Add(new TaHq(id, desc, hqSource, hqRootMove, hqRootMovePath, hqchecktype, hqIdx, _taHqIdxCnt, hqFiles, hqDestPath, hqStartTime));


                            // Part2.清算配置（还没写）



                        }//eof if ta
                    }//eof foreach
                }//eof if taListNode not null






            }
        }

        /// <summary>
        /// 源路径是否可以访问
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool IsPathAvailabel(string path)
        {
            if (Directory.Exists(path))
                return true;
            else
                return false;
        }




        #endregion 方法




        #region 属性

        /// <summary>
        /// 获取TA列表
        /// </summary>
        public List<TaHq> TaHqList
        {
            get { return _taHqList; }
        }

        /// <summary>
        /// 行情文件完成数
        /// </summary>
        public int TaHqOKCnt
        {
            get
            {
                int iRet = 0;
                foreach (TaHq taHq in _taHqList)
                {
                    if (taHq.IsOK)
                        iRet++;
                }

                return iRet;
            }
        }


        /// <summary>
        /// IsRequired的完成数
        /// </summary>
        public int TaHqRequiredOKCnt
        {
            get
            {
                int iRet = 0;
                foreach (TaHq taHq in _taHqList)
                {
                    if (taHq.IsRequired)
                    {
                        iRet++;
                    }
                }

                return iRet;
            }
        }


        /// <summary>
        /// 未完成的TA列表
        /// </summary>
        public List<TaHq> TaHqNotPreparedList
        {
            get
            {
                List<TaHq> retList = new List<TaHq>();
                foreach (TaHq taHq in _taHqList)
                {
                    if (taHq.IsOK == false)
                        retList.Add(taHq);
                }
                return retList;
            }
        }


        /// <summary>
        /// TA行情文件全就绪
        /// 20180709-只判断IsRequired是true的文件
        /// </summary>
        public bool IsHqAllOK
        {
            get
            {
                foreach (TaHq tmpTa in _taHqList)
                {
                    if (!tmpTa.IsRequiredOK)
                        return false;
                }

                return true;
            }
        }




        /// <summary>
        /// 当前处理日期
        /// </summary>
        public DateTime DateNow
        {
            get { return _dtJYR; }
        }

        #endregion 属性
    }
}
