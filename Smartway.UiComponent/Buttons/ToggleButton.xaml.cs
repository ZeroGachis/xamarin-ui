using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.Buttons
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToggleButton
    {

        public enum SelectedToggleButton
        {
            Left,
            Right
        }

        public static readonly BindableProperty OnLeftButtonTappedCommandProperty = BindableProperty.Create(
            nameof(OnLeftButtonTappedCommand), typeof(ICommand), typeof(ToggleButton));

        public static readonly BindableProperty OnRightButtonTappedCommandProperty = BindableProperty.Create(
            nameof(OnRightButtonTappedCommand), typeof(ICommand), typeof(ToggleButton));

        public static readonly BindableProperty LeftTextProperty = BindableProperty.Create(
            nameof(LeftText), typeof(string), typeof(ToggleButton));

        public static readonly BindableProperty RightTextProperty = BindableProperty.Create(
            nameof(RightText), typeof(string), typeof(ToggleButton));

        public static readonly BindableProperty SelectedButtonProperty = BindableProperty.Create(
            nameof(SelectedButton), typeof(SelectedToggleButton), typeof(ToggleButton),
            defaultValue: SelectedToggleButton.Left);

        public string LeftText
        {
            get => (string)GetValue(LeftTextProperty);
            set => SetValue(LeftTextProperty, value);
        }

        public string RightText
        {
            get => (string)GetValue(RightTextProperty);
            set => SetValue(RightTextProperty, value);
        }

        public SelectedToggleButton SelectedButton
        {
            get => (SelectedToggleButton)GetValue(SelectedButtonProperty);
            set => SetValue(SelectedButtonProperty, value);
        }

        public ICommand OnLeftButtonTappedCommand
        {
            get => (ICommand)GetValue(OnLeftButtonTappedCommandProperty);
            set => SetValue(OnLeftButtonTappedCommandProperty, value);
        }

        public ICommand OnRightButtonTappedCommand
        {
            get => (ICommand)GetValue(OnRightButtonTappedCommandProperty);
            set => SetValue(OnRightButtonTappedCommandProperty, value);
        }

        public ToggleButton()
        {
            InitializeComponent();

            OnLeftButtonTappedCommand = new Command(OnLeftButtonTapped);
            OnRightButtonTappedCommand = new Command(OnRightButtonTapped);
        }

        private void OnLeftButtonTapped()
        {
            SwitchButtonTo(SelectedToggleButton.Left);
        }

        private void OnRightButtonTapped()
        {
            SwitchButtonTo(SelectedToggleButton.Right);
        }

        private void SwitchButtonTo(SelectedToggleButton value)
        {
            if (SelectedButton != value)
                SelectedButton = value;
        }
    }
}