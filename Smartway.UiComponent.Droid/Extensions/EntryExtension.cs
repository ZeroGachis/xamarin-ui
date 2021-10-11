using Android.OS;
using Android.Runtime;
using Android.Widget;
using Xamarin.Forms.Platform.Android;

namespace Smartway.UiComponent.Droid.Extensions
{
    public static class EntryExtension
    {
        public static void RemoveHintBottomLine(this FormsEditText control)
        {
            control.SetBackground(null);
        }

        public static void SetCursorColor(this FormsEditText control)
        {
            if (control == null)
                return;

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Q)
            {
                //This API Intrduced in android 10
                control.SetTextCursorDrawable(Resource.Drawable.cursor); 
            }
            else
            {
                var intPtrtextViewClass = JNIEnv.FindClass(typeof(TextView));
                var mCursorDrawableResProperty = JNIEnv.GetFieldID(intPtrtextViewClass, "mCursorDrawableRes", "I");
                JNIEnv.SetField(control.Handle, mCursorDrawableResProperty, Resource.Drawable.cursor);
            }
        }
    }
}