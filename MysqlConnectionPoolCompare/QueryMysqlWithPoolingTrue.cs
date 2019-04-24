using System;
using System.Collections.Generic;
using System.Text;

namespace MysqlConnectionPoolCompare
{
    /// <summary>
    /// 显示指定使用线程池的连接字符串
    /// </summary>
    public class QueryMysqlWithPoolingTrue : IExecute
    {
        public int Execute(string connStr)
        {
            return 111;
        }
    }
}
