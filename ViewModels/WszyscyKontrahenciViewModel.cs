namespace FirmaMeble.ViewModels
{
    using Base;
    using Data.Models;

    internal class WszyscyKontrahenciViewModel : WszystkieViewModel<Kontrahent>
    {
        public WszyscyKontrahenciViewModel()
            : base("All Kontrahent")
        {
        }

        public override IQueryable<Kontrahent> GetQueryStatement()
        {
            return DbEntities.KontrahentDbSet.Select(kontrahent =>
                new Kontrahent
                {
                    IdKontrahenta = kontrahent.IdKontrahenta,
                    Kod = kontrahent.Kod,
                    Nazwa = kontrahent.Nazwa,
                    Nip = kontrahent.Nip,
                    IdStatusu = kontrahent.IdStatusu
                });
        }
    }
}
