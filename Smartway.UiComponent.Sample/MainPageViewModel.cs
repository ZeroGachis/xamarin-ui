using System.Windows.Input;
using Xamarin.Forms;

namespace Smartway.UiComponent.Sample
{
    public class MainPageViewModel : ViewModel
    {
        public ICommand SectionForm => new Command(async () =>
        {
            await NavigateTo(new SectionFormSample());
        });
    }
}
