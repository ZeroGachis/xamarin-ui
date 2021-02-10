using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Smartway.UiComponent.Effects
{
    public class CustomTapEffect : RoutingEffect
    {
        public static readonly BindableProperty CommandProperty = BindableProperty.CreateAttached("Command", typeof(ICommand), typeof(CustomTapEffect), null);
        public static readonly BindableProperty CommandParameterProperty = BindableProperty.CreateAttached("CommandParameter", typeof(object), typeof(CustomTapEffect), null);
        public static readonly BindableProperty NumberOfTapsProperty = BindableProperty.CreateAttached("NumberOfTaps", typeof(int), typeof(CustomTapEffect), 0);

        public CustomTapEffect() : base("ai.smartway.CustomTapEffect")
        {}

        public static ICommand GetCommand(BindableObject view) => (ICommand) view.GetValue(CommandProperty);

        public static void SetCommand(BindableObject view, ICommand value) => view.SetValue(CommandProperty, value);

        public static object GetCommandParameter(BindableObject view) => view.GetValue(CommandParameterProperty);

        public static int GetNumberOfTaps(BindableObject view) => (int)view.GetValue(NumberOfTapsProperty);

        public static void SetNumberOfTaps(BindableObject view, int value) => view.SetValue(NumberOfTapsProperty, value);
    }
}