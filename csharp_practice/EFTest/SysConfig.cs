using System;

namespace csharp_practice.EFTest
{
    public class SysConfig
    {
        public int Id { get; set; }
        public string ConfigSection { get; set; }
        public string ConfigKey { get; set; }
        public string ConfigValue { get; set; }
        public DateTime GmtCreate { get; set; }
    }
}
