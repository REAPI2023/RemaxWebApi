using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RemaxWebApi.Migrations
{
    /// <inheritdoc />
    public partial class Create_14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ModulePermissions",
                columns: table => new
                {
                    ModuleShortName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModuleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Permission = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModulePermissions", x => x.ModuleShortName);
                });

            migrationBuilder.CreateTable(
                name: "RoleModulePermissionDetails",
                columns: table => new
                {
                    RoleShortCode = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleShortCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermissionShortCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleModulePermissionDetails", x => x.RoleShortCode);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModulePermissions");

            migrationBuilder.DropTable(
                name: "RoleModulePermissionDetails");
        }
    }
}
