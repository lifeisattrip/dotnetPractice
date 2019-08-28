using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace csharp_practice.EFTest
{
    class EfTester : TestBase
    {
        public void TestSelect()
        {
            using var db = new AppDbContext();
            List<SysUser> list = db.SysUsers.Where(u => u.UserName.Contains("3")).ToList();
            list.ForEach(n => PrintObj(n.Id));
        }

        public void AddTestData()
        {
            using var appDbContext = new AppDbContext();


            var sysReses = new List<SysRes>();
            for (int i = 0; i < 5; i++)
            {
                var sysRes = new SysRes();
                sysRes.ResName = $"username-{i}";
                sysRes.GmtCreate = DateTime.Now;
                sysReses.Add(sysRes);
            }

            appDbContext.SysRes.AddRange(sysReses);

            var sysRoles = new List<SysRole>();
            for (int i = 0; i < 5; i++)
            {
                var sysRole = new SysRole();
                sysRole.RoleName = $"rolename-{i}";
                sysRole.GmtCreate = DateTime.Now;
                sysRoles.Add(sysRole);
            }

            appDbContext.SysRoles.AddRange(sysRoles);

            var sysRoleReses = new List<SysRoleRes>();
            foreach (var sysRole in sysRoles)
            {
                foreach (var sysRese in sysReses)
                {
                    var sysRoleRes = new SysRoleRes();
                    sysRoleRes.Res = sysRese;
                    sysRoleRes.Role = sysRole;
                    sysRoleReses.Add(sysRoleRes);
                }
            }

            appDbContext.SysRoleRes.AddRange(sysRoleReses);
            appDbContext.SaveChanges();
        }

        public void TestM2MSelect()
        {
            using var appDbContext = new AppDbContext();

            var sysRole = appDbContext.SysRoles.Include(r => r.RoleResource).ThenInclude(r=>r.Res).First(u => u.Id == 1);
            PrintObj(sysRole.RoleResource.Count);
        }
    }
}
