namespace FirmaMeble.Data.DbContexts
{
    using FirmaMeble.Data.DbContexts;
    using FirmaMeble.Data.Models;
    using System;
    using System.Linq;

    public class DataSeeder
    {
        public static void SeedDataBase(DataBaseEntities context)
        {
            if (!context.Adres.Any())
            {
                // Dodawanie adresów
                var adresy = new[]
                {
                    new Adres { Miejscowosc = "Warszawa", Ulica = "Marszałkowska", NrDomu = "10", NrLokalu = "15", KodPocztowy = "00-950" },
                    new Adres { Miejscowosc = "Kraków", Ulica = "Floriańska", NrDomu = "5", NrLokalu = "2", KodPocztowy = "31-019" },
                    // Dodaj więcej adresów według potrzeb
                };
                context.Adres.AddRange(adresy);
                context.SaveChanges();
            }

            if (!context.Kontrahents.Any())
            {
                // Dodawanie kontrahentów
                var kontrahenci = new[]
                {
                    new Kontrahent { Nazwa = "Klient A", IdAdresu = 1 /* itd. */ },
                    new Kontrahent { Nazwa = "Dostawca X", IdAdresu = 2 /* itd. */ },
                    // Dodaj więcej kontrahentów według potrzeb
                };
                context.Kontrahents.AddRange(kontrahenci);
                context.SaveChanges();
            }

            if (!context.Fakturas.Any())
            {
                // Dodawanie faktur
                var faktury = new[]
                {
                    new Faktura { Numer = "FV/2024/01", DataWystawienia = DateTime.Now, IdKontrahenta = 1, TerminPlatnosci = DateTime.Now.AddDays(30) /* itd. */ },
                    // Dodaj więcej faktur według potrzeb
                };
                context.Fakturas.AddRange(faktury);
                context.SaveChanges();
            }

            // Dodaj więcej danych dla pozostałych tabel według wzoru powyżej
        }
    }
}
