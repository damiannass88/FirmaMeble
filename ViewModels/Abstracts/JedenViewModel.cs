namespace FirmaMeble.ViewModels.Abstracts
{
    using System.Windows.Input;
    using Commands;
    using Data.DbContexts;

    public class JedenViewModel<T> : WorkspaceViewModel
    {
        protected DataBaseEntities DbEntities;

        protected T Item;
        private RelayCommand saveAndCloseCommand;

        public JedenViewModel(string tabHeaderName)
        {
            TabHeaderName = tabHeaderName;
            DbEntities = new DataBaseEntities();
        }

        public ICommand SaveAndCloseCommand
        {
            get
            {
                saveAndCloseCommand = new RelayCommand(SaveAndClose);
                return saveAndCloseCommand;
            }
        }

        public void Save()
        {
            if (Item == null)
            {
                return;
            }

            DbEntities.Add(Item);
            DbEntities.SaveChanges();
        }

        private void SaveAndClose()
        {
            Save();
            OnRequestClose();
        }
    }
}
