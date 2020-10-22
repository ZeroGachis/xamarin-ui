using System;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.Cards
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpanderCard
    {
        public static readonly BindableProperty StatusProperty = BindableProperty.Create(
            nameof(Status), typeof(string), typeof(ExpanderCard)
        );

        public static readonly BindableProperty TitleProperty = BindableProperty.Create(
            nameof(Title), typeof(string), typeof(ExpanderCard)
        );

        public static readonly BindableProperty CounterProperty = BindableProperty.Create(
            nameof(Counter), typeof(string), typeof(ExpanderCard)
        );

        public string Status
        {
            get => (string) GetValue(StatusProperty);
            set => SetValue(StatusProperty, value);
        }

        public string Title
        {
            get => (string) GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public string Counter
        {
            get => (string) GetValue(CounterProperty);
            set => SetValue(CounterProperty, value);
        }

        public ExpanderCard()
        {
            InitializeComponent();
            SizeChanged += SetMaxHeight;
        }

        private void SetMaxHeight(object sender, EventArgs e)
        {
            if (IsExpanded && Height >= 328)
                HeightRequest = 328;
            else
                HeightRequest = -1; // magical xamarin number for auto size.
        }
    }
}