namespace FirmaMeble.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Umowa")]
    public class Umowa
    {
        [Key] public int IdUmowy { get; set; }

        public int StanowiskoId { get; set; }

        [Column(TypeName = "date")] public DateTime DataRozpoczecia { get; set; }

        [Column(TypeName = "date")] public DateTime? DataZakonczenia { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal KwotaBrutto { get; set; }

        public bool CzyAktywna { get; set; }

        public string? Opis { get; set; }

        // Właściwość nawigacyjna dla Pracownika
        [InverseProperty("Umowa")] public virtual Pracownik Pracownik { get; set; }
    }
}
