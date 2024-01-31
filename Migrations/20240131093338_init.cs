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
                    BirthDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
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
                    { new Guid("db75d4bf-7588-45c1-bdcf-b53859b3dfea"), "G224", "Padova", "PD" },
                    { new Guid("e12d1843-c8d5-4921-b99e-21961d76eff5"), "L840", "Vicenza", "VI" },
                    { new Guid("edcd6feb-8677-4481-94f6-eb694b3f1509"), "L407", "Treviso", "TV" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "BirthDate", "Email", "Gender", "Name", "Surname", "TownId" },
                values: new object[,]
                {
                    { new Guid("3fdbbf4d-fd52-44a1-bc6f-7407cb4eddf7"), new DateTimeOffset(new DateTime(2015, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "ok@gipo.dev", "Male", "John1", "Doe", new Guid("db75d4bf-7588-45c1-bdcf-b53859b3dfea") },
                    { new Guid("40e03028-a131-4a8d-a630-91ef293754a2"), new DateTimeOffset(new DateTime(2015, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "ok@gipo.dev", "Male", "John3", "Doe", new Guid("edcd6feb-8677-4481-94f6-eb694b3f1509") },
                    { new Guid("f78054e0-dfe5-4063-9df7-30048ed0bc0d"), new DateTimeOffset(new DateTime(2015, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "ok@gipo.dev", "Male", "John2", "Doe", new Guid("e12d1843-c8d5-4921-b99e-21961d76eff5") }
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
