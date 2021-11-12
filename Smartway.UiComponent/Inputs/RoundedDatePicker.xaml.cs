using System;
using Smartway.UiComponent.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.Inputs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RoundedDatePicker
    {
        public RoundedDatePicker()
        {
            InitializeComponent();
            InitializeDatePicker();
        }

        public static readonly BindableProperty DateProperty =
            BindableProperty.Create(nameof(Date), typeof(DateTime), typeof(RoundedDatePicker), defaultBindingMode: BindingMode.TwoWay);

        public static readonly BindableProperty MinimumDateProperty =
            BindableProperty.Create(nameof(MinimumDate), typeof(DateTime), typeof(RoundedDatePicker));

        public static readonly BindableProperty MaximumDateProperty =
            BindableProperty.Create(nameof(MaximumDate), typeof(DateTime), typeof(RoundedDatePicker), new DateTime(2100, 12, 31));

        public DateTime Date
        {
            get => (DateTime)GetValue(DateProperty);
            set => SetValue(DateProperty, value);
        }

        public DateTime MinimumDate
        {
            get => (DateTime)GetValue(MinimumDateProperty);
            set => SetValue(MinimumDateProperty, value);
        }

        public DateTime MaximumDate
        {
            get => (DateTime)GetValue(MaximumDateProperty);
            set => SetValue(MaximumDateProperty, value);
        }

        private void InitializeDatePicker()
        {
            var platformInfo = DependencyService.Get<IPlatormInfoProvider>();
            var datePicker = platformInfo.OsSdkVersion <= 23 ? new DatePicker() : new NoDialogDatePicker { HeightRequest = 172 };
            datePicker.SetBinding(DatePicker.DateProperty, new Binding("Date", source: this));
            datePicker.SetBinding(DatePicker.MaximumDateProperty, new Binding("MaximumDate", source: this));
            datePicker.SetBinding(DatePicker.MinimumDateProperty, new Binding("MinimumDate", source: this));
            RoundedFrame.Content = datePicker;
        }
    }
}