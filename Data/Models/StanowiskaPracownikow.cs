namespace FirmaMeble.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Stanowisko")]
    public class StanowiskaPracownikow
    {
        [Key] public int IdStanowiska { get; set; }

        [StringLength(100)] public string StanowiskoNazwa { get; set; }
    }
}
