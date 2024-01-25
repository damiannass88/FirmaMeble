namespace FirmaMeble.ViewModels
{
    using System.Text;
    using System.Windows;
    using Base;
    using Data.Models;
    using Data.Validators;

    internal class NowyKontrahentViewModel : JedenViewModel<Kontrahent>
    {
        public NowyKontrahentViewModel()
            : base("Kontrahent")
        {
            InitForm();
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

        public string? Nip
        {
            get => Item.Nip;

            set
            {
                if (Item.Nip != value)
                {
                    Item.Nip = value;
                    OnPropertyChanged(() => Nip);
                }
            }
        }

        public int IdAdresu
        {
            get => Item.IdAdresu;

            set
            {
                if (Item.IdAdresu != value)
                {
                    Item.IdAdresu = value;
                    OnPropertyChanged(() => IdAdresu);
                }
            }
        }

        public IQueryable<KeyAndValue> StatusKontrahentaComboBoxItems =>
        (
            from status in DbEntities.StatusKontrahentaDbSet
            select new KeyAndValue
            {
                Key = status.IdStatusu,
                Value = status.Nazwa
            }
        ).ToList().AsQueryable();


        public int SelectedStatusKontrahenta
        {
            get => 1;
            set => Item.IdStatusu = value;
        }

        public string? Miejscowosc
        {
            get => Item.IdAdresuNavigation.Miejscowosc;
            set
            {
                if (value != Item.IdAdresuNavigation.Miejscowosc)
                {
                    Item.IdAdresuNavigation.Miejscowosc = value;
                    OnPropertyChanged(() => Miejscowosc);
                }
            }
        }

        public string? Ulica
        {
            get => Item.IdAdresuNavigation.Ulica;
            set
            {
                if (value != Item.IdAdresuNavigation.Ulica)
                {
                    Item.IdAdresuNavigation.Ulica = value;
                    OnPropertyChanged(() => Ulica);
                }
            }
        }

        public int? NrDomu
        {
            get => Item.IdAdresuNavigation.NrDomu;
            set
            {
                if (value != Item.IdAdresuNavigation.NrDomu)
                {
                    Item.IdAdresuNavigation.NrDomu = value;
                    OnPropertyChanged(() => NrDomu);
                }
            }
        }

        public string? NrLokalu
        {
            get => Item.IdAdresuNavigation.NrLokalu;
            set
            {
                if (value != Item.IdAdresuNavigation.NrLokalu)
                {
                    Item.IdAdresuNavigation.NrLokalu = value;
                    OnPropertyChanged(() => NrLokalu);
                }
            }
        }

        public string? KodPocztowy
        {
            get => Item.IdAdresuNavigation.KodPocztowy;
            set
            {
                if (value != Item.IdAdresuNavigation.KodPocztowy)
                {
                    Item.IdAdresuNavigation.KodPocztowy = value;
                    OnPropertyChanged(() => NrLokalu);
                }
            }
        }

        public string this[string name]
        {
            get
            {
                string komunikat = string.Empty;
                switch (name)
                {
                    case "Kod":
                        komunikat = StringValidator.CheckIfStringIsEmpty(Kod);
                        break;
                    
                    case "Nazwa":
                        komunikat = StringValidator.CheckIfStringIsEmpty(Nazwa);
                        break;

                    case "Nip":
                        komunikat = BusinessValidator.CheckNip(Nip);
                        break;

                    case "Ulica":
                        komunikat = StringValidator.CheckIfStringIsEmpty(Ulica);
                        if (komunikat != string.Empty)
                        {
                            break;
                        }

                        komunikat = StringValidator.CheckIfStartsWithUpperCase(Ulica);
                        break;
                    case "NrDomu":
                        komunikat = BusinessValidator.CheckIfNumberIsSet(NrDomu);
                        break;
                    case "KodPocztowy":
                        komunikat = StringValidator.CheckIfStringIsEmpty(KodPocztowy);
                        break;
                    case "Miejscowosc":
                        komunikat = StringValidator.CheckIfStringIsEmpty(Miejscowosc);
                        if (komunikat != string.Empty)
                        {
                            break;
                        }

                        komunikat = StringValidator.CheckIfStartsWithUpperCase(Miejscowosc);
                        break;
                }

                return komunikat;
            }
        }

        private void InitForm()
        {
            Item = new Kontrahent
            {
                IdAdresuNavigation = new Adres(),
                IdStatusKontrahentaNavigation = new StatusKontrahenta()
            };
        }

        public override void ClearForm()
        {
            InitForm();
            RefreshViewItems();
            MessageBox.Show("Cleared Form!", "Formularz");
        }

        private void RefreshViewItems()
        {
            OnPropertyChanged(() => Kod);
            OnPropertyChanged(() => Nazwa);
            OnPropertyChanged(() => Ulica);
            OnPropertyChanged(() => NrDomu);
            OnPropertyChanged(() => NrLokalu);
            OnPropertyChanged(() => Nip);
            OnPropertyChanged(() => KodPocztowy);
            OnPropertyChanged(() => Miejscowosc);
        }

        public override bool IsDateSetValid()
        {
            string invalidMassage = IsValid();
            if (!string.IsNullOrWhiteSpace(invalidMassage))
            {
                MessageBox.Show(invalidMassage, "Uzupełnij dane");
                return false;
            }

            return true;
        }

        public string IsValid()
        {
            StringBuilder komunikat = new();

            komunikat.AppendFormat(this["Kod"] == string.Empty ? "" : "Pole Kod: " + this["Kod"] + Environment.NewLine);
            komunikat.AppendFormat(this["Nazwa"] == string.Empty ? "" : "Pole Nazwa: " + this["Nazwa"] + Environment.NewLine);
            komunikat.AppendFormat(this["Nip"] == string.Empty ? "" : "Pole Nip: " + this["Nip"] + Environment.NewLine);
            komunikat.AppendFormat(this["Adres"] == string.Empty
                ? ""
                : "Pole Adres: " + this["Adres"] + Environment.NewLine);
            komunikat.AppendFormat(this["Ulica"] == string.Empty
                ? ""
                : "Pole Ulica: " + this["Ulica"] + Environment.NewLine);
            komunikat.AppendFormat(this["NrDomu"] == string.Empty
                ? ""
                : "Pole Nr Domu: " + this["NrDomu"] + Environment.NewLine);
            komunikat.AppendFormat(this["KodPocztowy"] == string.Empty
                ? ""
                : "Pole Kod Pocztowy: " + this["KodPocztowy"] + Environment.NewLine);
            komunikat.AppendFormat(this["Miejscowosc"] == string.Empty
                ? ""
                : "Pole Miejscowosc: " + this["Miejscowosc"] + Environment.NewLine);

            return komunikat.ToString();
        }
    }
}
