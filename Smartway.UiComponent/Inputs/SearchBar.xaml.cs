using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.Inputs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchBar
    {
        public static readonly BindableProperty SearchTextProperty = BindableProperty.Create(
            nameof(SearchText), typeof(string), typeof(SearchBar), default(string), BindingMode.TwoWay);

        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
            nameof(Placeholder), typeof(string), typeof(SearchBar), default(string));

        public static readonly BindableProperty PlaceholderColorProperty = BindableProperty.Create(
            nameof(PlaceholderColor), typeof(Color), typeof(SearchBar));

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
            nameof(TextColor), typeof(Color), typeof(SearchBar));

        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(
            nameof(FontFamily), typeof(string), typeof(SearchBar), "OpenSans");

        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
            nameof(FontSize), typeof(double), typeof(SearchBar), 14d);

        public static readonly BindableProperty FontAttributesProperty = BindableProperty.Create(
            nameof(FontAttributes), typeof(FontAttributes), typeof(SearchBar));

        public static readonly BindableProperty CompletedCommandProperty = BindableProperty.Create(
            nameof(CompletedCommand), typeof(ICommand), typeof(SearchBar));

        public static readonly BindableProperty TextChangedCommandProperty = BindableProperty.Create(
            nameof(TextChangedCommand), typeof(ICommand), typeof(SearchBar));

        public SearchBar()
        {
            InitializeComponent();
        }

        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }

        public Color PlaceholderColor
        {
            get => (Color)GetValue(PlaceholderColorProperty);
            set => SetValue(PlaceholderColorProperty, value);
        }

        public FontAttributes FontAttributes
        {
            get => (FontAttributes)GetValue(FontAttributesProperty);
            set => SetValue(FontAttributesProperty, value);
        }

        public string FontFamily
        {
            get => (string)GetValue(FontFamilyProperty);
            set => SetValue(FontFamilyProperty, value);
        }

        [TypeConverter(typeof(FontSizeConverter))]
        public double FontSize
        {
            get => (double)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }

        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
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

        /// <summary>
        /// Called when text is changed. Should not be useful because SearchText property is already there.
        /// </summary>
        public ICommand TextChangedCommand
        {
            get => (ICommand)GetValue(TextChangedCommandProperty);
            set => SetValue(TextChangedCommandProperty, value);
        }

        /// <summary>
        /// Called when entry is validated with return button or text is cleared.
        /// </summary>
        public ICommand CompletedCommand
        {
            get => (ICommand)GetValue(CompletedCommandProperty);
            set => SetValue(CompletedCommandProperty, value);
        }

        private void ClearSearchText(object sender, EventArgs e)
        {
            SearchText = string.Empty;

            Completed();
        }

        public bool CanClearSearchText => !string.IsNullOrEmpty(SearchText);
        
        private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            TextChanged();
        }

        private void OnEntryCompleted(object sender, EventArgs e)
        {
            Completed();
        }

        private void Completed()
        {
            if (!(CompletedCommand?.CanExecute(null) ?? false)) return;

            CompletedCommand.Execute(null);
        }

        private void TextChanged()
        {
            if (!(TextChangedCommand?.CanExecute(null) ?? false)) return;

            TextChangedCommand.Execute(null);
        }
    }
}