using System;
using System.ComponentModel.DataAnnotations;

namespace csharp_practice.EFTest
{
    public class SysConfig
    {   
        [Key]
        public int Id { get; set; }
        [Required]
        public string ConfigSection { get; set; }
        [Required]
        public string ConfigKey { get; set; }
        [Required]
        public string ConfigValue { get; set; }
        public DateTime GmtCreate { get; set; }
    }
}
