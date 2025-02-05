﻿// <auto-generated />
using System;
using FirmaMeble.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FirmaMeble.Migrations
{
    [DbContext(typeof(DataBaseEntities))]
    partial class DataBaseEntitiesModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FirmaMeble.Data.Models.Adres", b =>
                {
                    b.Property<int>("IdAdresu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAdresu"));

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("KodPocztowy")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Miejscowosc")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("NrDomu")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<string>("NrLokalu")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Ulica")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdAdresu");

                    b.ToTable("Adres");

                    b.HasData(
                        new
                        {
                            IdAdresu = 1,
                            CreateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            KodPocztowy = "00-950",
                            Miejscowosc = "Warszawa",
                            NrDomu = 10,
                            NrLokalu = "15",
                            Ulica = "Marszałkowska"
                        },
                        new
                        {
                            IdAdresu = 2,
                            CreateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            KodPocztowy = "31-019",
                            Miejscowosc = "Kraków",
                            NrDomu = 5,
                            NrLokalu = "2",
                            Ulica = "Floriańska"
                        });
                });

            modelBuilder.Entity("FirmaMeble.Data.Models.Dostawca", b =>
                {
                    b.Property<int>("IdDostawcy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDostawcy"));

                    b.Property<int>("IdAdresu")
                        .HasColumnType("int");

                    b.Property<string>("NazwaFirmy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nip")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdDostawcy");

                    b.HasIndex("IdAdresu");

                    b.ToTable("Dostawca");
                });

            modelBuilder.Entity("FirmaMeble.Data.Models.Faktura", b =>
                {
                    b.Property<int>("IdFaktury")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFaktury"));

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<DateTime?>("DataWystawienia")
                        .HasColumnType("date");

                    b.Property<int?>("IdKontrahenta")
                        .HasColumnType("int");

                    b.Property<int?>("IdSposobuPlatnosci")
                        .HasColumnType("int");

                    b.Property<string>("Numer")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("TerminPlatnosci")
                        .HasColumnType("date");

                    b.HasKey("IdFaktury");

                    b.HasIndex("IdKontrahenta");

                    b.HasIndex("IdSposobuPlatnosci");

                    b.ToTable("Faktura");

                    b.HasData(
                        new
                        {
                            IdFaktury = 2,
                            CreateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataWystawienia = new DateTime(2024, 1, 26, 21, 12, 44, 403, DateTimeKind.Local).AddTicks(8753),
                            IdKontrahenta = 1,
                            IdSposobuPlatnosci = 1,
                            Numer = "FV/2024/01",
                            TerminPlatnosci = new DateTime(2024, 2, 25, 21, 12, 44, 403, DateTimeKind.Local).AddTicks(8807)
                        });
                });

            modelBuilder.Entity("FirmaMeble.Data.Models.FakturaForView", b =>
                {
                    b.Property<int>("IdFaktury")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFaktury"));

                    b.Property<DateTime?>("DataWystawienia")
                        .HasColumnType("datetime2");

                    b.Property<string>("KontrahentAdres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KontrahentNIP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KontrahentNazwa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SposobPlatnosciNazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TerminPlatnosci")
                        .HasColumnType("datetime2");

                    b.HasKey("IdFaktury");

                    b.ToTable("FakturaForViewDbSet");
                });

            modelBuilder.Entity("FirmaMeble.Data.Models.Kontrahent", b =>
                {
                    b.Property<int>("IdKontrahenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdKontrahenta"));

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<int>("IdAdresu")
                        .HasColumnType("int");

                    b.Property<int?>("IdStatusu")
                        .HasColumnType("int");

                    b.Property<string>("Kod")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Nazwa")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nip")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdKontrahenta");

                    b.HasIndex("IdAdresu");

                    b.HasIndex("IdStatusu");

                    b.ToTable("Kontrahent");

                    b.HasData(
                        new
                        {
                            IdKontrahenta = 1,
                            CreateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdAdresu = 1,
                            IdStatusu = 1,
                            Nazwa = "Klient A"
                        },
                        new
                        {
                            IdKontrahenta = 2,
                            CreateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdAdresu = 2,
                            IdStatusu = 2,
                            Nazwa = "Dostawca X"
                        });
                });

            modelBuilder.Entity("FirmaMeble.Data.Models.Magazyn", b =>
                {
                    b.Property<int>("IdMagazynu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMagazynu"));

                    b.Property<int>("IdAdresu")
                        .HasColumnType("int");

                    b.Property<string>("Lokalizacja")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Pojemność")
                        .HasColumnType("int");

                    b.HasKey("IdMagazynu");

                    b.HasIndex("IdAdresu");

                    b.ToTable("Magazyn");
                });

            modelBuilder.Entity("FirmaMeble.Data.Models.Pracownik", b =>
                {
                    b.Property<int>("IdPracownika")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPracownika"));

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<DateTime>("DataUrodzenia")
                        .HasColumnType("date");

                    b.Property<string>("DrugieImie")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("IdAdresu")
                        .HasColumnType("int");

                    b.Property<int>("IdUmowy")
                        .HasColumnType("int");

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ImieMatki")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ImieOjca")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MiejsceUrodzenia")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nip")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Pesel")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Stanowisko")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdPracownika");

                    b.HasIndex("IdAdresu");

                    b.HasIndex("IdUmowy")
                        .IsUnique();

                    b.ToTable("Pracownik");

                    b.HasData(
                        new
                        {
                            IdPracownika = 1,
                            CreateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataUrodzenia = new DateTime(1979, 1, 26, 0, 0, 0, 0, DateTimeKind.Local),
                            DrugieImie = "Matejko",
                            Email = "kasia@wp.pl",
                            IdAdresu = 1,
                            IdUmowy = 1,
                            Imie = "Maciek",
                            ImieMatki = "Kasia",
                            ImieOjca = "Stanisław",
                            MiejsceUrodzenia = "Nowy Sącz",
                            Nazwisko = "Kowalski",
                            Nip = "1234567890",
                            Pesel = "77021205531",
                            Stanowisko = "Profesor",
                            Telefon = "1234567"
                        });
                });

            modelBuilder.Entity("FirmaMeble.Data.Models.ProdukcjaMebla", b =>
                {
                    b.Property<int>("IdProdukcji")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProdukcji"));

                    b.Property<DateTime>("DataRozpoczęcia")
                        .HasColumnType("date");

                    b.Property<DateTime>("DataZakończenia")
                        .HasColumnType("date");

                    b.Property<int>("IdPracownika")
                        .HasColumnType("int");

                    b.Property<int>("IdTowaru")
                        .HasColumnType("int");

                    b.Property<int>("IlośćProdukowanychSztuk")
                        .HasColumnType("int");

                    b.Property<int>("StatusProdukcjiIdStatus")
                        .HasColumnType("int");

                    b.HasKey("IdProdukcji");

                    b.HasIndex("IdPracownika");

                    b.HasIndex("IdTowaru");

                    b.HasIndex("StatusProdukcjiIdStatus");

                    b.ToTable("ProdukcjaMebla");
                });

            modelBuilder.Entity("FirmaMeble.Data.Models.SposobPlatnosci", b =>
                {
                    b.Property<int>("IdSposobuPlatnosci")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSposobuPlatnosci"));

                    b.Property<string>("Nazwa")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdSposobuPlatnosci");

                    b.ToTable("SposobPlatnosci");

                    b.HasData(
                        new
                        {
                            IdSposobuPlatnosci = 1,
                            Nazwa = "Płatność kartą"
                        },
                        new
                        {
                            IdSposobuPlatnosci = 2,
                            Nazwa = "Płatność gotówką"
                        },
                        new
                        {
                            IdSposobuPlatnosci = 3,
                            Nazwa = "Przelew bankowy"
                        });
                });

            modelBuilder.Entity("FirmaMeble.Data.Models.StanowiskaPracownikow", b =>
                {
                    b.Property<int>("IdStanowiska")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdStanowiska"));

                    b.Property<string>("StanowiskoNazwa")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdStanowiska");

                    b.ToTable("Stanowisko");

                    b.HasData(
                        new
                        {
                            IdStanowiska = 1,
                            StanowiskoNazwa = "Pracownik Produkcji"
                        },
                        new
                        {
                            IdStanowiska = 2,
                            StanowiskoNazwa = "Pracownik Sprzedaży"
                        },
                        new
                        {
                            IdStanowiska = 3,
                            StanowiskoNazwa = "Kierownik Działu"
                        },
                        new
                        {
                            IdStanowiska = 4,
                            StanowiskoNazwa = "Sekretarz"
                        },
                        new
                        {
                            IdStanowiska = 5,
                            StanowiskoNazwa = "Księgowy"
                        },
                        new
                        {
                            IdStanowiska = 6,
                            StanowiskoNazwa = "Dostawca"
                        });
                });

            modelBuilder.Entity("FirmaMeble.Data.Models.StatusKontrahenta", b =>
                {
                    b.Property<int>("IdStatusu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdStatusu"));

                    b.Property<string>("Nazwa")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdStatusu");

                    b.ToTable("StatusKontrahenta");

                    b.HasData(
                        new
                        {
                            IdStatusu = 1,
                            Nazwa = "Aktywny klient"
                        },
                        new
                        {
                            IdStatusu = 2,
                            Nazwa = "Czasowy klient"
                        },
                        new
                        {
                            IdStatusu = 3,
                            Nazwa = "Zawieszony klient"
                        });
                });

            modelBuilder.Entity("FirmaMeble.Data.Models.StatusProdukcji", b =>
                {
                    b.Property<int>("IdStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdStatus"));

                    b.Property<string>("Nazwa")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdStatus");

                    b.ToTable("StatusProdukcji");

                    b.HasData(
                        new
                        {
                            IdStatus = 1,
                            Nazwa = "nie rozpoczęto"
                        },
                        new
                        {
                            IdStatus = 2,
                            Nazwa = "w przygotowaniu"
                        },
                        new
                        {
                            IdStatus = 3,
                            Nazwa = "produkcja"
                        },
                        new
                        {
                            IdStatus = 4,
                            Nazwa = "gotowe"
                        });
                });

            modelBuilder.Entity("FirmaMeble.Data.Models.SzczegolyZamowienia", b =>
                {
                    b.Property<int>("IdSzczegolyZamowienia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSzczegolyZamowienia"));

                    b.Property<decimal>("CenaZaSztuke")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("IdTowaru")
                        .HasColumnType("int");

                    b.Property<int>("IdZamowienia")
                        .HasColumnType("int");

                    b.Property<int>("Ilość")
                        .HasColumnType("int");

                    b.HasKey("IdSzczegolyZamowienia");

                    b.HasIndex("IdTowaru");

                    b.HasIndex("IdZamowienia");

                    b.ToTable("SzczegolyZamowienia");
                });

            modelBuilder.Entity("FirmaMeble.Data.Models.Towar", b =>
                {
                    b.Property<int>("IdTowaru")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTowaru"));

                    b.Property<decimal?>("Cena")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("Kod")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal?>("Marza")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<string>("Nazwa")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal?>("StawkaVatSprzedazy")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<decimal?>("StawkaVatZakupu")
                        .HasColumnType("decimal(18, 0)");

                    b.HasKey("IdTowaru");

                    b.ToTable("Towar");
                });

            modelBuilder.Entity("FirmaMeble.Data.Models.Umowa", b =>
                {
                    b.Property<int>("IdUmowy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUmowy"));

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<bool>("CzyAktywna")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataRozpoczecia")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DataZakonczenia")
                        .HasColumnType("date");

                    b.Property<decimal>("KwotaBrutto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StanowiskoId")
                        .HasColumnType("int");

                    b.HasKey("IdUmowy");

                    b.ToTable("Umowa");

                    b.HasData(
                        new
                        {
                            IdUmowy = 1,
                            CreateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CzyAktywna = false,
                            DataRozpoczecia = new DateTime(2024, 1, 26, 0, 0, 0, 0, DateTimeKind.Local),
                            DataZakonczenia = new DateTime(2027, 1, 26, 0, 0, 0, 0, DateTimeKind.Local),
                            KwotaBrutto = 300m,
                            Opis = "Jakiś opis",
                            StanowiskoId = 1
                        });
                });

            modelBuilder.Entity("FirmaMeble.Data.Models.ZakupMaterialow", b =>
                {
                    b.Property<int>("IdZakupu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdZakupu"));

                    b.Property<DateTime>("DataZakupu")
                        .HasColumnType("date");

                    b.Property<int>("IdDostawcy")
                        .HasColumnType("int");

                    b.Property<decimal>("Kwota")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("IdZakupu");

                    b.HasIndex("IdDostawcy");

                    b.ToTable("ZakupMaterialow");
                });

            modelBuilder.Entity("FirmaMeble.Data.Models.Zamowienie", b =>
                {
                    b.Property<int>("IdZamowienia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdZamowienia"));

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<DateTime>("DataZamowienia")
                        .HasColumnType("date");

                    b.Property<int>("IdKlienta")
                        .HasColumnType("int");

                    b.Property<int>("KlientIdKontrahenta")
                        .HasColumnType("int");

                    b.Property<DateTime?>("PrzewidywanaDataDostawy")
                        .HasColumnType("date");

                    b.Property<string>("StatusZamowienia")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdZamowienia");

                    b.HasIndex("KlientIdKontrahenta");

                    b.ToTable("Zamowienie");
                });

            modelBuilder.Entity("FirmaMeble.Data.Models.Dostawca", b =>
                {
                    b.HasOne("FirmaMeble.Data.Models.Adres", "Adres")
                        .WithMany()
                        .HasForeignKey("IdAdresu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adres");
                });

            modelBuilder.Entity("FirmaMeble.Data.Models.Faktura", b =>
                {
                    b.HasOne("FirmaMeble.Data.Models.Kontrahent", "IdKontrahentaNavigation")
                        .WithMany("FakturaDbSet")
                        .HasForeignKey("IdKontrahenta");

                    b.HasOne("FirmaMeble.Data.Models.SposobPlatnosci", "IdSposobuPlatnosciNavigation")
                        .WithMany()
                        .HasForeignKey("IdSposobuPlatnosci");

                    b.Navigation("IdKontrahentaNavigation");

                    b.Navigation("IdSposobuPlatnosciNavigation");
                });

            modelBuilder.Entity("FirmaMeble.Data.Models.Kontrahent", b =>
                {
                    b.HasOne("FirmaMeble.Data.Models.Adres", "IdAdresuNavigation")
                        .WithMany()
                        .HasForeignKey("IdAdresu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FirmaMeble.Data.Models.StatusKontrahenta", "IdStatusKontrahentaNavigation")
                        .WithMany()
                        .HasForeignKey("IdStatusu");

                    b.Navigation("IdAdresuNavigation");

                    b.Navigation("IdStatusKontrahentaNavigation");
                });

            modelBuilder.Entity("FirmaMeble.Data.Models.Magazyn", b =>
                {
                    b.HasOne("FirmaMeble.Data.Models.Adres", "Adres")
                        .WithMany()
                        .HasForeignKey("IdAdresu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adres");
                });

            modelBuilder.Entity("FirmaMeble.Data.Models.Pracownik", b =>
                {
                    b.HasOne("FirmaMeble.Data.Models.Adres", "Adres")
                        .WithMany()
                        .HasForeignKey("IdAdresu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FirmaMeble.Data.Models.Umowa", "Umowa")
                        .WithOne("Pracownik")
                        .HasForeignKey("FirmaMeble.Data.Models.Pracownik", "IdUmowy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adres");

                    b.Navigation("Umowa");
                });

            modelBuilder.Entity("FirmaMeble.Data.Models.ProdukcjaMebla", b =>
                {
                    b.HasOne("FirmaMeble.Data.Models.Pracownik", "Pracownik")
                        .WithMany()
                        .HasForeignKey("IdPracownika")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FirmaMeble.Data.Models.Towar", "Towar")
                        .WithMany()
                        .HasForeignKey("IdTowaru")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FirmaMeble.Data.Models.StatusProdukcji", "StatusProdukcji")
                        .WithMany()
                        .HasForeignKey("StatusProdukcjiIdStatus")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pracownik");

                    b.Navigation("StatusProdukcji");

                    b.Navigation("Towar");
                });

            modelBuilder.Entity("FirmaMeble.Data.Models.SzczegolyZamowienia", b =>
                {
                    b.HasOne("FirmaMeble.Data.Models.Towar", "Towar")
                        .WithMany()
                        .HasForeignKey("IdTowaru")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FirmaMeble.Data.Models.Zamowienie", "Zamowienie")
                        .WithMany()
                        .HasForeignKey("IdZamowienia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Towar");

                    b.Navigation("Zamowienie");
                });

            modelBuilder.Entity("FirmaMeble.Data.Models.ZakupMaterialow", b =>
                {
                    b.HasOne("FirmaMeble.Data.Models.Dostawca", "Dostawca")
                        .WithMany()
                        .HasForeignKey("IdDostawcy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dostawca");
                });

            modelBuilder.Entity("FirmaMeble.Data.Models.Zamowienie", b =>
                {
                    b.HasOne("FirmaMeble.Data.Models.Kontrahent", "Klient")
                        .WithMany()
                        .HasForeignKey("KlientIdKontrahenta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Klient");
                });

            modelBuilder.Entity("FirmaMeble.Data.Models.Kontrahent", b =>
                {
                    b.Navigation("FakturaDbSet");
                });

            modelBuilder.Entity("FirmaMeble.Data.Models.Umowa", b =>
                {
                    b.Navigation("Pracownik")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
