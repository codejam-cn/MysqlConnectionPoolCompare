using System.Diagnostics;
using Dapper;
using MysqlConnectionPoolCompare.Database.ConnectionPool;
using MysqlConnectionPoolCompare.Model;
using MySql.Data.MySqlClient;

namespace MysqlConnectionPoolCompare
{
    /// <summary>
    /// 自己C#写的线程池
    /// </summary>
    public class QueryMysqlWithCsPooling : IExecute
    {
        public int Execute(string connStr)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            using (MySqlConnection con = new ConnectionPool(connStr).GetConnection())
            {
                var list = con.Query<q_4_1_single_table>(Program.sql);
                var a = list;
            }
            sw.Stop();
            return sw.Elapsed.Milliseconds;
        }
    }
}
