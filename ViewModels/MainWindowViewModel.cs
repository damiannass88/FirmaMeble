// ReSharper disable UnusedMember.Global
namespace FirmaMeble.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Windows.Data;
    using System.Windows.Input;
    using Base;
    using Commands;

    public class MainWindowViewModel : BaseViewModel
    {
        private static readonly MainWindowViewModel Instance = new();

        public MainWindowViewModel()
        {
            WorkspacesTabViewsCollection = new ObservableCollection<WorkspaceViewModel>();
            WorkspacesTabViewsCollection.CollectionChanged += OnWorkspacesTabViewsCollectionChanged;
        }

        public ICommand CreateTowarCommand => new RelayCommand(CreateTowar);

        public ICommand ShowAllTowaryCommand => new RelayCommand(ShowAllTowar);

        public ICommand CreatePracownikCommand => new RelayCommand(CreatePracownik);

        public ICommand ShowAllPracownicyCommand => new RelayCommand(ShowAllPracownicy);

        public ICommand CreateFakturaCommand => new RelayCommand(CreateFaktura);

        public ICommand ShowAllFakturyCommand => new RelayCommand(ShowAllFaktury);
        
        public ICommand ShowUmowyPracownikowCommand => new RelayCommand(ShowAllUmowyPracownikow);

        public ReadOnlyCollection<CommandViewModel> GetAvailableCommands => new(CreateCommands());

        public ObservableCollection<WorkspaceViewModel> WorkspacesTabViewsCollection { get; set; }

        public static MainWindowViewModel GetInstance()
        {
            return Instance;
        }

        private List<CommandViewModel> CreateCommands()
        {
            return
            [
                new CommandViewModel("Nowy Towar", new RelayCommand(CreateTowar)),
                new CommandViewModel("All Towary", new RelayCommand(ShowAllTowar)),
                new CommandViewModel("Nowy Pracownik", new RelayCommand(CreatePracownik)),
                new CommandViewModel("All Pracownicy", new RelayCommand(ShowAllPracownicy)),
                new CommandViewModel("Nowa Faktura", new RelayCommand(CreateFaktura)),
                new CommandViewModel("All Faktury", new RelayCommand(ShowAllFaktury)),
                new CommandViewModel("Umowy Pracowników", new RelayCommand(ShowAllUmowyPracownikow)),
                new CommandViewModel("Nowy Kontrahent", new RelayCommand(CreateKontrahent)),
                new CommandViewModel("All Kontrahent", new RelayCommand(ShowAllKontrahent))
            ];
        }

        private void OnWorkspacesTabViewsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
            {
                foreach (WorkspaceViewModel workspace in e.NewItems)
                {
                    workspace.RequestClose += OnWorkspaceRequestClose;
                }
            }

            if (e.OldItems != null && e.OldItems.Count != 0)
            {
                foreach (WorkspaceViewModel workspace in e.OldItems)
                {
                    workspace.RequestClose -= OnWorkspaceRequestClose;
                }
            }
        }

        private void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            if (sender is WorkspaceViewModel workspace)
            {
                WorkspacesTabViewsCollection.Remove(workspace);
            }
        }

        private void CreateTowar()
        {
            NowyTowarViewModel workspace = new();
            WorkspacesTabViewsCollection.Add(workspace);
            SetActiveWorkspace(workspace);
        }

        private void CreatePracownik()
        {
            NowyPracownikViewModel workspace = new();
            WorkspacesTabViewsCollection.Add(workspace);
            SetActiveWorkspace(workspace);
        }

        private void CreateFaktura()
        {
            NowaFakturaViewModel workspace = new();
            WorkspacesTabViewsCollection.Add(workspace);
            SetActiveWorkspace(workspace);
        }

        private void ShowAllTowar()
        {
            if (WorkspacesTabViewsCollection.FirstOrDefault(vm => vm is WszystkieTowaryViewModel) is not
                WszystkieTowaryViewModel workspace)
            {
                workspace = new WszystkieTowaryViewModel();
                WorkspacesTabViewsCollection.Add(workspace);
            }

            SetActiveWorkspace(workspace);
        }

        private void ShowAllPracownicy()
        {
            WszyscyPracownicyViewModel? workspace =
                WorkspacesTabViewsCollection.FirstOrDefault(vm => vm is WszyscyPracownicyViewModel)
                    as WszyscyPracownicyViewModel;
            if (workspace == null)
            {
                workspace = new WszyscyPracownicyViewModel();
                WorkspacesTabViewsCollection.Add(workspace);
            }

            SetActiveWorkspace(workspace);
        }

        private void ShowAllFaktury()
        {
            if (WorkspacesTabViewsCollection.FirstOrDefault(vm => vm is WszystkieFakturyViewModel) is not
                WszystkieFakturyViewModel workspace)
            {
                workspace = new WszystkieFakturyViewModel();
                WorkspacesTabViewsCollection.Add(workspace);
            }

            SetActiveWorkspace(workspace);
        }

        private void ShowAllUmowyPracownikow()
        {
            if (WorkspacesTabViewsCollection.FirstOrDefault(vm => vm is PracownicyUmowyViewModel) is not
                PracownicyUmowyViewModel workspace)
            {
                workspace = new PracownicyUmowyViewModel();
                WorkspacesTabViewsCollection.Add(workspace);
            }

            SetActiveWorkspace(workspace);
        }

        private void CreateKontrahent()
        {
            NowyKontrahentViewModel workspace = new();
            WorkspacesTabViewsCollection.Add(workspace);
            SetActiveWorkspace(workspace);
        }

        private void ShowAllKontrahent()
        {
            WszyscyKontrahenciViewModel? workspace =
                WorkspacesTabViewsCollection.FirstOrDefault(vm => vm is WszyscyKontrahenciViewModel)
                    as WszyscyKontrahenciViewModel;
            if (workspace == null)
            {
                workspace = new WszyscyKontrahenciViewModel();
                WorkspacesTabViewsCollection.Add(workspace);
            }

            SetActiveWorkspace(workspace);
        }

        private void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            //Debug.Assert(WorkspacesTabViewsCollection.Contains(workspace));
            ICollectionView? collectionView = CollectionViewSource.GetDefaultView(WorkspacesTabViewsCollection);
            collectionView?.MoveCurrentTo(workspace);
        }
    }
}
