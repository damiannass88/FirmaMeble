namespace FirmaMeble.ViewModels
{
    using Base;
    using Data.Models;

    public class WszyscyPracownicyViewModel : WszystkieViewModel<Pracownik>
    {
        public WszyscyPracownicyViewModel()
            : base("All Pracownicy")
        {
        }

        public override IQueryable<Pracownik> GetQueryStatement()
        {
            return DbEntities.PracownikDbSet.Select(pracownik => new Pracownik
            {
                Imie = pracownik.Imie,
                DrugieImie = pracownik.DrugieImie,
                Nazwisko = pracownik.Nazwisko,
                MiejsceUrodzenia = pracownik.MiejsceUrodzenia,
                ImieOjca = pracownik.ImieOjca,
                ImieMatki = pracownik.ImieMatki,
                Email = pracownik.Email,
                Telefon = pracownik.Telefon,
                Nip = pracownik.Nip,
                Pesel = pracownik.Pesel,
                Stanowisko = pracownik.Stanowisko
            });
        }
    }
}
