using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirmaMeble.Data.Models
{
    [Table("SposobPlatnosci")]
    public partial class SposobPlatnosci
    {
        [Key]
        public int IdSposobuPlatnosci { get; set; }

        [StringLength(50)]
        public string? Nazwa { get; set; }

        [InverseProperty("IdSposobuPlatnosciNavigation")]
        public virtual ICollection<Faktura> Fakturas { get; set; } = new List<Faktura>();
    }
}
