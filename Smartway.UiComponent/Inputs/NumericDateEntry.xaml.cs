using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.Inputs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NumericDateEntry
    {
        public static readonly BindableProperty GlobalFontSizeProperty =
            BindableProperty.Create(nameof(GlobalFontSize), typeof(int), typeof(NumericDateEntry), 24);

        public static readonly BindableProperty FilledDateTimeProperty =
            BindableProperty.Create(nameof(FilledDateTime), typeof(DateTime), typeof(NumericDateEntry), defaultBindingMode: BindingMode.TwoWay, propertyChanged: FilledDateTimePropertyChanged);

        public static readonly BindableProperty DatePlaceholderProperty =
            BindableProperty.Create(nameof(DatePlaceholder), typeof(DateTime), typeof(NumericDateEntry), propertyChanged: DatePlaceholderPropertyChanged);

        public static readonly BindableProperty ErrorCommandProperty =
            BindableProperty.Create(nameof(ErrorCommand), typeof(ICommand), typeof(NumericDateEntry));

        public static readonly BindableProperty PlaceholderColorProperty =
            BindableProperty.Create(nameof(PlaceholderColor), typeof(Color), typeof(NumericDateEntry), Color.LightGray);

        private static void DatePlaceholderPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            (bindable as NumericDateEntry)?.SetEntriesPlaceHolders();
        }

        private static void FilledDateTimePropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            (bindable as NumericDateEntry)?.SetFilledDate();
        }

        public int GlobalFontSize
        {
            get => (int)GetValue(GlobalFontSizeProperty);
            set => SetValue(GlobalFontSizeProperty, value);
        }

        public DateTime FilledDateTime
        {
            get => (DateTime)GetValue(FilledDateTimeProperty);
            set => SetValue(FilledDateTimeProperty, value);
        }

        public DateTime DatePlaceholder
        {
            get => (DateTime)GetValue(DatePlaceholderProperty);
            set => SetValue(DatePlaceholderProperty, value);
        }

        public Color PlaceholderColor
        {
            get => (Color)GetValue(PlaceholderColorProperty);
            set => SetValue(PlaceholderColorProperty, value);
        }

        public ICommand ErrorCommand
        {
            get => (ICommand)GetValue(ErrorCommandProperty);
            set => SetValue(ErrorCommandProperty, value);
        }

        private List<Entry> _dateEntries;
        protected Entry DayEntry;
        protected Entry MonthEntry;
        protected Entry YearEntry;

        public NumericDateEntry()
        {
            InitializeComponent();

            SetupEntries();
        }

        protected virtual void OnEntryTextChanged(object sender, EventArgs e)
        {
            var currentEntry = sender as Entry;
            if (!IsValidDateEntry(currentEntry))
                return;

            var hasEmptyEntryFocused = FocusNextUnvalidEntry();
            if (hasEmptyEntryFocused)
                return;

            FillDate();
        }

        protected virtual DateTime GetFilledDate()
        {
            var day = int.Parse(DayEntry.Text);
            var month = int.Parse(MonthEntry.Text);
            var year = CultureInfo.CurrentCulture.Calendar.ToFourDigitYear(int.Parse(YearEntry.Text));

            return new DateTime(year, month, day);
        }

        protected void FillDate()
        {
            try
            {
                FilledDateTime = GetFilledDate();
            }
            catch (Exception exception)
            {
                ErrorCommand?.Execute(exception);
            }
        }

        protected bool FocusNextUnvalidEntry()
        {
            foreach (var entry in _dateEntries)
            {
                if (IsValidDateEntry(entry))
                    continue;

                entry.Focus();
                return true;
            }

            return false;
        }

        protected bool IsValidDateEntry(Entry entry)
        {
            return !string.IsNullOrEmpty(entry.Text) && entry.Text.Length == 2;
        }

        private void SetupEntries()
        {
            SetEntriesPosition();
            SetEntriesPlaceHolders();
            SetFilledDate();
            _dateEntries.ForEach(_ => _.TextChanged += OnEntryTextChanged);
        }

        private void SetEntriesPlaceHolders()
        {
            if (DateTimeIsNull(DatePlaceholder))
            {
                SetDefaultPlaceholder();
                return;
            }

            SetDateTimePlaceholder();
        }

        private void SetDateTimePlaceholder()
        {
            DayEntry.Placeholder = DatePlaceholder.Day.ToString();
            MonthEntry.Placeholder = DatePlaceholder.Month.ToString();
            YearEntry.Placeholder = DatePlaceholder.Year.ToString().Substring(2);
        }

        private void SetFilledDate()
        {
            if (DateTimeIsNull(FilledDateTime))
                return;

            DayEntry.Text = FilledDateTime.Day.ToString();
            MonthEntry.Text = FilledDateTime.Month.ToString();
            YearEntry.Text = FilledDateTime.Year.ToString().Substring(2);
        }

        private void SetEntriesPosition()
        {
            if (IsDayMonthCalendar())
            {
                DayEntry = FirstEntry;
                MonthEntry = SecondEntry;
            }
            else
            {
                MonthEntry = FirstEntry;
                DayEntry = SecondEntry;
            }

            YearEntry = ThirdEntry;

            _dateEntries = new List<Entry>
            {
                FirstEntry,
                SecondEntry,
                ThirdEntry
            };
        }

        private bool DateTimeIsNull(DateTime date)
        {
            // null value of datetime is a datetime at 01/01/01
            return date.Year == 1;
        }
        private void SetDefaultPlaceholder()
        {
            if (IsDayMonthCalendar())
            {
                DayEntry.Placeholder = "JJ";
                MonthEntry.Placeholder = "MM";
                YearEntry.Placeholder = "AA";
            }
            else
            {
                MonthEntry.Placeholder = "MM";
                DayEntry.Placeholder = "DD";
                YearEntry.Placeholder = "YY";
            }
        }

        private bool IsDayMonthCalendar()
        {
            var calendarType =
                CultureInfo.GetCultureInfo(CultureInfo.CurrentCulture.Name).DateTimeFormat.MonthDayPattern;
            return calendarType == "d MMMM";
        }

        private void OnFocusedSelectAllEntryContent(object sender, FocusEventArgs e)
        {
            var entry = sender as Entry;
            if (!string.IsNullOrEmpty(entry?.Text))
            {
                SelectAllEntryContent(entry);
            }
        }

        private void SelectAllEntryContent(Entry entry)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                entry.CursorPosition = 0;
                entry.SelectionLength = entry.Text.Length;
            });
        }
    }
}
