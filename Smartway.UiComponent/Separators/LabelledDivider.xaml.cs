using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.Separators
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LabelledDivider
    {
        public static readonly BindableProperty LabelProperty = BindableProperty.Create(nameof(Label), typeof(string), typeof(LabelledDivider));
        public static readonly BindableProperty ColorProperty = BindableProperty.Create(nameof(Color), typeof(string), typeof(LabelledDivider), "#E2E4F0");

        public string Label
        {
            get => (string) GetValue(LabelProperty); 
            set => SetValue(LabelProperty, value);
        }

        public string Color
        {
            get => (string) GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }

        public LabelledDivider()
        {
            InitializeComponent();
        }
    }
}