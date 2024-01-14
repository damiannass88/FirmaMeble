namespace FirmaMeble.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Towar")]
    public class Towar
    {
        [Key] public int IdTowaru { get; set; }

        [StringLength(50)] public string? Kod { get; set; }

        [StringLength(50)] public string? Nazwa { get; set; }

        [Column(TypeName = "decimal(18, 0)")] public decimal? StawkaVatSprzedazy { get; set; }

        [Column(TypeName = "decimal(18, 0)")] public decimal? StawkaVatZakupu { get; set; }

        [Column(TypeName = "decimal(18, 0)")] public decimal? Cena { get; set; }

        [Column(TypeName = "decimal(18, 0)")] public decimal? Marza { get; set; }
    }
}
