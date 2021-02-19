using System.Windows.Input;
using Smartway.UiComponent.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.Sample.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModalSample : ContentPage
    {
        private ModalDialogSample modalDialogSample = new ModalDialogSample(); 
        public ModalSample()
        {
            InitializeComponent();
        }

        public ICommand ModalSettingsFullHeight => new Command(async () =>
        {
            await this.Navigation.PushModalAsync(new ModalSettingsSample
            {
                BodyHeight = LayoutOptions.FillAndExpand
            }, 
                false);
        });

        public ICommand ModalSettingsCustomHeight => new Command(async () =>
        {
            await this.Navigation.PushModalAsync(new ModalSettingsSample
                {
                    BodyHeight = LayoutOptions.CenterAndExpand
                },
                false);
        });

        public ICommand ModalDialogDefault=> new Command(async () =>
        {
            var modalFooter = new YesNoModalFooter {CancelCommand = modalDialogSample.CancelCommand};
            modalDialogSample.NavigationContent = modalFooter;

            await this.Navigation.PushModalAsync(modalDialogSample, false);
        });

        public ICommand ModalDialogInfo => new Command(async () =>
        {
            var modalFooter = new YesModalFooter {ApplyCommand = modalDialogSample.CancelCommand};
            modalDialogSample.NavigationContent = modalFooter;

            await this.Navigation.PushModalAsync(modalDialogSample, false);
        });
    }
}