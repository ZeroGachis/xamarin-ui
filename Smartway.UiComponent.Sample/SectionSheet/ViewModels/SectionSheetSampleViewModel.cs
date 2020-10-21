using System.Windows.Input;
using Xamarin.Forms;

namespace Smartway.UiComponent.Sample.SectionSheet.ViewModels
{
    class SectionSheetSampleViewModel: ViewModel
    {
        public ICommand NavigationTest => new Command((param) =>
        {
            System.Console.WriteLine("DEBUG: PARAM Navigation test : " + param.ToString());
        });
    }
}
