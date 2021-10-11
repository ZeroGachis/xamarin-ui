using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Smartway.UiComponent.Droid.Extensions;
using Smartway.UiComponent.Droid.Renderers;
using Smartway.UiComponent.Inputs.Barcode;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Android.Graphics.Color;

[assembly: ExportRenderer(typeof(BarcodeEntry), typeof(BarcodeEntryRenderer))]
namespace Smartway.UiComponent.Droid.Renderers
{
    public class BarcodeEntryRenderer : EntryRenderer
    {
        public BarcodeEntryRenderer(Context context)
            : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
                return;

            RemoveHintBottomLine();
            Control.SetCursorColor();
        }

        private void RemoveHintBottomLine()
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                Control.BackgroundTintList = ColorStateList.ValueOf(Color.Transparent);
            else
                Control.Background.SetColorFilter(Color.Transparent, PorterDuff.Mode.SrcAtop);
        }
    }
}
