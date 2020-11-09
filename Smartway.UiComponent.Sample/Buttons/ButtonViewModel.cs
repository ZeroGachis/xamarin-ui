using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Smartway.UiComponent.Sample.Buttons
{
    public class ButtonViewModel : ViewModel
    {
        public ICommand ScanCommand => new Command((param) =>
        {
            var message = "Scan is tapped";
            DependencyService.Get<INotifyMessage>().ShortAlert(message);
        });
    }
}
