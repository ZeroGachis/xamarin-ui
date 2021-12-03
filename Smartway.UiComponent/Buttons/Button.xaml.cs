using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.Buttons
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Button
    {
        public static readonly BindableProperty SizeProperty = BindableProperty.Create(nameof(Size), typeof(string), typeof(Button), "Large");
        public static readonly BindableProperty StatusProperty = BindableProperty.Create(nameof(Status), typeof(string), typeof(Button), "Primary");
        public static readonly BindableProperty ActivatedProperty = BindableProperty.Create(nameof(Activated), typeof(bool), typeof(Button), true);

        public string Size
        {
            get => (string)GetValue(SizeProperty);
            set => SetValue(SizeProperty, value);
        }
        public string Status
        {
            get => (string)GetValue(StatusProperty);
            set => SetValue(StatusProperty, value);
        }
        public bool Activated
        {
            get => (bool)GetValue(ActivatedProperty);
            set => SetValue(ActivatedProperty, value);
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName != nameof(Width))
                return;

            AdjustMinimumWidth();
        }

        public Button()
        { 
            InitializeComponent();
        }

        private void AdjustMinimumWidth()
        {
            if (MinimumWidthRequest > Width)
                WidthRequest = MinimumWidthRequest;
        }
    }
}
