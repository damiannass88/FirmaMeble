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

        public int? IdStatusu { get; set; }

        public int IdAdresu { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreateDate { get; set; }

        [InverseProperty("IdKontrahentaNavigation")]
        public virtual ICollection<Faktura> FakturaDbSet { get; set; } = new List<Faktura>();

        [ForeignKey("IdAdresu")]
        public virtual Adres IdAdresuNavigation { get; set; }

        [ForeignKey("IdStatusu")]
        public virtual StatusKontrahenta? IdStatusKontrahentaNavigation { get; set; }
         
    }
}
