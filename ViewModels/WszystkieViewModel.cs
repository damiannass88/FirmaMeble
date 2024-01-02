namespace FirmaMeble.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using FirmaMeble.Data.DbContexts;
    using FirmaMeble.Helpers;

    //
    public abstract class WszystkieViewModel<T> : WorkspaceViewModel
    {
        protected readonly FakturyEntities fakturyEntities;
        private BaseCommand _LoadCommand;

        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null)
                {
                    _LoadCommand = new BaseCommand(() => load());
                }

                return _LoadCommand;
            }
        }

        //tu ....
        private ObservableCollection<T> _List;

        public ObservableCollection<T> List
        {
            get
            {
                //jak lista....
                if (_List == null)
                {
                    load();
                }

                return _List;
            }

            set
            {
                _List = value;
                OnPropertyChanged(() => List);
            }
        }

        public WszystkieViewModel(string displayName)
        {
            base.DisplayName = displayName;//to jest ustawienie nazwy zkładki
            //tworze obiekt dostepowy do BD
            fakturyEntities = new FakturyEntities();
        }

        public abstract void load();
    }
}
