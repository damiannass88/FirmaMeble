namespace FirmaMeble.ViewModels
{
    using System.Windows.Input;
    using Base;
    using Commands;
    using Data.DbContexts;

    internal class StatystykaViewModel : WorkspaceViewModel
    {
        protected readonly DataBaseEntities DbEntities;

        //private ObservableCollection<T> list;

        protected StatystykaViewModel()
        {
            TabHeaderName = "Statystyka";
            DbEntities = new DataBaseEntities();
            //LoadContext();
        }

        public ICommand LoadCommand => new RelayCommand(LoadContext);

        public ICommand RefreshCommand => new RelayCommand(LoadContext);

        //public ObservableCollection<T> List
        //{
        //    get => list;

        //    set
        //    {
        //        list = value;
        //        OnPropertyChanged(() => List);
        //    }
        //}

        private void LoadContext()
        {
            //TryLoadDataContext(GetQueryStatement());
        }

        //public abstract IQueryable<T> GetQueryStatement();

        //public virtual void TryLoadDataContext(IQueryable<T> listStatement)
        //{
        //    try
        //    {
        //        List<T> collection = listStatement.ToList();

        //        if (collection.Any())
        //        {
        //            List = new ObservableCollection<T>(collection);
        //        }
        //        else
        //        {
        //            MessageBox.Show("Brak Records!", "Komunikat");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Could not load View! \n\n Error: \n" + ex, "Błąd ładowania danych!");
        //        List = new ObservableCollection<T>();
        //    }
        //}
    }
}
