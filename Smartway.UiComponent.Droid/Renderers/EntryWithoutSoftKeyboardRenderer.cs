using Android.Content;
using Android.Views.InputMethods;
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
            if (args.NewElement != null)
            {
                ((EntryWithoutSoftKeyboard)args.NewElement).PropertyChanging += HideKeyboardIfPoppedWhenGettingFocus;
            }

            if (args.OldElement != null)
            {
                ((EntryWithoutSoftKeyboard)args.OldElement).PropertyChanging -= HideKeyboardIfPoppedWhenGettingFocus;
            }

            Control.ShowSoftInputOnFocus = false;
        }

        private void HideKeyboardIfPoppedWhenGettingFocus(object sender,
            PropertyChangingEventArgs propertyChangingEventArgs)
        {
            var isGettingFocus = propertyChangingEventArgs.PropertyName == VisualElement.IsFocusedProperty.PropertyName;
            if (isGettingFocus)
            {
                InputMethodManager imm = (InputMethodManager)Context.GetSystemService(Context.InputMethodService);
                imm.HideSoftInputFromWindow(Control.WindowToken, HideSoftInputFlags.None);
            }
        }

        protected override void OnFocusChangeRequested(object sender, VisualElement.FocusRequestArgs e)
        {
            if (!e.Focus)
            {
                base.OnFocusChangeRequested(sender, e);
                return;
            }

            Device.BeginInvokeOnMainThread(() =>
            {
                Control?.RequestFocus();
            });
        }
    }
}