using System;
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
            "Value", typeof(uint), typeof(Counter), default(uint), BindingMode.TwoWay);

        public uint Value
        {
            get => (uint)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
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
            if (Value == 0)
                return;
            Value--;
        }

        private void IncreaseCounterValue(object sender, EventArgs e)
        {
            Value++;
        }
    }
}