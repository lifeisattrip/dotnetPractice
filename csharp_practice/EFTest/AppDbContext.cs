﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace csharp_practice.EFTest
{
   public class AppDbContext: DbContext
    {
        public DbSet<SysConfig> SysConfigs { get; set; }
        public DbSet<SysUser> SysUsers { get; set; }
        public DbSet<SysRole> SysRoles { get; set; }
        public DbSet<SysResource> SysResources { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new EFLoggerProvider());
            optionsBuilder
                .UseLoggerFactory(loggerFactory)
                .UseMySQL(
               //"server=172.16.0.183;userid=root;pwd=xianwei;port=3306;database=testef;charset=utf8;sslmode=None"
                "server=127.0.0.1;userid=root;pwd=123456;port=3306;database=testef;charset=utf8;sslmode=None"
            );
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
            modelBuilder.Entity<SysConfig>()
            .HasIndex(p => new { p.ConfigSection, p.ConfigKey })
            .IsUnique(true);

            modelBuilder.Entity<SysRoleResource>()
                .HasKey(rr => new { rr.ResourceId, rr.RoleId });
            modelBuilder.Entity<SysRoleResource>()
                .HasOne(rr => rr.Role)
                .WithMany(rr => rr.RoleResource)
                .HasForeignKey(rr => rr.RoleId);

            modelBuilder.Entity<SysRoleResource>()
                .HasOne(rr => rr.Resource)
                .WithMany(rr => rr.RoleResource)
                .HasForeignKey(rr => rr.ResourceId);
        }
    }
}