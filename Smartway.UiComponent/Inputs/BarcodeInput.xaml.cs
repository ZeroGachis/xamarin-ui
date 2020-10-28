using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.Inputs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BarcodeInput
    {
        public static readonly BindableProperty HasFocusProperty = BindableProperty.Create(nameof(HasFocus), typeof(bool), typeof(BarcodeInput));
        public static readonly BindableProperty ValueProperty = BindableProperty.Create(nameof(Value), typeof(string), typeof(BarcodeInput));
        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(BarcodeInput));
        public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(BarcodeInput));
        public static readonly BindableProperty OnFocusedProperty = BindableProperty.Create(nameof(OnFocused), typeof(ICommand), typeof(BarcodeInput));
        public static readonly BindableProperty OnUnfocusedProperty = BindableProperty.Create(nameof(OnUnfocused), typeof(ICommand), typeof(BarcodeInput));

        public BarcodeInput()
        {
            InitializeComponent();
        }

        public bool HasFocus
        {
            get { return (bool)GetValue(HasFocusProperty); }
            set { SetValue(HasFocusProperty, value); }
        }

        public string Value
        {
            get {
                return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public ICommand OnFocused
        {
            get { return (ICommand)GetValue(OnFocusedProperty); }
            set { SetValue(OnFocusedProperty, value); }
        }

        public ICommand OnUnfocused
        {
            get { return (ICommand)GetValue(OnUnfocusedProperty); }
            set { SetValue(OnUnfocusedProperty, value); }
        }

        private void Entry_OnFocused(object sender, FocusEventArgs e)
        {
            HasFocus = true;
            OnFocused?.Execute(null);
        }

        private void Entry_OnUnfocused(object sender, FocusEventArgs e)
        {
            HasFocus = false;
            OnUnfocused?.Execute(null);
        }
    }
}