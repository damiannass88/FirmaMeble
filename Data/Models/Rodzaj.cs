namespace FirmaMeble.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Rodzaj")]
    public class Rodzaj
    {
        [Key] public int IdRodzaju { get; set; }

        [StringLength(50)] public string? Nazwa { get; set; }

        [InverseProperty("IdRodzajuNavigation")]
        public virtual ICollection<Kontrahent> KontrahentDbSet { get; set; } = new List<Kontrahent>();
    }
}
