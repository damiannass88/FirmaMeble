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
        private double dataGridHeight;
        private bool isFiltrAndSortPanelVisible;
        private const double DataGridHeightOnPanelExpanded = 740;
        private const double DataGridHeightOnPanelRetracted = 772;

        private ObservableCollection<T> list;

        protected WszystkieViewModel(string tabHeaderName)
        {
            TabHeaderName = tabHeaderName;
            DbEntities = new DataBaseEntities();
            DataGridHeight = DataGridHeightOnPanelRetracted;
            LoadContext();
        }

        public double DataGridHeight
        {
            get => dataGridHeight;
            set
            {
                dataGridHeight = value;
                OnPropertyChanged(() => DataGridHeight);
            }
        }

        public bool IsFiltrAndSortPanelVisible
        {
            get => isFiltrAndSortPanelVisible;
            set
            {
                if (value == isFiltrAndSortPanelVisible)
                {
                    return;
                }

                isFiltrAndSortPanelVisible = value;
                OnPropertyChanged(() => IsFiltrAndSortPanelVisible);
            }
        }

        public ICommand LoadCommand => new RelayCommand(LoadContext);

        public ICommand RefreshCommand => new RelayCommand(LoadContext);

        public ICommand ToggleFiltrSortPanelCommand => new RelayCommand(TogglePanelVisibility);

        public ObservableCollection<T> List
        {
            get => list;

            set
            {
                list = value;
                OnPropertyChanged(() => List);
            }
        }

        private void TogglePanelVisibility()
        {
            IsFiltrAndSortPanelVisible = !IsFiltrAndSortPanelVisible;
            AdjustDataGridHeight();
        }

        private void AdjustDataGridHeight()
        {
            DataGridHeight = IsFiltrAndSortPanelVisible
                ? DataGridHeightOnPanelExpanded
                : DataGridHeightOnPanelRetracted;
        }

        public void LoadContext()
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
                    OnPropertyChanged(() => List);
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
