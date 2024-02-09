namespace FirmaMeble.ViewModels.Base
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    internal interface ISortAndFiltr<T> where T : class
    {
        ICommand FireFiltrByTextCommand { get; }
        
        ICommand FireFiltrByDateCommand { get; }

        DateTime CreateDataTo { get; set; }

        DateTime CreateDataForm { get; set; }

        string SearchContext { get; set; }

        int SelectedSort { get; set; }

        ObservableCollection<KeyValuePair<string, string>> SortBy { get; }
        
        IQueryable<T> QueryStatement { get; set; }
    }
}
