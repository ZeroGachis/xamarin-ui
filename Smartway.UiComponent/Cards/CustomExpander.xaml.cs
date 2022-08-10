using System.Windows.Input;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.Cards
{
    [ContentProperty("Content")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomExpander
    {
        public static readonly BindableProperty StatusProperty = BindableProperty.Create(
            nameof(Status), typeof(string), typeof(ExpanderCard)
        );

        public static readonly BindableProperty TitleProperty = BindableProperty.Create(
            nameof(Title), typeof(string), typeof(ExpanderCard)
        );

        public static readonly BindableProperty CounterProperty = BindableProperty.Create(
            nameof(Counter), typeof(string), typeof(ExpanderCard)
        );

        public static readonly BindableProperty ExpanderContentProperty = BindableProperty.Create(
            nameof(ExpanderContent), typeof(View), typeof(ExpanderCard)
        );

        public static readonly BindableProperty IsExpandedProperty = BindableProperty.Create(
            nameof(IsExpanded), typeof(bool), typeof(ExpanderCard)
        );

        public static readonly BindableProperty StateProperty = BindableProperty.Create(
            nameof(State), typeof(ExpandState), typeof(ExpanderCard), default(ExpandState), BindingMode.OneWayToSource
        );

        public static readonly BindableProperty CommandProperty = BindableProperty.Create(
            nameof(Command), typeof(ICommand), typeof(ExpanderCard)
        );

        public static readonly BindableProperty ForceUpdateSizeCommandProperty = BindableProperty.Create(
            nameof(ForceUpdateSizeCommand), typeof(ICommand), typeof(ExpanderCard), null, BindingMode.OneWayToSource
        );

        public static readonly BindableProperty ExpanderTemplateProperty = BindableProperty.Create(
            nameof(ExpanderTemplate), typeof(DataTemplate), typeof(ExpanderCard));


        public bool IsExpanded
        {
            get => (bool)GetValue(IsExpandedProperty);
            set => SetValue(IsExpandedProperty, value);
        }

        public string Status
        {
            get => (string) GetValue(StatusProperty);
            set => SetValue(StatusProperty, value);
        }

        public string Title
        {
            get => (string) GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public string Counter
        {
            get => (string) GetValue(CounterProperty);
            set => SetValue(CounterProperty, value);
        }

        public string State
        {
            get => (string)GetValue(StateProperty);
            set => SetValue(StatusProperty, value);
        }

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public ICommand ForceUpdateSizeCommand
        {
            get => (ICommand)GetValue(ForceUpdateSizeCommandProperty);
            set => SetValue(ForceUpdateSizeCommandProperty, value);
        }
        public DataTemplate ExpanderTemplate
        {
            get => (DataTemplate)GetValue(ExpanderTemplateProperty);
            set => SetValue(ExpanderTemplateProperty, value);
        }

        public View ExpanderContent
        {
            get => (View)GetValue(ExpanderContentProperty);
            set => SetValue(ExpanderContentProperty, value);
        }

        public CustomExpander()
        {
            InitializeComponent();
        }
    }
}