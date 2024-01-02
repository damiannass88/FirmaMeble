namespace FirmaMeble.Data.Repositories
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Zamowienie
    {
        [Key]
        public int IdZamowienia { get; set; }

        [ForeignKey("Kontrahent")]
        public int IdKlienta { get; set; }

        public virtual Kontrahent Klient { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataZamowienia { get; set; }

        [StringLength(50)]
        public string StatusZamowienia { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PrzewidywanaDataDostawy { get; set; }
    }
}
