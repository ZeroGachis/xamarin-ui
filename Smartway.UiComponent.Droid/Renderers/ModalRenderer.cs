using Android.Content;
using Android.Views;
using System;
using Smartway.UiComponent.Droid.Renderers;
using Smartway.UiComponent.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Android.Graphics.Color;

[assembly: ExportRenderer(typeof(Modal), typeof(ModalRenderer))]
namespace Smartway.UiComponent.Droid.Renderers
{
    class ModalRenderer : PageRenderer
    {
        private Color statusBarColor;
        public ModalRenderer(Context context)
            : base(context) { }

        protected override void OnAttachedToWindow()
        {
            Element.Appearing += OnAppearing;
            Element.Disappearing += OnDisappearing;
        }

        private void OnAppearing(object sender, EventArgs e)
        {
            var currentWindow = GetCurrentWindow();
            statusBarColor = new Color(currentWindow?.StatusBarColor ?? 0);

            currentWindow?.SetStatusBarColor(Color.Argb(140, 0, 0, 0));
        }

        private void OnDisappearing(object sender, EventArgs e)
        {
            var currentWindow = GetCurrentWindow();
            currentWindow?.SetStatusBarColor(statusBarColor);
        }

        private Window GetCurrentWindow()
        {
            try
            {
                var window = Context.GetActivity().Window;
                window?.ClearFlags(WindowManagerFlags.TranslucentStatus);
                window?.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
                return window;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return null;

        }
    }
    
}