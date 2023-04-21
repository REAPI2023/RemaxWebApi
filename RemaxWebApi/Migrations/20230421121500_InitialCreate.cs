using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RemaxWebApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leads",
                columns: table => new
                {
                    LeadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhNumber = table.Column<int>(type: "int", nullable: false),
                    Budget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Criteria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeadStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviousSchedule = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NextSchedule = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Facility = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leads", x => x.LeadId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leads");
        }
    }
}
