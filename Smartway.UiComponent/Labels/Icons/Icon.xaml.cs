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
            AccessAlarm,
            ArrowBack,
            ArrowDropDown,
            ArrowDropUp,
            ArrowLeft,
            ArrowRight,
            CalendarToday,
            Clear,
            NotificationImportant,
            Search,
            SignalCellularNoSim,
            ViewHeadline
        }

        /// <summary>
        /// <see cref="https://github.com/google/material-design-icons/blob/master/font/MaterialIconsOutlined-Regular.codepoints"/> for icon codes.
        /// </summary>
        private readonly Dictionary<IconNames, string> _iconCodes = new Dictionary<IconNames, string>
        {
            { IconNames.AccessAlarm, "\ue190" },
            { IconNames.ArrowBack, "\ue5c4" },
            { IconNames.ArrowDropDown, "\ue5c5" },
            { IconNames.ArrowDropUp, "\ue5c7" },
            { IconNames.ArrowLeft, "\ue5de" },
            { IconNames.ArrowRight, "\ue5df" },
            { IconNames.CalendarToday, "\ue935" },
            { IconNames.Clear, "\ue14c" },
            { IconNames.NotificationImportant, "\ue004" },
            { IconNames.Search, "\ue8b6" },
            { IconNames.SignalCellularNoSim, "\ue1ce" },
            { IconNames.ViewHeadline, "\ue8ee" }
        };

        public Icon()
        {
            InitializeComponent();
        }

        private IconNames _value;
        public IconNames Value
        {
            get => _value;
            set
            {
                _value = value;
                Text = System.Text.RegularExpressions.Regex.Unescape(_iconCodes[value]);
            }
        }
    }
}