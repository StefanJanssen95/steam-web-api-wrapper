using Dapper.Contrib.Extensions;

namespace EvilRabbot.Database.Models
{
    public class ConfigSetting
    {
        [Key] public int Id { get; set; }
        public string Name{ get; set; }
        public string Value{ get; set; }
    }
}