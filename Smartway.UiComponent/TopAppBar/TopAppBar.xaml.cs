using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.TopAppBar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TopAppBar
    {
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(TopAppBar));
        public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(TopAppBar));
        public static readonly BindableProperty TypeProperty = BindableProperty.Create(nameof(Type), typeof(string), typeof(TopAppBar), "Default");
        public static readonly BindableProperty ExtraNavigationLabelProperty = BindableProperty.Create(nameof(ExtraNavigationLabel), typeof(string), typeof(TopAppBar));
        public static readonly BindableProperty ExtraNavigationCommandProperty = BindableProperty.Create(nameof(ExtraNavigationCommand), typeof(ICommand), typeof(TopAppBar));
        public static readonly BindableProperty IconSourceProperty = BindableProperty.Create(nameof(IconSource), typeof(string), typeof(TopAppBar), String.Empty);
        public static readonly BindableProperty IsDarkThemeProperty = BindableProperty.Create(nameof(IsDarkTheme), typeof(bool), typeof(TopAppBar));


        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }
        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }
        public string Type
        {
            get => (string)GetValue(TypeProperty);
            set => SetValue(TypeProperty, value);
        }
        public string ExtraNavigationLabel
        {
            get => (string)GetValue(ExtraNavigationLabelProperty);
            set => SetValue(ExtraNavigationLabelProperty, value);
        }
        public ICommand ExtraNavigationCommand
        {
            get => (ICommand)GetValue(ExtraNavigationCommandProperty);
            set => SetValue(ExtraNavigationCommandProperty, value);
        }
        public string IconSource
        {
            get => (string) GetValue(IconSourceProperty);
            set => SetValue(IconSourceProperty, value);
        }
        public bool IsDarkTheme
        {
            get => (bool)GetValue(IsDarkThemeProperty);
            set => SetValue(IsDarkThemeProperty, value);
        }

        public TopAppBar()
        {
            InitializeComponent();
        }
    }
}