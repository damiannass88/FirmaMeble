namespace FirmaMeble.Data.Repositories
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class SzczegolyZamowienia
    {
        [Key]
        public int IdSzczegolyZamowienia { get; set; }

        [ForeignKey("Zamowienie")]
        public int IdZamowienia { get; set; }

        public virtual Zamowienie Zamowienie { get; set; }

        [ForeignKey("Towar")]
        public int IdTowaru { get; set; }

        public virtual Towar Towar { get; set; }

        public int Ilość { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal CenaZaSztuke { get; set; }
    }
}
