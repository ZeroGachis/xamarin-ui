using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Smartway.UiComponent.Sample.Effects.ViewModels
{
    public class EffectsViewModel: ViewModel
    {
        public ICommand MyHoldCommand => new Command((param) =>
        {
            var message = "** Hoooooooooooooold **";
            Console.WriteLine("Hoooooooooold");
            DependencyService.Get<INotifyMessage>().ShortAlert(message);
        });

        public ICommand MyTapCommand => new Command((param) =>
        {
            var message = "** Taaaaaaaaaaaaaaaaap **";
            Console.WriteLine("Taaaaaaaaaaaaaaaaap");
            DependencyService.Get<INotifyMessage>().ShortAlert(message);
        });
    }

}
