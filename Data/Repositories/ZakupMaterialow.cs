namespace FirmaMeble.Data.Repositories
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ZakupMaterialow
    {
        [Key]
        public int IdZakupu { get; set; }

        [ForeignKey("Dostawca")]
        public int IdDostawcy { get; set; }

        public virtual Dostawca Dostawca { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataZakupu { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Kwota { get; set; }

        [StringLength(255)]
        public string Opis { get; set; }
    }
}
