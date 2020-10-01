using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.Layouts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Section
    {
        public Section()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(Section));

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }
    }
}