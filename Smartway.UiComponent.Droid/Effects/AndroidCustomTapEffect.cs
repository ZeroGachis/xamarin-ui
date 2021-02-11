using Android.Views;
using Smartway.UiComponent.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using Zg.Remote.Droid.Effects;
using View = Android.Views.View;

[assembly: ResolutionGroupName("ai.smartway")]
[assembly: ExportEffect(typeof(AndroidCustomTapEffect), nameof(CustomTapEffect))]
namespace Zg.Remote.Droid.Effects
{
    public class AndroidCustomTapEffect : PlatformEffect
    {
        private readonly int FAST_TIME_CLICK = 200;

        private bool _attached;
        private int _currentNumberOfTaps;

        private readonly TouchGesture _touchGesture;

        public AndroidCustomTapEffect()
        {
            _touchGesture = new TouchGesture(FAST_TIME_CLICK)
            {
                OnRing = () =>
                {
                    _currentNumberOfTaps = 0;
                },
                OnClicked = () =>
                {
                    if (CustomTapEffect.GetNumberOfTaps(Element) == ++_currentNumberOfTaps)
                    {
                        var command = CustomTapEffect.GetCommand(Element);
                        _currentNumberOfTaps = 0;

                        command?.Execute(CustomTapEffect.GetCommandParameter(Element));
                    }
                }
            };
        }

        protected override void OnAttached()
        {
            if (!_attached)
            {
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
                    _touchGesture?.Release();
                    break;

                case MotionEventActions.Up:
                    _touchGesture?.Trigger();
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