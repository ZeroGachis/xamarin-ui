using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.Layouts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClickableItem
    {
        public static readonly BindableProperty HitBoxWidthProperty = 
            BindableProperty.Create(nameof(HitBoxWidth), typeof(int), typeof(ClickableItem));

        public static readonly BindableProperty HitBoxHeightProperty = 
            BindableProperty.Create(nameof(HitBoxHeight), typeof(int), typeof(ClickableItem));

        public static readonly BindableProperty LayoutContentProperty = 
            BindableProperty.Create(nameof(LayoutContent), typeof(View), typeof(ClickableItem));

        public static readonly BindableProperty TapCommandProperty = 
            BindableProperty.Create(nameof(TapCommand), typeof(ICommand), typeof(ClickableItem));

        public ClickableItem()
        {
            InitializeComponent();
        }
        public View LayoutContent
        {
            get => (View)GetValue(LayoutContentProperty);
            set => SetValue(LayoutContentProperty, value);
        }

        public int HitBoxWidth
        {
            get => (int)GetValue(HitBoxWidthProperty);
            set => SetValue(HitBoxWidthProperty, value);
        }

        public int HitBoxHeight
        {
            get => (int)GetValue(HitBoxHeightProperty);
            set => SetValue(HitBoxHeightProperty, value);
        }

        public ICommand TapCommand
        {
            get => (ICommand)GetValue(TapCommandProperty);
            set => SetValue(TapCommandProperty, value);
        }

    }
}
