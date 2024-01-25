namespace FirmaMeble.ViewModels
{
    using System.Text;
    using System.Windows;
    using Base;
    using Data.Models;
    using Data.Validators;

    public class NowyPracownikViewModel : JedenViewModel<Pracownik>
    {
        public NowyPracownikViewModel()
            : base("Pracownik")
        {
            InitForm();
        }

        public string Imie
        {
            get => Item.Imie;
            set
            {
                if (value != Item.Imie)
                {
                    Item.Imie = value;
                    OnPropertyChanged(() => Imie);
                }
            }
        }

        public string DrugieImie
        {
            get => Item.DrugieImie;
            set
            {
                if (value != Item.DrugieImie)
                {
                    Item.DrugieImie = value;
                    OnPropertyChanged(() => DrugieImie);
                }
            }
        }

        public string Nazwisko
        {
            get => Item.Nazwisko;
            set
            {
                if (value != Item.Nazwisko)
                {
                    Item.Nazwisko = value;
                    OnPropertyChanged(() => Nazwisko);
                }
            }
        }

        public string MiejsceUrodzenia
        {
            get => Item.MiejsceUrodzenia;
            set
            {
                if (value != Item.MiejsceUrodzenia)
                {
                    Item.MiejsceUrodzenia = value;
                    OnPropertyChanged(() => MiejsceUrodzenia);
                }
            }
        }

        public string ImieOjca
        {
            get => Item.ImieOjca;
            set
            {
                if (value != Item.ImieOjca)
                {
                    Item.ImieOjca = value;
                    OnPropertyChanged(() => ImieOjca);
                }
            }
        }

        public string ImieMatki
        {
            get => Item.ImieMatki;
            set
            {
                if (value != Item.ImieMatki)
                {
                    Item.ImieMatki = value;
                    OnPropertyChanged(() => ImieMatki);
                }
            }
        }

        public string Pesel
        {
            get => Item.Pesel;
            set
            {
                if (value != Item.Pesel)
                {
                    Item.Pesel = value;
                    OnPropertyChanged(() => Pesel);
                }
            }
        }

        public string Nip
        {
            get => Item.Nip;
            set
            {
                if (value != Item.Nip)
                {
                    Item.Nip = value;
                    OnPropertyChanged(() => Nip);
                }
            }
        }

        public string Telefon
        {
            get => Item.Telefon;
            set
            {
                if (value != Item.Telefon)
                {
                    Item.Telefon = value;
                    OnPropertyChanged(() => Telefon);
                }
            }
        }

        public string Email
        {
            get => Item.Email;
            set
            {
                if (value != Item.Email)
                {
                    Item.Email = value;
                    OnPropertyChanged(() => Email);
                }
            }
        }

        public string Stanowisko
        {
            get => Item.Stanowisko;

            set
            {
                if (Item.Stanowisko != value)
                {
                    Item.Stanowisko = value;
                    OnPropertyChanged(() => Stanowisko);
                }
            }
        }

        public DateTime DataUrodzenia
        {
            get => Item.DataUrodzenia;

            set
            {
                if (Item.DataUrodzenia != value)
                {
                    Item.DataUrodzenia = value;
                    OnPropertyChanged(() => DataUrodzenia);
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

        public IQueryable<KeyAndValue> AdresyComboBoxItems =>
        (
            from adres in DbEntities.AdresDbSet
            select new KeyAndValue
            {
                Key = adres.IdAdresu,
                Value = adres.Ulica + " " + adres.NrDomu +
                        (adres.NrLokalu.Equals("") ? "" : "/" + adres.NrLokalu) +
                        ", " + adres.KodPocztowy + " " + adres.Miejscowosc
            }
        ).ToList().AsQueryable();


        public int UmowaId
        {
            get => Item.Umowa.IdUmowy;
            set
            {
                if (value != Item.Umowa.IdUmowy)
                {
                    Item.Umowa.IdUmowy = value;
                    OnPropertyChanged(() => UmowaId);
                }
            }
        }

        public IQueryable<KeyAndValue> StanowiskaComboBoxItems => DbEntities.StanowiskaPracownikowDbSet
            .Select(umowy => new KeyAndValue
            {
                Key = umowy.IdStanowiska,
                Value = umowy.StanowiskoNazwa
            })
            .ToList().AsQueryable();

        public string SelectedStanowisko
        {
            get => "Wybierz Stanowisko!";
            set => Stanowisko = value;
        }

        public DateTime DataRozpoczecia
        {
            get => Item.Umowa.DataRozpoczecia;
            set
            {
                if (value != Item.Umowa.DataRozpoczecia)
                {
                    Item.Umowa.DataRozpoczecia = value;
                    OnPropertyChanged(() => DataRozpoczecia);
                }
            }
        }

        public DateTime? DataZakonczenia
        {
            get => Item.Umowa.DataZakonczenia;
            set
            {
                if (value != Item.Umowa.DataZakonczenia)
                {
                    Item.Umowa.DataZakonczenia = value;
                    OnPropertyChanged(() => DataZakonczenia);
                }
            }
        }

        public bool CzyAktywna
        {
            get => Item.Umowa.CzyAktywna;
            set
            {
                if (value != Item.Umowa.CzyAktywna)
                {
                    Item.Umowa.CzyAktywna = value;
                    OnPropertyChanged(() => CzyAktywna);
                }
            }
        }

        public decimal KwotaBrutto
        {
            get => Item.Umowa.KwotaBrutto;
            set
            {
                if (value != Item.Umowa.KwotaBrutto)
                {
                    Item.Umowa.KwotaBrutto = value;
                    OnPropertyChanged(() => KwotaBrutto);
                }
            }
        }

        public string? Opis
        {
            get => Item.Umowa.Opis;
            set
            {
                if (value != Item.Umowa.Opis)
                {
                    Item.Umowa.Opis = value;
                    OnPropertyChanged(() => Opis);
                }
            }
        }

        public string? Miejscowosc
        {
            get => Item.Adres.Miejscowosc;
            set
            {
                if (value != Item.Adres.Miejscowosc)
                {
                    Item.Adres.Miejscowosc = value;
                    OnPropertyChanged(() => Miejscowosc);
                }
            }
        }

        public string? Ulica
        {
            get => Item.Adres.Ulica;
            set
            {
                if (value != Item.Adres.Ulica)
                {
                    Item.Adres.Ulica = value;
                    OnPropertyChanged(() => Ulica);
                }
            }
        }

        public int? NrDomu
        {
            get => Item.Adres.NrDomu;
            set
            {
                if (value != Item.Adres.NrDomu)
                {
                    Item.Adres.NrDomu = value;
                    OnPropertyChanged(() => NrDomu);
                }
            }
        }

        public string? NrLokalu
        {
            get => Item.Adres.NrLokalu;
            set
            {
                if (value != Item.Adres.NrLokalu)
                {
                    Item.Adres.NrLokalu = value;
                    OnPropertyChanged(() => NrLokalu);
                }
            }
        }

        public string? KodPocztowy
        {
            get => Item.Adres.KodPocztowy;
            set
            {
                if (value != Item.Adres.KodPocztowy)
                {
                    Item.Adres.KodPocztowy = value;
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
                    case "Imie":
                        komunikat = StringValidator.CheckIfStartsWithUpperCase(Imie);
                        if (komunikat != string.Empty)
                        {
                            break;
                        }

                        komunikat = StringValidator.CheckIfStringIsEmpty(Imie);
                        break;
                    case "DrugieImie":
                        komunikat = StringValidator.CheckIfStartsWithUpperCase(DrugieImie);
                        break;
                    case "Nazwisko":
                        komunikat = StringValidator.CheckIfStringIsEmpty(Nazwisko);
                        if (komunikat != string.Empty)
                        {
                            break;
                        }

                        komunikat = StringValidator.CheckIfStartsWithUpperCase(Nazwisko);
                        break;
                    case "Pesel":
                        komunikat = BusinessValidator.CheckPesel(Pesel);
                        break;
                    case "Nip":
                        komunikat = BusinessValidator.CheckNip(Nip);
                        break;
                    case "MiejsceUrodzenia":
                        komunikat = StringValidator.CheckIfStringIsEmpty(MiejsceUrodzenia);
                        if (komunikat != string.Empty)
                        {
                            break;
                        }

                        komunikat = StringValidator.CheckIfStartsWithUpperCase(MiejsceUrodzenia);
                        break;
                    case "ImieOjca":
                        komunikat = StringValidator.CheckIfStartsWithUpperCase(ImieOjca);
                        break;
                    case "ImieMatki":
                        komunikat = StringValidator.CheckIfStartsWithUpperCase(ImieMatki);
                        break;
                    case "Telefon":
                        komunikat = StringValidator.CheckIfStringIsEmpty(Telefon);
                        if (komunikat != string.Empty)
                        {
                            break;
                        }

                        komunikat = StringValidator.CheckIsNumeric(Telefon);
                        break;
                    case "Email":
                        komunikat = StringValidator.CheckEmail(Email);
                        if (komunikat != string.Empty)
                        {
                            break;
                        }

                        komunikat = StringValidator.CheckIfStringIsEmpty(Email);
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

                    case "Stanowisko":
                        komunikat = StringValidator.CheckIfStringIsEmpty(Stanowisko);
                        break;
                    case "KwotaBrutto":
                        komunikat = BusinessValidator.CheckIfIsNotLessThanZero(KwotaBrutto);
                        break;
                    case "Opis":
                        komunikat = StringValidator.CheckIfStringIsEmpty(Opis);
                        break;
                    case "DataUrodzenia":
                        komunikat = BusinessValidator.CheckDateIsNotEarlier(DataUrodzenia, DateTime.Now.AddYears(-18));
                        break;
                }

                return komunikat;
            }
        }

        private void InitForm()
        {
            Item = new Pracownik
            {
                Umowa = new Umowa(),
                Adres = new Adres()
            };

            DataUrodzenia = DateTime.Today.AddYears(-18);
            Item.Umowa.DataRozpoczecia = DateTime.Today;
        }

        public override void ClearForm()
        {
            InitForm();
            RefreshViewItems();
            MessageBox.Show("Cleared Form!", "Formularz");
        }

        private void RefreshViewItems()
        {
            OnPropertyChanged(() => Imie);
            OnPropertyChanged(() => Nazwisko);
            OnPropertyChanged(() => DrugieImie);
            OnPropertyChanged(() => Pesel);
            OnPropertyChanged(() => ImieOjca);
            OnPropertyChanged(() => MiejsceUrodzenia);
            OnPropertyChanged(() => ImieMatki);
            OnPropertyChanged(() => Telefon);
            OnPropertyChanged(() => Email);
            OnPropertyChanged(() => Ulica);
            OnPropertyChanged(() => Nip);
            OnPropertyChanged(() => NrDomu);
            OnPropertyChanged(() => NrLokalu);
            OnPropertyChanged(() => KodPocztowy);
            OnPropertyChanged(() => Miejscowosc);
            OnPropertyChanged(() => KwotaBrutto);
            OnPropertyChanged(() => Stanowisko);
            OnPropertyChanged(() => Opis);
            OnPropertyChanged(() => DataUrodzenia);
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
            komunikat.AppendFormat(this["Imie"] == string.Empty
                ? ""
                : "Pole Imię: " + this["Imie"] + Environment.NewLine);
            komunikat.AppendFormat(this["DrugieImie"] == string.Empty
                ? ""
                : "Pole Drugie imię: " + this["DrugieImie"] + Environment.NewLine);
            komunikat.AppendFormat(this["Nazwisko"] == string.Empty
                ? ""
                : "Pole Nazwisko: " + this["Nazwisko"] + Environment.NewLine);
            komunikat.AppendFormat(this["Pesel"] == string.Empty
                ? ""
                : "Pole Pesel: " + this["Pesel"] + Environment.NewLine);
            komunikat.AppendFormat(this["Nip"] == string.Empty ? "" : "Pole Nip: " + this["Nip"] + Environment.NewLine);
            komunikat.AppendFormat(this["MiejsceUrodzenia"] == string.Empty
                ? ""
                : "Pole Miejsce urodzenia: " + this["MiejsceUrodzenia"] + Environment.NewLine);
            komunikat.AppendFormat(this["ImieOjca"] == string.Empty
                ? ""
                : "Pole Imię ojca: " + this["ImieOjca"] + Environment.NewLine);
            komunikat.AppendFormat(this["ImieMatki"] == string.Empty
                ? ""
                : "Pole Imię matki: " + this["ImieMatki"] + Environment.NewLine);
            komunikat.AppendFormat(this["Telefon"] == string.Empty
                ? ""
                : "Pole Telefon: " + this["Telefon"] + Environment.NewLine);
            komunikat.AppendFormat(this["Email"] == string.Empty
                ? ""
                : "Pole Email: " + this["Email"] + Environment.NewLine);
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

            komunikat.AppendFormat(this["Stanowisko"] == string.Empty
                ? ""
                : "Pole Stanowisko: " + this["Stanowisko"] + Environment.NewLine);
            komunikat.AppendFormat(this["KwotaBrutto"] == string.Empty
                ? ""
                : "Pole KwotaBrutto: " + this["KwotaBrutto"] + Environment.NewLine);
            komunikat.AppendFormat(this["Opis"] == string.Empty
                ? ""
                : "Pole Opis: " + this["Opis"] + Environment.NewLine);
            komunikat.AppendFormat(this["DataUrodzenia"] == string.Empty
                ? ""
                : "Pole Data Urodzenia: " + this["DataUrodzenia"] + Environment.NewLine);

            return komunikat.ToString();
        }
    }
}
