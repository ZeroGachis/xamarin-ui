using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.Sample.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModalSample : ContentPage
    {
        public ModalSample()
        {
            InitializeComponent();
        }

        public ICommand DefaultModal => new Command(async () =>
        {
            await this.Navigation.PushModalAsync(new DefaultModal(), false);
        });
    }
}