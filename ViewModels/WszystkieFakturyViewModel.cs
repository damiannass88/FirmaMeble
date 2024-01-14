namespace FirmaMeble.ViewModels
{
    using System.Collections.ObjectModel;
    using Data.Models;
    using FirmaMeble.ViewModels.Abstracts;

    public class WszystkieFakturyViewModel : WszystkieViewModel<FakturaForView>
    {
        public WszystkieFakturyViewModel()
            : base("Faktury")
        {
        }
 
        public override void Load()
        {
            List = new ObservableCollection<FakturaForView>
            (
                //dla każdej fatury z bazy danych faktur
                from faktura in DbEntities.FakturaDbSet
                    //tworzymy nową FakturęForView
                select new FakturaForView
                {
                    IdFaktury = faktura.IdFaktury,//id nowej faktury ustawiamy takie jak id faktury z bazy danych
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
                }
            );
        }
    }
}
