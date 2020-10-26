using System.Windows.Input;
using Smartway.UiComponent.Sample.ExpanderCard;
using Smartway.UiComponent.Sample.Indicators.ViewModels;
using Smartway.UiComponent.Sample.SectionSheet.ViewModels;
using Smartway.UiComponent.Sample.SectionSheet.Views;
using Smartway.UiComponent.Sample.TopAppBar.ViewModels;
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

        public ICommand TopAppBar => new Command(async () =>
        {
            await NavigateTo(new TopAppBar.Views.TopAppBar{ BindingContext =  new TopAppBarViewModel()});
        });

        public ICommand ExpanderCard => new Command(async () =>
        {
            await NavigateTo(new ExpanderCardSample());
        });
    }
}
