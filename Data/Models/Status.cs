namespace FirmaMeble.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Status")]
    public class Status
    {
        [Key] public int IdStatusu { get; set; }

        [StringLength(50)] public string? Nazwa { get; set; }

        [InverseProperty("IdStatusuNavigation")]
        public virtual ICollection<Kontrahent> KontrahentDbSet { get; set; } = new List<Kontrahent>();
    }
}
