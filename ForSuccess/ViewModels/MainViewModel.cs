namespace ForSuccess.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        private object _currentViewModel;
        public object CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public MainViewModel()
        {
            // 초기 ViewModel 설정
            CurrentViewModel = new LoginViewModel();
            //CurrentViewModel = new HomeViewModel();
        }
    }
}
