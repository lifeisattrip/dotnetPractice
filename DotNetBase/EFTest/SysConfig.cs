﻿using System;
using System.ComponentModel.DataAnnotations;

namespace csharp_practice.EFTest
{
    public class SysConfig
    {   
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(32)]
        public string ConfigSection { get; set; }
        [Required]
        [MaxLength(32)]
        public string ConfigKey { get; set; }
        [Required]
        public string ConfigValue { get; set; }
        public DateTime GmtCreate { get; set; }
    }
}
