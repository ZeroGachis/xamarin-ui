using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Smartway.UiComponent.Sample.Inputs.ViewModels
{
    public class FormEntryViewModel: ViewModel
    {
        public ICommand MyCommand => new Command((param) =>
        {
            var message = "Choose your item";
            DependencyService.Get<INotifyMessage>().ShortAlert(message);
        });
    }

}
