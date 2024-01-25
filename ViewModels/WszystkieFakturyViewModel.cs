namespace FirmaMeble.ViewModels
{
    using Base;
    using Data.Models;

    public class WszystkieFakturyViewModel : WszystkieViewModel<FakturaForView>
    {
        public WszystkieFakturyViewModel()
            : base("All Faktury")
        {
        }

        public override IQueryable<FakturaForView> GetQueryStatement()
        {
            return from faktura in DbEntities.FakturaDbSet
                //tworzymy nową FakturyForView
                select new FakturaForView
                {
                    IdFaktury = faktura.IdFaktury, //id nowej faktury ustawiamy takie jak id faktury z bazy danych
                    Numer = faktura.Numer,
                    DataWystawienia = faktura.DataWystawienia,
                    KontrahentNazwa = faktura.IdKontrahentaNavigation.Nazwa,
                    KontrahentNIP = faktura.IdKontrahentaNavigation.Nip,
                    KontrahentAdres =
                        faktura.IdKontrahentaNavigation.IdAdresuNavigation.Miejscowosc + " "
                        + faktura.IdKontrahentaNavigation.IdAdresuNavigation.Ulica + " "
                        + faktura.IdKontrahentaNavigation.IdAdresuNavigation.NrDomu,
                    TerminPlatnosci = faktura.TerminPlatnosci,
                    SposobPlatnosciNazwa = faktura.IdSposobuPlatnosciNavigation.Nazwa
                };
        }
    }
}
