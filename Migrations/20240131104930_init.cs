using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ItsWdfs.Csharp.Exam.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Towns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Province = table.Column<string>(type: "text", nullable: true),
                    CodiceCatastale = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Towns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    TownId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Towns_TownId",
                        column: x => x.TownId,
                        principalTable: "Towns",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "Id", "CodiceCatastale", "Name", "Province" },
                values: new object[,]
                {
                    { new Guid("4e8db196-df99-42f4-a2b5-5647b2891ed8"), "G224", "Padova", "PD" },
                    { new Guid("c154caa7-e053-4b24-8377-d261f559a1da"), "L840", "Vicenza", "VI" },
                    { new Guid("cd27eac6-d6bd-4208-b516-c641a458de9f"), "L407", "Treviso", "TV" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "BirthDate", "Email", "Gender", "Name", "Surname", "TownId" },
                values: new object[,]
                {
                    { new Guid("c559d086-2abf-4811-b86c-5fe3682ff3ca"), new DateTime(2015, 12, 30, 23, 0, 0, 0, DateTimeKind.Utc), "ok@gipo.dev", "Male", "John1", "Doe", new Guid("4e8db196-df99-42f4-a2b5-5647b2891ed8") },
                    { new Guid("c7062ac4-439a-485a-83ac-3a13a9d1b85d"), new DateTime(2015, 12, 30, 23, 0, 0, 0, DateTimeKind.Utc), "ok@gipo.dev", "Male", "John3", "Doe", new Guid("cd27eac6-d6bd-4208-b516-c641a458de9f") },
                    { new Guid("e436dbaa-a076-43ea-8bcb-4a4470d3e2d4"), new DateTime(2015, 12, 30, 23, 0, 0, 0, DateTimeKind.Utc), "ok@gipo.dev", "Male", "John2", "Doe", new Guid("c154caa7-e053-4b24-8377-d261f559a1da") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_TownId",
                table: "Employees",
                column: "TownId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Towns");
        }
    }
}
