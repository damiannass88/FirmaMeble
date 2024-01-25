using FirmaMeble.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FirmaMeble.ViewModels
{
    using Base;
    using Data.Models;
    using System.Windows;

    public class NowaFakturaViewModel : JedenViewModel<Faktura>
    {
        public NowaFakturaViewModel()
            : base("Faktura")
        {
            Item = new Faktura();
        }

        public string? Numer
        {
            get => Item.Numer;

            set
            {
                if (Item.Numer != value)
                {
                    Item.Numer = value;
                    OnPropertyChanged(() => Numer);
                }
            }
        }

        public DateTime? DataWystawienia
        {
            get => Item.DataWystawienia;

            set
            {
                if (Item.DataWystawienia != value)
                {
                    Item.DataWystawienia = value;
                    OnPropertyChanged(() => DataWystawienia);
                }
            }
        }

        public int? IdKontrahenta
        {
            get => Item.IdKontrahenta;

            set
            {
                if (Item.IdKontrahenta != value)
                {
                    Item.IdKontrahenta = value;
                    OnPropertyChanged(() => IdKontrahenta);
                }
            }
        }

        public DateTime? TerminPlatnosci
        {
            get => Item.TerminPlatnosci;

            set
            {
                if (Item.TerminPlatnosci != value)
                {
                    Item.TerminPlatnosci = value;
                    OnPropertyChanged(() => TerminPlatnosci);
                }
            }
        }

        public int? IdSposobuPlatnosci
        {
            get => Item.IdSposobuPlatnosci;

            set
            {
                if (Item.IdSposobuPlatnosci != value)
                {
                    Item.IdSposobuPlatnosci = value;
                    OnPropertyChanged(() => IdSposobuPlatnosci);
                }
            }
        }

        public IQueryable<Kontrahent> KontrahenciComboBoxItems =>
        (
            from kontrahent in DbEntities.KontrahentDbSet
            select kontrahent
        ).ToList().AsQueryable();

        public IQueryable<SposobPlatnosci> SposobPlatnosciComboBoxItems =>
        (
            from sposobPlatnosci in DbEntities.SposobPlatnosciDbSet
            select sposobPlatnosci
        ).ToList().AsQueryable();



        //public ObservableCollection<Umowa> Umowy
        //{
        //    get => new(Item.Umowy);
        //    set
        //    {
        //        if (Item.Umowy != value)
        //        {
        //            Item.Umowy = value;
        //            OnPropertyChanged(() => Umowy);
        //        }
        //    }
        //}

        //public void DodajUmowe(Umowa umowa)
        //{
        //    if (umowa != null && !Item.Umowy.Contains(umowa))
        //    {
        //        Item.Umowy.Add(umowa);
        //        OnPropertyChanged(() => Umowy);
        //    }
        //}

        //public void UsunUmowe(Umowa umowa)
        //{
        //    if (umowa != null && Item.Umowy.Contains(umowa))
        //    {
        //        Item.Umowy.Remove(umowa);
        //        OnPropertyChanged(() => Umowy);
        //    }
        //}


        public override void ClearForm()
        {
            MessageBox.Show("Cleared Form!", "Formularz");
        }

        public override bool IsDateSetValid()
        {
            throw new NotImplementedException();
        }
    }
}
