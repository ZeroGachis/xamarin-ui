using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Smartway.UiComponent.Sample.TopAppBar.ViewModels
{
    public class TopAppBarViewModel : ViewModel
    {
        public ICommand Back => new Command(async _ => await Back());
    }
}