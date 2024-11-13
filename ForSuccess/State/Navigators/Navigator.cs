using ForSuccess.ViewModels;

namespace ForSuccess.State.Navigators
{
    public class Navigator : INavigator
    {
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel?.Dispose();

                _currentViewModel = value;
                // 이벤트 호출
                StateChanged?.Invoke();
            }
        }

        public event Action StateChanged;
    }
}
