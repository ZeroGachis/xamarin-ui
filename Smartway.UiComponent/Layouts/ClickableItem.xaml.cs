using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.Layouts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClickableItem
    {
        public static readonly BindableProperty BoxWidthProperty = BindableProperty.Create(nameof(BoxWidth), typeof(int), typeof(ClickableItem));
        public static readonly BindableProperty BoxHeightProperty = BindableProperty.Create(nameof(BoxHeight), typeof(int), typeof(ClickableItem));
        public static readonly BindableProperty LayoutContentProperty = BindableProperty.Create(nameof(LayoutContent), typeof(View), typeof(ClickableItem));

        public ClickableItem()
        {
            InitializeComponent();
        }
        public View LayoutContent
        {
            get => (View)GetValue(LayoutContentProperty);
            set => SetValue(LayoutContentProperty, value);
        }

        public int BoxWidth
        {
            get => (int)GetValue(BoxWidthProperty);
            set => SetValue(BoxWidthProperty, value);
        }

        public int BoxHeight
        {
            get => (int)GetValue(BoxHeightProperty);
            set => SetValue(BoxHeightProperty, value);
        }

    }
}
