using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FirmaMeble.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Adres",
                columns: new[] { "IdAdresu", "KodPocztowy", "Miejscowosc", "NrDomu", "NrLokalu", "Ulica" },
                values: new object[,]
                {
                    { 1, "00-950", "Warszawa", "10", "15", "Marszałkowska" },
                    { 2, "31-019", "Kraków", "5", "2", "Floriańska" }
                });

            migrationBuilder.InsertData(
                table: "Faktura",
                columns: new[] { "IdFaktury", "DataWystawienia", "IdKontrahenta", "IdSposobuPlatnosci", "Numer", "TerminPlatnosci" },
                values: new object[] { 1, null, null, null, null, null });

            migrationBuilder.InsertData(
                table: "Kontrahent",
                columns: new[] { "IdKontrahenta", "IdAdresu", "IdRodzaju", "IdStatusu", "Kod", "Nazwa", "Nip" },
                values: new object[,]
                {
                    { 1, 1, null, null, null, "Klient A", null },
                    { 2, 2, null, null, null, "Dostawca X", null }
                });

            migrationBuilder.InsertData(
                table: "Faktura",
                columns: new[] { "IdFaktury", "DataWystawienia", "IdKontrahenta", "IdSposobuPlatnosci", "Numer", "TerminPlatnosci" },
                values: new object[] { 2, new DateTime(2024, 1, 7, 19, 28, 54, 23, DateTimeKind.Local).AddTicks(3354), 1, null, "FV/2024/01", new DateTime(2024, 2, 6, 19, 28, 54, 23, DateTimeKind.Local).AddTicks(3404) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Faktura",
                keyColumn: "IdFaktury",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Faktura",
                keyColumn: "IdFaktury",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Kontrahent",
                keyColumn: "IdKontrahenta",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Adres",
                keyColumn: "IdAdresu",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Kontrahent",
                keyColumn: "IdKontrahenta",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Adres",
                keyColumn: "IdAdresu",
                keyValue: 1);
        }
    }
}
