using Android.OS;
using Smartway.UiComponent.Droid.Services;
using Smartway.UiComponent.Services;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidInfoProvider))]
namespace Smartway.UiComponent.Droid.Services
{
    public class AndroidInfoProvider : IPlatormInfoProvider
    {
        public int OsSdkVersion { get { return ((int)Build.VERSION.SdkInt); } }
    }
}