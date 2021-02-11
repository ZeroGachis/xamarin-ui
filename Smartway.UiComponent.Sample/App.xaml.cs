using Xamarin.Forms;

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
