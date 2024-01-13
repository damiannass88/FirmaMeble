using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirmaMeble.Data.Models
{
    public partial class Dostawca
    {
        [Key]
        public int IdDostawcy { get; set; }

        [StringLength(100)]
        public string NazwaFirmy { get; set; }

        [StringLength(50)]
        public string NIP { get; set; }

        [ForeignKey("Adres")]
        public int IdAdresu { get; set; }

        public virtual Adres Adres { get; set; }
    }
}
