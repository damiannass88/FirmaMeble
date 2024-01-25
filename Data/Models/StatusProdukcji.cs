namespace FirmaMeble.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("StatusProdukcji")]
    public class StatusProdukcji
    {
        [Key] public int IdStatus { get; set; }

        [StringLength(50)] public string? Nazwa { get; set; }
    }
}
