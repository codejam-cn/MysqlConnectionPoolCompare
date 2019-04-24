using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Dapper;
using MysqlConnectionPoolCompare.Model;
using MySql.Data.MySqlClient;

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
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < Program.repeatTimes; i++)
            {
                using (MySqlConnection con = new MySqlConnection(connStr))
                {
                    var sql = $"select * from q_4_1_single_table t where t.id > 20 and t.question_description like '%在%';";
                    var list = con.Query<q_4_1_single_table>(sql);

                }
            }
            sw.Stop();
            return sw.Elapsed.Milliseconds;
        }
    }
}
