using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class DeleteDiskType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pcs_DiskTypes_DiskTypeId",
                table: "pcs");

            migrationBuilder.DropTable(
                name: "DiskTypes");

            migrationBuilder.DropIndex(
                name: "IX_pcs_DiskTypeId",
                table: "pcs");

            migrationBuilder.RenameColumn(
                name: "DiskTypeId",
                table: "pcs",
                newName: "DiskType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DiskType",
                table: "pcs",
                newName: "DiskTypeId");

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

            migrationBuilder.InsertData(
                table: "DiskTypes",
                column: "Type",
                values: new object[]
                {
                    "HDD",
                    "Hybrydowy",
                    "NVMe",
                    "SSD"
                });

            migrationBuilder.CreateIndex(
                name: "IX_pcs_DiskTypeId",
                table: "pcs",
                column: "DiskTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_pcs_DiskTypes_DiskTypeId",
                table: "pcs",
                column: "DiskTypeId",
                principalTable: "DiskTypes",
                principalColumn: "Type",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
