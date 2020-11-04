using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.Separators
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LabelledDivider
    {
        public static readonly BindableProperty LabelProperty = BindableProperty.Create(nameof(Label), typeof(string), typeof(LabelledDivider));

        public string Label
        {
            get => (string) GetValue(LabelProperty); 
            set => SetValue(LabelProperty, value);
        }
        public LabelledDivider()
        {
            InitializeComponent();
        }
    }
}