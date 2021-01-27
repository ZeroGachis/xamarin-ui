using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.Indicators
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Status
    {
        private const StatusValuesEnum DefaultState = StatusValuesEnum.Basic;

        public static readonly BindableProperty ValueProperty = BindableProperty.Create(nameof(Value), 
            typeof(StatusValuesEnum), 
            typeof(Status),
            DefaultState,
            propertyChanged:OnValueChange);

        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(Status));

        public StatusValuesEnum Value
        {
            get => (StatusValuesEnum)GetValue(ValueProperty);
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
            GoToState(this, DefaultState.ToString());
        }

        private static void OnValueChange(BindableObject bindable, object oldvalue, object newvalue)
        {
            GoToState(bindable as Status, newvalue.ToString());
        }

        private static void GoToState(Status status, string state)
        {
            VisualStateManager.GoToState(status.BoxView, state);
        }

        public enum StatusValuesEnum
        {
            Success,
            Warning,
            Info,
            Basic,
            Danger,
            Dark
        }
    }
}