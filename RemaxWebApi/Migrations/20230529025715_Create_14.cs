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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModulePermissions");
        }
    }
}
