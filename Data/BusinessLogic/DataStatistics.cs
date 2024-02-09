namespace FirmaMeble.Data.BusinessLogic
{
    using System.Windows;
    using DbContexts;
    using Microsoft.EntityFrameworkCore;

    public static class DataStatistics
    {
        private static readonly DataBaseEntities DbContext = new();

        public static double AverageWiekPracownikowOdDaty(DateTime dateFrom, DateTime dateTo)
        {
            double averageWiekPracownikow;

            try
            {
                averageWiekPracownikow = DbContext.PracownikDbSet
                    .Where(p => p.DataUrodzenia >= dateFrom &&
                                p.DataUrodzenia <= dateTo)
                    .Average(p => EF.Functions.DateDiffDay(p.DataUrodzenia, DateTime.Now));
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data!");
                return 0;
            }

            return averageWiekPracownikow;
        }

        public static int LiczbaPracownikowZatrudnionychOdDaty(DateTime dateFrom, DateTime dateTo)
        {
            int liczbaPracownikowZatrudnionych;

            try
            {
                liczbaPracownikowZatrudnionych =
                    DbContext.PracownikDbSet.Count(p => p.CreateDate > dateFrom && p.CreateDate < dateTo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data!");
                return 0;
            }

            return liczbaPracownikowZatrudnionych;
        }

        public static double YoungestPracownik()
        {
            double youngestWiek;

            try
            {
                List<DateTime> dataUrodzeniaList = DbContext.PracownikDbSet
                    .Select(p => p.DataUrodzenia)
                    .ToList();

                youngestWiek = dataUrodzeniaList
                    .Min(p => (DateTime.Today - p).TotalDays / 365.25);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data!");
                return 0;
            }

            return youngestWiek;
        }

        public static double OldestPracownik()
        {
            double oldestWiek;

            try
            {
                List<DateTime> dataUrodzeniaList = DbContext.PracownikDbSet
                    .Select(p => p.DataUrodzenia)
                    .ToList();

                oldestWiek = dataUrodzeniaList
                    .Min(p => (DateTime.Today - p).TotalDays / 365.25);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data!");
                return 0;
            }

            return oldestWiek;
        }

        public static double ProcentPracownikowWithEmail()
        {
            double procentZEmail;

            try
            {
                procentZEmail = (double)DbContext.PracownikDbSet
                    .Count(p => !string.IsNullOrEmpty(p.Email)) / DbContext.PracownikDbSet.Count() * 100;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data!");
                return 0;
            }

            return procentZEmail;
        }
    }
}
