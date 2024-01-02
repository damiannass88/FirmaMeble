namespace FirmaMeble.ViewModels
{
    using System.Windows.Input;
    using FirmaMeble.Helpers;

    //to jest VM
    //każda 
    public class WorkspaceViewModel : BaseViewModel
    {
        //kaz    
        public string DisplayName { get; set; }//to jest nazwa zakładki

        private BaseCommand _CloseCommand;

        public ICommand CloseCommand
        {
            get
            {
                if (_CloseCommand == null)
                    _CloseCommand = new BaseCommand(OnRequestClose);//komenada...
                return _CloseCommand;
            }
        }

        public event EventHandler RequestClose;

        protected void OnRequestClose()
        {
            EventHandler handler = this.RequestClose;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
    }
}
