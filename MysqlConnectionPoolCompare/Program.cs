using System;
using System.Linq;
using Autofac;
using Dapper;
using MysqlConnectionPoolCompare.Model;
using MySql.Data.MySqlClient;
using Autofac.Core;

namespace MysqlConnectionPoolCompare
{
    public class Program
    {
        public static int repeatTimes = 10000;

        private const string connStrDefault = "server=localhost;User Id=sa;password=guest;Database=leyan;Charset=utf8";
        private const string connStrPoolingTrue = "server=localhost;User Id=sa;password=guest;Database=leyan;Charset=utf8;Pooling=true;";
        private const string connStrPoolingFalse = "server=localhost;User Id=sa;password=guest;Database=leyan;Charset=utf8;Pooling=false;";

        static void Main(string[] args)
        {
            //DI
            var builder = new ContainerBuilder();
            builder.RegisterType<QueryMysqlWithDefault>().As(typeof(IExecute));
            var container = builder.Build(); //可是得到这个是为了干啥呢

            

            using (var scope = container.BeginLifetimeScope())
            {
                var writer = scope.Resolve<IExecute>();

                var defaultSpan = writer.Execute(connStrDefault);
            }
        }
    }
}
