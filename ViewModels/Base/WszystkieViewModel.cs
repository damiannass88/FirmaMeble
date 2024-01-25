namespace FirmaMeble.ViewModels.Base
{
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Input;
    using Commands;
    using Data.DbContexts;

    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public abstract class WszystkieViewModel<T> : WorkspaceViewModel
    {
        protected readonly DataBaseEntities DbEntities;

        private ObservableCollection<T> list;

        protected WszystkieViewModel(string tabHeaderName)
        {
            TabHeaderName = tabHeaderName;
            DbEntities = new DataBaseEntities();
            LoadContext();
        }

        public ICommand LoadCommand => new RelayCommand(LoadContext);

        public ICommand RefreshCommand => new RelayCommand(LoadContext);

        public ObservableCollection<T> List
        {
            get => list;

            set
            {
                list = value;
                OnPropertyChanged(() => List);
            }
        }

        private void LoadContext()
        {
            TryLoadDataContext(GetQueryStatement());
        }

        public abstract IQueryable<T> GetQueryStatement();

        public virtual void TryLoadDataContext(IQueryable<T> listStatement)
        {
            try
            {
                List<T> collection = listStatement.ToList();
                
                if (collection.Any())
                {
                    List = new ObservableCollection<T>(collection);
                }
                else
                {
                    MessageBox.Show("Brak Records!", "Komunikat");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load View! \n\n Error: \n" + ex, "Błąd ładowania danych!");
                List = new ObservableCollection<T>();
            }
        }
    }
}
