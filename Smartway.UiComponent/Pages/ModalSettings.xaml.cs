using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModalSettings : Modal
    {

        public ICommand CancelCommand => new Command(async () =>
        {
            await Navigation.PopModalAsync(false);
        });

        public ModalSettings()
        {
            InitializeComponent();
        }
    }
}