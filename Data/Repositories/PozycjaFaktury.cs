using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirmaMeble.Data.Repositories;

[Table("PozycjaFaktury")]
public partial class PozycjaFaktury
{
    [Key]
    public int IdPozycjiFaktury { get; set; }

    public int? IdFaktury { get; set; }

    public int? IdTowaru { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? Cena { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? Ilosc { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? Rabat { get; set; }

    [ForeignKey("IdFaktury")]
    [InverseProperty("PozycjaFakturies")]
    public virtual Faktura? IdFakturyNavigation { get; set; }

    [ForeignKey("IdTowaru")]
    [InverseProperty("PozycjaFakturies")]
    public virtual Towar? IdTowaruNavigation { get; set; }
}
