using System;
using Android.Views;
using Smartway.UiComponent.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using Zg.Remote.Droid.Effects;
using View = Android.Views.View;

[assembly: ExportEffect(typeof(AndroidHoldTapEffect), nameof(HoldTapEffect))]
namespace Zg.Remote.Droid.Effects
{
    public class AndroidHoldTapEffect : PlatformEffect
    {
        private bool _attached;

        private TouchGesture _holdGesture;

        public AndroidHoldTapEffect()
        {
            
        }

        protected override void OnAttached()
        {
            if (!_attached)
            {
                var holdTime = HoldTapEffect.GetHoldTime(Element);

                _holdGesture = new TouchGesture(holdTime)
                {
                    OnRing = () =>
                    {
                        var commandCustom = HoldTapEffect.GetCommand(Element);

                        commandCustom?.Execute(HoldTapEffect.GetCommandParameter(Element));
                    }
                };

                if (Control != null)
                {
                    Control.Touch += Control_Touched;
                }
                else
                {
                    Container.Touch += Control_Touched;
                }

                _attached = true;
            }
        }

        private void Control_Touched(object sender, View.TouchEventArgs e)
        {
            switch (e.Event.Action)
            {
                case MotionEventActions.Down:
                    _holdGesture?.Trigger();
                    break;

                case MotionEventActions.Up:
                    _holdGesture?.Release();
                    break;
            }
        }

        protected override void OnDetached()
        {
            if (_attached)
            {
                 if (Control != null)
                 {
                     Control.Touch -= Control_Touched;
                 }
                 else
                 {
                     Container.Touch += Control_Touched;
                 }

                _attached = false;
            }
        }
    }
}