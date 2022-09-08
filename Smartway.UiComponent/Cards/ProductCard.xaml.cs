using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.Cards
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductCard
    {
        public static readonly BindableProperty LabelProperty = BindableProperty.Create(
               nameof(Label), typeof(string), typeof(ProductCard));

        public static readonly BindableProperty GencodeProperty = BindableProperty.Create(
            nameof(Gencode), typeof(string), typeof(ProductCard));

        public static readonly BindableProperty InitialPriceProperty = BindableProperty.Create(
            nameof(InitialPrice), typeof(string), typeof(ProductCard));

        public static readonly BindableProperty QuantityProperty = BindableProperty.Create(
            nameof(Quantity), typeof(int?), typeof(ProductCard));

        public static readonly BindableProperty DetailsProperty = BindableProperty.Create(
            nameof(Details), typeof(ContentView), typeof(ProductCard));

        public static readonly BindableProperty TimeProperty = BindableProperty.Create(
            nameof(Time), typeof(DateTime?), typeof(ProductCard));

        public static readonly BindableProperty ClickCommandProperty = BindableProperty.Create(
            nameof(ClickCommand), typeof(ICommand), typeof(ProductCard));

        public static readonly BindableProperty ClickCommandParameterProperty = BindableProperty.Create(
            nameof(ClickCommandParameter), typeof(object), typeof(ProductCard));

        public static readonly BindableProperty IsVariableProductProperty = BindableProperty.Create(
            nameof(IsVariableProduct), typeof(bool), typeof(ProductCard));

        public static readonly BindableProperty WeightProperty = BindableProperty.Create(
            nameof(Weight), typeof(long?), typeof(ProductCard));

        public static readonly BindableProperty IsMultilocationProperty = BindableProperty.Create(
            nameof(IsMultilocation), typeof(bool), typeof(ProductCard), false);

        public ProductCard()
        {
            InitializeComponent();
        }

        public string Label
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        public string Gencode
        {
            get => (string)GetValue(GencodeProperty);
            set => SetValue(GencodeProperty, value);
        }

        public string InitialPrice
        {
            get => (string)GetValue(InitialPriceProperty);
            set => SetValue(InitialPriceProperty, value);
        }

        public int? Quantity
        {
            get => (int?)GetValue(QuantityProperty);
            set => SetValue(QuantityProperty, value);
        }

        public ContentView Details
        {
            get => (ContentView)GetValue(DetailsProperty);
            set => SetValue(DetailsProperty, value);
        }

        public DateTime? Time
        {
            get => (DateTime?)GetValue(TimeProperty);
            set => SetValue(TimeProperty, value);
        }

        public ICommand ClickCommand
        {
            get => (ICommand)GetValue(ClickCommandProperty);
            set => SetValue(ClickCommandProperty, value);
        }

        public object ClickCommandParameter
        {
            get => GetValue(ClickCommandParameterProperty);
            set => SetValue(ClickCommandParameterProperty, value);
        }

        public bool IsVariableProduct
        {
            get => (bool)GetValue(IsVariableProductProperty);
            set => SetValue(IsVariableProductProperty, value);
        }

        public long? Weight
        {
            get => (long?)GetValue(WeightProperty);
            set => SetValue(WeightProperty, value);
        }

        public bool IsMultilocation
        {
            get => (bool)GetValue(IsMultilocationProperty);
            set => SetValue(IsMultilocationProperty, value);
        }
    }
}