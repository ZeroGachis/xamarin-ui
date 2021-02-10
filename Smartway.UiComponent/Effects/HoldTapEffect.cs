using System.Windows.Input;
using Xamarin.Forms;

namespace Smartway.UiComponent.Effects
{
    public class HoldTapEffect : RoutingEffect
    {
        public static readonly BindableProperty CommandProperty = BindableProperty.CreateAttached("Command", typeof(ICommand), typeof(HoldTapEffect), null);
        public static readonly BindableProperty CommandParameterProperty = BindableProperty.CreateAttached("CommandParameter", typeof(object), typeof(HoldTapEffect), null);
        public static readonly BindableProperty HoldTimeProperty = BindableProperty.CreateAttached("HoldTime", typeof(int), typeof(CustomTapEffect), 0);

        public HoldTapEffect() : base("ai.smartway.HoldTapEffect")
        {}

        public static int GetHoldTime(BindableObject view) => (int) view.GetValue(HoldTimeProperty);

        public static void SetHoldTime(BindableObject view, int value) => view.SetValue(HoldTimeProperty, value);

        public static ICommand GetCommand(BindableObject view) => (ICommand) view.GetValue(CommandProperty);

        public static void SetCommand(BindableObject view, ICommand value) => view.SetValue(CommandProperty, value);

        public static object GetCommandParameter(BindableObject view) => view.GetValue(CommandParameterProperty);

        public static void SetCommandParameter(BindableObject view, object value) => view.SetValue(CommandParameterProperty, value);
    }
}