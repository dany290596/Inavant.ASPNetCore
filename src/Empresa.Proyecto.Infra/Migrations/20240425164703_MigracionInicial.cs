using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Empresa.Proyecto.Infra.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SimpleEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimpleEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompleteEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SimpleEntityId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompleteEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompleteEntity_SimpleEntity",
                        column: x => x.SimpleEntityId,
                        principalTable: "SimpleEntity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ComplexEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CatalogExampleId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplexEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComplexEntity_SimpleEntity_CatalogExampleId",
                        column: x => x.CatalogExampleId,
                        principalTable: "SimpleEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SimpleEntity",
                columns: new[] { "Id", "Created", "Modified", "Name", "Value" },
                values: new object[] { 1, new DateTime(2024, 4, 25, 10, 47, 3, 528, DateTimeKind.Local).AddTicks(2399), new DateTime(2024, 4, 25, 10, 47, 3, 528, DateTimeKind.Local).AddTicks(2412), "Nuevo", "Nuevo" });

            migrationBuilder.InsertData(
                table: "SimpleEntity",
                columns: new[] { "Id", "Created", "Modified", "Name", "Value" },
                values: new object[] { 2, new DateTime(2024, 4, 25, 10, 47, 3, 528, DateTimeKind.Local).AddTicks(2414), new DateTime(2024, 4, 25, 10, 47, 3, 528, DateTimeKind.Local).AddTicks(2414), "Existente", "Existente" });

            migrationBuilder.InsertData(
                table: "SimpleEntity",
                columns: new[] { "Id", "Created", "Modified", "Name", "Value" },
                values: new object[] { 3, new DateTime(2024, 4, 25, 10, 47, 3, 528, DateTimeKind.Local).AddTicks(2415), new DateTime(2024, 4, 25, 10, 47, 3, 528, DateTimeKind.Local).AddTicks(2416), "Reconstruido", "Reconstruido" });

            migrationBuilder.CreateIndex(
                name: "IX_CompleteEntity_SimpleEntityId",
                table: "CompleteEntity",
                column: "SimpleEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplexEntity_CatalogExampleId",
                table: "ComplexEntity",
                column: "CatalogExampleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompleteEntity");

            migrationBuilder.DropTable(
                name: "ComplexEntity");

            migrationBuilder.DropTable(
                name: "SimpleEntity");
        }
    }
}
