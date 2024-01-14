namespace FirmaMeble.Data.DbContexts
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class DataBaseEntities : DbContext
    {
        public virtual DbSet<Adres> AdresDbSet { get; set; }

        public virtual DbSet<Faktura> FakturaDbSet { get; set; }

        public virtual DbSet<Kontrahent> KontrahentDbSet { get; set; }

        public virtual DbSet<Rodzaj> RodzajDbSet { get; set; }
        
        public virtual DbSet<Umowa> UmowaDbSet { get; set; }

        public virtual DbSet<SposobPlatnosci> SposobPlatnosciDbSet { get; set; }

        public virtual DbSet<Status> StatusDbSet { get; set; }

        public virtual DbSet<Towar> TowarDbSet { get; set; }

        public virtual DbSet<Dostawca> DostawcaDbSet { get; set; }

        public virtual DbSet<FakturaForView> FakturaForViewDbSet { get; set; }

        public virtual DbSet<Magazyn> MagazynDbSet { get; set; }

        public virtual DbSet<Pracownik> PracownikDbSet { get; set; }

        public virtual DbSet<ProdukcjaMebla> ProdukcjaMeblaDbSet { get; set; }

        public virtual DbSet<SzczegolyZamowienia> SzczegolyZamowieniaDbSet { get; set; }

        public virtual DbSet<ZakupMaterialow> ZakupMaterialowDbSet { get; set; }

        public virtual DbSet<Zamowienie> ZamowienieDbSet { get; set; }

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
                    .WithMany(p => p.FakturaDbSet)
                    .HasForeignKey(d => d.IdKontrahenta);
                entity.HasOne(d => d.IdSposobuPlatnosciNavigation)
                    .WithMany(p => p.FakturaDbSet)
                    .HasForeignKey(d => d.IdSposobuPlatnosci);
            });

            modelBuilder.Entity<Faktura>().HasData(
                new { IdFaktury = 1, PostId = 2, Title = "Second post", Content = "Test 2" });

            modelBuilder.Entity<Kontrahent>(entity =>
            {
                entity.HasKey(e => e.IdKontrahenta);
                entity.HasOne(d => d.IdAdresuNavigation)
                    .WithMany(p => p.KontrahentDbSet)
                    .HasForeignKey(d => d.IdAdresu);
                entity.HasOne(d => d.IdRodzajuNavigation)
                    .WithMany(p => p.KontrahentDbSet)
                    .HasForeignKey(d => d.IdRodzaju);
                entity.HasOne(d => d.IdStatusuNavigation)
                    .WithMany(p => p.KontrahentDbSet)
                    .HasForeignKey(d => d.IdStatusu);
            });

            modelBuilder.Entity<Magazyn>(entity =>
            {
                entity.HasKey(e => e.IdMagazynu);
                entity.HasOne(d => d.Adres)
                    .WithMany()
                    .HasForeignKey(d => d.IdAdresu);
            });

            modelBuilder.Entity<Umowa>(entity =>
            {
                entity.HasKey(e => e.IdUmowy);

                entity.Property(e => e.TypUmowy)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(e => e.DataRozpoczecia)
                    .HasColumnType("date")
                    .IsRequired();

                entity.Property(e => e.DataZakonczenia)
                    .HasColumnType("date");

                entity.Property(e => e.KwotaBrutto)
                    .HasColumnType("decimal(18, 2)")
                    .IsRequired();

                entity.HasOne(d => d.Pracownik)
                    .WithMany(p => p.Umowy)
                    .HasForeignKey(d => d.IdPracownika)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Umowa_Pracownik");
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
                new Adres
                {
                    IdAdresu = 1, Miejscowosc = "Warszawa", Ulica = "Marszałkowska", NrDomu = "10", NrLokalu = "15",
                    KodPocztowy = "00-950"
                },
                new Adres
                {
                    IdAdresu = 2, Miejscowosc = "Kraków", Ulica = "Floriańska", NrDomu = "5", NrLokalu = "2",
                    KodPocztowy = "31-019"
                }
            );

            modelBuilder.Entity<Kontrahent>().HasData(
                new Kontrahent { IdKontrahenta = 1, Nazwa = "Klient A", IdAdresu = 1 },
                new Kontrahent { IdKontrahenta = 2, Nazwa = "Dostawca X", IdAdresu = 2 }
            );

            modelBuilder.Entity<Faktura>().HasData(
                new Faktura
                {
                    IdFaktury = 2, Numer = "FV/2024/01", DataWystawienia = DateTime.Now, IdKontrahenta = 1,
                    TerminPlatnosci = DateTime.Now.AddDays(30)
                }
            );
        }
    }
}
