using System;
using System.Linq;
using Autofac;
using Dapper;
using MysqlConnectionPoolCompare.Model;
using MySql.Data.MySqlClient;
using Autofac.Core;

namespace MysqlConnectionPoolCompare
{
    /// <summary>
    /// 学习链接： https://mp.weixin.qq.com/s?__biz=MjM5NTczNjY0OA==&mid=2650533431&idx=1&sn=9db13cba21a69da6b2d4cabb53ed75e6&mpshare=1&scene=1&srcid=0424EL7S4r7wxE56CSMved2B&key=4ec74a34b449763d58f18aaae8d9a78880ad74d89929b59f5bc8e264ed6c563260653657e7ede900d4672e9cefb43b069ee9a9c0a88657e5adf1f96d20fd70f91e4c5b013e8191ac7226ab468d3a4998&ascene=1&uin=MTk1NjU1OTU%3D&devicetype=Windows+10&version=62060739&lang=zh_CN&pass_ticket=efP%2FKSO0z4pSf7f3feeJyXR2fPHZ7xfcNROj9pPES3s%3D
    /// </summary>
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

            builder.RegisterType<QueryMysqlWithDefault>().Keyed<IExecute>(PoolingTypeEnum.Default);
            builder.RegisterType<QueryMysqlWithPoolingTrue>().Keyed<IExecute>(PoolingTypeEnum.PoolingTrue);
            builder.RegisterType<QueryMysqlWithPoolingFalse>().Keyed<IExecute>(PoolingTypeEnum.PoolingFalse);
            builder.RegisterType<QueryMysqlWithCsPooling>().Keyed<IExecute>(PoolingTypeEnum.CsPooling);
            var container = builder.Build(); //可是得到这个是为了干啥呢

            

            using (var scope = container.BeginLifetimeScope())
            {
                var writer = scope.ResolveKeyed<IExecute>(PoolingTypeEnum.PoolingTrue);
                

                var defaultSpan = writer.Execute(connStrDefault);
            }
        }
    }
}
 