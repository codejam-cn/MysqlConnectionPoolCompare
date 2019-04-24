using System;
using System.Collections.Generic;
using System.Text;

namespace MysqlConnectionPoolCompare
{
    /// <summary>
    /// 自己C#写的线程池
    /// </summary>
    public class QueryMysqlWithCsPooling : IExecute
    {
        public int Execute(string connStr)
        {
            return 1;
        }
    }
}
