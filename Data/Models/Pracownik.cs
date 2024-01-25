namespace FirmaMeble.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Pracownik")]
    public class Pracownik
    {
        [Key] public int IdPracownika { get; set; }

        [StringLength(50)] public string Imie { get; set; }

        [StringLength(50)] public string DrugieImie { get; set; }

        [StringLength(50)] public string Nazwisko { get; set; }

        [StringLength(50)] public string MiejsceUrodzenia { get; set; }

        [StringLength(50)] public string ImieOjca { get; set; }

        [StringLength(50)] public string ImieMatki { get; set; }

        [StringLength(50)] public string Email { get; set; }

        [StringLength(50)] public string Telefon { get; set; }

        [StringLength(50)] public string Nip { get; set; }

        [StringLength(50)] public string Pesel { get; set; }

        [StringLength(50)] public string Stanowisko { get; set; }
        
        [Column(TypeName = "date")] public DateTime DataUrodzenia { get; set; }

        
        public int IdAdresu { get; set; }

        // Właściwość nawigacyjna dla Adresu
        [ForeignKey("IdAdresu")]
        public virtual Adres Adres { get; set; }

        public int IdUmowy { get; set; }

        // Właściwość nawigacyjna dla Umowy
        [ForeignKey("IdUmowy")]
        public virtual Umowa Umowa { get; set; }
    }
}
