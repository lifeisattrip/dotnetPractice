using System;
using System.Collections.Generic;

namespace csharp_practice.EFTest
{
    public class SysRole
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public DateTime GmtCreate { get; set; }
        public List<SysResource> resources { get; set; }
    }
}
