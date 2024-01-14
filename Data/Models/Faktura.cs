namespace FirmaMeble.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Faktura")]
    public class Faktura
    {
        [Key] public int IdFaktury { get; set; }

        [StringLength(50)] public string? Numer { get; set; }

        [Column(TypeName = "date")] public DateTime? DataWystawienia { get; set; }

        public int? IdKontrahenta { get; set; }

        [Column(TypeName = "date")] public DateTime? TerminPlatnosci { get; set; }

        public int? IdSposobuPlatnosci { get; set; }

        [ForeignKey("IdKontrahenta")]
        [InverseProperty("FakturaDbSet")]
        public virtual Kontrahent? IdKontrahentaNavigation { get; set; }

        [ForeignKey("IdSposobuPlatnosci")]
        [InverseProperty("FakturaDbSet")]
        public virtual SposobPlatnosci? IdSposobuPlatnosciNavigation { get; set; }
    }
}
