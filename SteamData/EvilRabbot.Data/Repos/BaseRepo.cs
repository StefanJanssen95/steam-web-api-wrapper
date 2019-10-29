using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Dapper.Contrib.Extensions;
using Npgsql;

namespace EvilRabbot.Database.Repos
{
    public abstract class BaseRepo<T> where T : class
    {
        private const string ConnectionString = "Server=127.0.0.1;Port=5432;Database=postgres;User Id=postgres; Password=dev;";

        protected IDbConnection connection => new NpgsqlConnection(ConnectionString);

        public T Get(int id)
        {
            return connection.Get<T>(id);
        }

        public bool Update(T data)
        {
            return connection.Update(data);
        }
        
        public bool Delete(T data)
        {
            return connection.Delete(data);
        }

        public List<T> GetAll()
        {
            return connection.GetAll<T>().ToList();
        }

        public void CreateOrUpdate(T data)
        {
            if (!connection.Update(data))
                connection.Insert(data);
        }
        
        public long Insert(T data)
        {
            return connection.Insert(data);
        }

        public T FindFirstOrDefault(string columnName, object value)
        {
            var tableName = "evilrabbot.users";
            var sql = $"SELECT * FROM {tableName} WHERE {columnName} = @value;";
            return connection.QueryFirstOrDefault<T>(sql, new {value});
        }
    }
}