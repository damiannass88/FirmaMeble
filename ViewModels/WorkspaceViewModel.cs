namespace FirmaMeble.ViewModels
{
    using System.Windows.Input;
    using Commands;

    public class WorkspaceViewModel : BaseViewModel
    {
        private RelayCommand closeCommand;

        public string? TabHeaderName { get; set; }

        public ICommand CloseCommand
        {
            get
            {
                closeCommand = new RelayCommand(OnRequestClose);
                return closeCommand;
            }
        }

        public event EventHandler? RequestClose;

        protected void OnRequestClose()
        {
            EventHandler? handler = RequestClose;
            handler?.Invoke(this, EventArgs.Empty);
        }
    }
}
