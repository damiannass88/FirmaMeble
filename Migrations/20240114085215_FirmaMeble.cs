using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FirmaMeble.Migrations
{
    /// <inheritdoc />
    public partial class FirmaMeble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adres",
                columns: table => new
                {
                    IdAdresu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Miejscowosc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Ulica = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NrDomu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NrLokalu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    KodPocztowy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adres", x => x.IdAdresu);
                });

            migrationBuilder.CreateTable(
                name: "FakturaForViewDbSet",
                columns: table => new
                {
                    IdFaktury = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataWystawienia = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KontrahentNazwa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KontrahentNIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KontrahentAdres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TerminPlatnosci = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SposobPlatnosciNazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FakturaForViewDbSet", x => x.IdFaktury);
                });

            migrationBuilder.CreateTable(
                name: "Rodzaj",
                columns: table => new
                {
                    IdRodzaju = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rodzaj", x => x.IdRodzaju);
                });

            migrationBuilder.CreateTable(
                name: "SposobPlatnosci",
                columns: table => new
                {
                    IdSposobuPlatnosci = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SposobPlatnosci", x => x.IdSposobuPlatnosci);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    IdStatusu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.IdStatusu);
                });

            migrationBuilder.CreateTable(
                name: "Towar",
                columns: table => new
                {
                    IdTowaru = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Nazwa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StawkaVatSprzedazy = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    StawkaVatZakupu = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    Cena = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    Marza = table.Column<decimal>(type: "decimal(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Towar", x => x.IdTowaru);
                });

            migrationBuilder.CreateTable(
                name: "Dostawca",
                columns: table => new
                {
                    IdDostawcy = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaFirmy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nip = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdAdresu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dostawca", x => x.IdDostawcy);
                    table.ForeignKey(
                        name: "FK_Dostawca_Adres_IdAdresu",
                        column: x => x.IdAdresu,
                        principalTable: "Adres",
                        principalColumn: "IdAdresu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Magazyn",
                columns: table => new
                {
                    IdMagazynu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lokalizacja = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Pojemność = table.Column<int>(type: "int", nullable: false),
                    IdAdresu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Magazyn", x => x.IdMagazynu);
                    table.ForeignKey(
                        name: "FK_Magazyn_Adres_IdAdresu",
                        column: x => x.IdAdresu,
                        principalTable: "Adres",
                        principalColumn: "IdAdresu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pracownik",
                columns: table => new
                {
                    IdPracownika = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Stanowisko = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdAdresu = table.Column<int>(type: "int", nullable: false),
                    DataZatrudnienia = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pracownik", x => x.IdPracownika);
                    table.ForeignKey(
                        name: "FK_Pracownik_Adres_IdAdresu",
                        column: x => x.IdAdresu,
                        principalTable: "Adres",
                        principalColumn: "IdAdresu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kontrahent",
                columns: table => new
                {
                    IdKontrahenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kod = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Nazwa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Nip = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IdRodzaju = table.Column<int>(type: "int", nullable: true),
                    IdStatusu = table.Column<int>(type: "int", nullable: true),
                    IdAdresu = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kontrahent", x => x.IdKontrahenta);
                    table.ForeignKey(
                        name: "FK_Kontrahent_Adres_IdAdresu",
                        column: x => x.IdAdresu,
                        principalTable: "Adres",
                        principalColumn: "IdAdresu");
                    table.ForeignKey(
                        name: "FK_Kontrahent_Rodzaj_IdRodzaju",
                        column: x => x.IdRodzaju,
                        principalTable: "Rodzaj",
                        principalColumn: "IdRodzaju");
                    table.ForeignKey(
                        name: "FK_Kontrahent_Status_IdStatusu",
                        column: x => x.IdStatusu,
                        principalTable: "Status",
                        principalColumn: "IdStatusu");
                });

            migrationBuilder.CreateTable(
                name: "ZakupMaterialow",
                columns: table => new
                {
                    IdZakupu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDostawcy = table.Column<int>(type: "int", nullable: false),
                    DataZakupu = table.Column<DateTime>(type: "date", nullable: false),
                    Kwota = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZakupMaterialow", x => x.IdZakupu);
                    table.ForeignKey(
                        name: "FK_ZakupMaterialow_Dostawca_IdDostawcy",
                        column: x => x.IdDostawcy,
                        principalTable: "Dostawca",
                        principalColumn: "IdDostawcy",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdukcjaMebla",
                columns: table => new
                {
                    IdProdukcji = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTowaru = table.Column<int>(type: "int", nullable: false),
                    DataRozpoczęcia = table.Column<DateTime>(type: "date", nullable: false),
                    DataZakończenia = table.Column<DateTime>(type: "date", nullable: false),
                    IlośćProdukowanychSztuk = table.Column<int>(type: "int", nullable: false),
                    IdPracownika = table.Column<int>(type: "int", nullable: false),
                    StatusProdukcji = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdukcjaMebla", x => x.IdProdukcji);
                    table.ForeignKey(
                        name: "FK_ProdukcjaMebla_Pracownik_IdPracownika",
                        column: x => x.IdPracownika,
                        principalTable: "Pracownik",
                        principalColumn: "IdPracownika",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdukcjaMebla_Towar_IdTowaru",
                        column: x => x.IdTowaru,
                        principalTable: "Towar",
                        principalColumn: "IdTowaru",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Umowa",
                columns: table => new
                {
                    IdUmowy = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypUmowy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataRozpoczecia = table.Column<DateTime>(type: "date", nullable: false),
                    DataZakonczenia = table.Column<DateTime>(type: "date", nullable: true),
                    KwotaBrutto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdPracownika = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Umowa", x => x.IdUmowy);
                    table.ForeignKey(
                        name: "Umowa_Pracownik",
                        column: x => x.IdPracownika,
                        principalTable: "Pracownik",
                        principalColumn: "IdPracownika");
                });

            migrationBuilder.CreateTable(
                name: "Faktura",
                columns: table => new
                {
                    IdFaktury = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DataWystawienia = table.Column<DateTime>(type: "date", nullable: true),
                    IdKontrahenta = table.Column<int>(type: "int", nullable: true),
                    TerminPlatnosci = table.Column<DateTime>(type: "date", nullable: true),
                    IdSposobuPlatnosci = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faktura", x => x.IdFaktury);
                    table.ForeignKey(
                        name: "FK_Faktura_Kontrahent_IdKontrahenta",
                        column: x => x.IdKontrahenta,
                        principalTable: "Kontrahent",
                        principalColumn: "IdKontrahenta");
                    table.ForeignKey(
                        name: "FK_Faktura_SposobPlatnosci_IdSposobuPlatnosci",
                        column: x => x.IdSposobuPlatnosci,
                        principalTable: "SposobPlatnosci",
                        principalColumn: "IdSposobuPlatnosci");
                });

            migrationBuilder.CreateTable(
                name: "Zamowienie",
                columns: table => new
                {
                    IdZamowienia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdKlienta = table.Column<int>(type: "int", nullable: false),
                    KlientIdKontrahenta = table.Column<int>(type: "int", nullable: false),
                    DataZamowienia = table.Column<DateTime>(type: "date", nullable: false),
                    StatusZamowienia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PrzewidywanaDataDostawy = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamowienie", x => x.IdZamowienia);
                    table.ForeignKey(
                        name: "FK_Zamowienie_Kontrahent_KlientIdKontrahenta",
                        column: x => x.KlientIdKontrahenta,
                        principalTable: "Kontrahent",
                        principalColumn: "IdKontrahenta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SzczegolyZamowienia",
                columns: table => new
                {
                    IdSzczegolyZamowienia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdZamowienia = table.Column<int>(type: "int", nullable: false),
                    IdTowaru = table.Column<int>(type: "int", nullable: false),
                    Ilość = table.Column<int>(type: "int", nullable: false),
                    CenaZaSztuke = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SzczegolyZamowienia", x => x.IdSzczegolyZamowienia);
                    table.ForeignKey(
                        name: "FK_SzczegolyZamowienia_Towar_IdTowaru",
                        column: x => x.IdTowaru,
                        principalTable: "Towar",
                        principalColumn: "IdTowaru",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SzczegolyZamowienia_Zamowienie_IdZamowienia",
                        column: x => x.IdZamowienia,
                        principalTable: "Zamowienie",
                        principalColumn: "IdZamowienia",
                        onDelete: ReferentialAction.Cascade);
                });

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
                values: new object[] { 2, new DateTime(2024, 1, 14, 9, 52, 14, 615, DateTimeKind.Local).AddTicks(6282), 1, null, "FV/2024/01", new DateTime(2024, 2, 13, 9, 52, 14, 615, DateTimeKind.Local).AddTicks(6327) });

            migrationBuilder.CreateIndex(
                name: "IX_Dostawca_IdAdresu",
                table: "Dostawca",
                column: "IdAdresu");

            migrationBuilder.CreateIndex(
                name: "IX_Faktura_IdKontrahenta",
                table: "Faktura",
                column: "IdKontrahenta");

            migrationBuilder.CreateIndex(
                name: "IX_Faktura_IdSposobuPlatnosci",
                table: "Faktura",
                column: "IdSposobuPlatnosci");

            migrationBuilder.CreateIndex(
                name: "IX_Kontrahent_IdAdresu",
                table: "Kontrahent",
                column: "IdAdresu");

            migrationBuilder.CreateIndex(
                name: "IX_Kontrahent_IdRodzaju",
                table: "Kontrahent",
                column: "IdRodzaju");

            migrationBuilder.CreateIndex(
                name: "IX_Kontrahent_IdStatusu",
                table: "Kontrahent",
                column: "IdStatusu");

            migrationBuilder.CreateIndex(
                name: "IX_Magazyn_IdAdresu",
                table: "Magazyn",
                column: "IdAdresu");

            migrationBuilder.CreateIndex(
                name: "IX_Pracownik_IdAdresu",
                table: "Pracownik",
                column: "IdAdresu");

            migrationBuilder.CreateIndex(
                name: "IX_ProdukcjaMebla_IdPracownika",
                table: "ProdukcjaMebla",
                column: "IdPracownika");

            migrationBuilder.CreateIndex(
                name: "IX_ProdukcjaMebla_IdTowaru",
                table: "ProdukcjaMebla",
                column: "IdTowaru");

            migrationBuilder.CreateIndex(
                name: "IX_SzczegolyZamowienia_IdTowaru",
                table: "SzczegolyZamowienia",
                column: "IdTowaru");

            migrationBuilder.CreateIndex(
                name: "IX_SzczegolyZamowienia_IdZamowienia",
                table: "SzczegolyZamowienia",
                column: "IdZamowienia");

            migrationBuilder.CreateIndex(
                name: "IX_Umowa_IdPracownika",
                table: "Umowa",
                column: "IdPracownika");

            migrationBuilder.CreateIndex(
                name: "IX_ZakupMaterialow_IdDostawcy",
                table: "ZakupMaterialow",
                column: "IdDostawcy");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienie_KlientIdKontrahenta",
                table: "Zamowienie",
                column: "KlientIdKontrahenta");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Faktura");

            migrationBuilder.DropTable(
                name: "FakturaForViewDbSet");

            migrationBuilder.DropTable(
                name: "Magazyn");

            migrationBuilder.DropTable(
                name: "ProdukcjaMebla");

            migrationBuilder.DropTable(
                name: "SzczegolyZamowienia");

            migrationBuilder.DropTable(
                name: "Umowa");

            migrationBuilder.DropTable(
                name: "ZakupMaterialow");

            migrationBuilder.DropTable(
                name: "SposobPlatnosci");

            migrationBuilder.DropTable(
                name: "Towar");

            migrationBuilder.DropTable(
                name: "Zamowienie");

            migrationBuilder.DropTable(
                name: "Pracownik");

            migrationBuilder.DropTable(
                name: "Dostawca");

            migrationBuilder.DropTable(
                name: "Kontrahent");

            migrationBuilder.DropTable(
                name: "Adres");

            migrationBuilder.DropTable(
                name: "Rodzaj");

            migrationBuilder.DropTable(
                name: "Status");
        }
    }
}
