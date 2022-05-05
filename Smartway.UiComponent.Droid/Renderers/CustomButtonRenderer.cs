using System.ComponentModel;
using Android.Content;
using Smartway.UiComponent.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using ButtonRenderer = Xamarin.Forms.Platform.Android.FastRenderers.ButtonRenderer;

[assembly: ExportRenderer(typeof(Button), typeof(CustomButtonRenderer))]
namespace Smartway.UiComponent.Droid.Renderers
{
    public class CustomButtonRenderer : ButtonRenderer
    {
        public CustomButtonRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> args)
        {
            base.OnElementChanged(args);
            if (Control != null)
                SetOpacity();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(sender, args);
            if (args.PropertyName == nameof(Button.IsEnabled))
                SetOpacity();
        }

        private void SetOpacity()
        {
            Element.Opacity = Element.IsEnabled ? 1 : 0.3;
        }
    }
}