using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.Layouts
{
    [ContentProperty("LayoutContent")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScannableLayout
    {
        public static readonly BindableProperty LayoutContentProperty =
            BindableProperty.Create(nameof(LayoutContent), typeof(View), typeof(ScannableLayout));

        public static readonly BindableProperty ScanButtonCommandProperty =
            BindableProperty.Create(nameof(ScanButtonCommand), typeof(ICommand), typeof(ScannableLayout));

        public ScannableLayout()
        {
            InitializeComponent();
        }

        public  View LayoutContent
        {
            get => (View)GetValue(LayoutContentProperty);
            set => SetValue(LayoutContentProperty, value);
        }
        public ICommand ScanButtonCommand
        {
            get => (ICommand)GetValue(ScanButtonCommandProperty);
            set => SetValue(ScanButtonCommandProperty, value);
        }
    }
}