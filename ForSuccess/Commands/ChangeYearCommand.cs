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
                _homeViewModel.CreateYearCommand.Execute(null);

                DateTime newDate = new DateTime(_homeViewModel.CurrentYear, _homeViewModel.CurrentMonth, _homeViewModel.CurrentDay);
                _homeViewModel.DisplayDate = newDate.AddYears(1);

                _homeViewModel.updateDisplayDate();
            } 
            else if (parameter is string)
            {
                string p = (string)parameter;
                DateTime newDate = new DateTime(_homeViewModel.CurrentYear, _homeViewModel.CurrentMonth, _homeViewModel.CurrentDay);

                if (p == "N")
                {
                    _homeViewModel.DisplayDate = newDate.AddYears(5);

                }
                else if (p == "P")
                {
                    _homeViewModel.DisplayDate = newDate.AddYears(-5);
                }

                _homeViewModel.updateDisplayDate();

                _homeViewModel.CreateYearCommand.Execute(null);
            }
        }
    }
}
