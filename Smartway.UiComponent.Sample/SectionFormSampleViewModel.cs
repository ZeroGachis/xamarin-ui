using System.Windows.Input;
using Xamarin.Forms;

namespace Smartway.UiComponent.Sample
{
    public class SectionFormSampleViewModel : ViewModel
    {
        private string _entry3;

        public string Entry3
        {
            get => _entry3;
            set
            {
                Set(nameof(Entry3), ref _entry3, value);
                NotifyPropertyChanged(nameof(Validate));
            }
        }

        public ICommand Validate => new Command(
            _ => { },
            _ => !string.IsNullOrEmpty(Entry3)
        );
    }
}
