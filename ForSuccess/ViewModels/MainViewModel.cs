using ForSuccess.Commands;
using ForSuccess.State.Navigators;
using System.Windows.Input;

namespace ForSuccess.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        private readonly INavigator _navigator;
        private readonly ViewModelFactory _viewModelFactory;

        public ViewModelBase CurrentViewModel => _navigator.CurrentViewModel;

        public ICommand UpdateCurrentViewModelCommand { get; }

        public MainViewModel(INavigator navigator, ViewModelFactory viewModelFactory)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;

            _navigator.StateChanged += Navigator_StateChanged;

            // 초기 ViewModel 설정
            //_navigator.CurrentViewModel = new LoginViewModel();
            //CurrentViewModel = new HomeViewModel();

            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, _viewModelFactory);
            UpdateCurrentViewModelCommand.Execute(ViewType.Login);
        }

        private void Navigator_StateChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
