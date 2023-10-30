﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RemaxWebAPI.Models;

#nullable disable

namespace RemaxWebApi.Migrations
{
    [DbContext(typeof(RelEstDbContext))]
    [Migration("20230606180412_Create_202")]
    partial class Create_202
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RemaxWebAPI.Models.Leads", b =>
                {
                    b.Property<int>("LeadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LeadId"));

                    b.Property<decimal>("Budget")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Criteria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Facility")
                        .HasColumnType("int");

                    b.Property<string>("LeadStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LeadId");

                    b.ToTable("Leads");
                });

            modelBuilder.Entity("RemaxWebApi.Models.CodeTypeValues", b =>
                {
                    b.Property<string>("ShortCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CodeTypeShortCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ShortCode");

                    b.ToTable("CodeTypeValues");
                });

            modelBuilder.Entity("RemaxWebApi.Models.CodeTypes", b =>
                {
                    b.Property<string>("ShortCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedBy")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ShortCode");

                    b.ToTable("CodeTypes");
                });

            modelBuilder.Entity("RemaxWebApi.Models.CommercialProperty", b =>
                {
                    b.Property<int>("PropertyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PropertyId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Amenities")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("AskingPrice")
                        .HasColumnType("float");

                    b.Property<double>("CarpetArea")
                        .HasColumnType("float");

                    b.Property<int>("ContractType")
                        .HasColumnType("int");

                    b.Property<int?>("Facility")
                        .HasColumnType("int");

                    b.Property<string>("Facing")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("FinalPrice")
                        .HasColumnType("float");

                    b.Property<string>("FloorDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FurnishedStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LockInPeriod")
                        .HasColumnType("int");

                    b.Property<double>("Maintenance")
                        .HasColumnType("float");

                    b.Property<int>("NoOfCabins")
                        .HasColumnType("int");

                    b.Property<int?>("NoOfCarParkings")
                        .HasColumnType("int");

                    b.Property<int>("NoOfWashRooms")
                        .HasColumnType("int");

                    b.Property<int>("NoOfWorkStations")
                        .HasColumnType("int");

                    b.Property<bool>("PantryAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("Pictures")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PropertyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PropertyType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("SecurityDeposit")
                        .HasColumnType("float");

                    b.Property<double>("SuperBuiltUpArea")
                        .HasColumnType("float");

                    b.HasKey("PropertyId");

                    b.ToTable("CommercialProperty");
                });

            modelBuilder.Entity("RemaxWebApi.Models.LeadNotes", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Facility")
                        .HasColumnType("int");

                    b.Property<int>("LeadId")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("LeadNotes");
                });

            modelBuilder.Entity("RemaxWebApi.Models.LeadPropertyDetails", b =>
                {
                    b.Property<int>("LeadPropertyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LeadPropertyID"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("LeadId")
                        .HasColumnType("int");

                    b.Property<int>("PropertyId")
                        .HasColumnType("int");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("LeadPropertyID");

                    b.ToTable("LeadPropertyDetails");
                });

            modelBuilder.Entity("RemaxWebApi.Models.ModulePermission", b =>
                {
                    b.Property<string>("ModuleShortName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ModuleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Permission")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ModuleShortName");

                    b.ToTable("ModulePermissions");
                });

            modelBuilder.Entity("RemaxWebApi.Models.ModulePermissionDetails", b =>
                {
                    b.Property<long>("ModulePermissionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ModulePermissionID"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModuleShortCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PermissionShortCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ModulePermissionID");

                    b.ToTable("ModulePermissionDetails");
                });

            modelBuilder.Entity("RemaxWebApi.Models.ModuleRolePermissionDetails", b =>
                {
                    b.Property<long?>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long?>("RoleID"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModuleShortCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PermissionShortCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleShortCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("RoleID");

                    b.ToTable("ModuleRolePermissionDetails");
                });

            modelBuilder.Entity("RemaxWebApi.Models.ResidentialProperty", b =>
                {
                    b.Property<int>("PropertyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PropertyId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Amenities")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("AskingPrice")
                        .HasColumnType("float");

                    b.Property<double>("Dimention")
                        .HasColumnType("float");

                    b.Property<int?>("Facility")
                        .HasColumnType("int");

                    b.Property<string>("Facing")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("FinalPrice")
                        .HasColumnType("float");

                    b.Property<int>("FlatFloor")
                        .HasColumnType("int");

                    b.Property<string>("FurnishedStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NoOfBalcony")
                        .HasColumnType("int");

                    b.Property<int>("NoOfBathRooms")
                        .HasColumnType("int");

                    b.Property<int>("NoOfBeds")
                        .HasColumnType("int");

                    b.Property<int?>("NoOfCarParkings")
                        .HasColumnType("int");

                    b.Property<int>("NoOfFlatsInAFloor")
                        .HasColumnType("int");

                    b.Property<int>("NoOfLifts")
                        .HasColumnType("int");

                    b.Property<string>("Pictures")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PropertyAge")
                        .HasColumnType("int");

                    b.Property<string>("PropertyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PropertyType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalFloors")
                        .HasColumnType("int");

                    b.HasKey("PropertyId");

                    b.ToTable("ResidentialProperty");
                });

            modelBuilder.Entity("RemaxWebApi.Models.RoleModulePermissionDetails", b =>
                {
                    b.Property<string>("RoleShortCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModuleShortCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PermissionShortCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("RoleShortCode");

                    b.ToTable("RoleModulePermissionDetails");
                });

            modelBuilder.Entity("RemaxWebApi.Models.Schedule", b =>
                {
                    b.Property<int>("ScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScheduleId"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Facility")
                        .HasColumnType("int");

                    b.Property<int>("LeadId")
                        .HasColumnType("int");

                    b.Property<string>("ScheduleNotes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ScheduleTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ScheduleType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedBy")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ScheduleId");

                    b.ToTable("Schedule");
                });

            modelBuilder.Entity("RemaxWebApi.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}