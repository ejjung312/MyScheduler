using System.ComponentModel;

namespace ForSuccess.ViewModels
{
    /*
     * delegate => 메서드 참조를 저장하고 실행할 수 있는 형식. 메서드를 변수처럼 전달하거나 저장
     * TViewModel => 제네릭 타입 매개변수.
     * where TViewModel : ViewModelBase => TViewModel은 반드시 ViewModelBase나 파생클래스에서만 사용 가능
     */
    public delegate TViewModel CreateViewModel<TViewModel>() where TViewModel : ViewModelBase;

    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // virtual 키워드를 사용하여 메서드가 재정의 가능하도록
        public virtual void Dispose() { }
    }
}
