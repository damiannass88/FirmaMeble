using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirmaMeble.Data.Models
{
    [Table("Faktura")]
    public partial class Faktura
    {
        [Key]
        public int IdFaktury { get; set; }

        [StringLength(50)]
        public string? Numer { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DataWystawienia { get; set; }

        public int? IdKontrahenta { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TerminPlatnosci { get; set; }

        public int? IdSposobuPlatnosci { get; set; }

        [ForeignKey("IdKontrahenta")]
        [InverseProperty("Fakturas")]
        public virtual Kontrahent? IdKontrahentaNavigation { get; set; }

        [ForeignKey("IdSposobuPlatnosci")]
        [InverseProperty("Fakturas")]
        public virtual SposobPlatnosci? IdSposobuPlatnosciNavigation { get; set; }

        [InverseProperty("IdFakturyNavigation")]
        public virtual ICollection<PozycjaFaktury> PozycjaFakturies { get; set; } = new List<PozycjaFaktury>();
    }
}
