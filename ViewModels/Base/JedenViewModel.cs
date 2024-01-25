namespace FirmaMeble.ViewModels.Base
{
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Input;
    using Commands;
    using Data.DbContexts;

    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public abstract class JedenViewModel<T> : WorkspaceViewModel
    {
        protected DataBaseEntities DbEntities;

        protected T Item;

        protected JedenViewModel(string tabHeaderName)
        {
            TabHeaderName = tabHeaderName;
            DbEntities = new DataBaseEntities();
        }

        public ICommand SaveAndCloseCommand => new RelayCommand(SaveAndClose);

        public ICommand SaveAndClearFormCommand => new RelayCommand(SaveAndClearForm);

        public ICommand ClearEntireFormCommand => new RelayCommand(ClearForm);

        private void SaveAndClose()
        {
            if (!IsDateSetValid())
            {
                return;
            }

            Save();
            OnRequestClose();
        }

        private void Save()
        {
            try
            {
                if (Item == null)
                {
                    throw new InvalidOperationException("Item cannot be null");
                }

                DbEntities.Add(Item);
                DbEntities.SaveChanges();
                MessageBox.Show("Saved in Data source!", "Komunikat");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                MessageBox.Show(e.ToString(), "Błąd Sql!");
            }
        }

        private void SaveAndClearForm()
        {
            if (!IsDateSetValid())
            {
                return;
            }

            Save();
            ClearForm();
        }

        public abstract void ClearForm();

        public abstract bool IsDateSetValid();
    }
}
