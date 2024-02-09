namespace FirmaMeble.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Base;
    using Commands;
    using Data.Models;

    public class WszyscyPracownicyViewModel : WszystkieViewModel<Pracownik>, ISortAndFiltr<Pracownik>
    {
        private KeyValuePair<string, string> selectedSortBy;

        public WszyscyPracownicyViewModel()
            : base("All Pracownicy")
        {
            QueryStatement = GetMainQueryStatement();
            CreateDataTo = DateTime.Today;
        }

        public KeyValuePair<string, string> SelectedSortBy
        {
            get => selectedSortBy;
            set
            {
                selectedSortBy = value;
                QueryStatement = GetSortedQueryStatement(SelectedSortBy.Key);
                OnPropertyChanged(() => SelectedSortBy);
                LoadContext();
            }
        }

        public ICommand FireFiltrByTextCommand => new RelayCommand(TryFiltrCollectionByText);

        public ICommand FireFiltrByDateCommand => new RelayCommand(TryFiltrCollectionByDate);

        public DateTime CreateDataForm { get; set; }

        public DateTime CreateDataTo { get; set; }

        public string SearchContext { get; set; }

        public int SelectedSort { get; set; }

        public IQueryable<Pracownik> QueryStatement { get; set; }

        public ObservableCollection<KeyValuePair<string, string>> SortBy =>
            new()
            {
                new KeyValuePair<string, string>("IdPracownika", "Id Pracownika"),
                new KeyValuePair<string, string>("Imie", "Imie"),
                new KeyValuePair<string, string>("DrugieImie", "Drugie Imie"),
                new KeyValuePair<string, string>("Nazwisko", "Nazwisko"),
                new KeyValuePair<string, string>("MiejsceUrodzenia", "Miejsce Urodzenia"),
                new KeyValuePair<string, string>("ImieOjca", "Imie Ojca"),
                new KeyValuePair<string, string>("ImieMatki", "Imie Matki"),
                new KeyValuePair<string, string>("Email", "Email"),
                new KeyValuePair<string, string>("Telefon", "Telefon"),
                new KeyValuePair<string, string>("Pesel", "Pesel"),
                new KeyValuePair<string, string>("Stanowisko", "Stanowisko"),
                new KeyValuePair<string, string>("Nip", "Nip"),
                new KeyValuePair<string, string>("CreateDate", "Data Utworzenia")
            };

        private void TryFiltrCollectionByText()
        {
            if (!string.IsNullOrEmpty(SearchContext))
            {
                QueryStatement = GetTextSearchQueryStatement();
            }

            LoadContext();
        }

        private void TryFiltrCollectionByDate()
        {
            QueryStatement = GetDateRangeQueryStatement();

            LoadContext();
        }

        public override IQueryable<Pracownik> GetQueryStatement()
        {
            if (!IsFiltrAndSortPanelVisible)
            {
                return GetMainQueryStatement();
            }

            return QueryStatement;
        }

        private IQueryable<Pracownik> GetMainQueryStatement()
        {
            return DbEntities.PracownikDbSet.Select(pracownik => new Pracownik
            {
                IdPracownika = pracownik.IdPracownika,
                Imie = pracownik.Imie,
                DrugieImie = pracownik.DrugieImie,
                Nazwisko = pracownik.Nazwisko,
                MiejsceUrodzenia = pracownik.MiejsceUrodzenia,
                DataUrodzenia = pracownik.DataUrodzenia,
                CreateDate = pracownik.CreateDate,
                ImieOjca = pracownik.ImieOjca,
                ImieMatki = pracownik.ImieMatki,
                Email = pracownik.Email,
                Telefon = pracownik.Telefon,
                Nip = pracownik.Nip,
                Pesel = pracownik.Pesel,
                Stanowisko = pracownik.Stanowisko
            });
        }

        private IQueryable<Pracownik> GetTextSearchQueryStatement()
        {
            IQueryable<Pracownik> query = GetMainQueryStatement();

            return query.Where(pracownik =>
                (!string.IsNullOrEmpty(pracownik.Imie) && pracownik.Imie.Contains(SearchContext)) ||
                (!string.IsNullOrEmpty(pracownik.DrugieImie) && pracownik.DrugieImie.Contains(SearchContext)) ||
                (!string.IsNullOrEmpty(pracownik.Nazwisko) && pracownik.Nazwisko.Contains(SearchContext)) ||
                (!string.IsNullOrEmpty(pracownik.MiejsceUrodzenia) &&
                 pracownik.MiejsceUrodzenia.Contains(SearchContext)) ||
                (!string.IsNullOrEmpty(pracownik.ImieOjca) && pracownik.ImieOjca.Contains(SearchContext)) ||
                (!string.IsNullOrEmpty(pracownik.ImieMatki) && pracownik.ImieMatki.Contains(SearchContext)) ||
                (!string.IsNullOrEmpty(pracownik.Email) && pracownik.Email.Contains(SearchContext)) ||
                (!string.IsNullOrEmpty(pracownik.Telefon) && pracownik.Telefon.Contains(SearchContext)) ||
                (!string.IsNullOrEmpty(pracownik.Pesel) && pracownik.Pesel.Contains(SearchContext)) ||
                (!string.IsNullOrEmpty(pracownik.Stanowisko) && pracownik.Stanowisko.Contains(SearchContext)) ||
                (!string.IsNullOrEmpty(pracownik.Nip) && pracownik.Nip.Contains(SearchContext)));
        }

        private IQueryable<Pracownik> GetDateRangeQueryStatement()
        {
            IQueryable<Pracownik> query = GetMainQueryStatement();

            return query.Where(pracownik =>
                (CreateDataForm == default || pracownik.CreateDate >= CreateDataForm) &&
                (CreateDataTo == default || pracownik.CreateDate <= CreateDataTo));
        }

        private IQueryable<Pracownik> GetSortedQueryStatement(string sortBy)
        {
            IQueryable<Pracownik> query = GetMainQueryStatement();

            switch (sortBy)
            {
                case "IdPracownika":
                    query = query.OrderBy(k => k.IdPracownika);
                    break;
                case "Imie":
                    query = query.OrderBy(k => k.Imie);
                    break;
                 case "DrugieImie":
                    query = query.OrderBy(k => k.DrugieImie);
                    break;
                case "Nazwisko":
                    query = query.OrderBy(k => k.Nazwisko);
                    break;
                 case "ImieOjca":
                    query = query.OrderBy(k => k.ImieOjca);
                    break;
                 case "ImieMatki":
                    query = query.OrderBy(k => k.ImieMatki);
                    break;
                 case "MiejsceUrodzenia":
                    query = query.OrderBy(k => k.MiejsceUrodzenia);
                    break;
                 case "Email":
                    query = query.OrderBy(k => k.Email);
                    break;
                 case "Telefon":
                    query = query.OrderBy(k => k.Telefon);
                    break;
                 case "Pesel":
                    query = query.OrderBy(k => k.Pesel);
                    break;
                case "Stanowisko":
                    query = query.OrderBy(k => k.Stanowisko);
                    break;
                case "Nip":
                    query = query.OrderBy(k => k.Nip);
                    break;
                case "CreateDate":
                    query = query.OrderBy(k => k.CreateDate);
                    break;
            }

            return query;
        }
    }
}
