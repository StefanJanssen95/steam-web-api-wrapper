using System.Text.RegularExpressions;
using Dapper.FluentMap.Conventions;

namespace EvilRabbot.Database.Mappers
{
    public class ColumnConventionMapper: Convention
    {
        public ColumnConventionMapper()
        {
            // Map all properties of type int and with the name 'id' to column 'autID'.
            Properties()
                .Configure(c => c.Transform(s => Regex.Replace(input: s, pattern: "([A-Z])([A-Z][a-z])|([a-z0-9])([A-Z])", replacement: "$1$3_$2$4").ToLower()));
        }
    }
}