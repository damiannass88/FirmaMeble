using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirmaMeble.Data.Repositories;

public partial class Adres
{
    [Key]
    public int IdAdresu { get; set; }

    [StringLength(50)]
    public string? Miejscowosc { get; set; }

    [StringLength(50)]
    public string? Ulica { get; set; }

    [StringLength(50)]
    public string? NrDomu { get; set; }

    [StringLength(50)]
    public string? NrLokalu { get; set; }

    [StringLength(50)]
    public string? KodPocztowy { get; set; }

    [InverseProperty("IdAdresuNavigation")]
    public virtual ICollection<Kontrahent> Kontrahents { get; set; } = new List<Kontrahent>();
}
