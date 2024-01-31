using System.Collections.Generic;
using Smartway.UiComponent.Labels.Icons.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.Labels.Icons
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Icon
    {
        /// <summary>
        /// <see cref="https://material.io/resources/icons/"/> for icon names
        /// </summary>
        public enum IconNames
        {
            Alarm,
            ArrowBack,
            ArrowDropDown,
            ArrowDropUp,
            ArrowLeft,
            ArrowRight,
            CalendarToday,
            CenterFocusStrong,
            Check,
            Clear,
            Close,
            Delete,
            FormatAlignLeft,
            GridView,
            NotificationImportant,
            NotInterested,
            Search,
            SignalCellularNoSim,
            Today,
            ViewHeadline,
            Warning,
            Settings,
            BarcodeScan,
            DatamatrixScan,
            KeyboardSpace,
            BackSpaceOutline,
            CheckOutline,
            Dash,
            Heart,
            AlertOutline,
            Alert,
            ListOutline,
            List,
            RevalueOutline,
            Revalue,
            Stick,
            Sync,
            Printer,
            Logout,
            WifiOff
        }

        /// <summary>
        /// <see cref="https://github.com/google/material-design-icons/blob/master/font/MaterialIconsOutlined-Regular.codepoints"/> for icon codes.
        /// </summary>
        private readonly List<IconModel> _iconModels = new List<IconModel>
        {
            new MaterialIcon(IconNames.Alarm, "\ue190"),
            new MaterialIcon(IconNames.ArrowBack, "\ue5c4"),
            new MaterialIcon(IconNames.ArrowDropDown, "\ue5c5"),
            new MaterialIcon(IconNames.ArrowDropUp, "\ue5c7"),
            new MaterialIcon(IconNames.CalendarToday, "\ue935"),
            new MaterialIcon(IconNames.CenterFocusStrong, "\ue3b4"),
            new MaterialIcon(IconNames.Clear, "\ue14c"),
            new MaterialIcon(IconNames.Close, "\ue5cd"),
            new MaterialIcon(IconNames.Delete, "\ue872"),
            new MaterialIcon(IconNames.FormatAlignLeft, "\ue236"),
            new MaterialIcon(IconNames.GridView, "\ue9b0"),
            new MaterialIcon(IconNames.NotificationImportant, "\ue004"),
            new MaterialIcon(IconNames.NotInterested, "\ue033"),
            new MaterialIcon(IconNames.WifiOff, "\ue648"),
            new MaterialIcon(IconNames.Search, "\ue8b6"),
            new MaterialIcon(IconNames.SignalCellularNoSim, "\ue1ce"),
            new MaterialIcon(IconNames.Today, "\ue8df"),
            new MaterialIcon(IconNames.ViewHeadline, "\ue8ee"),
            new MaterialIcon(IconNames.Warning, "\ue002"),
            new MaterialIcon(IconNames.Settings, "\ue8b8"),
            new MaterialIcon(IconNames.Printer, "\ue8ad"),
            new MaterialIcon(IconNames.Logout, "\ue9ba"),
            new MaterialIcon(IconNames.Sync, "\ue627"),

            new SmartwayIcon(IconNames.BarcodeScan, "\ue900"),
            new SmartwayIcon(IconNames.DatamatrixScan, "\ue901"),
            new SmartwayIcon(IconNames.KeyboardSpace, "\ue902"),
            new SmartwayIcon(IconNames.BackSpaceOutline, "\ue903"),
            new SmartwayIcon(IconNames.Check, "\ue904"),
            new SmartwayIcon(IconNames.Dash, "\ue905"),
            new SmartwayIcon(IconNames.ArrowRight, "\ue906"),
            new SmartwayIcon(IconNames.ArrowLeft, "\ue907"),
            new SmartwayIcon(IconNames.CheckOutline, "\ue908"),
            new SmartwayIcon(IconNames.Heart, "\ue909"),
            new SmartwayIcon(IconNames.AlertOutline, "\ue90a"),
            new SmartwayIcon(IconNames.Alert, "\ue90b"),
            new SmartwayIcon(IconNames.ListOutline, "\ue90c"),
            new SmartwayIcon(IconNames.List, "\ue90d"),
            new SmartwayIcon(IconNames.RevalueOutline, "\ue90e"),
            new SmartwayIcon(IconNames.Revalue, "\ue90f"),
            new SmartwayIcon(IconNames.Stick, "\ue910")
        };

        public static readonly BindableProperty ValueProperty = BindableProperty.Create(nameof(Value),
            typeof(IconNames), typeof(Icon), propertyChanged: OnValueChanged);

        private static void OnValueChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((Icon)bindable).UpdateText();
        }

        public Icon()
        {
            InitializeComponent();
            UpdateText();
        }

        private void UpdateText()
        {
            var icon = _iconModels.Find(_ => _.Name == Value);
            Text = icon.Code;
            FontFamily = icon.FontFamily;
        }

        public IconNames Value
        {
            get => (IconNames)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }
    }
}