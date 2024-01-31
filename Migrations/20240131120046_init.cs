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
                    FiscalCode = table.Column<string>(type: "text", nullable: true),
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
                    { new Guid("93a30cd4-a06f-4fec-9219-699f5d710dd2"), "G224", "Padova", "PD" },
                    { new Guid("b469698c-85cc-49fb-ac52-de4321eb78f9"), "L840", "Vicenza", "VI" },
                    { new Guid("c81e07c2-4a95-4ab0-8365-75da1d94a57f"), "L407", "Treviso", "TV" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "BirthDate", "Email", "FiscalCode", "Gender", "Name", "Surname", "TownId" },
                values: new object[,]
                {
                    { new Guid("cd46f869-acf3-44b8-a30e-9f3a35e67af8"), new DateTime(2015, 12, 30, 23, 0, 0, 0, DateTimeKind.Utc), "ok@gipo.dev", null, "Male", "John1", "Doe", new Guid("93a30cd4-a06f-4fec-9219-699f5d710dd2") },
                    { new Guid("ed9c4f97-da6d-482e-bf83-31cd2df461b0"), new DateTime(2015, 12, 30, 23, 0, 0, 0, DateTimeKind.Utc), "ok@gipo.dev", null, "Male", "John3", "Doe", new Guid("c81e07c2-4a95-4ab0-8365-75da1d94a57f") },
                    { new Guid("fe68413b-4e15-4a06-9888-076cc7e19b8b"), new DateTime(2015, 12, 30, 23, 0, 0, 0, DateTimeKind.Utc), "ok@gipo.dev", null, "Male", "John2", "Doe", new Guid("b469698c-85cc-49fb-ac52-de4321eb78f9") }
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
