using Xamarin.Forms;

[assembly: ExportFont("OpenSans-Bold.ttf", Alias = "OpenSansBold")]
[assembly: ExportFont("OpenSans-SemiBold.ttf", Alias = "OpenSansSemiBold")]
[assembly: ExportFont("OpenSans-Regular.ttf", Alias = "OpenSans")]
namespace Smartway.UiComponent.Sample
{
    public partial class App
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage{ BindingContext = new MainPageViewModel() });
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
