using ForSuccess.ViewModels;
using System.Windows.Input;

namespace ForSuccess.Commands
{
    public class ChangeYearCommand : ICommand
    {
        private readonly HomeViewModel _homeViewModel;

        public ChangeYearCommand(HomeViewModel homeViewModel)
        {
            _homeViewModel = homeViewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter is int)
            {
                _homeViewModel.CurrentYear = (int)parameter;
            }
        }
    }
}
