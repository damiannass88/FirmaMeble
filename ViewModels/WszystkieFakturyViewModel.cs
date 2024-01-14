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
            var fakturas = DbEntities.FakturaDbSet;
            var fakturaForViews = fakturas.Select(faktura => CreateFakturaForView(faktura));
            List = new ObservableCollection<FakturaForView>(fakturaForViews);
        }
        private FakturaForView CreateFakturaForView(Faktura faktura)
        {
            return new FakturaForView
            {
                IdFaktury = faktura.IdFaktury,
                Numer = faktura.Numer,
                DataWystawienia = faktura.DataWystawienia,
                KontrahentNazwa = faktura.IdKontrahentaNavigation?.Nazwa,
                KontrahentNIP = faktura.IdKontrahentaNavigation?.Nip,
                KontrahentAdres = CreateKontrahentAdres(faktura),
                TerminPlatnosci = faktura.TerminPlatnosci,
                SposobPlatnosciNazwa = faktura.IdSposobuPlatnosciNavigation.Nazwa
            };
        }
        private string CreateKontrahentAdres(Faktura faktura)
        {
            var adres = faktura.IdKontrahentaNavigation?.IdAdresuNavigation;
            return $"{adres.Miejscowosc} {adres.Ulica} {adres.NrDomu}";
        }
    }
}
