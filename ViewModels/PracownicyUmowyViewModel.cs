namespace FirmaMeble.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Windows;
    using Base;
    using Data.Models;

    public class PracownicyUmowyViewModel : WszystkieViewModel<KeyAndValue>
    {
        private IQueryable<KeyAndValue> pracownicyComboBoxItems;

        private int selectedPracownik;

        public PracownicyUmowyViewModel()
            : base("All Umowy Prac")
        {
            TryLoadDataContext(GetQueryStatement());
        }

        public int SelectedPracownik
        {
            get => selectedPracownik;
            set
            {
                if (value != selectedPracownik)
                {
                    selectedPracownik = value;
                    LoadPracownikData();
                    OnPropertyChanged(() => SelectedPracownik);
                }
            }
        }

        public ObservableCollection<Umowa> UmowaView { get; set; }

        public ObservableCollection<Adres> AdresView { get; set; }

        public ObservableCollection<Pracownik> PracownikView { get; set; }

        public IQueryable<KeyAndValue> PracownicyComboBoxItems
        {
            get => pracownicyComboBoxItems;
            set
            {
                pracownicyComboBoxItems = value;
                OnPropertyChanged(() => PracownicyComboBoxItems);
            }
        }

        public sealed override IQueryable<KeyAndValue> GetQueryStatement()
        {
            return DbEntities.PracownikDbSet
                .Select(pracownik => new KeyAndValue
                {
                    Key = pracownik.IdPracownika,
                    Value = pracownik.Nazwisko
                });
        }

        public sealed override void TryLoadDataContext(IQueryable<KeyAndValue> listStatement)
        {
            try
            {
                PracownicyComboBoxItems = listStatement.ToList().AsQueryable();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load View! \n\nError:\n" + ex, "Błąd ładowania danych!");
            }
        }

        private void LoadPracownikData()
        {
            PracownikView = new ObservableCollection<Pracownik>(DbEntities.PracownikDbSet
                .Where(pracownik => pracownik.IdPracownika == SelectedPracownik)
                .Select(pracownik => new Pracownik
                {
                    Imie = pracownik.Imie,
                    DrugieImie = pracownik.DrugieImie,
                    Nazwisko = pracownik.Nazwisko,
                    MiejsceUrodzenia = pracownik.MiejsceUrodzenia,
                    ImieOjca = pracownik.ImieOjca,
                    ImieMatki = pracownik.ImieMatki,
                    Email = pracownik.Email,
                    Telefon = pracownik.Telefon,
                    Nip = pracownik.Nip,
                    Pesel = pracownik.Pesel,
                    Stanowisko = pracownik.Stanowisko
                }).ToList());
            OnPropertyChanged(() => PracownikView);

            Umowa? umowaView = DbEntities.PracownikDbSet
                .Where(pracownik => pracownik.IdPracownika == SelectedPracownik)
                .Select(pracownik => pracownik.Umowa)
                .FirstOrDefault();

            UmowaView = [umowaView];
            OnPropertyChanged(() => UmowaView);

            Adres? adresView = DbEntities.PracownikDbSet
                .Where(pracownik => pracownik.IdPracownika == SelectedPracownik)
                .Select(pracownik => pracownik.Adres)
                .FirstOrDefault();

            AdresView = [adresView];
            OnPropertyChanged(() => AdresView);
        }
    }
}
