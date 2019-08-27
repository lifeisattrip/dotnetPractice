using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace csharp_practice.EFTest
{
    class EfTester:TestBase
    {
        public void TestSelect()
        {
            using var db = new AppDbContext();
            List<SysUser> list = db.SysUsers.Where(u=>u.UserName.Contains("3")).ToList();
            list.ForEach(n=>PrintObj(n.Id));
        }
    }
}
