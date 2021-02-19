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

        public ICommand ModalSettingsFullHeight => new Command(async () =>
        {
            await this.Navigation.PushModalAsync(new ModalSettingsSample()
            {
                BodyHeight = LayoutOptions.FillAndExpand
            }, 
                false);
        });

        public ICommand ModalSettingsCustomHeight => new Command(async () =>
        {
            await this.Navigation.PushModalAsync(new ModalSettingsSample()
                {
                    BodyHeight = LayoutOptions.CenterAndExpand
                },
                false);
        });
    }
}