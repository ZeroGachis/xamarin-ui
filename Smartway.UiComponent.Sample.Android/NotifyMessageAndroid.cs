using Android.App;
using Android.Widget;
using Smartway.UiComponent.Sample.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(NotifyMessageAndroid))]
namespace Smartway.UiComponent.Sample.Droid
{
    public class NotifyMessageAndroid : INotifyMessage
    {
        public void LongAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }

        public void ShortAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }
    }
}