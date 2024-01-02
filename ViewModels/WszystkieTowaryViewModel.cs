namespace FirmaMeble.ViewModels
{
    using System.Collections.ObjectModel;
    using FirmaMeble.Data.Repositories;

    public class WszystkieTowaryViewModel : WszystkieViewModel<Towar>
    {
        public WszystkieTowaryViewModel()
            : base("Towary")
        {
        }

        public override void load()
        {
            List = new ObservableCollection<Towar>
                (
                    //z bazy danych pobieram wszystkie towary
                    //tu bedzie zapytanie Linq, ....
                    fakturyEntities.Towars
                );
        }
    }
}
