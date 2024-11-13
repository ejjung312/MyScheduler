using ForSuccess.State.Navigators;

namespace ForSuccess.ViewModels
{
    public class ViewModelFactory
    {
        private readonly CreateViewModel<LoginViewModel> _createLoginViewModel;

        public ViewModelFactory(CreateViewModel<LoginViewModel> createLoginViewModel)
        {
            _createLoginViewModel = createLoginViewModel;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Login:
                    return _createLoginViewModel();
                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType");
            }
        }
    }
}
