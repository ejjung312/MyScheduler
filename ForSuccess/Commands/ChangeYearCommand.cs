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
                _homeViewModel.SelectedDate = _homeViewModel.DisplayDate;

                _homeViewModel.CurrentMonthEng = _homeViewModel.getDateEng("MMMM", _homeViewModel.DisplayDate);
                _homeViewModel.CurrentDayEng = _homeViewModel.getDateEng("dddd", _homeViewModel.DisplayDate);
            }
        }
    }
}
