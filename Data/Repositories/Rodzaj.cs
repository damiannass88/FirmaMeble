using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirmaMeble.Data.Repositories;

[Table("Rodzaj")]
public partial class Rodzaj
{
    [Key]
    public int IdRodzaju { get; set; }

    [StringLength(50)]
    public string? Nazwa { get; set; }

    [InverseProperty("IdRodzajuNavigation")]
    public virtual ICollection<Kontrahent> Kontrahents { get; set; } = new List<Kontrahent>();
}
