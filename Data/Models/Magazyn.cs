using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirmaMeble.Data.Models
{
    public partial class Magazyn
    {
        [Key]
        public int IdMagazynu { get; set; }

        [StringLength(100)]
        public string Lokalizacja { get; set; }

        public int Pojemność { get; set; }

        [ForeignKey("Adres")]
        public int IdAdresu { get; set; }

        public virtual Adres Adres { get; set; }
    }
}
