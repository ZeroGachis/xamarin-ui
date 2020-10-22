using System.Windows.Input;
using Xamarin.Forms;

namespace Smartway.UiComponent.Sample.SectionSheet.ViewModels
{
    class SectionSheetSampleViewModel: ViewModel
    {
        public ICommand NavigationTest => new Command((param) =>
        {
            var message = "Tapped on " + param.ToString();
            DependencyService.Get<INotifyMessage>().ShortAlert(message);
        });
    }
}
