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
                name: "SysRes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    ResName = table.Column<string>(nullable: true),
                    GmtCreate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysRes", x => x.Id);
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
                name: "SysRoleRes",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false),
                    ResourceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysRoleRes", x => new { x.ResourceId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_SysRoleRes_SysRes_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "SysRes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SysRoleRes_SysRoles_RoleId",
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
                name: "IX_SysRoleRes_RoleId",
                table: "SysRoleRes",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SysConfigs");

            migrationBuilder.DropTable(
                name: "SysRoleRes");

            migrationBuilder.DropTable(
                name: "SysUsers");

            migrationBuilder.DropTable(
                name: "SysRes");

            migrationBuilder.DropTable(
                name: "SysRoles");
        }
    }
}
