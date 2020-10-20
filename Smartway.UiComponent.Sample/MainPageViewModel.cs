using System.Windows.Input;
using Smartway.UiComponent.Sample.Indicators.ViewModels;
using Xamarin.Forms;

namespace Smartway.UiComponent.Sample
{
    public class MainPageViewModel : ViewModel
    {
        public ICommand SectionForm => new Command(async () =>
        {
            await NavigateTo(new SectionFormSample{ BindingContext = new SectionFormSampleViewModel()});
        });

        public ICommand Indicators => new Command(async () =>
        {
            await NavigateTo(new Indicators.Views.Indicators{ BindingContext = new IndicatorsViewModel()});
        });
    }
}
