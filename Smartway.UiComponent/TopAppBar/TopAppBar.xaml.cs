using Smartway.UiComponent.Labels.Icons;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.TopAppBar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TopAppBar
    {
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(
            nameof(Title), typeof(string), typeof(TopAppBar));

        public static readonly BindableProperty IsTitleCenteredProperty = BindableProperty.Create(
            nameof(IsTitleCentered), typeof(bool), typeof(TopAppBar));

        public static readonly BindableProperty CommandProperty = BindableProperty.Create(
            nameof(Command), typeof(ICommand), typeof(TopAppBar));

        public static readonly BindableProperty TypeProperty = BindableProperty.Create(
            nameof(Type), typeof(string), typeof(TopAppBar), "Default");

        public static readonly BindableProperty ExtraNavigationLabelProperty = BindableProperty.Create(
            nameof(ExtraNavigationLabel), typeof(string), typeof(TopAppBar));

        public static readonly BindableProperty ExtraNavigationCommandProperty = BindableProperty.Create(
            nameof(ExtraNavigationCommand), typeof(ICommand), typeof(TopAppBar));

        public static readonly BindableProperty IconSourceProperty = BindableProperty.Create(
            nameof(IconSource), typeof(Icon.IconNames?), typeof(TopAppBar));

        public static readonly BindableProperty IsDarkThemeProperty = BindableProperty.Create(
            nameof(IsDarkTheme), typeof(bool), typeof(TopAppBar), propertyChanged: OnThemeChanged);

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
            nameof(TextColor), typeof(Color), typeof(TopAppBar), defaultValue: Color.Black);



        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }
        public bool IsTitleCentered
        {
            get => (bool)GetValue(IsTitleCenteredProperty);
            set => SetValue(IsTitleCenteredProperty, value);
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
        public Icon.IconNames? IconSource
        {
            get => (Icon.IconNames?) GetValue(IconSourceProperty);
            set => SetValue(IconSourceProperty, value);
        }
        public bool IsDarkTheme
        {
            get => (bool)GetValue(IsDarkThemeProperty);
            set => SetValue(IsDarkThemeProperty, value);
        }

        private static void OnThemeChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            (bindable as TopAppBar)?.OnPropertyChanged(nameof(TextColor));
        }

        public Color TextColor
        {
            get => IsDarkTheme ? Color.White : (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }

        public TopAppBar()
        {
            InitializeComponent();
        }
    }
}