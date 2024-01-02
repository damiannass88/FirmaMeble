namespace FirmaMeble.ViewModels
{
    using System.Windows.Input;

    public class CommandViewModel : BaseViewModel
    {
        //ka...
        public string DisplayName { get; set; }

        public ICommand Command { get; set; }

        public CommandViewModel(string displayName, ICommand command)
        {
            DisplayName = displayName;
            Command = command;
        }
    }
}
