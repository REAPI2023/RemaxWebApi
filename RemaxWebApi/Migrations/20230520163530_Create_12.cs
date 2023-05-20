using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RemaxWebApi.Migrations
{
    /// <inheritdoc />
    public partial class Create_12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PropertyID",
                table: "LeadPropertyDetails",
                newName: "PropertyId");

            migrationBuilder.RenameColumn(
                name: "LeadsID",
                table: "LeadPropertyDetails",
                newName: "LeadId");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "LeadPropertyDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "LeadPropertyDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "LeadPropertyDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "LeadPropertyDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "LeadPropertyDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "LeadPropertyDetails",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "LeadPropertyDetails");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "LeadPropertyDetails");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "LeadPropertyDetails");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "LeadPropertyDetails");

            migrationBuilder.RenameColumn(
                name: "PropertyId",
                table: "LeadPropertyDetails",
                newName: "PropertyID");

            migrationBuilder.RenameColumn(
                name: "LeadId",
                table: "LeadPropertyDetails",
                newName: "LeadsID");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "LeadPropertyDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "LeadPropertyDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
