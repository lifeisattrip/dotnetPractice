using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace csharp_practice.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SysConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    ConfigSection = table.Column<string>(maxLength: 32, nullable: false),
                    ConfigKey = table.Column<string>(maxLength: 32, nullable: false),
                    ConfigValue = table.Column<string>(nullable: false),
                    GmtCreate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysConfigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysResources",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    ResName = table.Column<string>(nullable: true),
                    GmtCreate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysResources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    RoleName = table.Column<string>(nullable: true),
                    GmtCreate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    UserName = table.Column<string>(nullable: true),
                    Account = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    GmtCreate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysRoleResource",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false),
                    ResourceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysRoleResource", x => new { x.ResourceId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_SysRoleResource_SysResources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "SysResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SysRoleResource_SysRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "SysRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SysConfigs_ConfigSection_ConfigKey",
                table: "SysConfigs",
                columns: new[] { "ConfigSection", "ConfigKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SysRoleResource_RoleId",
                table: "SysRoleResource",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SysConfigs");

            migrationBuilder.DropTable(
                name: "SysRoleResource");

            migrationBuilder.DropTable(
                name: "SysUsers");

            migrationBuilder.DropTable(
                name: "SysResources");

            migrationBuilder.DropTable(
                name: "SysRoles");
        }
    }
}
