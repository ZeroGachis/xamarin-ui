using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.Inputs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchBar : ContentView
    {
        public static readonly BindableProperty SearchTextProperty = BindableProperty.Create(nameof(SearchText), typeof(string),
            typeof(SearchBar), default(string), BindingMode.TwoWay);

        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder), typeof(string),
            typeof(SearchBar), default(string));

        public SearchBar()
        {
            InitializeComponent();
        }

        public string SearchText
        {
            get => (string)GetValue(SearchTextProperty);
            set
            {
                SetValue(SearchTextProperty, value);
                OnPropertyChanged(nameof(CanClearSearchText));
            }
        }

        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }

        private void ClearSearchText(object sender, EventArgs e)
        {
            SearchText = string.Empty;
        }

        public bool CanClearSearchText => !string.IsNullOrEmpty(SearchText);
    }
}