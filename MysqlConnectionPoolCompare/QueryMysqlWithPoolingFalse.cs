namespace MysqlConnectionPoolCompare
{
    /// <summary>
    /// 显示指定不使用线程池的连接字符串
    /// </summary>
    public class QueryMysqlWithPoolingFalse : IExecute
    {
        public int Execute(string connStr)
        {
            return ExecuteQuery.Execute(connStr);
        }
    }
}
