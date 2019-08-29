using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace csharp_practice.EFTest
{
    public class AppDbContext : DbContext
    {
        public DbSet<SysConfig> SysConfigs { get; set; }
        public DbSet<SysUser> SysUsers { get; set; }
        public DbSet<SysRole> SysRoles { get; set; }
        public DbSet<SysRes> SysRes { get; set; }
        public DbSet<SysRoleRes> SysRoleRes { get; set; }
        private bool HasOption = false;

        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions options) : base(options)
        {
            HasOption = true;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!HasOption)
            {
                var loggerFactory = new LoggerFactory();
                loggerFactory.AddProvider(new EFLoggerProvider());
                optionsBuilder
                    .UseLoggerFactory(loggerFactory)
                    .UseMySQL(
                        "server=172.16.0.183;userid=root;pwd=xianwei;port=3306;database=testef;charset=utf8;sslmode=None"
//                        "server=127.0.0.1;userid=root;pwd=123456;port=3306;database=testef;charset=utf8;sslmode=None"
                    );
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SysConfig>()
                .HasIndex(p => new {p.ConfigSection, p.ConfigKey})
                .IsUnique(true);

            modelBuilder.Entity<SysRoleRes>()
                .HasKey(rr => new {rr.ResourceId, rr.RoleId});
            modelBuilder.Entity<SysRoleRes>()
                .HasOne(rr => rr.Role)
                .WithMany(rr => rr.RoleResource)
                .HasForeignKey(rr => rr.RoleId);

            modelBuilder.Entity<SysRoleRes>()
                .HasOne(rr => rr.Res)
                .WithMany(rr => rr.RoleResource)
                .HasForeignKey(rr => rr.ResourceId);
        }
    }
}
