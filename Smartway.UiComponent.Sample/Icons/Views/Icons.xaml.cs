using System;
using Smartway.UiComponent.Labels.Icons;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.Sample.Icons.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Icons
    {
        public Icons()
        {
            InitializeComponent();
        }

        public Array IconNames => Enum.GetValues(typeof(Icon.IconNames));
    }
}