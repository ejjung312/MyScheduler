using ForSuccess.ViewModels;
using System.Windows.Input;

namespace ForSuccess.Commands
{
    internal class ChangeMonthCommand : ICommand
    {
        private readonly HomeViewModel _homeViewModel;

        public ChangeMonthCommand(HomeViewModel homeViewModel)
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
            if (parameter is string)
            {
                string p = (string)parameter;

                DateTime newDate = new DateTime(_homeViewModel.CurrentYear, _homeViewModel.CurrentMonth, _homeViewModel.CurrentDay);
                if (p == "N")
                {
                    _homeViewModel.DisplayDate = newDate.AddMonths(1);

                } else if (p == "P")
                {
                    _homeViewModel.DisplayDate = newDate.AddMonths(-1);
                }

                _homeViewModel.updateDisplayDate();

                if (newDate.Year != _homeViewModel.CurrentYear) _homeViewModel.CreateYearCommand.Execute(null);
            }
        }
    }
}
