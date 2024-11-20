using ForSuccess.ViewModels;

namespace ForSuccess.State.Navigators
{
    public enum ViewType
    {
        Login,
        Home
    }

    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }

        // 이벤트가 발생했을 때 구독자들에게 알림
        event Action StateChanged;
    }
}
