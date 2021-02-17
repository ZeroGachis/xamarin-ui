using System.Windows.Input;
using Smartway.UiComponent.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.Sample.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DefaultModal : Modal
    {
        public DefaultModal()
        {
            InitializeComponent();
        }

        public ICommand CancelCommand => new Command(async () =>
        {
            await Navigation.PopModalAsync(false);
        });
    }
}