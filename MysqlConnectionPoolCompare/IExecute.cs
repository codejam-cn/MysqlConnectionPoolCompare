using System;
using System.Collections.Generic;
using System.Text;

namespace MysqlConnectionPoolCompare
{
    internal interface IExecute
    {
        int Execute(string connStr);
    }
}
