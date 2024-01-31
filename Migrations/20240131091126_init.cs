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
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
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
                    { new Guid("51416c54-8090-46ed-846c-9fd049353ce3"), "L840", "Vicenza", "VI" },
                    { new Guid("6d6015c6-d698-48a2-ad90-f26a5509acb3"), "G224", "Padova", "PD" },
                    { new Guid("a74f9d2e-6ce9-4de1-bef2-8acf6e9bcd35"), "L407", "Treviso", "TV" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "BirthDate", "Email", "Gender", "Name", "Surname", "TownId" },
                values: new object[,]
                {
                    { new Guid("1183d79a-b4fb-4d95-830f-4d6a20039ac9"), new DateOnly(1, 1, 1), "ok@gipo.dev", "Male", "John2", "Doe", new Guid("51416c54-8090-46ed-846c-9fd049353ce3") },
                    { new Guid("15b2af53-30a7-4d42-8835-93ac9d126c02"), new DateOnly(1, 1, 1), "ok@gipo.dev", "Male", "John1", "Doe", new Guid("6d6015c6-d698-48a2-ad90-f26a5509acb3") },
                    { new Guid("8d92b651-4d90-45bd-bc9a-c28e3ef32cf2"), new DateOnly(1, 1, 1), "ok@gipo.dev", "Male", "John3", "Doe", new Guid("a74f9d2e-6ce9-4de1-bef2-8acf6e9bcd35") }
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
