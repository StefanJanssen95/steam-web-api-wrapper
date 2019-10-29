using Dapper.FluentMap.Mapping;
using EvilRabbot.Database.Models;

namespace EvilRabbot.Database.Mappers
{
    public class UserMapper : EntityMap<User>
    {
        public UserMapper()
        {
            
        }
    }
}