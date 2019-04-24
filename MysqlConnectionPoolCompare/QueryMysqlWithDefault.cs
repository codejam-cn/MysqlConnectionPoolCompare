namespace MysqlConnectionPoolCompare
{
    /// <summary>
    /// 默认连接字符串
    /// </summary>
    public class QueryMysqlWithDefault : IExecute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Execute(string connStr)
        {
            return ExecuteQuery.Execute(connStr);
        }
    }
}
