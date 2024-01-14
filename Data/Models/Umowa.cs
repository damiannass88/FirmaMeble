namespace FirmaMeble.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Umowa")]
    public class Umowa
    {
        [Key] public int IdUmowy { get; set; }

        [StringLength(100)] public string TypUmowy { get; set; }

        [Column(TypeName = "date")] public DateTime DataRozpoczecia { get; set; }

        [Column(TypeName = "date")] public DateTime? DataZakonczenia { get; set; }

        public decimal KwotaBrutto { get; set; }

        // Klucz obcy odnoszący się do Pracownika
        [ForeignKey("Pracownik")]
        public int IdPracownika { get; set; }

        // Właściwość nawigacyjna dla Pracownika
        public virtual Pracownik Pracownik { get; set; }
    }
}
