using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class YesModalFooter : ContentView
    {
        public static readonly BindableProperty ApplyCommandProperty =
            BindableProperty.Create(nameof(ApplyCommand), typeof(ICommand), typeof(YesNoModalFooter));

        public ICommand ApplyCommand
        {
            get => (ICommand)GetValue(ApplyCommandProperty);
            set => SetValue(ApplyCommandProperty, value);
        }

        public YesModalFooter()
        {
            InitializeComponent();
        }
    }
}