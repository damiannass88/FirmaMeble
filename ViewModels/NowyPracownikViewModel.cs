namespace FirmaMeble.ViewModels
{
    using System.Collections.ObjectModel;
    using Abstracts;
    using Data.Models;

    public class NowyPracownikViewModel : JedenViewModel<Pracownik>
    {
        public NowyPracownikViewModel()
            : base("Pracownik")
        {
            Item = new Pracownik
            {
                Umowy = new ObservableCollection<Umowa>(DbEntities.UmowaDbSet)
            };
        }

        public string Imie
        {
            get => Item.Imie;

            set
            {
                if (Item.Imie != value)
                {
                    Item.Imie = value;
                    OnPropertyChanged(() => Imie);
                }
            }
        }

        public string Nazwisko
        {
            get => Item.Nazwisko;

            set
            {
                if (Item.Nazwisko != value)
                {
                    Item.Nazwisko = value;
                    OnPropertyChanged(() => Nazwisko);
                }
            }
        }

        public string Stanowisko
        {
            get => Item.Stanowisko;

            set
            {
                if (Item.Stanowisko != value)
                {
                    Item.Stanowisko = value;
                    OnPropertyChanged(() => Stanowisko);
                }
            }
        }

        public int IdAdresu
        {
            get => Item.IdAdresu;

            set
            {
                if (Item.IdAdresu != value)
                {
                    Item.IdAdresu = value;
                    OnPropertyChanged(() => IdAdresu);
                }
            }
        }

        public IQueryable<Adres> AdresyComboBoxItems =>
        (
            from adres in DbEntities.AdresDbSet
            select adres
        ).AsQueryable();

        public DateTime DataZatrudnienia
        {
            get => Item.DataZatrudnienia;

            set
            {
                if (Item.DataZatrudnienia != value)
                {
                    Item.DataZatrudnienia = value;
                    OnPropertyChanged(() => DataZatrudnienia);
                }
            }
        }

        public ObservableCollection<Umowa> Umowy
        {
            get => new(Item.Umowy);
            set
            {
                if (Item.Umowy != value)
                {
                    Item.Umowy = value;
                    OnPropertyChanged(() => Umowy);
                }
            }
        }

        public void DodajUmowe(Umowa umowa)
        {
            if (umowa != null && !Item.Umowy.Contains(umowa))
            {
                Item.Umowy.Add(umowa);
                OnPropertyChanged(() => Umowy);
            }
        }

        public void UsunUmowe(Umowa umowa)
        {
            if (umowa != null && Item.Umowy.Contains(umowa))
            {
                Item.Umowy.Remove(umowa);
                OnPropertyChanged(() => Umowy);
            }
        }
    }
}
