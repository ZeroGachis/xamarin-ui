using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.FormsElements
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormElement
    {
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(FormElement));
        public static readonly BindableProperty PrefixProperty = BindableProperty.Create(nameof(Prefix), typeof(string), typeof(FormElement),"");
        public static readonly BindableProperty InputProperty = BindableProperty.Create(nameof(Input), typeof(string), typeof(FormElement));
        public static readonly BindableProperty HelperProperty = BindableProperty.Create(nameof(Helper), typeof(string), typeof(FormElement));
        public static readonly BindableProperty ReadOnlyProperty = BindableProperty.Create(nameof(ReadOnly), typeof(bool), typeof(FormElement), false);
        public static readonly BindableProperty DisabledProperty = BindableProperty.Create(nameof(Disabled), typeof(bool), typeof(FormElement), false);

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }
        public string Prefix
        {
            get => (string)GetValue(PrefixProperty);
            set => SetValue(PrefixProperty, value);
        }
        public string Input
        {
            get => (string)GetValue(InputProperty);
            set => SetValue(InputProperty, value);
        }
        public string Helper
        {
            get => (string)GetValue(HelperProperty);
            set => SetValue(HelperProperty, value);
        }
        public bool ReadOnly
        {
            get => (bool)GetValue(ReadOnlyProperty);
            set => SetValue(ReadOnlyProperty, value);
        }
        public bool Disabled
        {
            get => (bool)GetValue(DisabledProperty);
            set => SetValue(DisabledProperty, value);
        }
        public FormElement()
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
    }
}