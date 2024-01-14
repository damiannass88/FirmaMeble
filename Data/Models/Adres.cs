namespace FirmaMeble.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Adres")]
    public class Adres
    {
        [Key] public int IdAdresu { get; set; }

        [StringLength(50)] public string? Miejscowosc { get; set; }

        [StringLength(50)] public string? Ulica { get; set; }

        [StringLength(50)] public string? NrDomu { get; set; }

        [StringLength(50)] public string? NrLokalu { get; set; }

        [StringLength(50)] public string? KodPocztowy { get; set; }

        [InverseProperty("IdAdresuNavigation")]
        public virtual ICollection<Kontrahent> KontrahentDbSet { get; set; } = new List<Kontrahent>();
    }
}
