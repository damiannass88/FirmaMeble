﻿namespace FirmaMeble.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Magazyn")]
    public class Magazyn
    {
        [Key] public int IdMagazynu { get; set; }

        [StringLength(100)] public string Lokalizacja { get; set; }

        public int Pojemność { get; set; }

        [ForeignKey("Adres")] public int IdAdresu { get; set; }

        public virtual Adres Adres { get; set; }
    }
}
