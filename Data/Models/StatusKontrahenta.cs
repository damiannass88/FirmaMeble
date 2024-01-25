namespace FirmaMeble.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("StatusKontrahenta")]
    public class StatusKontrahenta
    {
        [Key] public int IdStatusu { get; set; }

        [StringLength(50)] public string? Nazwa { get; set; }
    }
}
