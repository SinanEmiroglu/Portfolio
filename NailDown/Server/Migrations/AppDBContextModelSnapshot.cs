﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NailDown.Server.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NailDown.Server.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("NailDown.Shared.Model.JobModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastEditDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Jobs");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Description = "Totus",
                            LastEditDate = new DateTime(2023, 9, 21, 16, 50, 9, 743, DateTimeKind.Local).AddTicks(9904),
                            Status = 2,
                            Title = "Register to gym"
                        },
                        new
                        {
                            Id = 2L,
                            Description = "Totus",
                            LastEditDate = new DateTime(2023, 9, 21, 16, 50, 9, 743, DateTimeKind.Local).AddTicks(9933),
                            Status = 1,
                            Title = "Unregister to gym"
                        },
                        new
                        {
                            Id = 3L,
                            Description = "Totus",
                            LastEditDate = new DateTime(2023, 9, 21, 16, 50, 9, 743, DateTimeKind.Local).AddTicks(9935),
                            Status = 0,
                            Title = "Reregister to gym"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
