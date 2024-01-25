namespace FirmaMeble.ViewModels
{
    using System.Windows;
    using System.Windows.Input;
    using Base;
    using Commands;
    using Data.Models;

    public class NowyTowarViewModel : JedenViewModel<Towar>
    {

        public NowyTowarViewModel()
            : base("Towar")
        {
            Item = new Towar();
        }

        public string? Kod
        {
            get => Item.Kod;

            set
            {
                if (Item.Kod != value)
                {
                    Item.Kod = value;
                    OnPropertyChanged(() => Kod);
                }
            }
        }

        public override void ClearForm()
        {
            MessageBox.Show("ClearForm!", "Formularz");
        }

        public string? Nazwa
        {
            get => Item.Nazwa;

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
            get => Item.StawkaVatSprzedazy;

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
            get => Item.StawkaVatZakupu;

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
            get => Item.Cena;

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
            get => Item.Marza;

            set
            {
                if (Item.Marza != value)
                {
                    Item.Marza = value;
                    OnPropertyChanged(() => Marza);
                }
            }
        }

        public override bool IsDateSetValid()
        {
            throw new NotImplementedException();
        }

    }
}
