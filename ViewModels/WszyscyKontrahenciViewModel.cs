namespace FirmaMeble.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Base;
    using Commands;
    using Data.Models;

    internal class WszyscyKontrahenciViewModel : WszystkieViewModel<Kontrahent>, ISortAndFiltr<Kontrahent>
    {
        private KeyValuePair<string, string> selectedSortBy;

        public WszyscyKontrahenciViewModel()
            : base("All Kontrahent")
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

        public IQueryable<Kontrahent> QueryStatement { get; set; }

        public ObservableCollection<KeyValuePair<string, string>> SortBy =>
            new()
            {
                new KeyValuePair<string, string>("IdKontrahenta", "Id Kontrahenta"),
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

        public override IQueryable<Kontrahent> GetQueryStatement()
        {
            if (!IsFiltrAndSortPanelVisible)
            {
                return GetMainQueryStatement();
            }

            return QueryStatement;
        }

        private IQueryable<Kontrahent> GetMainQueryStatement()
        {
            return DbEntities.KontrahentDbSet.Select(kontrahent =>
                new Kontrahent
                {
                    IdKontrahenta = kontrahent.IdKontrahenta,
                    Kod = kontrahent.Kod,
                    Nazwa = kontrahent.Nazwa,
                    Nip = kontrahent.Nip,
                    IdStatusu = kontrahent.IdStatusu,
                    CreateDate = kontrahent.CreateDate
                });
        }

        private IQueryable<Kontrahent> GetTextSearchQueryStatement()
        {
            IQueryable<Kontrahent> query = GetMainQueryStatement();

            return query.Where(kontrahent =>
                (!string.IsNullOrEmpty(kontrahent.Kod) && kontrahent.Kod.Contains(SearchContext)) ||
                (!string.IsNullOrEmpty(kontrahent.Nazwa) && kontrahent.Nazwa.Contains(SearchContext)) ||
                (!string.IsNullOrEmpty(kontrahent.Nip) && kontrahent.Nip.Contains(SearchContext)));
        }

        private IQueryable<Kontrahent> GetDateRangeQueryStatement()
        {
            IQueryable<Kontrahent> query = GetMainQueryStatement();

            return query.Where(kontrahent =>
                (CreateDataForm == default || kontrahent.CreateDate >= CreateDataForm) &&
                (CreateDataTo == default || kontrahent.CreateDate <= CreateDataTo));
        }

        private IQueryable<Kontrahent> GetSortedQueryStatement(string sortBy)
        {
            IQueryable<Kontrahent> query = GetMainQueryStatement();

            switch (sortBy)
            {
                case "IdKontrahenta":
                    query = query.OrderBy(k => k.IdKontrahenta);
                    break;
                case "Kod":
                    query = query.OrderBy(k => k.Kod);
                    break;
                case "Nazwa":
                    query = query.OrderBy(k => k.Nazwa);
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
