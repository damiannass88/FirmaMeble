﻿namespace FirmaMeble.ViewModels
{
    using System.Windows.Input;

    public class CommandViewModel : BaseViewModel
    {
        public string DisplayAsideName { get; set; }

        public ICommand Command { get; set; }

        public CommandViewModel(string displayAsideName, ICommand command)
        {
            DisplayAsideName = displayAsideName;
            Command = command;
        }
    }
}
