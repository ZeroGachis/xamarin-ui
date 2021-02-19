using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModalDialog : Modal
    {
        public static readonly BindableProperty MessageProperty =
            BindableProperty.Create(nameof(Message), typeof(string), typeof(ModalDialog));

        public string Message
        {
            get => (string)GetValue(MessageProperty);
            set => SetValue(MessageProperty, value);
        }

        public ICommand CancelCommand => new Command(async () =>
        {
            await Navigation.PopModalAsync(false);
        });

        public ModalDialog()
        {
            InitializeComponent();
        }
    }
}