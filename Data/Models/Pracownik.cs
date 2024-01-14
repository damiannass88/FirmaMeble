namespace FirmaMeble.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Pracownik")]
    public class Pracownik
    {
        [Key] public int IdPracownika { get; set; }

        [StringLength(50)] public string Imie { get; set; }

        [StringLength(50)] public string Nazwisko { get; set; }

        [StringLength(50)] public string Stanowisko { get; set; }

        [ForeignKey("Adres")] public int IdAdresu { get; set; }

        public virtual Adres Adres { get; set; }

        [Column(TypeName = "date")] public DateTime DataZatrudnienia { get; set; }
        
        public virtual ICollection<Umowa> Umowy { get; set; }
    }
}
