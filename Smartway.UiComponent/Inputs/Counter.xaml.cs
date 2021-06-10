using System;
using Smartway.UiComponent.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.Inputs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Counter
    {
        public Counter()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty ValueProperty = BindableProperty.Create(
            "Value", typeof(int), typeof(Counter), default(int), BindingMode.TwoWay, propertyChanged: ValueChanged);

        private static void ValueChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (bindable is Counter counter)
                counter.RefreshButtonsEnabled();
        }

        public int Value
        {
            get => (int)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public static readonly BindableProperty MinValueProperty = BindableProperty.Create(
            "MinValue", typeof(int), typeof(Counter), int.MinValue);

        public int MinValue
        {
            get => (int)GetValue(MinValueProperty);
            set => SetValue(MinValueProperty, value);
        }

        public static readonly BindableProperty MaxValueProperty = BindableProperty.Create(
            "MaxValue", typeof(int), typeof(Counter), int.MaxValue);

        public int MaxValue
        {
            get => (int)GetValue(MaxValueProperty);
            set => SetValue(MaxValueProperty, value);
        }

        public static readonly BindableProperty FontColorProperty = BindableProperty.Create(
            "FontColor", typeof(Color), typeof(Counter), default(Color));

        public Color FontColor
        {
            get => (Color)GetValue(FontColorProperty);
            set => SetValue(FontColorProperty, value);
        }

        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
            "FontSize", typeof(double), typeof(Counter), default(double));

        public double FontSize
        {
            get => (double)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }

        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(
            "FontFamily", typeof(string), typeof(IFontElement), default(string));

        public string FontFamily
        {
            get => (string)GetValue(FontFamilyProperty);
            set => SetValue(FontFamilyProperty, value);
        }

        private void DecreaseCounterValue(object sender, EventArgs e)
        {
            Value--;
        }

        private void IncreaseCounterValue(object sender, EventArgs e)
        {
            Value++;
        }

        private void RefreshButtonsEnabled()
        {
            DecreaseButton.IsEnabled = Value > MinValue;
            IncreaseButton.IsEnabled = Value < MaxValue;
        }
    }
}