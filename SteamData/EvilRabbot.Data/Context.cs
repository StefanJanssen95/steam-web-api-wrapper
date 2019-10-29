using System;
using System.Linq;
using System.Reflection;
using Dapper.Contrib.Extensions;
using Dapper.FluentMap;
using EvilRabbot.Database.Mappers;
using EvilRabbot.Database.Repos;

namespace EvilRabbot.Database
{
    public class Context
    {
        public static void Init()
        {
            SqlMapperExtensions.TableNameMapper = TableNameMapper;
            FluentMapper.Initialize(config =>
                {
                    config.AddConvention<ColumnConventionMapper>().ForEntitiesInCurrentAssembly("EvilRabbot.Database.Models");
                });
        }
        
        private static string TableNameMapper(Type type)
        {
            string name;
            var tableAttrName =
                type.GetCustomAttribute<TableAttribute>(false)?.Name
                ?? (type.GetCustomAttributes(false).FirstOrDefault(attr => attr.GetType().Name == "TableAttribute") as dynamic)?.Name;

            if (tableAttrName != null)
                name = tableAttrName;
            else
            {
                name = type.Name + "s";
                if (type.IsInterface && name.StartsWith("I"))
                    name = name.Substring(1);
                name = string.Concat(name.Select((x,i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())).ToLower();
            }

            return $"EvilRabbot.{name}";
        }


        public static ConfigRepo ConfigRepo = new ConfigRepo();
        public static UserRepo UserRepo = new UserRepo();
        public static EmojiCounterRepo EmojiCounterRepo = new EmojiCounterRepo();
    }
}