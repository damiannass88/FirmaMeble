namespace FirmaMeble.ViewModels
{
    using System.Windows.Input;
    using FirmaMeble.Data.DbContexts;
    using FirmaMeble.Helpers;

    public class JedenViewModel<T> : WorkspaceViewModel
    {
        //cała BD
        protected FakturyEntities fakturyEntities;
        //dodawany obiekt
        protected T item;
        private BaseCommand _SaveAndCloseCommand;

        //ta komenda bedzie podpieta pod przycisk Zapisz i Zamknik
        public ICommand SaveAndCloseCommand
        {
            get
            {
                if (_SaveAndCloseCommand == null)
                    //kom....
                    _SaveAndCloseCommand = new BaseCommand(SaveAndClose);
                return _SaveAndCloseCommand;
            }
        }

        public JedenViewModel(string displayName)
        {
            base.DisplayName = displayName;
            fakturyEntities = new FakturyEntities();
        }

        //funkcja zapisuje nowy towar do bd
        public void Save()
        {
            //dodanie do lakalnej kolekcji
            fakturyEntities.Add(item);
            //zapisujemy do bazy danych
            fakturyEntities.SaveChanges();

        }

        private void SaveAndClose()
        {
            //zaisujemy nowy obiekt
            Save();
            //zamykamy zakładke
            OnRequestClose();
        }
    }
}
