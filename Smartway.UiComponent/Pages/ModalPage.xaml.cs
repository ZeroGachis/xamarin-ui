using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModalPage : ContentPage
    {
        BindableProperty HeaderContentProperty = BindableProperty.Create(nameof(HeaderContent), typeof(View), typeof(ModalPage));
        BindableProperty BodyContentProperty = BindableProperty.Create(nameof(BodyContent), typeof(View), typeof(ModalPage));
        BindableProperty FooterContentProperty = BindableProperty.Create(nameof(FooterContent), typeof(View), typeof(ModalPage));

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


        public ModalPage()
        {
            InitializeComponent();
        }
    }
}