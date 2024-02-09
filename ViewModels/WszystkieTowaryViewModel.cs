namespace FirmaMeble.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Base;
    using Commands;
    using Data.Models;

    public class WszystkieTowaryViewModel : WszystkieViewModel<Towar>, ISortAndFiltr<Towar>
    {
        private KeyValuePair<string, string> selectedSortBy;

        public WszystkieTowaryViewModel()
            : base("All Towary")
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

        public IQueryable<Towar> QueryStatement { get; set; }

        public ObservableCollection<KeyValuePair<string, string>> SortBy =>
            new()
            {
                new KeyValuePair<string, string>("IdTowaru", "Id Towaru"),
                new KeyValuePair<string, string>("Nazwa", "Nazwa"),
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

        public override IQueryable<Towar> GetQueryStatement()
        {
            if (!IsFiltrAndSortPanelVisible)
            {
                return GetMainQueryStatement();
            }

            return QueryStatement;
        }

        private IQueryable<Towar> GetMainQueryStatement()
        {
            return from towar in
                    DbEntities.TowarDbSet
                select towar;
        }

        private IQueryable<Towar> GetTextSearchQueryStatement()
        {
            IQueryable<Towar> query = GetMainQueryStatement();

            return query.Where(towar =>
                (!string.IsNullOrEmpty(towar.Kod) && towar.Kod.Contains(SearchContext)) ||
                (!string.IsNullOrEmpty(towar.Nazwa) && towar.Nazwa.Contains(SearchContext)));
        }

        private IQueryable<Towar> GetDateRangeQueryStatement()
        {
            IQueryable<Towar> query = GetMainQueryStatement();

            return query.Where(towar =>
                (CreateDataForm == default || towar.CreateDate >= CreateDataForm) &&
                (CreateDataTo == default || towar.CreateDate <= CreateDataTo));
        }

        private IQueryable<Towar> GetSortedQueryStatement(string sortBy)
        {
            IQueryable<Towar> query = GetMainQueryStatement();

            switch (sortBy)
            {
                case "IdTowaru":
                    query = query.OrderBy(k => k.IdTowaru);
                    break;
                case "Kod":
                    query = query.OrderBy(k => k.Kod);
                    break;
                case "Nazwa":
                    query = query.OrderBy(k => k.Nazwa);
                    break;
                case "CreateDate":
                    query = query.OrderBy(k => k.CreateDate);
                    break;
            }

            return query;
        }
    }
}
