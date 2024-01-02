using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirmaMeble.Data.Repositories;

[Table("Kontrahent")]
public partial class Kontrahent
{
    [Key]
    public int IdKontrahenta { get; set; }

    [StringLength(10)]
    public string? Kod { get; set; }

    [StringLength(50)]
    public string? Nazwa { get; set; }

    [StringLength(50)]
    public string? Nip { get; set; }

    public int? IdRodzaju { get; set; }

    public int? IdStatusu { get; set; }

    public int? IdAdresu { get; set; }

    [InverseProperty("IdKontrahentaNavigation")]
    public virtual ICollection<Faktura> Fakturas { get; set; } = new List<Faktura>();

    [ForeignKey("IdAdresu")]
    [InverseProperty("Kontrahents")]
    public virtual Adres? IdAdresuNavigation { get; set; }

    [ForeignKey("IdRodzaju")]
    [InverseProperty("Kontrahents")]
    public virtual Rodzaj? IdRodzajuNavigation { get; set; }

    [ForeignKey("IdStatusu")]
    [InverseProperty("Kontrahents")]
    public virtual Status? IdStatusuNavigation { get; set; }
}
