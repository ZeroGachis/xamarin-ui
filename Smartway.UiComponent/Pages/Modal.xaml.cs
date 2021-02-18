using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Modal : ContentPage
    {

        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create(nameof(Title), typeof(string), typeof(Modal));

        public static readonly BindableProperty BodyContentProperty =
            BindableProperty.Create(nameof(BodyContent), typeof(View), typeof(Modal));

        public static readonly BindableProperty HasDividerProperty =
            BindableProperty.Create(nameof(HasDivider), typeof(bool), typeof(Modal));

        public static readonly BindableProperty NavigationContentProperty =
            BindableProperty.Create(nameof(NavigationContent), typeof(View), typeof(Modal));

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public View BodyContent
        {
            get => (View)GetValue(BodyContentProperty);
            set => SetValue(BodyContentProperty, value);
        }

        public bool HasDivider
        {
            get => (bool)GetValue(HasDividerProperty);
            set => SetValue(HasDividerProperty, value);
        }

        public View NavigationContent
        {
            get => (View)GetValue(NavigationContentProperty);
            set => SetValue(NavigationContentProperty, value);
        }

        public Modal()
        {
            InitializeComponent();
            BackgroundColor = Color.FromRgba(0, 0, 0, 140);
        }
    }
}