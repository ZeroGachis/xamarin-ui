using System.Windows.Input;
using Smartway.UiComponent.Sample.Indicators.ViewModels;
using Smartway.UiComponent.Sample.SectionSheet;
using Smartway.UiComponent.Sample.SectionSheet.ViewModels;
using Smartway.UiComponent.Sample.SectionSheet.Views;
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

        public ICommand SectionSheet => new Command(async () =>
        {
            await NavigateTo(new SectionSheetSample{ BindingContext = new SectionSheetSampleViewModel() });
        });
    }
}
