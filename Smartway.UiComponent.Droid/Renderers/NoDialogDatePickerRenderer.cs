using System;
using System.ComponentModel;
using Android.App;
using Android.Content;
using Android.Views;
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
        private bool _disposed;

		public NoDialogDatePickerRenderer(Context context) : base(context)
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                _disposed = true;

                if (Control != null)
                    Control.DateChanged -= AndroidControlOnDateChanged;

                if (Element != null)
                    Element.DateSelected -= ElementDateChanged;
            }

            base.Dispose(disposing);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<DatePickerForms> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                var dialog = new DatePickerDialog(Context);
                SetNativeControl(dialog.DatePicker);
                DisableDatePickerKeyboard(dialog.DatePicker);
            }

            if (Control != null)
            {
                LinkDatePickerToAndroidControl(e.NewElement);
                UpdateSelectDate();
                UpdateMinimumDate();
                UpdateMaximumDate();
            }
        }

        private void DisableDatePickerKeyboard(DatePickerAndroid dialogDatePicker)
        {
            dialogDatePicker.DescendantFocusability = DescendantFocusability.BlockDescendants;
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == DatePickerForms.MinimumDateProperty.PropertyName) 
                UpdateMinimumDate();
            else if (e.PropertyName == DatePickerForms.MaximumDateProperty.PropertyName)
                UpdateMaximumDate();
        }

        private void UpdateSelectDate()
        {
            Control.DateTime = Element.Date;
        }

        private void UpdateMaximumDate()
        {
            Control.MaxDate = ConvertDateToJavaFormat(Element.MaximumDate.ToUniversalTime());
        }

        private void UpdateMinimumDate()
        {
            Control.MinDate = ConvertDateToJavaFormat(Element.MinimumDate.ToUniversalTime());
        }

        private void LinkDatePickerToAndroidControl(DatePickerForms element)
        {
            element.DateSelected += ElementDateChanged;
            Control.DateChanged += AndroidControlOnDateChanged;
        }

        private void AndroidControlOnDateChanged(object sender, DatePickerAndroid.DateChangedEventArgs e)
        {
            var newDate = new DateTime(e.Year, e.MonthOfYear+1, e.DayOfMonth);
            if (Element.Date == newDate)
                return;
            Element.Date = newDate;
        }

        private void ElementDateChanged(object sender, DateChangedEventArgs e)
        {
            if (Control.DateTime == e.NewDate)
                return;

            Control.DateTime = e.NewDate;
        }

        private long ConvertDateToJavaFormat(DateTime date)
        {
            var javaDate = new DateTime(1970, 1, 1);
            var javaDiff = date - javaDate;
            return (long)javaDiff.TotalMilliseconds;
        }
    }
}