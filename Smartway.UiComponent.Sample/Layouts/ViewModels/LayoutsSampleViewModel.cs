using System.Windows.Input;
using Xamarin.Forms;

namespace Smartway.UiComponent.Sample.Layouts.ViewModels
{
    public class LayoutsSampleViewModel: ViewModel
    {
        public ICommand ScanCommand => new Command(_ =>
        {
            DependencyService.Get<INotifyMessage>().ShortAlert("Scan clicked !");
        });

        public ICommand ClickCommand => new Command(_ =>
        {
            DependencyService.Get<INotifyMessage>().ShortAlert("Button clicked !");
        });
    }

}
