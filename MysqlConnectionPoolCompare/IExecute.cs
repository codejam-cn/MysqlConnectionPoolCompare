namespace MysqlConnectionPoolCompare
{
    internal interface IExecute
    {
        int Execute(string connStr);
    }
}
