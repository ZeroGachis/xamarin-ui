using System;
using System.Timers;

namespace Smartway.UiComponent.Effects
{
    public class TouchGesture
    {
        private Timer _clickTimer;
        public Action OnRing;
        public Action OnClicked;

        public TouchGesture(double timerDuration)
        {
            TimerDuration = timerDuration;
        }

        public double TimerDuration { get; set; }

        public void Trigger()
        {
            ManageClickEvent();
        }

        public void Release()
        {
            ReleaseClickTimer();
        }

        private void ManageClickEvent()
        {
            OnClicked?.Invoke();

            lock (this)
            {
                if (_clickTimer != null)
                    return;

                _clickTimer = new Timer(TimerDuration);
                _clickTimer.Elapsed += OnTimerRinged;
                _clickTimer.Start();
            }
        }

        private void ReleaseClickTimer()
        {
            lock (this)
            {
                if (_clickTimer == null)
                    return;

                _clickTimer.Stop();
                _clickTimer.Dispose();
                _clickTimer = null;
            }
        }

        private void OnTimerRinged(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            OnRing?.Invoke();
            ReleaseClickTimer();
        }
    }
}
