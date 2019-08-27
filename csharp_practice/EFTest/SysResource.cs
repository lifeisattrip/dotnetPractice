using System;
using System.Collections.Generic;

namespace csharp_practice.EFTest
{
    public class SysResource
    {
        public int Id { get; set; }
        public string ResName { get; set; }
        public DateTime GmtCreate { get; set; }
        public List<SysRoleResource> RoleResource { get; set; }
    }
}
