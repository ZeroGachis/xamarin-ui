using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.Inputs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NumericInput
    {
        public static readonly BindableProperty InputProperty = BindableProperty.Create(nameof(Input),
            typeof(int?), typeof(NumericInput));
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(nameof(FontSize),
            typeof(int), typeof(NumericInput), 34);
        public static readonly BindableProperty MaxLengthProperty = BindableProperty.Create(nameof(MaxLength),
            typeof(int), typeof(NumericInput), 2);

        public int? Input
        {
            get => (int?)GetValue(InputProperty);
            set
            {
                if (value != null)
                    SetValue(InputProperty, value);
            }
        }

        public int FontSize
        {
            get => (int)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }
        public int MaxLength
        {
            get => (int)GetValue(MaxLengthProperty);
            set => SetValue(MaxLengthProperty, value);
        }

        public NumericInput()
        {
            InitializeComponent();
        }

        public void NumericValidation(object sender, TextChangedEventArgs args)
        {
            var entry = (Entry)sender;
            var input = entry.Text;
            if (int.TryParse(input, out var numericInput))
            {
                entry.Text = numericInput.ToString();
                return;
            }

            entry.Text = args.OldTextValue;
        }
    }
}
