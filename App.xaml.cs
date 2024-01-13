namespace FirmaMeble
{
    using System.Windows;
    using ViewModels;
    using Views;

    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindowView window = new();
            window.DataContext = MainWindowViewModel.GetInstance();
            window.Show();
        }
    }
}
