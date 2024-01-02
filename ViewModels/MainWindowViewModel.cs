namespace FirmaMeble.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Windows.Data;
    using System.Windows.Input;
    using FirmaMeble.Helpers;

    public class MainWindowViewModel : BaseViewModel
    {
        public ICommand TowarCommand
        {
            get
            {
                //komenda wy....
                return new BaseCommand(CreateTowar);
            }
        }

        public ICommand TowaryCommand
        {
            get
            {
                return new BaseCommand(ShowAllTowar);
            }
        }

        private ReadOnlyCollection<CommandViewModel> _Commands;

        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get
            {
                if (_Commands == null)
                {
                    List<CommandViewModel> cmds = CreateCommands();
                    //i ...
                    _Commands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }

                return _Commands;
            }
        }

        private List<CommandViewModel> CreateCommands()
        {
            //tworze....
            return new List<CommandViewModel>
            {
                //tu decyduje 
                new CommandViewModel("Towar",new BaseCommand(CreateTowar)),
                new CommandViewModel("Towary",new BaseCommand(ShowAllTowar)),
                new CommandViewModel("Pracownik",new BaseCommand(CreatePracownik)),
                new CommandViewModel("Pracownicy",new BaseCommand(ShowAllPracownicy)),
                new CommandViewModel("Faktura",new BaseCommand(CreateFaktura)),
                new CommandViewModel("Faktury",new BaseCommand(ShowAllFaktury)),
            };
        }

        private ObservableCollection<WorkspaceViewModel> _Workspaces;

        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (_Workspaces == null)
                {
                    _Workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _Workspaces.CollectionChanged += this.onWorkspacesChanged;
                }

                return _Workspaces;
            }
        }

        private void onWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.onWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.onWorkspaceRequestClose;
        }

        private void onWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            //workspace.Dispos();
            this.Workspaces.Remove(workspace);
        }

        private void CreateTowar()
        {
            //1. Naj...
            NowyTowarViewModel workspace = new NowyTowarViewModel();
            //2. 
            Workspaces.Add(workspace);
            //3. 
            SetActiveWorkspace(workspace);
        }

        private void CreatePracownik()
        {
            NowyPracownikViewModel workspace = new NowyPracownikViewModel();
            Workspaces.Add(workspace);
            SetActiveWorkspace(workspace);
        }

        private void CreateFaktura()
        {
            NowaFakturaViewModel workspace = new NowaFakturaViewModel();
            Workspaces.Add(workspace);
            SetActiveWorkspace(workspace);
        }


        private void ShowAllTowar()
        {
            WszystkieTowaryViewModel workspace = Workspaces.FirstOrDefault(vm => vm is WszystkieTowaryViewModel)
                as WszystkieTowaryViewModel;
            //Jeżeli takiej zakładki brak
            if (workspace == null)
            {
                //to tworze nową
                workspace = new WszystkieTowaryViewModel();
                //i dodaje ją do kolekcji zakładek
                Workspaces.Add(workspace);
            }

            SetActiveWorkspace(workspace);
        }

        private void ShowAllPracownicy()
        {
            WszyscyPracownicyViewModel workspace = Workspaces.FirstOrDefault(vm => vm is WszyscyPracownicyViewModel)
                 as WszyscyPracownicyViewModel;
            if (workspace == null)
            {
                workspace = new WszyscyPracownicyViewModel();
                Workspaces.Add(workspace);
            }

            SetActiveWorkspace(workspace);
        }

        private void ShowAllFaktury()
        {
            WszystkieFakturyViewModel workspace = Workspaces.FirstOrDefault(vm => vm is WszystkieFakturyViewModel)
                 as WszystkieFakturyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieFakturyViewModel();
                Workspaces.Add(workspace);
            }

            SetActiveWorkspace(workspace);
        }

        private void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }
    }
}
