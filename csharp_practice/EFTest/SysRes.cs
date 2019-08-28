using System;
using System.Collections.Generic;

namespace csharp_practice.EFTest
{
    public class SysRes
    {
        public int Id { get; set; }
        public string ResName { get; set; }
        public DateTime GmtCreate { get; set; }
        public List<SysRoleRes> RoleResource { get; set; }
    }
}
