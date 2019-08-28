using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_practice.EFTest
{
    public class SysRoleRes
    {
        public int RoleId { get; set; }
        public SysRole Role { get; set; }
        public int ResourceId { get; set; }
        public SysRes Res { get; set; }
    }
}
