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
    [Migration("20230421121500_InitialCreate")]
    partial class InitialCreate
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

                    b.Property<DateTime?>("NextSchedule")
                        .HasColumnType("datetime2");

                    b.Property<int>("PhNumber")
                        .HasColumnType("int");

                    b.Property<DateTime?>("PreviousSchedule")
                        .HasColumnType("datetime2");

                    b.HasKey("LeadId");

                    b.ToTable("Leads");
                });
#pragma warning restore 612, 618
        }
    }
}
