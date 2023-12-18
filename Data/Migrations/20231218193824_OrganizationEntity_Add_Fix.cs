using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class OrganizationEntityAddFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "contacts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Regon = table.Column<string>(type: "TEXT", nullable: false),
                    Nip = table.Column<string>(type: "TEXT", nullable: false),
                    AddressCity = table.Column<string>(name: "Address_City", type: "TEXT", nullable: true),
                    AddressStreet = table.Column<string>(name: "Address_Street", type: "TEXT", nullable: true),
                    AddressPostalCode = table.Column<string>(name: "Address_PostalCode", type: "TEXT", nullable: true),
                    AddressRegion = table.Column<string>(name: "Address_Region", type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Nip", "Regon", "Title", "Address_City", "Address_PostalCode", "Address_Region", "Address_Street" },
                values: new object[,]
                {
                    { 1, "83492384", "13424234", "WSEI", "Kraków", "31-150", "małopolskie", "Św. Filipa 17" },
                    { 2, "2498534", "0873439249", "Firma", "Kraków", "31-150", "małopolskie", "Krowoderska 45/6" }
                });

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "birth_date", "Email", "Name", "OrganizationId", "Phone" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adam", "AA", 1, "13424234" });

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "birth_date", "Email", "Name", "OrganizationId", "Phone" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ewa", "C#", 2, "02879283" });

            migrationBuilder.CreateIndex(
                name: "IX_contacts_OrganizationId",
                table: "contacts",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_contacts_Organizations_OrganizationId",
                table: "contacts",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contacts_Organizations_OrganizationId",
                table: "contacts");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_contacts_OrganizationId",
                table: "contacts");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "contacts");

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "birth_date", "Email", "Name", "Phone" },
                values: new object[] { new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "adam@wsei.edu.pl", "Adam", "127813268163" });

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "birth_date", "Email", "Name", "Phone" },
                values: new object[] { new DateTime(1999, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ewa@wsei.edu.pl", "Ewa", "293443823478" });
        }
    }
}
