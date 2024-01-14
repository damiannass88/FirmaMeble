using FirmaMeble.Data.Models;

namespace FirmaMeble.ViewModels
{
    using System.Collections.ObjectModel;
    using FirmaMeble.ViewModels.Abstracts;

    public class WszystkieTowaryViewModel : WszystkieViewModel<Towar>
    {
        public WszystkieTowaryViewModel()
            : base("Towary")
        {
        }

        public override void Load()
        {
            List = new ObservableCollection<Towar>
                (
                    //z bazy danych pobieram wszystkie towary
                    //tu bedzie zapytanie Linq, ....
                    DbEntities.TowarDbSet
                );
        }
    }
}
