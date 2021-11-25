using System.ComponentModel;
using Android.Content;
using Smartway.UiComponent.Droid.Renderers;
using Smartway.UiComponent.Inputs;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(EntryWithoutSoftKeyboard), typeof(EntryWithoutSoftKeyboardRenderer))]
namespace Smartway.UiComponent.Droid.Renderers
{
    public class EntryWithoutSoftKeyboardRenderer : CustomEntryRenderer
    {
        public EntryWithoutSoftKeyboardRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> args)
        {
            base.OnElementChanged(args);
            Control.ShowSoftInputOnFocus = false;
        }
    }
}