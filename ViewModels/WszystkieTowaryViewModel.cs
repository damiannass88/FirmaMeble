namespace FirmaMeble.ViewModels
{
    using Base;
    using Data.Models;

    public class WszystkieTowaryViewModel : WszystkieViewModel<Towar>
    {
        public WszystkieTowaryViewModel()
            : base("All Towary")
        {
        }

        public override IQueryable<Towar> GetQueryStatement()
        {
            return from towar in
                    DbEntities.TowarDbSet
                select towar;
        }
    }
}
