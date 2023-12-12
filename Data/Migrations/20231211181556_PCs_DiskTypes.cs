using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class PCsDiskTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiskTypes",
                columns: table => new
                {
                    Type = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiskTypes", x => x.Type);
                });

            migrationBuilder.CreateTable(
                name: "pcs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Processor = table.Column<string>(type: "TEXT", nullable: false),
                    RAM = table.Column<string>(type: "TEXT", nullable: false),
                    Disk = table.Column<string>(type: "TEXT", nullable: false),
                    DiskTypeId = table.Column<string>(type: "TEXT", nullable: false),
                    GPU = table.Column<string>(type: "TEXT", nullable: false),
                    Manufacturer = table.Column<string>(type: "TEXT", nullable: true),
                    ProductionDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pcs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pcs_DiskTypes_DiskTypeId",
                        column: x => x.DiskTypeId,
                        principalTable: "DiskTypes",
                        principalColumn: "Type",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DiskTypes",
                column: "Type",
                values: new object[]
                {
                    "HDD",
                    "NVMe",
                    "SSD"
                });

            migrationBuilder.CreateIndex(
                name: "IX_pcs_DiskTypeId",
                table: "pcs",
                column: "DiskTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pcs");

            migrationBuilder.DropTable(
                name: "DiskTypes");
        }
    }
}
