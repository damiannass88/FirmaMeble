using FirmaMeble.Data.Models;
using FirmaMeble.ViewModels.Abstracts;

namespace FirmaMeble.ViewModels
{
    public class NowyTowarViewModel : JedenViewModel<Towar>
    {
        public NowyTowarViewModel()
            : base("Towar")
        {
            Item = new Towar();
        }

        public string Kod
        {
            get
            {
                return Item.Kod;
            }

            set
            {
                if (Item.Kod != value)
                {
                    Item.Kod = value;
                    OnPropertyChanged(() => Kod);
                }
            }
        }

        public string Nazwa
        {
            get
            {
                return Item.Nazwa;
            }

            set
            {
                if (Item.Nazwa != value)
                {
                    Item.Nazwa = value;
                    OnPropertyChanged(() => Nazwa);
                }
            }
        }

        public decimal? StawkaVatSprzedazy
        {
            get
            {
                return Item.StawkaVatSprzedazy;
            }

            set
            {
                if (Item.StawkaVatSprzedazy != value)
                {
                    Item.StawkaVatSprzedazy = value;
                    OnPropertyChanged(() => StawkaVatSprzedazy);
                }
            }
        }

        public decimal? StawkaVatZakupu
        {
            get
            {
                return Item.StawkaVatZakupu;
            }

            set
            {
                if (Item.StawkaVatZakupu != value)
                {
                    Item.StawkaVatZakupu = value;
                    OnPropertyChanged(() => StawkaVatZakupu);
                }
            }
        }

        public decimal? Cena
        {
            get
            {
                return Item.Cena;
            }

            set
            {
                if (Item.Cena != value)
                {
                    Item.Cena = value;
                    OnPropertyChanged(() => Cena);
                }
            }
        }

        public decimal? Marza
        {
            get
            {
                return Item.Marza;
            }

            set
            {
                if (Item.Marza != value)
                {
                    Item.Marza = value;
                    OnPropertyChanged(() => Marza);
                }
            }
        }
    }
}
