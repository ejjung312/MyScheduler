using ForSuccess.ViewModels;
using System.Windows.Input;

namespace ForSuccess.Commands
{
    public class CreateYearCommand : ICommand
    {
        private readonly HomeViewModel _homeViewModel;

        public CreateYearCommand(HomeViewModel homeViewModel)
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
            _homeViewModel.YearButtons.Clear();
            int CurrentYear = _homeViewModel.CurrentYear;

            for (int y = CurrentYear - 2; y <= CurrentYear + 2; y++)
            {
                YearButton yearButton = new YearButton
                {
                    Year = y,
                    Command = new ChangeYearCommand(_homeViewModel),
                };

                if (y == CurrentYear)
                {
                    yearButton.FontSize = 24;
                    yearButton.IsCurrentYear = true;
                }

                _homeViewModel.YearButtons.Add(yearButton);
            }
        }
    }
}
