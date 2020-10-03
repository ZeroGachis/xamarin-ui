using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.Indicators
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Status
    {
        private const string DefaultState = "Basic";

        public static readonly BindableProperty ValueProperty = BindableProperty.Create(nameof(Value), typeof(string), typeof(Status), DefaultState, propertyChanged:OnValueChange);

        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(Status));

        public string Value
        {
            get => (string)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public Status()
        {
            InitializeComponent();
            GoToState(this, DefaultState);
        }

        private static void OnValueChange(BindableObject bindable, object oldvalue, object newvalue)
        {
            GoToState(bindable as Status, newvalue as string);
        }

        private static void GoToState(Status status, string state)
        {
            VisualStateManager.GoToState(status.BoxView, state);
        }
    }
}