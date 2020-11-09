using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.Layouts
{
    [ContentProperty("LayoutContent")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScannableLayout
    {
        public static readonly BindableProperty LayoutContentProperty = BindableProperty.Create(nameof(LayoutContent), typeof(View), typeof(ScannableLayout));

        public ScannableLayout()
        {
            InitializeComponent();
        }
        public  View LayoutContent
        {
            get => (View)GetValue(LayoutContentProperty);
            set => SetValue(LayoutContentProperty, value);
        }
    }
}