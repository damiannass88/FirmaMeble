namespace FirmaMeble.ViewModels
{
    using FirmaMeble.Data.Repositories;

    public class NowaFakturaViewModel : JedenViewModel<Faktura>
    {
        public NowaFakturaViewModel()
            : base("Faktura")
        {
            item = new Faktura();
        }

        public string? Numer
        {
            get
            {
                return item.Numer;
            }

            set
            {
                if (item.Numer != value)
                {
                    item.Numer = value;
                    base.OnPropertyChanged(() => Numer);
                }
            }
        }

        public DateTime? DataWystawienia
        {
            get
            {
                return item.DataWystawienia;
            }

            set
            {
                if (item.DataWystawienia != value)
                {
                    item.DataWystawienia = value;
                    base.OnPropertyChanged(() => DataWystawienia);
                }
            }
        }

        public int? IdKontrahenta
        {
            get
            {
                return item.IdKontrahenta;
            }

            set
            {
                if (item.IdKontrahenta != value)
                {
                    item.IdKontrahenta = value;
                    base.OnPropertyChanged(() => IdKontrahenta);
                }
            }
        }

        public DateTime? TerminPlatnosci
        {
            get
            {
                return item.TerminPlatnosci;
            }

            set
            {
                if (item.TerminPlatnosci != value)
                {
                    item.TerminPlatnosci = value;
                    base.OnPropertyChanged(() => TerminPlatnosci);
                }
            }
        }

        public int? IdSposobuPlatnosci
        {
            get
            {
                return item.IdSposobuPlatnosci;
            }

            set
            {
                if (item.IdSposobuPlatnosci != value)
                {
                    item.IdSposobuPlatnosci = value;
                    base.OnPropertyChanged(() => IdSposobuPlatnosci);
                }
            }
        }

        public IQueryable<SposobPlatnosci> SposobPlatnosciComboBoxItems
        {
            get
            {
                return
                    (
                        from sposobPlatnosci in fakturyEntities.SposobPlatnoscis
                        select sposobPlatnosci
                    ).ToList().AsQueryable();
            }
        }
    }
}
