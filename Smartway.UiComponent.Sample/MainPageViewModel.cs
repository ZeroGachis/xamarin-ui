using System.Windows.Input;
using Smartway.UiComponent.Sample.Basics;
using Smartway.UiComponent.Sample.ExpanderCard;
using Smartway.UiComponent.Sample.Buttons;
using Smartway.UiComponent.Sample.Effects.ViewModels;
using Smartway.UiComponent.Sample.ExpanderCard.ViewModels;
using Smartway.UiComponent.Sample.Indicators.ViewModels;
using Smartway.UiComponent.Sample.Inputs.ViewModels;
using Smartway.UiComponent.Sample.SectionSheet.ViewModels;
using Smartway.UiComponent.Sample.SectionSheet.Views;
using Smartway.UiComponent.Sample.Separator;
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
            await NavigateTo(new ExpanderCardSample{ BindingContext = new ExpanderCardSampleViewModel()});
        });

        public ICommand BasicComponents => new Command(async () =>
        {
            await NavigateTo(new BasicComponents());
        });

        public ICommand Separators => new Command(async () =>
        {
            await NavigateTo(new SeparatorsSample());
        });

        public ICommand Button => new Command(async () =>
        {
            await NavigateTo(new Buttons.Button{BindingContext = new ButtonViewModel()});
        });

        public ICommand Inputs => new Command(async () =>
        {
            await NavigateTo(new Inputs.Views.Inputs{ BindingContext = new InputsViewModel()});
        });

        public ICommand Layouts => new Command(async () =>
        {
            await NavigateTo(new Layouts.LayoutsSample());
        });

        public ICommand Modal => new Command(async () =>
        {
            await NavigateTo(new Pages.ModalSample());
        });

        public ICommand FormsElements => new Command(async () =>
        {
            await NavigateTo(new Inputs.Views.FormEntry { BindingContext = new FormEntryViewModel() });
        });

        public ICommand EffectsPage => new Command(async () =>
        {
            await NavigateTo(new Effects.Views.Effect { BindingContext = new EffectsViewModel() });
        });
    }
}
