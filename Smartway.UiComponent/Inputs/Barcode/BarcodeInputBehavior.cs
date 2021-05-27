using System.Linq;
using System.Windows.Input;
using Smartway.Barcode.Ean13;
using Smartway.UiComponent.Behaviors;
using Xamarin.Forms;

namespace Smartway.UiComponent.Inputs.Barcode
{
    public class BarcodeInputBehavior: BaseBehavior<Entry>
    {
        public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(BarcodeInputBehavior));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        protected override void OnAttachedTo(BindableObject bindable)
        {
            base.OnAttachedTo(bindable);

            AssociatedObject.Focused += OnAssociatedObjectOnFocused;
            AssociatedObject.TextChanged += OnTextChanged;
        }

        protected override void OnDetachingFrom(BindableObject bindable)
        {
            base.OnDetachingFrom(bindable);

            AssociatedObject.Focused -= OnAssociatedObjectOnFocused;
            AssociatedObject.TextChanged -= OnTextChanged;
        }

        private void OnAssociatedObjectOnFocused(object sender, FocusEventArgs e)
        {
            AssociatedObject.Keyboard = Keyboard.Numeric;
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
                return;

            if (InputIsInvalid(e.NewTextValue))
            {
                AssociatedObject.Text = e.OldTextValue;
                return;
            }

            if (e.NewTextValue.Length != Ean13.CheckedLength)
                return;

            Command?.Execute(e.NewTextValue);
        }

        private bool InputIsInvalid(string input)
        {
            return input.Length > Ean13.CheckedLength
                   || input.Length == Ean13.CheckedLength && !Ean13.Check(input)
                   || input.ToCharArray().Any(_ => !char.IsDigit(_));
        }
    }
}
