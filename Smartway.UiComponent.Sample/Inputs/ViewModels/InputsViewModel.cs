using System;
using System.Collections.Generic;
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
        private readonly List<string> _searchableContentList = new List<string>()
        {
            "Test", "a-Test", "bac a-tett", "Top result", "BIM", "Smartway"
        };

        private string _searchText;

        public InputsViewModel()
        {
            RadioButtons = new ObservableCollection<RadioButtonInputViewModel>
            {
                new RadioButtonInputViewModel{Label = "Vanille", IsChecked = true},
                new RadioButtonInputViewModel{Label = "Chocolat"}
            };

            SearchableContentList = _searchableContentList.ToList();
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
        
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                SearchableContentList = _searchableContentList.Where(c =>
                    c.StartsWith(_searchText, StringComparison.InvariantCultureIgnoreCase)).ToList();
                SearchableContentList.AddRange(_searchableContentList.Where(c => c.IndexOf(_searchText, StringComparison.InvariantCultureIgnoreCase) > 0));
                RaisedPropertyChanged(nameof(SearchableContentList));
                RaisedPropertyChanged(nameof(SearchText));
            }
        }

        public ICommand SearchCompletedCommand => new Command(() =>
        {
            Console.WriteLine("Search complete");
        });

        public ICommand SearchTextChangedCommand => new Command(() =>
        {
            Console.WriteLine("Search text changed");
        });

        public List<string> SearchableContentList { get; set; }

        private DateTime _date;
        public DateTime Date
        {
            get => _date;
            set => Set(nameof(Date), ref _date, value);
        }

        public DateTime MinimumDate => DateTime.Today;
        public DateTime MaximumDate => DateTime.Today.AddYears(4);
    }
}
