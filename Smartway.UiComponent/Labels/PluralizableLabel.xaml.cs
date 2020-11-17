using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.Labels
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PluralizableLabel : Label
    {
        public static readonly BindableProperty ItemCountProperty = BindableProperty.Create(nameof(ItemCount), typeof(int), typeof(PluralizableLabel), propertyChanged: UpdateLabel);

        public static readonly BindableProperty SingularFormProperty = BindableProperty.Create(nameof(SingularText), typeof(string), typeof(PluralizableLabel), propertyChanged: UpdateLabel);

        public static readonly BindableProperty PluralFormProperty = BindableProperty.Create(nameof(PluralText), typeof(string), typeof(PluralizableLabel), propertyChanged:UpdateLabel);
        public PluralizableLabel()
        {
            InitializeComponent();
        }

        public int ItemCount
        {
            get => (int)GetValue(ItemCountProperty);
            set => SetValue(ItemCountProperty, value);
        }

        public string SingularText
        {
            get => (string) GetValue(SingularFormProperty);
            set => SetValue(SingularFormProperty, value);
        }
        public string PluralText
        {
            get => (string) GetValue(PluralFormProperty);
            set => SetValue(PluralFormProperty, value);
        }
        
        public string FormattedLabel
        {
            get
            {
                if (PluralText == null || SingularText == null)
                {
                    return string.Empty;
                }

                return string.Format(ItemCount > 1 ? PluralText : SingularText, ItemCount);
            }
        }
        
        private static void UpdateLabel(BindableObject bindable, object oldVal, object newVal)
        {
            (bindable as PluralizableLabel)?.OnPropertyChanged(nameof(FormattedLabel));
        }
    }
}