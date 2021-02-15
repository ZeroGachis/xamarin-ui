using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Modal : ContentPage
    {
        BindableProperty HeaderContentProperty = BindableProperty.Create(nameof(HeaderContent), typeof(View), typeof(Modal));
        BindableProperty BodyContentProperty = BindableProperty.Create(nameof(BodyContent), typeof(View), typeof(Modal));
        BindableProperty FooterContentProperty = BindableProperty.Create(nameof(FooterContent), typeof(View), typeof(Modal));

        public View HeaderContent
        {
            get => (View) GetValue(HeaderContentProperty);
            set => SetValue(HeaderContentProperty, value);
        }

        public View BodyContent
        {
            get => (View)GetValue(BodyContentProperty);
            set => SetValue(BodyContentProperty, value);
        }
        public View FooterContent
        {
            get => (View)GetValue(FooterContentProperty);
            set => SetValue(FooterContentProperty, value);
        }


        public Modal()
        {
            InitializeComponent();
        }
    }
}