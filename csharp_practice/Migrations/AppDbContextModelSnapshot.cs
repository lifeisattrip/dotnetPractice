﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using csharp_practice.EFTest;

namespace csharp_practice.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("csharp_practice.EFTest.SysConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConfigKey")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.Property<string>("ConfigSection")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.Property<string>("ConfigValue")
                        .IsRequired();

                    b.Property<DateTime>("GmtCreate");

                    b.HasKey("Id");

                    b.HasIndex("ConfigSection", "ConfigKey")
                        .IsUnique();

                    b.ToTable("SysConfigs");
                });

            modelBuilder.Entity("csharp_practice.EFTest.SysRes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("GmtCreate");

                    b.Property<string>("ResName");

                    b.HasKey("Id");

                    b.ToTable("SysRes");
                });

            modelBuilder.Entity("csharp_practice.EFTest.SysRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("GmtCreate");

                    b.Property<string>("RoleName");

                    b.HasKey("Id");

                    b.ToTable("SysRoles");
                });

            modelBuilder.Entity("csharp_practice.EFTest.SysRoleRes", b =>
                {
                    b.Property<int>("ResourceId");

                    b.Property<int>("RoleId");

                    b.HasKey("ResourceId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("SysRoleRes");
                });

            modelBuilder.Entity("csharp_practice.EFTest.SysUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Account");

                    b.Property<string>("Address");

                    b.Property<string>("Email");

                    b.Property<DateTime>("GmtCreate");

                    b.Property<string>("Password");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("SysUsers");
                });

            modelBuilder.Entity("csharp_practice.EFTest.SysRoleRes", b =>
                {
                    b.HasOne("csharp_practice.EFTest.SysRes", "Res")
                        .WithMany("RoleResource")
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("csharp_practice.EFTest.SysRole", "Role")
                        .WithMany("RoleResource")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
