using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.Inputs
{
    [ContentProperty("CustomContent")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Chips: ContentView
    {
        public static readonly BindableProperty IsSelectedProperty =
        BindableProperty.Create(nameof(IsSelected), typeof(bool), typeof(Chips), false);

        public static readonly BindableProperty LabelProperty = BindableProperty.Create(nameof(Label), typeof(string),
            typeof(Chips));

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(Chips));

        public bool IsSelected
        {
            get => (bool) GetValue(IsSelectedProperty);
            set => SetValue(IsSelectedProperty, value);
        }

        public string Label
        {
            get => (string) GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        public ICommand Command
        {
            get => (ICommand) GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public Chips()
        {
            InitializeComponent();
        }

        private void OnTapped(object sender, EventArgs e)
        {
            IsSelected = !IsSelected;
            Command?.Execute(this);
        }
    }
}