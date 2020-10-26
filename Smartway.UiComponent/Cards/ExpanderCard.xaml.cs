using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.Cards
{
    [ContentProperty("Content")]
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

        public static readonly BindableProperty ExpanderContentProperty = BindableProperty.Create(nameof(ExpanderContent), typeof(View), typeof(ExpanderCard));

        public string Status
        {
            get => (string)GetValue(StatusProperty);
            set => SetValue(StatusProperty, value);
        }

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public string Counter
        {
            get => (string)GetValue(CounterProperty);
            set => SetValue(CounterProperty, value);
        }

        public View ExpanderContent
        {
            get => (View)GetValue(ExpanderContentProperty);
            set => SetValue(ExpanderContentProperty, value);
        }

        public ExpanderCard()
        {
            InitializeComponent();
        }
    }
}