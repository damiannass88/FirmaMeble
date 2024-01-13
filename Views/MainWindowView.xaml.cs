namespace FirmaMeble.Views
{
    using System.Windows;
    using System.Windows.Input;

    public partial class MainWindowView : Window
    {
        public MainWindowView()
        {
            InitializeComponent();
        }

        private void Window_DragMove(object sender, MouseButtonEventArgs e)
        {
            ViewMainWindow.Cursor = Cursors.Hand;

            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }

            if (e.ButtonState == MouseButtonState.Released)
            {
                ViewMainWindow.Cursor = Cursors.Arrow;
            }
        }

        private void CloseAppButton(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void MinimizeAppButton(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
