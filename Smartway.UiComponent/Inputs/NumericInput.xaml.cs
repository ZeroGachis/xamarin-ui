using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.Inputs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NumericInput : ISelectableInput
    {
        public static readonly BindableProperty InputProperty = BindableProperty.Create(nameof(Input),
            typeof(int?), typeof(NumericInput), propertyChanging: InputChanging);
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(nameof(FontSize),
            typeof(int), typeof(NumericInput), 34);
        public static readonly BindableProperty MaxLengthProperty = BindableProperty.Create(nameof(MaxLength),
            typeof(int), typeof(NumericInput), 2);
        public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create(nameof(IsSelected),
            typeof(bool), typeof(NumericInput), false);

        public NumericInput()
        {
            InitializeComponent();
        }

        public int? Input
        {
            get => (int?)GetValue(InputProperty);
            set => SetValue(InputProperty, value);
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

        public bool IsSelected
        {
            get => (bool)GetValue(IsSelectedProperty);
            set => SetValue(IsSelectedProperty, value);
        }

        public event EventHandler OnSelected;

        private static void InputChanging(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (newvalue is int newValue)
            {
                var numericInput = (NumericInput)bindable;

                if (newValue >= Math.Pow(10, numericInput.MaxLength))
                    numericInput.Input = (int)oldvalue;
            }
        }

        private void OnTapped(object sender, EventArgs e)
        {
            OnSelected?.Invoke(this, e);
        }
    }
}
