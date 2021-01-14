using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Smartway.UiComponent.Inputs;
using Xamarin.Forms;

namespace Smartway.UiComponent.Sample.Inputs.ViewModels
{
    public class RadioButtonInputViewModel : ViewModel
    {
        public string Label { get; set; }

        public bool IsChecked { get; set; }
    }

    public class InputsViewModel: ViewModel
    {
        public InputsViewModel()
        {
            RadioButtons = new ObservableCollection<RadioButtonInputViewModel>
            {
                new RadioButtonInputViewModel{Label = "Vanille", IsChecked = true},
                new RadioButtonInputViewModel{Label = "Chocolat"}
            };
        }

        public ObservableCollection<RadioButtonInputViewModel> RadioButtons { get; set; }

        private RadioButtonInputViewModel SelectedElement => RadioButtons.FirstOrDefault(_ => _.IsChecked);

        public ICommand Validate => new Command(() =>
        {
            var message = $"{SelectedElement.Label} selected element";
            DependencyService.Get<INotifyMessage>().ShortAlert(message);
        });

        public ICommand ChipsAction => new Command((param) =>
        {
            var chips = (Chips) param;
            chips.IsVisible = false;
            DependencyService.Get<INotifyMessage>().ShortAlert("Chips tapped !");
        });
    }
}
