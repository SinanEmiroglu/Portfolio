using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NailDown.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitializedDBAndCreatedJobModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    LastEditDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "Description", "LastEditDate", "Status", "Title" },
                values: new object[,]
                {
                    { 1L, "Totus", new DateTime(2023, 9, 21, 16, 50, 9, 743, DateTimeKind.Local).AddTicks(9904), 2, "Register to gym" },
                    { 2L, "Totus", new DateTime(2023, 9, 21, 16, 50, 9, 743, DateTimeKind.Local).AddTicks(9933), 1, "Unregister to gym" },
                    { 3L, "Totus", new DateTime(2023, 9, 21, 16, 50, 9, 743, DateTimeKind.Local).AddTicks(9935), 0, "Reregister to gym" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jobs");
        }
    }
}
