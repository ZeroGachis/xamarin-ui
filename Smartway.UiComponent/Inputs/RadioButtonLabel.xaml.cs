using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.Inputs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RadioButtonLabel
    {
        public class CommandParameters
        {
            /// <summary>
            /// The component from where the command has been fired.
            /// </summary>
            public RadioButtonLabel Sender { get; set; }

            /// <summary>
            /// The user defined parameter passed to the command.
            /// </summary>
            public object Parameter { get; set; }
        }

        public static readonly BindableProperty IsCheckedProperty =
            BindableProperty.Create(nameof(IsChecked), typeof(bool), typeof(RadioButtonLabel));
        public static readonly BindableProperty LabelProperty =
            BindableProperty.Create(nameof(Label), typeof(string), typeof(RadioButtonLabel));
        public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(RadioButtonLabel));
        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(RadioButtonLabel));
        public static readonly BindableProperty IndexProperty = BindableProperty.Create(nameof(Index), typeof(int), typeof(RadioButtonLabel));

        public bool IsChecked
        {
            get => (bool)GetValue(IsCheckedProperty);
            set => SetValue(IsCheckedProperty, value);
        }

        public string Label
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        public int Index
        {
            get => (int)GetValue(IndexProperty);
            set => SetValue(IndexProperty, value);
        }

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public ICommand ToggleRadioButton => new Command(() =>
        {
            IsChecked = true;
        });

        public object CommandParameter
        {
            get => new CommandParameters{ Sender = this, Parameter = GetValue(CommandParameterProperty)};
            set => SetValue(CommandParameterProperty, value);
        }

        public RadioButtonLabel()
        {
            InitializeComponent();
        }
    }
}
