namespace FirmaMeble.ViewModels.Abstracts
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Commands;
    using Data.DbContexts;

    public abstract class WszystkieViewModel<T> : WorkspaceViewModel
    {
        protected readonly DataBaseEntities DbEntities;

        private ObservableCollection<T> list;
        private RelayCommand loadCommand;

        protected WszystkieViewModel(string tabHeaderName)
        {
            TabHeaderName = tabHeaderName;
            DbEntities = new DataBaseEntities();
        }

        public ICommand LoadCommand
        {
            get
            {
                if (loadCommand == null)
                {
                    loadCommand = new RelayCommand(() =>
                    {
                        try
                        {
                            Load();
                        }
                        catch (Exception ex)
                        {
                            // Handle exception
                        }
                    });
                }

                return loadCommand;
            }
        }

        public ObservableCollection<T> List
        {
            get
            {
                if (!list.Any())
                {
                    Load();
                }

                return list;
            }

            set
            {
                list = value;
                OnPropertyChanged(() => List);
            }
        }

        public abstract void Load();
    }
}
