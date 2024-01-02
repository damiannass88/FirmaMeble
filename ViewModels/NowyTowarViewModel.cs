namespace FirmaMeble.ViewModels
{
    using FirmaMeble.Data.Repositories;

    public class NowyTowarViewModel : JedenViewModel<Towar>
    {
        public NowyTowarViewModel()
            : base("Towar")
        {
            item = new Towar();
        }

        public string Kod
        {
            get
            {
                return item.Kod;
            }

            set
            {
                if (item.Kod != value)
                {
                    item.Kod = value;
                    OnPropertyChanged(() => Kod);
                }
            }
        }

        public string Nazwa
        {
            get
            {
                return item.Nazwa;
            }

            set
            {
                if (item.Nazwa != value)
                {
                    item.Nazwa = value;
                    OnPropertyChanged(() => Nazwa);
                }
            }
        }

        public decimal? StawkaVatSprzedazy
        {
            get
            {
                return item.StawkaVatSprzedazy;
            }

            set
            {
                if (item.StawkaVatSprzedazy != value)
                {
                    item.StawkaVatSprzedazy = value;
                    OnPropertyChanged(() => StawkaVatSprzedazy);
                }
            }
        }

        public decimal? StawkaVatZakupu
        {
            get
            {
                return item.StawkaVatZakupu;
            }

            set
            {
                if (item.StawkaVatZakupu != value)
                {
                    item.StawkaVatZakupu = value;
                    OnPropertyChanged(() => StawkaVatZakupu);
                }
            }
        }

        public decimal? Cena
        {
            get
            {
                return item.Cena;
            }

            set
            {
                if (item.Cena != value)
                {
                    item.Cena = value;
                    OnPropertyChanged(() => Cena);
                }
            }
        }

        public decimal? Marza
        {
            get
            {
                return item.Marza;
            }

            set
            {
                if (item.Marza != value)
                {
                    item.Marza = value;
                    OnPropertyChanged(() => Marza);
                }
            }
        }
    }
}
