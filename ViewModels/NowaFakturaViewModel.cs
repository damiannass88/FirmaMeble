namespace FirmaMeble.ViewModels
{
    using Data.Models;

    public class NowaFakturaViewModel : JedenViewModel<Faktura>
    {
        public NowaFakturaViewModel()
            : base("Faktura")
        {
            Item = new Faktura();
        }

        public string? Numer
        {
            get => Item.Numer;

            set
            {
                if (Item.Numer != value)
                {
                    Item.Numer = value;
                    OnPropertyChanged(() => Numer);
                }
            }
        }

        public DateTime? DataWystawienia
        {
            get => Item.DataWystawienia;

            set
            {
                if (Item.DataWystawienia != value)
                {
                    Item.DataWystawienia = value;
                    OnPropertyChanged(() => DataWystawienia);
                }
            }
        }

        public int? IdKontrahenta
        {
            get => Item.IdKontrahenta;

            set
            {
                if (Item.IdKontrahenta != value)
                {
                    Item.IdKontrahenta = value;
                    OnPropertyChanged(() => IdKontrahenta);
                }
            }
        }

        public DateTime? TerminPlatnosci
        {
            get => Item.TerminPlatnosci;

            set
            {
                if (Item.TerminPlatnosci != value)
                {
                    Item.TerminPlatnosci = value;
                    OnPropertyChanged(() => TerminPlatnosci);
                }
            }
        }

        public int? IdSposobuPlatnosci
        {
            get => Item.IdSposobuPlatnosci;

            set
            {
                if (Item.IdSposobuPlatnosci != value)
                {
                    Item.IdSposobuPlatnosci = value;
                    OnPropertyChanged(() => IdSposobuPlatnosci);
                }
            }
        }

        public IQueryable<SposobPlatnosci> SposobPlatnosciComboBoxItems =>
        (
            from sposobPlatnosci in FakturyEntities.SposobPlatnoscis
            select sposobPlatnosci
        ).ToList().AsQueryable();
    }
}
