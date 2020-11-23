using System;
using Android.App;
using Android.Content;
using Smartway.UiComponent.Droid.Renderers;
using Smartway.UiComponent.Inputs;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using DatePickerForms = Xamarin.Forms.DatePicker;
using DatePickerAndroid = Android.Widget.DatePicker;

[assembly: ExportRenderer(typeof(NoDialogDatePicker), typeof(NoDialogDatePickerRenderer))]
namespace Smartway.UiComponent.Droid.Renderers
{
	public class NoDialogDatePickerRenderer : ViewRenderer<DatePickerForms, DatePickerAndroid>
	{
		public NoDialogDatePickerRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<DatePickerForms> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                var dialog = new DatePickerDialog(Context);
                SetNativeControl(dialog.DatePicker);
            }
        }   
    }
}