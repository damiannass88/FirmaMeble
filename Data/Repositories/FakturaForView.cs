namespace FirmaMeble.Data.Repositories
{
    using System.ComponentModel.DataAnnotations;


    public class FakturaForView
    {
        [Key]
        public int IdFaktury { get; set; }

        public string? Numer { get; set; }

        public DateTime? DataWystawienia { get; set; }

        //poniższe pola będą zamiast idKontrahenta
        public string? KontrahentNazwa { get; set; }

        public string? KontrahentNIP { get; set; }

        public string? KontrahentAdres { get; set; }

        public DateTime? TerminPlatnosci { get; set; }

        //to pole jest zamiast idSposobuPlatnosci
        public string SposobPlatnosciNazwa { get; set; }
    }
}
