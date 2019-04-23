using System;
using System.Linq;
using Dapper;
using MysqlConnectionPoolCompare.Model;
using MySql.Data.MySqlClient;

namespace MysqlConnectionPoolCompare
{
    class Program
    {
        private const string connStrDefault = "server=localhost;User Id=sa;password=guest;Database=leyan;Charset=utf8";
        private const string connStrPoolingTrue = "server=localhost;User Id=sa;password=guest;Database=leyan;Charset=utf8;Pooling=true;";
        private const string connStrPoolingFalse = "server=localhost;User Id=sa;password=guest;Database=leyan;Charset=utf8;Pooling=false;";

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (MySqlConnection con = new MySqlConnection(connStrDefault))
            {
                var sql = $"select * from q_4_1_single_table t where t.id > 20 and t.question_description like '%在%';";
                var list = con.Query<q_4_1_single_table>(sql);

            }
        }
    }
}
