using System;
using System.Collections.Generic;
using System.Text;

namespace TaFileCheck
{
    /// <summary>
    /// 交易日对象
    /// </summary>
    public class MarketDbConn
    {
        public string ip = string.Empty;           // 数据库IP
        public string port = string.Empty;         // 数据库端口
        public string service = string.Empty;      // 数据库服务名
        public string acc = string.Empty;          // 账号
        public string pwd = string.Empty;          // 密码
        public string table = string.Empty;        // 交易日表
        public string colDate = string.Empty;      // 日期列
        public string colMarket = string.Empty;    // 市场列
        public string colStatus = string.Empty;    // 状态列。恒生逻辑: 1为交易日，其他或者无数据为非交易日

        public MarketDbConn(string ip, string port, string service, string acc, string pwd, string table, string colDate, string colMarket, string colStatus)
        {
            this.ip = ip;
            this.port = port;
            this.service = service;
            this.acc = acc;
            this.pwd = pwd;
            this.table = table;
            this.colDate = colDate;
            this.colMarket = colMarket;
            this.colStatus = colStatus;
        }
    }
}
