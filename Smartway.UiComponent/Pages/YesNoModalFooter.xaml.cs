using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class YesNoModalFooter : ContentView
    {
        public static readonly BindableProperty ValidateCommandProperty =
            BindableProperty.Create(nameof(ValidateCommand), typeof(ICommand), typeof(YesNoModalFooter));

        public static readonly BindableProperty CancelCommandProperty =
            BindableProperty.Create(nameof(CancelCommand), typeof(ICommand), typeof(YesNoModalFooter));

        public ICommand ValidateCommand
        {
            get => (ICommand)GetValue(ValidateCommandProperty);
            set => SetValue(ValidateCommandProperty, value);
        }

        public ICommand CancelCommand
        {
            get => (ICommand)GetValue(CancelCommandProperty);
            set => SetValue(CancelCommandProperty, value);
        }

        public YesNoModalFooter()
        {
            InitializeComponent();
        }
    }
}