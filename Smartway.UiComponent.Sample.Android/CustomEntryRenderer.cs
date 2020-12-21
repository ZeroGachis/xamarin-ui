using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Widget;
using Smartway.UiComponent.FormsElements;
using Smartway.UiComponent.Sample.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Xamarin.Forms.Color;

[assembly: ExportRenderer(typeof(Entry), typeof(CustomEntryRenderer))]
namespace Smartway.UiComponent.Sample.Droid
{
    public class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                GradientDrawable gd = new GradientDrawable();
                gd.SetColor(global::Android.Graphics.Color.Transparent);

                this.Control.SetPadding(0, 0, Control.PaddingRight, 0);

                if (e.OldElement != null)
                    return;

                RemoveHintBottomLine();
                SetCursorColor();
            }
        }

        private void SetCursorColor()
        {
            var IntPtrtextViewClass = JNIEnv.FindClass(typeof(TextView));
            var mCursorDrawableResProperty = JNIEnv.GetFieldID(IntPtrtextViewClass, "mCursorDrawableRes", "I");
            JNIEnv.SetField(Control.Handle, mCursorDrawableResProperty, Resource.Drawable.cursor);
        }

        private void RemoveHintBottomLine()
        {
            this.Control.SetBackground(null);
        }
    }
}
