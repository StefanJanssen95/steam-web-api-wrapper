using System;
using Dapper.Contrib.Extensions;

namespace EvilRabbot.Database.Models
{
    public class User
    {
        public int Id { get; set; }

        
        
        public long SnowflakeId { get; set; }
        public string LastKnownUsername { get; set; }
        public DateTime LastMessageDate { get; set; }
        
        public ulong GetSnowflakeId()
        {
            return (ulong) SnowflakeId;
        }
        public void SetSnowflakeId(ulong snowflake)
        {
            SnowflakeId = (long) snowflake;
        }
    }
}