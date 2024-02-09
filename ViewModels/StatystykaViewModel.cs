namespace FirmaMeble.ViewModels
{
    using System.Globalization;
    using System.Windows.Input;
    using Base;
    using Commands;
    using Data.BusinessLogic;

    public class StatystykaViewModel : WorkspaceViewModel
    {
        public StatystykaViewModel()
        {
            TabHeaderName = "Statystyka";
            DateFrom = DateTime.Today;
            DateTo = DateTime.Today;
        }

        public ICommand GetAverageEmployeeAgeCommand => new RelayCommand(GetAverageEmployeeAge);
        
        public ICommand GetLiczbaPracownikowCommand => new RelayCommand(GetLiczbaPracownikowZatrudnionychOdDaty);
        
        public ICommand GetYoungestPracownikCommand => new RelayCommand(GetYoungestPracownik);
        
        public ICommand GetOldestPracownikCommand => new RelayCommand(GetOldestPracownik);
        
        public ICommand GetProcentPracownikowWithEmailCommand => new RelayCommand(GetProcentPracownikowWithEmail);

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public string StatisticResult { get; set; }

        private void GetAverageEmployeeAge()
        {
            double averageDaysAge = DataStatistics.AverageWiekPracownikowOdDaty(DateFrom, DateTo);
            double averageAge = averageDaysAge / 365.25;
            StatisticResult = averageAge.ToString("F2", CultureInfo.InvariantCulture) + " lat";
            FireUpdatedStatisticResult();
        }
        
        private void GetLiczbaPracownikowZatrudnionychOdDaty()
        {
            double employeeCount = DataStatistics.LiczbaPracownikowZatrudnionychOdDaty(DateFrom, DateTo);
            StatisticResult = employeeCount.ToString(CultureInfo.InvariantCulture) + " pracowników";
            FireUpdatedStatisticResult();
        }
        
        private void GetYoungestPracownik()
        {
            double employeeAge = DataStatistics.YoungestPracownik();
            StatisticResult = employeeAge.ToString("F2", CultureInfo.InvariantCulture) + " pracownik Najstarszy";
            FireUpdatedStatisticResult();
        }
        
        private void GetOldestPracownik()
        {
            double employeeAge = DataStatistics.OldestPracownik();
            StatisticResult = employeeAge.ToString("F2", CultureInfo.InvariantCulture) + " pracownik Najmłodszy";
            FireUpdatedStatisticResult();
        }
        
        private void GetProcentPracownikowWithEmail()
        {
            double employeeAge = DataStatistics.ProcentPracownikowWithEmail();
            StatisticResult = employeeAge.ToString("F2", CultureInfo.InvariantCulture) + " %";
            FireUpdatedStatisticResult();
        }
        
        private void FireUpdatedStatisticResult()
        {
            OnPropertyChanged(() => StatisticResult);
        }
    }
}
