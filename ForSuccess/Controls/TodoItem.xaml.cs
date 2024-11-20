using FontAwesome6;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ForSuccess.Controls
{
    /// <summary>
    /// TodoItem.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TodoItem : UserControl
    {
        public TodoItem()
        {
            InitializeComponent();
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(TodoItem));

        public SolidColorBrush Color
        {
            get { return (SolidColorBrush)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        public static readonly DependencyProperty ColorProperty = DependencyProperty.Register("Color", typeof(SolidColorBrush), typeof(TodoItem));

        public EFontAwesomeIcon Icon
        {
            get { return (EFontAwesomeIcon)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(EFontAwesomeIcon), typeof(TodoItem));
    }
}
