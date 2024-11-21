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

                    updateSelectedDate();
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

        private int _currentYear;
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

		private int _currentMonth;
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

        private int _currentDay;
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
		public ICommand ChangeYearCommand { get; }

        public HomeViewModel()
        {
            DisplayDate = DateTime.Today;
            SelectedDate = DisplayDate;

            CurrentYear = SelectedDate.Year;
            CurrentMonth = SelectedDate.Month;
            CurrentDay = SelectedDate.Day;

            CurrentMonthEng = getDateEng("MMMM", SelectedDate);
            CurrentDayEng = getDateEng("dddd", SelectedDate);

            YearButtons = new ObservableCollection<YearButton>();

            ChangeYearCommand = new ChangeYearCommand(this);
            ChangeMonthCommand = new ChangeMonthCommand(this);

            CreateYearCommand = new CreateYearCommand(this);
			CreateYearCommand.Execute(null);
        }

        public string getDateEng(string format, DateTime d)
        {
            return d.ToString(format, new CultureInfo("en-US"));
        }

        public void updateSelectedDate()
        {
            CurrentYear = SelectedDate.Year;
            CurrentMonth = SelectedDate.Month;
            CurrentDay = SelectedDate.Day;

            CurrentMonthEng = getDateEng("MMMM", SelectedDate);
            CurrentDayEng = getDateEng("dddd", SelectedDate);
        }

        public void updateDisplayDate()
        {
            CurrentYear = DisplayDate.Year;
            CurrentMonth = DisplayDate.Month;
            CurrentDay = DisplayDate.Day;
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
