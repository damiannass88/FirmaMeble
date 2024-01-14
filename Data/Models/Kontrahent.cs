namespace FirmaMeble.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Kontrahent")]
    public class Kontrahent
    {
        [Key] public int IdKontrahenta { get; set; }

        [StringLength(10)] public string? Kod { get; set; }

        [StringLength(50)] public string? Nazwa { get; set; }

        [StringLength(50)] public string? Nip { get; set; }

        public int? IdRodzaju { get; set; }

        public int? IdStatusu { get; set; }

        public int? IdAdresu { get; set; }

        [InverseProperty("IdKontrahentaNavigation")]
        public virtual ICollection<Faktura> FakturaDbSet { get; set; } = new List<Faktura>();

        [ForeignKey("IdAdresu")]
        [InverseProperty("KontrahentDbSet")]
        public virtual Adres? IdAdresuNavigation { get; set; }

        [ForeignKey("IdRodzaju")]
        [InverseProperty("KontrahentDbSet")]
        public virtual Rodzaj? IdRodzajuNavigation { get; set; }

        [ForeignKey("IdStatusu")]
        [InverseProperty("KontrahentDbSet")]
        public virtual Status? IdStatusuNavigation { get; set; }
    }
}
