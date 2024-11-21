using ForSuccess.Commands;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;

namespace ForSuccess.ViewModels
{
    public class HomeViewModel : ViewModelBase
	{
        private DateTime _selectedDate;
        private DateTime _displayDate;

        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                if (_selectedDate != value)
                {
                    _selectedDate = value;
                    OnPropertyChanged(nameof(SelectedDate));
                }
            }
        }

        public DateTime DisplayDate
        {
            get => _displayDate;
            set
            {
                if (_displayDate != value)
                {
                    _displayDate = value;
                    OnPropertyChanged(nameof(DisplayDate));
                }
            }
        }

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

        private int _currentDay = DateTime.Now.Day;
        public int CurrentDay
        {
            get
            {
                return _currentDay;
            }
            set
            {
                _currentDay = value;
                OnPropertyChanged(nameof(CurrentDay));
            }
        }

        private string _currentMonthEng;
        public string CurrentMonthEng
        {
            get
            {
                return _currentMonthEng;
            }
            set
            {
                _currentMonthEng = value;
                OnPropertyChanged(nameof(CurrentMonthEng));
            }
        }

        private string _currentDayEng;
        public string CurrentDayEng
        {
            get
            {
                return _currentDayEng;
            }
            set
            {
                _currentDayEng = value;
                OnPropertyChanged(nameof(CurrentDayEng));
            }
        }

        public ObservableCollection<YearButton> YearButtons { get; set; }
		public ICommand CreateYearCommand { get; }
		public ICommand ChangeMonthCommand { get; }

        public HomeViewModel()
        {
            SelectedDate = DateTime.Today;
            DisplayDate = DateTime.Today;

            CurrentMonthEng = getDateEng("MMMM", DateTime.Now);
            CurrentDayEng = getDateEng("dddd", DateTime.Now);

            YearButtons = new ObservableCollection<YearButton>();

            ChangeMonthCommand = new ChangeMonthCommand(this);

            CreateYearCommand = new CreateYearCommand(this);
			CreateYearCommand.Execute(null);
        }

        public string getDateEng(string format, DateTime d)
        {
            return d.ToString(format, new CultureInfo("en-US"));
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
