using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirmaMeble.Data.Repositories;

[Table("Status")]
public partial class Status
{
    [Key]
    public int IdStatusu { get; set; }

    [StringLength(50)]
    public string? Nazwa { get; set; }

    [InverseProperty("IdStatusuNavigation")]
    public virtual ICollection<Kontrahent> Kontrahents { get; set; } = new List<Kontrahent>();
}
