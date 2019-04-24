using System;

namespace MysqlConnectionPoolCompare.AutoFacTest
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class Custom
    {
        public string CustomName { get; set; }
        public int CustomId { get; set; }
    }


    public interface Idal<T> where T : class
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }

    public class Dal<T> : Idal<T> where T : class
    {
        public void Delete(T entity)
        {
           Console.WriteLine("您删除了一个："+ entity.GetType().FullName);
        }

        public void Insert(T entity)
        {
            Console.WriteLine("您添加了一个：" + entity.GetType().FullName);
        }

        public void Update(T entity)
        {
            Console.WriteLine("您更新了一个：" + entity.GetType().FullName);
        }
    }

//    public interface IRepository<T>:where T : class {
//
//    }


}
