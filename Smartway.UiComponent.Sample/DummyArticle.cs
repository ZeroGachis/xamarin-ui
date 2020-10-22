using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Smartway.UiComponent.Sample
{
    class DummyArticle
    {
        public string Label { get; set; }
        public bool IsMultilocation { get; set; }

        public bool IsOnShortage { get; set; }
        public string Price { get; set; }
        public string Gencode { get; set; }
        public ICommand NavigationCommand => new Command((param) => {
            var message = "Tapped on " + param.ToString();
            DependencyService.Get<INotifyMessage>().ShortAlert(message);
        });
        public object NavigationParameter { get; set; }
        public string Status { get; set; }
        public DateTime ShortageAt => DateTime.Today;
    }
}
