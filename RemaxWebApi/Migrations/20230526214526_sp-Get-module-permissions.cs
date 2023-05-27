using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RemaxWebApi.Migrations
{
    /// <inheritdoc />
    public partial class spGetmodulepermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "ModulePermissionDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

             var sp = @"CREATE PROCEDURE [dbo].[Get_All_Modules_Permission]
                            AS
                            with cte as (
                                select  modules.[ShortCode],STRING_AGG (CONVERT(NVARCHAR(max),permission.[Description]), ',') AS permissions 
                                from CodeTypeValues modules
                                join CodeTypeValues permission on permission.CodeTypeShortCode='PERMISSIONS'
                                left join ModulePermissionDetails modper on modper.ModuleShortCode=Modules.ShortCode and modper.Permissionshortcode=permission.ShortCode
                                where  modules.CodeTypeShortCode in ('MODULES')  and modper.modulepermissionid is not null
                                group by modules.ShortCode
                                )  
                            select  modules.ShortCode as ModuleShortName , modules.[Description] as ModuleName,dp.permissions as Permission from CodeTypeValues modules
                                left join cte dp on dp.ShortCode=modules.ShortCode
                                where  modules.CodeTypeShortCode in ('MODULES') ";
                
        migrationBuilder.Sql(sp);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedBy",
                table: "ModulePermissionDetails",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
