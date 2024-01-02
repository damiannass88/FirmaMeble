namespace FirmaMeble.Data.DbContexts;
using FirmaMeble.Data.Repositories;
using Microsoft.EntityFrameworkCore;
public partial class FakturyEntities : DbContext
{
    public FakturyEntities()
    {
    }

    public FakturyEntities(DbContextOptions<FakturyEntities> options)
        : base(options)
    {
    }

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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=FirmaMeble;User Id=sa;Password=admina;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Adres
        modelBuilder.Entity<Adres>(entity =>
        {
            entity.HasKey(e => e.IdAdresu);
        });

        // Dostawca
        modelBuilder.Entity<Dostawca>(entity =>
        {
            entity.HasKey(e => e.IdDostawcy);
            entity.HasOne(d => d.Adres)
                .WithMany()
                .HasForeignKey(d => d.IdAdresu);
        });

        // Faktura
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

        // Kontrahent
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

        // Magazyn
        modelBuilder.Entity<Magazyn>(entity =>
        {
            entity.HasKey(e => e.IdMagazynu);
            entity.HasOne(d => d.Adres)
                .WithMany()
                .HasForeignKey(d => d.IdAdresu);
        });

        // PozycjaFaktury
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

        // Pracownik
        modelBuilder.Entity<Pracownik>(entity =>
        {
            entity.HasKey(e => e.IdPracownika);
            entity.HasOne(d => d.Adres)
                .WithMany()
                .HasForeignKey(d => d.IdAdresu);
        });

        // ProdukcjaMebla
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

        // Rodzaj
        modelBuilder.Entity<Rodzaj>(entity =>
        {
            entity.HasKey(e => e.IdRodzaju);
            // Dodatkowa konfiguracja, jeśli potrzebna
        });

        // SposobPlatnosci
        modelBuilder.Entity<SposobPlatnosci>(entity =>
        {
            entity.HasKey(e => e.IdSposobuPlatnosci);
            // Dodatkowa konfiguracja, jeśli potrzebna
        });

        // Status
        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.IdStatusu);
            // Dodatkowa konfiguracja, jeśli potrzebna
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
