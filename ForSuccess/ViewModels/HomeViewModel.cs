using ForSuccess.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ForSuccess.ViewModels
{
    public class HomeViewModel : ViewModelBase
	{
		private int _currentYear = DateTime.Now.Year;
		public int CurrentYear
		{
			get
			{
				return _currentYear;
			}
			set
			{
				_currentYear = value;
				OnPropertyChanged(nameof(CurrentYear));
			}
		}

		private int _currentMonth = DateTime.Now.Month;
		public int CurrentMonth
		{
			get
			{
				return _currentMonth;
			}
			set
			{
				_currentMonth = value;
				OnPropertyChanged(nameof(CurrentMonth));
			}
		}

		// 여기서 시작
		public DateTime SelectedDate { get; set; } = new DateTime(2024, 12, 25);
        public DateTime DisplayDate { get; set; } = new DateTime(2024, 12, 25);

        public ObservableCollection<YearButton> YearButtons { get; set; }
		public ICommand CreateYearCommand { get; }

        public HomeViewModel()
        {
			YearButtons = new ObservableCollection<YearButton>();
			CreateYearCommand = new CreateYearCommand(AddButtons);
        }

		private void AddButtons()
		{
            for (int y = CurrentYear - 2; y <= CurrentYear + 2; y++)
            {
                YearButton yearButton = new YearButton
                {
                    Year = y,
					Command = new ChangeYearCommand(this),
                };

                if (y == CurrentYear)
                {
                    yearButton.FontSize = 24;
					yearButton.IsCurrentYear = true;
                }

                YearButtons.Add(yearButton);
            }
        }
    }

	public class YearButton
	{
		public int FontSize { get; set; } = 20;
		public int Year { get; set; }

		public bool IsCurrentYear { get; set; } = false;

        public ICommand Command { get; set; }
    }
}
