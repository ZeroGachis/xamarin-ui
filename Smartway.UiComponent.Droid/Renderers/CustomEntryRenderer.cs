using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Text;
using Android.Text.Method;
using Android.Widget;
using Smartway.UiComponent.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Entry), typeof(CustomEntryRenderer))]
namespace Smartway.UiComponent.Droid.Renderers
{
    public class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
                return;

            var gd = new GradientDrawable();
            gd.SetColor(global::Android.Graphics.Color.Transparent);

            Control.SetPadding(0, 0, Control.PaddingRight, 0);

            if (Control.InputType.HasFlag(InputTypes.NumberFlagDecimal))
            {
                Control.KeyListener = DigitsKeyListener.GetInstance("0123456789.,");
                Control.TextChanged += Control_TextChanged;
            }

            if (e.OldElement != null)
                return;

            RemoveHintBottomLine();
            SetCursorColor();
        }

        private const string DecimalRegEx = @"^\d+((\.|\,){1})?\d*$";
        private void Control_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            var control = sender as FormsEditText;
            control.SetSelection(control.Text.Length);

            var lastChar = e.Text?.LastOrDefault();
            if (lastChar != ',' && lastChar != '.')
                return;

            if (!Regex.IsMatch(control.Text, DecimalRegEx))
                control.Text = control.Text.Remove(control.Text.Length - 1);

            var cultureDecimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            if (lastChar.ToString() == cultureDecimalSeparator)
                return;

            control.Text = control.Text.Replace(lastChar.ToString(), cultureDecimalSeparator);
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
