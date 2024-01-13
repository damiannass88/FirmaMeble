namespace FirmaMeble.Data.DbContexts
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class DataBaseEntities : DbContext
    {
        public virtual DbSet<Adres> Adres { get; set; }

        public virtual DbSet<Faktura> Fakturas { get; set; }

        public virtual DbSet<Kontrahent> Kontrahents { get; set; }

        public virtual DbSet<PozycjaFaktury> PozycjaFakturies { get; set; }

        public virtual DbSet<Rodzaj> Rodzajs { get; set; }

        public virtual DbSet<SposobPlatnosci> SposobPlatnoscis { get; set; }

        public virtual DbSet<Status> Statuses { get; set; }

        public virtual DbSet<Towar> Towars { get; set; }

        public virtual DbSet<Dostawca> Dostawcas { get; set; }

        public virtual DbSet<FakturaForView> FakturaForViews { get; set; }

        public virtual DbSet<Magazyn> Magazyns { get; set; }

        public virtual DbSet<Pracownik> Pracowniks { get; set; }

        public virtual DbSet<ProdukcjaMebla> ProdukcjaMeblas { get; set; }

        public virtual DbSet<SzczegolyZamowienia> SzczegolyZamowienias { get; set; }

        public virtual DbSet<ZakupMaterialow> ZakupMaterialows { get; set; }

        public virtual DbSet<Zamowienie> Zamowienies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=.\SQLEXPRESS;Database=FirmaMeble;User Id=sa;Password=admina;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Adres>(entity => { entity.HasKey(e => e.IdAdresu); });

            modelBuilder.Entity<Dostawca>(entity =>
            {
                entity.HasKey(e => e.IdDostawcy);
                entity.HasOne(d => d.Adres)
                    .WithMany()
                    .HasForeignKey(d => d.IdAdresu);
            });

            modelBuilder.Entity<Faktura>(entity =>
            {
                entity.HasKey(e => e.IdFaktury);
                entity.HasOne(d => d.IdKontrahentaNavigation)
                    .WithMany(p => p.Fakturas)
                    .HasForeignKey(d => d.IdKontrahenta);
                entity.HasOne(d => d.IdSposobuPlatnosciNavigation)
                    .WithMany(p => p.Fakturas)
                    .HasForeignKey(d => d.IdSposobuPlatnosci);
            });

            modelBuilder.Entity<Faktura>().HasData(
                new { IdFaktury = 1, PostId = 2, Title = "Second post", Content = "Test 2" });

            modelBuilder.Entity<Kontrahent>(entity =>
            {
                entity.HasKey(e => e.IdKontrahenta);
                entity.HasOne(d => d.IdAdresuNavigation)
                    .WithMany(p => p.Kontrahents)
                    .HasForeignKey(d => d.IdAdresu);
                entity.HasOne(d => d.IdRodzajuNavigation)
                    .WithMany(p => p.Kontrahents)
                    .HasForeignKey(d => d.IdRodzaju);
                entity.HasOne(d => d.IdStatusuNavigation)
                    .WithMany(p => p.Kontrahents)
                    .HasForeignKey(d => d.IdStatusu);
            });

            modelBuilder.Entity<Magazyn>(entity =>
            {
                entity.HasKey(e => e.IdMagazynu);
                entity.HasOne(d => d.Adres)
                    .WithMany()
                    .HasForeignKey(d => d.IdAdresu);
            });

            modelBuilder.Entity<PozycjaFaktury>(entity =>
            {
                entity.HasKey(e => e.IdPozycjiFaktury);
                entity.HasOne(d => d.IdFakturyNavigation)
                    .WithMany(p => p.PozycjaFakturies)
                    .HasForeignKey(d => d.IdFaktury);
                entity.HasOne(d => d.IdTowaruNavigation)
                    .WithMany(p => p.PozycjaFakturies)
                    .HasForeignKey(d => d.IdTowaru);
            });

            modelBuilder.Entity<Pracownik>(entity =>
            {
                entity.HasKey(e => e.IdPracownika);
                entity.HasOne(d => d.Adres)
                    .WithMany()
                    .HasForeignKey(d => d.IdAdresu);
            });

            modelBuilder.Entity<ProdukcjaMebla>(entity =>
            {
                entity.HasKey(e => e.IdProdukcji);
                entity.HasOne(d => d.Towar)
                    .WithMany()
                    .HasForeignKey(d => d.IdTowaru);
                entity.HasOne(d => d.Pracownik)
                    .WithMany()
                    .HasForeignKey(d => d.IdPracownika);
            });

            modelBuilder.Entity<Rodzaj>(entity => { entity.HasKey(e => e.IdRodzaju); });

            modelBuilder.Entity<SposobPlatnosci>(entity => { entity.HasKey(e => e.IdSposobuPlatnosci); });

            modelBuilder.Entity<Status>(entity => { entity.HasKey(e => e.IdStatusu); });



            // Dodanie danych początkowych
            modelBuilder.Entity<Adres>().HasData(
                new Adres { IdAdresu = 1, Miejscowosc = "Warszawa", Ulica = "Marszałkowska", NrDomu = "10", NrLokalu = "15", KodPocztowy = "00-950" },
                new Adres { IdAdresu = 2, Miejscowosc = "Kraków", Ulica = "Floriańska", NrDomu = "5", NrLokalu = "2", KodPocztowy = "31-019" }
                // Dodaj więcej adresów według potrzeb
            );

            modelBuilder.Entity<Kontrahent>().HasData(
                new Kontrahent { IdKontrahenta = 1, Nazwa = "Klient A", IdAdresu = 1 },
                new Kontrahent { IdKontrahenta = 2, Nazwa = "Dostawca X", IdAdresu = 2 }
                // Dodaj więcej kontrahentów według potrzeb
            );

            modelBuilder.Entity<Faktura>().HasData(
                new Faktura { IdFaktury = 2, Numer = "FV/2024/01", DataWystawienia = DateTime.Now, IdKontrahenta = 1, TerminPlatnosci = DateTime.Now.AddDays(30) }
                // Dodaj więcej faktur według potrzeb
            );


        }
    }
}
