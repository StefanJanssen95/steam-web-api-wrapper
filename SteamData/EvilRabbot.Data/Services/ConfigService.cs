using System.Collections.Generic;
using System.Linq;
using EvilRabbot.Database.Models;
using EvilRabbot.Database.Repos;

namespace EvilRabbot.Database.Services
{
    public class ConfigService
    {
        private static List<ConfigSetting> _configCache = null; 

        public string GetString(string name, string fallback = null)
        {
            if (_configCache == null)
                _configCache = Context.ConfigRepo.GetAll();

            return _configCache.FirstOrDefault(s => s.Name == name)?.Value ?? fallback;
        }

        public void ClearCache()
        {
            _configCache = null;
        }
    }
}