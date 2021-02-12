using System.Collections.Generic;
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
            Search,
            SignalCellularNoSim,
            Stop,
            Today,
            ViewHeadline,
            Warning,
        }

        /// <summary>
        /// <see cref="https://github.com/google/material-design-icons/blob/master/font/MaterialIconsOutlined-Regular.codepoints"/> for icon codes.
        /// </summary>
        private readonly Dictionary<IconNames, string> _iconCodes = new Dictionary<IconNames, string>
        {
            { IconNames.Alarm, "\ue190" },
            { IconNames.ArrowBack, "\ue5c4" },
            { IconNames.ArrowDropDown, "\ue5c5" },
            { IconNames.ArrowDropUp, "\ue5c7" },
            { IconNames.ArrowLeft, "\ue5de" },
            { IconNames.ArrowRight, "\ue5df" },
            { IconNames.CalendarToday, "\ue935" },
            { IconNames.CenterFocusStrong, "\ue3b4" },
            { IconNames.Check, "\ue5ca"},
            { IconNames.Clear, "\ue14c" },
            { IconNames.Close, "\ue5cd" },
            { IconNames.Delete, "\ue872"},
            { IconNames.FormatAlignLeft, "\ue236" },
            { IconNames.GridView, "\ue9b0" },
            { IconNames.NotificationImportant, "\ue004" },
            { IconNames.Search, "\ue8b6" },
            { IconNames.SignalCellularNoSim, "\ue1ce" },
            { IconNames.Stop, "\ue047" },
            { IconNames.Today, "\ue8df" },
            { IconNames.ViewHeadline, "\ue8ee" },
            { IconNames.Warning, "\ue002" },
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
            Text = _iconCodes[Value];
        }

        public IconNames Value
        {
            get => (IconNames)GetValue(ValueProperty);
            set =>  SetValue(ValueProperty, value);
        }
    }
}