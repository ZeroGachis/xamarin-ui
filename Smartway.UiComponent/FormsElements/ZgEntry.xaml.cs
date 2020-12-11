using System;
using System.Globalization;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.FormsElements
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ZgEntry
    {
        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create(nameof(Title), typeof(string), typeof(ZgEntry));

        public static readonly BindableProperty PrefixProperty =
            BindableProperty.Create(nameof(Prefix), typeof(string), typeof(ZgEntry), string.Empty);

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(ZgEntry));

        public static readonly BindableProperty PlaceHolderProperty =
            BindableProperty.Create(nameof(PlaceHolder), typeof(string), typeof(ZgEntry));

        public static readonly BindableProperty HelperProperty =
            BindableProperty.Create(nameof(Helper), typeof(string), typeof(ZgEntry));

        public static readonly BindableProperty ReadOnlyProperty =
            BindableProperty.Create(nameof(ReadOnly), typeof(bool), typeof(ZgEntry));

        public static readonly BindableProperty DisabledProperty = BindableProperty.Create(nameof(Disabled),
            typeof(bool), typeof(ZgEntry), propertyChanged: DisabledMode);

        public static readonly BindableProperty ErrorProperty =
            BindableProperty.Create(nameof(Error), typeof(string), typeof(ZgEntry), string.Empty);

        public string Title
        {
            get => (string) GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public string Prefix
        {
            get => (string) GetValue(PrefixProperty);
            set => SetValue(PrefixProperty, value);
        }

        public string Text
        {
            get => (string) GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public string PlaceHolder
        {
            get => (string) GetValue(PlaceHolderProperty);
            set => SetValue(PlaceHolderProperty, value);
        }

        public string Helper
        {
            get => (string) GetValue(HelperProperty);
            set => SetValue(HelperProperty, value);
        }

        public string Error
        {
            get => (string) GetValue(ErrorProperty);
            set => SetValue(ErrorProperty, value);
        }

        public bool ReadOnly
        {
            get => (bool) GetValue(ReadOnlyProperty);
            set => SetValue(ReadOnlyProperty, value);
        }

        public bool Disabled
        {
            get => (bool) GetValue(DisabledProperty);
            set => SetValue(DisabledProperty, value);
        }

        public ZgEntry()
        {
            InitializeComponent();
        }

        private void InputOnFocused(object sender, FocusEventArgs e)
        {
            DividerPrefix.BackgroundColor = Color.Black;
            DividerInput.BackgroundColor = Color.Black;
        }

        private void InputOnUnfocused(object sender, FocusEventArgs e)
        {
            DividerPrefix.BackgroundColor = Color.FromHex("#E2E4F0");
            DividerInput.BackgroundColor = Color.FromHex("#E2E4F0");
        }

        private static void DisabledMode(BindableObject bindable, object oldValue, object newValue)
        {
            if ((bool) newValue)
            {
                var formElement = (ZgEntry) bindable;
                var grayColor = Color.FromHex("#B2B2B2");

                formElement.TitleLabel.TextColor = grayColor;
                formElement.PrefixLabel.TextColor = grayColor;
                formElement.HelperLabel.TextColor = grayColor;
                formElement.CustomEntry.TextColor = grayColor;

                formElement.CustomEntry.IsEnabled = false;
            }
        }
    }
}