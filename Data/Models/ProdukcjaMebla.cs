namespace FirmaMeble.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ProdukcjaMebla")]
    public class ProdukcjaMebla
    {
        [Key] public int IdProdukcji { get; set; }

        [ForeignKey("Towar")] public int IdTowaru { get; set; }

        public virtual Towar Towar { get; set; }

        [Column(TypeName = "date")] public DateTime DataRozpoczęcia { get; set; }

        [Column(TypeName = "date")] public DateTime DataZakończenia { get; set; }

        public int IlośćProdukowanychSztuk { get; set; }

        [ForeignKey("Pracownik")] public int IdPracownika { get; set; }

        public virtual Pracownik Pracownik { get; set; }

        public StatusProdukcji StatusProdukcji { get; set; }
    }
}
