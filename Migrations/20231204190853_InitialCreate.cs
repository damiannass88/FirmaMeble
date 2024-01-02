#nullable disable

namespace FirmaMeble.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                name: "FakturaForViews",
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
                    table.PrimaryKey("PK_FakturaForViews", x => x.IdFaktury);
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
                name: "Dostawcas",
                columns: table => new
                {
                    IdDostawcy = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaFirmy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdAdresu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dostawcas", x => x.IdDostawcy);
                    table.ForeignKey(
                        name: "FK_Dostawcas_Adres_IdAdresu",
                        column: x => x.IdAdresu,
                        principalTable: "Adres",
                        principalColumn: "IdAdresu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Magazyns",
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
                    table.PrimaryKey("PK_Magazyns", x => x.IdMagazynu);
                    table.ForeignKey(
                        name: "FK_Magazyns_Adres_IdAdresu",
                        column: x => x.IdAdresu,
                        principalTable: "Adres",
                        principalColumn: "IdAdresu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pracowniks",
                columns: table => new
                {
                    IdPracownika = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imię = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Stanowisko = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdAdresu = table.Column<int>(type: "int", nullable: false),
                    DataZatrudnienia = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pracowniks", x => x.IdPracownika);
                    table.ForeignKey(
                        name: "FK_Pracowniks_Adres_IdAdresu",
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
                name: "ZakupMaterialows",
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
                    table.PrimaryKey("PK_ZakupMaterialows", x => x.IdZakupu);
                    table.ForeignKey(
                        name: "FK_ZakupMaterialows_Dostawcas_IdDostawcy",
                        column: x => x.IdDostawcy,
                        principalTable: "Dostawcas",
                        principalColumn: "IdDostawcy",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdukcjaMeblas",
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
                    table.PrimaryKey("PK_ProdukcjaMeblas", x => x.IdProdukcji);
                    table.ForeignKey(
                        name: "FK_ProdukcjaMeblas_Pracowniks_IdPracownika",
                        column: x => x.IdPracownika,
                        principalTable: "Pracowniks",
                        principalColumn: "IdPracownika",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdukcjaMeblas_Towar_IdTowaru",
                        column: x => x.IdTowaru,
                        principalTable: "Towar",
                        principalColumn: "IdTowaru",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Zamowienies",
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
                    table.PrimaryKey("PK_Zamowienies", x => x.IdZamowienia);
                    table.ForeignKey(
                        name: "FK_Zamowienies_Kontrahent_KlientIdKontrahenta",
                        column: x => x.KlientIdKontrahenta,
                        principalTable: "Kontrahent",
                        principalColumn: "IdKontrahenta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PozycjaFaktury",
                columns: table => new
                {
                    IdPozycjiFaktury = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFaktury = table.Column<int>(type: "int", nullable: true),
                    IdTowaru = table.Column<int>(type: "int", nullable: true),
                    Cena = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    Ilosc = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    Rabat = table.Column<decimal>(type: "decimal(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PozycjaFaktury", x => x.IdPozycjiFaktury);
                    table.ForeignKey(
                        name: "FK_PozycjaFaktury_Faktura_IdFaktury",
                        column: x => x.IdFaktury,
                        principalTable: "Faktura",
                        principalColumn: "IdFaktury");
                    table.ForeignKey(
                        name: "FK_PozycjaFaktury_Towar_IdTowaru",
                        column: x => x.IdTowaru,
                        principalTable: "Towar",
                        principalColumn: "IdTowaru");
                });

            migrationBuilder.CreateTable(
                name: "SzczegolyZamowienias",
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
                    table.PrimaryKey("PK_SzczegolyZamowienias", x => x.IdSzczegolyZamowienia);
                    table.ForeignKey(
                        name: "FK_SzczegolyZamowienias_Towar_IdTowaru",
                        column: x => x.IdTowaru,
                        principalTable: "Towar",
                        principalColumn: "IdTowaru",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SzczegolyZamowienias_Zamowienies_IdZamowienia",
                        column: x => x.IdZamowienia,
                        principalTable: "Zamowienies",
                        principalColumn: "IdZamowienia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dostawcas_IdAdresu",
                table: "Dostawcas",
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
                name: "IX_Magazyns_IdAdresu",
                table: "Magazyns",
                column: "IdAdresu");

            migrationBuilder.CreateIndex(
                name: "IX_PozycjaFaktury_IdFaktury",
                table: "PozycjaFaktury",
                column: "IdFaktury");

            migrationBuilder.CreateIndex(
                name: "IX_PozycjaFaktury_IdTowaru",
                table: "PozycjaFaktury",
                column: "IdTowaru");

            migrationBuilder.CreateIndex(
                name: "IX_Pracowniks_IdAdresu",
                table: "Pracowniks",
                column: "IdAdresu");

            migrationBuilder.CreateIndex(
                name: "IX_ProdukcjaMeblas_IdPracownika",
                table: "ProdukcjaMeblas",
                column: "IdPracownika");

            migrationBuilder.CreateIndex(
                name: "IX_ProdukcjaMeblas_IdTowaru",
                table: "ProdukcjaMeblas",
                column: "IdTowaru");

            migrationBuilder.CreateIndex(
                name: "IX_SzczegolyZamowienias_IdTowaru",
                table: "SzczegolyZamowienias",
                column: "IdTowaru");

            migrationBuilder.CreateIndex(
                name: "IX_SzczegolyZamowienias_IdZamowienia",
                table: "SzczegolyZamowienias",
                column: "IdZamowienia");

            migrationBuilder.CreateIndex(
                name: "IX_ZakupMaterialows_IdDostawcy",
                table: "ZakupMaterialows",
                column: "IdDostawcy");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienies_KlientIdKontrahenta",
                table: "Zamowienies",
                column: "KlientIdKontrahenta");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FakturaForViews");

            migrationBuilder.DropTable(
                name: "Magazyns");

            migrationBuilder.DropTable(
                name: "PozycjaFaktury");

            migrationBuilder.DropTable(
                name: "ProdukcjaMeblas");

            migrationBuilder.DropTable(
                name: "SzczegolyZamowienias");

            migrationBuilder.DropTable(
                name: "ZakupMaterialows");

            migrationBuilder.DropTable(
                name: "Faktura");

            migrationBuilder.DropTable(
                name: "Pracowniks");

            migrationBuilder.DropTable(
                name: "Towar");

            migrationBuilder.DropTable(
                name: "Zamowienies");

            migrationBuilder.DropTable(
                name: "Dostawcas");

            migrationBuilder.DropTable(
                name: "SposobPlatnosci");

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
