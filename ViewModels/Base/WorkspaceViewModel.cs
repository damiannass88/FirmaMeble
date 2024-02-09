namespace FirmaMeble.ViewModels.Base
{
    using System.Diagnostics.CodeAnalysis;
    using System.Windows.Input;
    using Commands;

    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class WorkspaceViewModel : BaseViewModel
    {
        public ICommand CloseCommand => new RelayCommand(OnRequestClose);
        public string? TabHeaderName { get; set; }

        public event EventHandler? RequestClose;

        protected void OnRequestClose()
        {
            EventHandler? handler = RequestClose;
            handler?.Invoke(this, EventArgs.Empty);
        }
    }
}
