using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.Cards
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArticleCard
    {
        public static readonly BindableProperty IsMultilocationProperty = BindableProperty.Create(nameof(IsMultilocation), typeof(bool), typeof(ArticleCard), false);
        public static readonly BindableProperty LabelProperty = BindableProperty.Create(nameof(Label), typeof(string), typeof(ArticleCard));
        public static readonly BindableProperty GencodeProperty = BindableProperty.Create(nameof(Gencode), typeof(string), typeof(ArticleCard));
        public static readonly BindableProperty IsOnShortageProperty = BindableProperty.Create(nameof(IsOnShortage), typeof(bool), typeof(ArticleCard), false);
        public static readonly BindableProperty PriceProperty = BindableProperty.Create(nameof(Price), typeof(string), typeof(ArticleCard));
        public static readonly BindableProperty NavigationCommandProperty = BindableProperty.Create(nameof(NavigationCommand), typeof(ICommand), typeof(ArticleCard));
        public static readonly BindableProperty NavigationParameterProperty = BindableProperty.Create(nameof(NavigationParameter), typeof(object), typeof(ArticleCard));
        public static readonly BindableProperty ShortageAtProperty = BindableProperty.Create(nameof(ShortageAt), typeof(DateTime), typeof(ArticleCard), DateTime.Today);
        public static readonly BindableProperty StatusProperty = BindableProperty.Create(nameof(Status), typeof(string), typeof(ArticleCard), "Unknown");

        public bool IsMultilocation
        {
            get => (bool) GetValue(IsMultilocationProperty);
            set => SetValue(IsMultilocationProperty, value);
        }

        public string Label
        {
            get => (string) GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        public string Gencode
        {
            get => (string) GetValue(GencodeProperty);
            set => SetValue(GencodeProperty, value);
        }

        public bool IsOnShortage
        {
            get => (bool) GetValue(IsOnShortageProperty);
            set => SetValue(IsOnShortageProperty, value);
        }

        public DateTime ShortageAt
        {
            get => (DateTime) GetValue(ShortageAtProperty);
            set => SetValue(ShortageAtProperty, value);
        }

        public string Price
        {
            get => (string) GetValue(PriceProperty);
            set => SetValue(PriceProperty, value);
        }

        public ICommand NavigationCommand
        {
            get => (ICommand) GetValue(NavigationCommandProperty);
            set => SetValue(NavigationCommandProperty, value);
        }

        public object NavigationParameter
        {
            get => (object) GetValue(NavigationParameterProperty);
            set => SetValue(NavigationParameterProperty, value);
        }

        public string Status
        {
            get => (string)GetValue(StatusProperty);
            set => SetValue(StatusProperty, value);
        }

        public ArticleCard()
        {
            InitializeComponent();
        }
    }
}