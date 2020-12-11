using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.Inputs
{
    [ContentProperty("CustomContent")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RadioButton
    {

        public class CommandParameters
        {
            /// <summary>
            /// The component from where the command has been fired.
            /// </summary>
            public RadioButton Sender { get; set; }

            /// <summary>
            /// The user defined parameter passed to the command.
            /// </summary>
            public object Parameter { get; set; }
        }

        public enum PositionType
        {
            Left,
            Right
        }

        public static readonly BindableProperty IsCheckedProperty = BindableProperty.Create(nameof(IsChecked), typeof(bool), typeof(RadioButton), false);

        public static readonly BindableProperty CustomContentProperty = BindableProperty.Create(nameof(CustomContent), typeof(View), typeof(RadioButton), propertyChanged:OnCustomContentChanged);

        public static readonly BindableProperty LeftContentProperty = BindableProperty.Create(nameof(LeftContent), typeof(View), typeof(RadioButton));

        public static readonly BindableProperty RightContentProperty = BindableProperty.Create(nameof(RightContent), typeof(View), typeof(RadioButton));

        public static readonly BindableProperty PositionProperty = BindableProperty.Create(nameof(Position), typeof(PositionType), typeof(RadioButton));

        public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(RadioButton));

        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(RadioButton));

        public static readonly BindableProperty IndexProperty = BindableProperty.Create(nameof(Index), typeof(int), typeof(RadioButton));

        public bool IsChecked
        {
            get => (bool) GetValue(IsCheckedProperty);
            set => SetValue(IsCheckedProperty, value);
        }

        public View CustomContent
        {
            get => (View) GetValue(CustomContentProperty);
            set => SetValue(CustomContentProperty, value);
        }

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public PositionType Position
        {
            get => (PositionType)GetValue(PositionProperty);
            set => SetValue(PositionProperty, value);
        }

        public View LeftContent
        {
            get => (View)GetValue(LeftContentProperty);
            set => SetValue(LeftContentProperty, value);
        }

        public View RightContent
        {
            get => (View)GetValue(RightContentProperty);
            set => SetValue(RightContentProperty, value);
        }

        public ICommand ToggleRadioButton => new Command(() =>
        {
            IsChecked = true;
        });

        public object CommandParameter
        {
            get => new CommandParameters { Sender = this, Parameter = GetValue(CommandParameterProperty) };
            set => SetValue(CommandParameterProperty, value);
        }

        public RadioButton()
        {
            InitializeComponent();
        }

        private static void OnCustomContentChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var radioButton = (RadioButton) bindable;
            switch (radioButton.Position)
            {
                case PositionType.Left:
                    radioButton.RightContent = (View)newvalue;
                    break;
                case PositionType.Right:
                    radioButton.LeftContent = (View)newvalue;
                    break;
            }
        }
    }
}
