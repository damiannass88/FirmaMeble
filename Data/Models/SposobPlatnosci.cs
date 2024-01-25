﻿namespace FirmaMeble.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SposobPlatnosci")]
    public class SposobPlatnosci
    {
        [Key] public int IdSposobuPlatnosci { get; set; }

        [StringLength(50)] public string? Nazwa { get; set; }
    }
}
