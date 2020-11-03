using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Smartway.UiComponent.Sample
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            SwitchThemeBtn.Clicked += SwitchTheme;
        }

        private void SwitchTheme(object sender, EventArgs e)
        {
            var currentTheme = Application.Current.RequestedTheme;
            Application.Current.UserAppTheme = currentTheme == OSAppTheme.Light ? OSAppTheme.Dark : OSAppTheme.Light;
        }
    }
}
