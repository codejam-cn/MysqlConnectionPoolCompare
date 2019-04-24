using System;
using Autofac;

namespace MysqlConnectionPoolCompare
{
    /// <summary>
    /// 学习链接： https://mp.weixin.qq.com/s?__biz=MjM5NTczNjY0OA==&mid=2650533431&idx=1&sn=9db13cba21a69da6b2d4cabb53ed75e6&mpshare=1&scene=1&srcid=0424EL7S4r7wxE56CSMved2B&key=4ec74a34b449763d58f18aaae8d9a78880ad74d89929b59f5bc8e264ed6c563260653657e7ede900d4672e9cefb43b069ee9a9c0a88657e5adf1f96d20fd70f91e4c5b013e8191ac7226ab468d3a4998&ascene=1&uin=MTk1NjU1OTU%3D&devicetype=Windows+10&version=62060739&lang=zh_CN&pass_ticket=efP%2FKSO0z4pSf7f3feeJyXR2fPHZ7xfcNROj9pPES3s%3D
    /// </summary>
    public class Program
    {
        public static int repeatTimes = 1000;

        private const string connStrDefault = "server=localhost;User Id=sa;password=guest;Database=leyan;Charset=utf8";
        private const string connStrPoolingTrue = "server=localhost;User Id=sa;password=guest;Database=leyan;Charset=utf8;Pooling=true;";
        private const string connStrPoolingFalse = "server=localhost;User Id=sa;password=guest;Database=leyan;Charset=utf8;Pooling=false;";

        static void Main(string[] args)
        {
            AutoFacConfig.Register(); //注册


            using (var scope = AutoFacConfig.Container.BeginLifetimeScope())
            {
                var queryInstance1 = scope.ResolveKeyed<IExecute>(PoolingTypeEnum.Default);
                var span1 = queryInstance1.Execute(connStrDefault);

                var queryInstance2 = scope.ResolveKeyed<IExecute>(PoolingTypeEnum.PoolingTrue);
                var span2 = queryInstance2.Execute(connStrPoolingTrue);

                var queryInstance3 = scope.ResolveKeyed<IExecute>(PoolingTypeEnum.PoolingFalse);
                var span3 = queryInstance3.Execute(connStrPoolingFalse);

                var queryInstance4 = scope.ResolveKeyed<IExecute>(PoolingTypeEnum.CsPooling);
                var span4 = queryInstance4.Execute(connStrDefault);

                Console.WriteLine($"Default = {span1}");
                Console.WriteLine($"PoolingTrue = {span2}");
                Console.WriteLine($"PoolingFalse = {span3}");
                Console.WriteLine($"CsPooling = {span4}");
            }
        }
    }
}
 