using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Zoo.ViewModels;

namespace Zoo.Commands
{
    public class UpdateViewCommand : ICommand
    {
        private WelcomeWindowVM viewModel;
        public UpdateViewCommand(WelcomeWindowVM viewModel)
        {
            this.viewModel = viewModel;
        }
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            
            if (parameter.ToString() == "Animals")
            {
                viewModel.SelectedViewModel = new AnimalsWindowVM();
            }
            else if (parameter.ToString() == "Events")
            {
                viewModel.SelectedViewModel = new EventsWindowVM();
            }
            else if (parameter.ToString() == "Tickets")
            {
                viewModel.SelectedViewModel = new TicketsWindowVM();
            }
        }
    }
}
