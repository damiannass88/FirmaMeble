namespace FirmaMeble.Data.DbContexts
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class DataBaseEntities : DbContext
    {
        public virtual DbSet<Adres> AdresDbSet { get; set; }

        public virtual DbSet<Faktura> FakturaDbSet { get; set; }

        public virtual DbSet<Kontrahent> KontrahentDbSet { get; set; }

        public virtual DbSet<Umowa> UmowaDbSet { get; set; }

        public virtual DbSet<SposobPlatnosci> SposobPlatnosciDbSet { get; set; }

        public virtual DbSet<StatusKontrahenta> StatusKontrahentaDbSet { get; set; }

        public virtual DbSet<Towar> TowarDbSet { get; set; }

        public virtual DbSet<Dostawca> DostawcaDbSet { get; set; }

        public virtual DbSet<FakturaForView> FakturaForViewDbSet { get; set; }

        public virtual DbSet<Magazyn> MagazynDbSet { get; set; }

        public virtual DbSet<Pracownik> PracownikDbSet { get; set; }

        public virtual DbSet<ProdukcjaMebla> ProdukcjaMeblaDbSet { get; set; }

        public virtual DbSet<SzczegolyZamowienia> SzczegolyZamowieniaDbSet { get; set; }

        public virtual DbSet<ZakupMaterialow> ZakupMaterialowDbSet { get; set; }

        public virtual DbSet<Zamowienie> ZamowienieDbSet { get; set; }

        public virtual DbSet<StatusProdukcji> StatusProdukcjiDbSet { get; set; }

        public virtual DbSet<StanowiskaPracownikow> StanowiskaPracownikowDbSet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=.\SQLEXPRESS;Database=FirmaMeble;User Id=sa;Password=admina;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureCreateDate<Adres>();
            modelBuilder.ConfigureCreateDate<Faktura>();
            modelBuilder.ConfigureCreateDate<Kontrahent>();
            modelBuilder.ConfigureCreateDate<Pracownik>();
            modelBuilder.ConfigureCreateDate<Towar>();
            modelBuilder.ConfigureCreateDate<Umowa>();
            modelBuilder.ConfigureCreateDate<Zamowienie>();

            // Dodanie danych początkowych
            modelBuilder.Entity<Adres>().HasData(
                new Adres
                {
                    IdAdresu = 1, Miejscowosc = "Warszawa", Ulica = "Marszałkowska", NrDomu = 10, NrLokalu = "15",
                    KodPocztowy = "00-950"
                },
                new Adres
                {
                    IdAdresu = 2, Miejscowosc = "Kraków", Ulica = "Floriańska", NrDomu = 5, NrLokalu = "2",
                    KodPocztowy = "31-019"
                }
            );

            modelBuilder.Entity<Kontrahent>().HasData(
                new Kontrahent { IdKontrahenta = 1, Nazwa = "Klient A", IdAdresu = 1, IdStatusu = 1 },
                new Kontrahent { IdKontrahenta = 2, Nazwa = "Dostawca X", IdAdresu = 2, IdStatusu = 2 }
            );

            modelBuilder.Entity<Faktura>().HasData(
                new Faktura
                {
                    IdFaktury = 2, Numer = "FV/2024/01", DataWystawienia = DateTime.Now, IdKontrahenta = 1,
                    TerminPlatnosci = DateTime.Now.AddDays(30), IdSposobuPlatnosci = 1
                }
            );

            modelBuilder.Entity<StanowiskaPracownikow>().HasData(
                new StanowiskaPracownikow { IdStanowiska = 1, StanowiskoNazwa = "Pracownik Produkcji" },
                new StanowiskaPracownikow { IdStanowiska = 2, StanowiskoNazwa = "Pracownik Sprzedaży" },
                new StanowiskaPracownikow { IdStanowiska = 3, StanowiskoNazwa = "Kierownik Działu" },
                new StanowiskaPracownikow { IdStanowiska = 4, StanowiskoNazwa = "Sekretarz" },
                new StanowiskaPracownikow { IdStanowiska = 5, StanowiskoNazwa = "Księgowy" },
                new StanowiskaPracownikow { IdStanowiska = 6, StanowiskoNazwa = "Dostawca" }
            );

            modelBuilder.Entity<SposobPlatnosci>().HasData(
                new SposobPlatnosci { IdSposobuPlatnosci = 1, Nazwa = "Płatność kartą" },
                new SposobPlatnosci { IdSposobuPlatnosci = 2, Nazwa = "Płatność gotówką" },
                new SposobPlatnosci { IdSposobuPlatnosci = 3, Nazwa = "Przelew bankowy" }
            );

            modelBuilder.Entity<StatusKontrahenta>().HasData(
                new StatusKontrahenta { IdStatusu = 1, Nazwa = "Aktywny klient" },
                new StatusKontrahenta { IdStatusu = 2, Nazwa = "Czasowy klient" },
                new StatusKontrahenta { IdStatusu = 3, Nazwa = "Zawieszony klient" }
            );

            modelBuilder.Entity<StatusProdukcji>().HasData(
                new StatusProdukcji { IdStatus = 1, Nazwa = "nie rozpoczęto" },
                new StatusProdukcji { IdStatus = 2, Nazwa = "w przygotowaniu" },
                new StatusProdukcji { IdStatus = 3, Nazwa = "produkcja" },
                new StatusProdukcji { IdStatus = 4, Nazwa = "gotowe" }
            );

            modelBuilder.Entity<Umowa>().HasData(
                new Umowa
                {
                    IdUmowy = 1, Opis = "Jakiś opis", StanowiskoId = 1, KwotaBrutto = 300,
                    DataRozpoczecia = DateTime.Today, DataZakonczenia = DateTime.Today.AddYears(3)
                }
            );

            modelBuilder.Entity<Pracownik>().HasData(
                new Pracownik
                {
                    IdPracownika = 1, Imie = "Maciek", DrugieImie = "Matejko", Nazwisko = "Kowalski",
                    MiejsceUrodzenia = "Nowy Sącz", ImieOjca = "Stanisław", ImieMatki = "Kasia",
                    Email = "kasia@wp.pl", Telefon = "1234567", Pesel = "77021205531", Nip = "1234567890",
                    Stanowisko = "Profesor",
                    DataUrodzenia = DateTime.Today.AddYears(-45), IdAdresu = 1, IdUmowy = 1
                }
            );
        }
    }
}
